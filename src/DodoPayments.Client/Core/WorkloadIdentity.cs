using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Exceptions;
using IOFile = System.IO.File;

namespace DodoPayments.Client.Core;

/// <summary>
/// Gets a subject token (a JWT from your identity provider) for a workload identity exchange.
/// The client calls the provider for each exchange.
/// </summary>
public delegate Task<string> SubjectTokenProvider(
    SubjectTokenContext context,
    CancellationToken cancellationToken
);

/// <summary>
/// The client data that a <see cref="SubjectTokenProvider"/> can use.
/// </summary>
public sealed class SubjectTokenContext
{
    /// <summary>
    /// The base URL of the client.
    /// </summary>
    public required string BaseUrl { get; init; }

    /// <summary>
    /// The HTTP client of the client.
    /// </summary>
    public required HttpClient HttpClient { get; init; }

    /// <summary>
    /// The maximum time for one HTTP call.
    /// </summary>
    public required TimeSpan Timeout { get; init; }
}

/// <summary>
/// The workload identity configuration. The client exchanges a subject token for a short-lived
/// access token and keeps the access token in a cache.
///
/// <para>All clients that use the same instance share the cache.</para>
/// </summary>
public sealed class WorkloadIdentityOptions
{
    internal const string TokenPath = "/workload-identity/token";

    internal const string RevokePath = "/workload-identity/token/revoke";

    internal const string IdentityProviderIDEnv = "DODO_PAYMENTS_IDENTITY_PROVIDER_ID";

    string? _identityProviderID = null;

    /// <summary>
    /// The identity provider ID (<c>wip_...</c>).
    ///
    /// <para>Defaults to the <c>DODO_PAYMENTS_IDENTITY_PROVIDER_ID</c> environment variable.</para>
    /// </summary>
    public string IdentityProviderID
    {
        get
        {
            return _identityProviderID
                ?? Environment.GetEnvironmentVariable(IdentityProviderIDEnv)
                ?? throw new DodoPaymentsInvalidDataException(
                    string.Format(
                        "{0} cannot be null. Set it or the {1} environment variable.",
                        nameof(IdentityProviderID),
                        IdentityProviderIDEnv
                    )
                );
        }
        init { _identityProviderID = value; }
    }

    /// <summary>
    /// The source of the subject token.
    ///
    /// <para>Defaults to <see cref="WorkloadIdentityProviders.Auto"/>.</para>
    /// </summary>
    public SubjectTokenProvider Provider { get; init; } = WorkloadIdentityProviders.Auto();

    internal WorkloadIdentityTokenCache Cache { get; } = new();

    internal static WorkloadIdentityOptions? FromEnvironment()
    {
        if (Environment.GetEnvironmentVariable("DODO_PAYMENTS_API_KEY") != null)
        {
            return null;
        }
        var identityProviderID = Environment.GetEnvironmentVariable(IdentityProviderIDEnv);
        if (string.IsNullOrEmpty(identityProviderID))
        {
            return null;
        }
        var provider = WorkloadIdentityProviders.Detect();
        if (provider == null)
        {
            return null;
        }
        return new() { IdentityProviderID = identityProviderID!, Provider = provider };
    }

    internal static DodoPaymentsInvalidDataException ConflictException()
    {
        return new DodoPaymentsInvalidDataException(
            "Set BearerToken or WorkloadIdentity, not both."
        );
    }
}

/// <summary>
/// Subject token providers for workload identity.
/// </summary>
public static class WorkloadIdentityProviders
{
    const string KubernetesTokenPath = "/var/run/secrets/tokens/dodo-token";

    const string TokenFileEnv = "DODO_PAYMENTS_IDENTITY_TOKEN_FILE";

    /// <summary>
    /// Gets a GitHub Actions OIDC token. The job must have the <c>id-token: write</c> permission.
    ///
    /// <para>The audience defaults to the origin of the client base URL.</para>
    /// </summary>
    public static SubjectTokenProvider GitHubActions(string? audience = null)
    {
        return async (context, cancellationToken) =>
        {
            var url = RequireEnv("ACTIONS_ID_TOKEN_REQUEST_URL");
            var requestToken = RequireEnv("ACTIONS_ID_TOKEN_REQUEST_TOKEN");
            var separator = url.Contains("?") ? "&" : "?";
            using HttpRequestMessage request = new(
                HttpMethod.Get,
                url
                    + separator
                    + "audience="
                    + Uri.EscapeDataString(audience ?? DefaultAudience(context.BaseUrl))
            );
            request.Headers.TryAddWithoutValidation(
                "Authorization",
                string.Format("bearer {0}", requestToken)
            );
            var body = await Send(context, request, cancellationToken).ConfigureAwait(false);
            using var document = JsonDocument.Parse(body);
            if (
                document.RootElement.ValueKind == JsonValueKind.Object
                && document.RootElement.TryGetProperty("value", out var value)
                && value.ValueKind == JsonValueKind.String
            )
            {
                return value.GetString()!;
            }
            throw new DodoPaymentsInvalidDataException(
                "The GitHub Actions OIDC response does not contain a value."
            );
        };
    }

    /// <summary>
    /// Reads a GitLab CI ID token from an environment variable.
    /// </summary>
    public static SubjectTokenProvider GitLab(string envVar = "DODO_PAYMENTS_ID_TOKEN")
    {
        return (_context, _cancellationToken) => Task.FromResult(RequireEnv(envVar));
    }

    /// <summary>
    /// Reads the Terraform Cloud workload identity token from <c>TFC_WORKLOAD_IDENTITY_TOKEN_DODO</c>
    /// or <c>TFC_WORKLOAD_IDENTITY_TOKEN</c>.
    /// </summary>
    public static SubjectTokenProvider TerraformCloud()
    {
        return (_context, _cancellationToken) =>
            Task.FromResult(
                Env("TFC_WORKLOAD_IDENTITY_TOKEN_DODO") ?? RequireEnv("TFC_WORKLOAD_IDENTITY_TOKEN")
            );
    }

    /// <summary>
    /// Gets an identity token from the Google Cloud metadata server.
    ///
    /// <para>The audience defaults to the origin of the client base URL.</para>
    /// </summary>
    public static SubjectTokenProvider Gcp(string? audience = null)
    {
        return async (context, cancellationToken) =>
        {
            using HttpRequestMessage request = new(
                HttpMethod.Get,
                "http://metadata.google.internal/computeMetadata/v1/instance/service-accounts/default/identity?audience="
                    + Uri.EscapeDataString(audience ?? DefaultAudience(context.BaseUrl))
                    + "&format=full"
            );
            request.Headers.TryAddWithoutValidation("Metadata-Flavor", "Google");
            var body = await Send(context, request, cancellationToken).ConfigureAwait(false);
            return body.Trim();
        };
    }

    /// <summary>
    /// Reads the Vercel OIDC token from <c>VERCEL_OIDC_TOKEN</c>.
    /// </summary>
    public static SubjectTokenProvider Vercel()
    {
        return (_context, _cancellationToken) => Task.FromResult(RequireEnv("VERCEL_OIDC_TOKEN"));
    }

    /// <summary>
    /// Reads a projected Kubernetes service account token. The file is read for each exchange.
    /// </summary>
    public static SubjectTokenProvider Kubernetes(string path = KubernetesTokenPath)
    {
        return File(path);
    }

    /// <summary>
    /// Reads the subject token from a file. The file is read for each exchange.
    ///
    /// <para>The path defaults to the <c>DODO_PAYMENTS_IDENTITY_TOKEN_FILE</c> environment variable.</para>
    /// </summary>
    public static SubjectTokenProvider File(string? path = null)
    {
        return (_context, _cancellationToken) =>
            Task.FromResult(IOFile.ReadAllText(path ?? RequireEnv(TokenFileEnv)).Trim());
    }

    /// <summary>
    /// Uses your function to get the subject token, for example from AWS STS
    /// <c>GetWebIdentityToken</c>.
    /// </summary>
    public static SubjectTokenProvider Aws(Func<CancellationToken, Task<string>> getToken)
    {
        return (_context, cancellationToken) => getToken(cancellationToken);
    }

    /// <summary>
    /// Always returns the same subject token. Use it for tests.
    /// </summary>
    public static SubjectTokenProvider Static(string token)
    {
        return (_context, _cancellationToken) => Task.FromResult(token);
    }

    /// <summary>
    /// Finds the subject token source from the environment for each exchange. The order is
    /// GitHub Actions, Terraform Cloud, <c>DODO_PAYMENTS_IDENTITY_TOKEN_FILE</c> and the
    /// Kubernetes token path.
    /// </summary>
    public static SubjectTokenProvider Auto()
    {
        return (context, cancellationToken) =>
        {
            var provider =
                Detect()
                ?? throw new DodoPaymentsInvalidDataException(
                    "No workload identity subject token source was found in the environment."
                );
            return provider(context, cancellationToken);
        };
    }

    internal static SubjectTokenProvider? Detect()
    {
        if (
            Env("ACTIONS_ID_TOKEN_REQUEST_URL") != null
            && Env("ACTIONS_ID_TOKEN_REQUEST_TOKEN") != null
        )
        {
            return GitHubActions();
        }
        if (
            Env("TFC_WORKLOAD_IDENTITY_TOKEN_DODO") != null
            || Env("TFC_WORKLOAD_IDENTITY_TOKEN") != null
        )
        {
            return TerraformCloud();
        }
        var tokenFile = Env(TokenFileEnv);
        if (tokenFile != null)
        {
            return File(tokenFile);
        }
        if (IOFile.Exists(KubernetesTokenPath))
        {
            return Kubernetes();
        }
        return null;
    }

    static string? Env(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);
        return string.IsNullOrEmpty(value) ? null : value;
    }

    static string RequireEnv(string name)
    {
        return Env(name)
            ?? throw new DodoPaymentsInvalidDataException(
                string.Format("The {0} environment variable is not set.", name)
            );
    }

    static string DefaultAudience(string baseUrl)
    {
        return new Uri(baseUrl).GetLeftPart(UriPartial.Authority);
    }

    static async Task<string> Send(
        SubjectTokenContext context,
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        using CancellationTokenSource timeoutCts = new(context.Timeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        try
        {
            using var response = await context
                .HttpClient.SendAsync(request, cts.Token)
                .ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new DodoPaymentsInvalidDataException(
                    string.Format(
                        "The subject token request failed with status code {0}.",
                        (int)response.StatusCode
                    )
                );
            }
#if NET
            return await response.Content.ReadAsStringAsync(cts.Token).ConfigureAwait(false);
#else
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
        }
        catch (HttpRequestException e)
        {
            throw new DodoPaymentsIOException("I/O exception", e);
        }
    }
}

sealed class WorkloadIdentityTokenCache
{
    static readonly TimeSpan RefreshWindow = TimeSpan.FromMinutes(5);

    sealed class Entry
    {
        public required string AccessToken { get; init; }

        public required DateTimeOffset ExpiresAt { get; init; }

        public bool IsFresh
        {
            get { return this.ExpiresAt - DateTimeOffset.UtcNow > RefreshWindow; }
        }
    }

    readonly SemaphoreSlim _exchangeLock = new(1, 1);

    Entry? _entry = null;

    internal string? CachedAccessToken
    {
        get { return Volatile.Read(ref _entry)?.AccessToken; }
    }

    internal async Task<string> GetAccessToken(
        WorkloadIdentityOptions workloadIdentity,
        ClientOptions options,
        CancellationToken cancellationToken
    )
    {
        var entry = Volatile.Read(ref _entry);
        if (entry != null && entry.IsFresh)
        {
            return entry.AccessToken;
        }

        await _exchangeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            entry = Volatile.Read(ref _entry);
            if (entry != null && entry.IsFresh)
            {
                return entry.AccessToken;
            }
            entry = await Exchange(workloadIdentity, options, cancellationToken)
                .ConfigureAwait(false);
            Volatile.Write(ref _entry, entry);
            return entry.AccessToken;
        }
        finally
        {
            _exchangeLock.Release();
        }
    }

    internal void Invalidate(string accessToken)
    {
        var entry = Volatile.Read(ref _entry);
        if (entry != null && entry.AccessToken == accessToken)
        {
            Interlocked.CompareExchange(ref _entry, null, entry);
        }
    }

    static async Task<Entry> Exchange(
        WorkloadIdentityOptions workloadIdentity,
        ClientOptions options,
        CancellationToken cancellationToken
    )
    {
        var subjectToken = await workloadIdentity
            .Provider(
                new()
                {
                    BaseUrl = options.BaseUrl,
                    HttpClient = options.HttpClient,
                    Timeout = options.Timeout ?? ClientOptions.DefaultTimeout,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        var identityProviderID = workloadIdentity.IdentityProviderID;
        using var response = await new DodoPaymentsClientWithRawResponse(options)
            .ExecuteWithRetries(
                new HttpRequest<WorkloadIdentityParams>
                {
                    Method = HttpMethod.Post,
                    Params = new()
                    {
                        Path = WorkloadIdentityOptions.TokenPath,
                        Body = ExchangeBody(subjectToken, identityProviderID),
                    },
                },
                null,
                false,
                cancellationToken
            )
            .ConfigureAwait(false);
        string body;
        try
        {
            body = await response.ReadAsString(cancellationToken).ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new DodoPaymentsIOException("I/O Exception", e);
        }
        return ParseTokenResponse(body);
    }

    static string ExchangeBody(string subjectToken, string identityProviderID)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteStartObject();
            writer.WriteString("grant_type", "urn:ietf:params:oauth:grant-type:token-exchange");
            writer.WriteString("subject_token_type", "urn:ietf:params:oauth:token-type:jwt");
            writer.WriteString("subject_token", subjectToken);
            writer.WriteString("identity_provider_id", identityProviderID);
            writer.WriteEndObject();
        }
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    static Entry ParseTokenResponse(string body)
    {
        using var document = JsonDocument.Parse(body);
        var root = document.RootElement;
        if (
            root.ValueKind != JsonValueKind.Object
            || !root.TryGetProperty("access_token", out var accessToken)
            || accessToken.ValueKind != JsonValueKind.String
        )
        {
            throw new DodoPaymentsInvalidDataException(
                "The workload identity token response does not contain an access_token."
            );
        }

        var now = DateTimeOffset.UtcNow;
        var expiresAt = now;
        if (
            root.TryGetProperty("expires_at", out var expiresAtElement)
            && expiresAtElement.ValueKind == JsonValueKind.String
            && DateTimeOffset.TryParse(
                expiresAtElement.GetString(),
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out var parsedExpiresAt
            )
        )
        {
            expiresAt = parsedExpiresAt;
        }
        else if (
            root.TryGetProperty("expires_in", out var expiresIn)
            && expiresIn.ValueKind == JsonValueKind.Number
        )
        {
            expiresAt = now.AddSeconds(expiresIn.GetDouble());
        }

        return new() { AccessToken = accessToken.GetString()!, ExpiresAt = expiresAt };
    }
}

sealed record class WorkloadIdentityParams : ParamsBase
{
    public required string Path { get; init; }

    public string? Body { get; init; }

    public override Uri Url(ClientOptions options)
    {
        return new Uri(options.BaseUrl.ToString().TrimEnd('/') + this.Path);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
    }

    internal override HttpContent? BodyContent()
    {
        return this.Body == null
            ? null
            : new StringContent(this.Body, Encoding.UTF8, "application/json");
    }
}
