using System;
using System.Net.Http;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    ///
    /// <para>Note: The HttpClient has a built-in timeout, which defaults to 100 seconds.
    /// When passing a custom HttpClient, this timeout may conflict with the SDK's
    /// own timeout handler and cause premature cancellation.</para>
    /// </summary>
    public HttpClient HttpClient { get; set; } =
        new(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Available })
        {
            Timeout = global::System.Threading.Timeout.InfiniteTimeSpan,
        };

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("DODO_PAYMENTS_BASE_URL") ?? EnvironmentUrl.LiveMode
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the live_mode environment: <see cref="EnvironmentUrl.LiveMode"/></para>
    ///
    /// <para>
    /// The following other environments are available:
    /// <list type="bullet">
    ///   <item>test_mode: <see cref="EnvironmentUrl.TestMode"/></item>
    /// </list>
    /// </para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="IDodoPaymentsClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    public int? MaxRetries { get; set; } = null;

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    Lazy<string> _bearerToken = new(() =>
        Environment.GetEnvironmentVariable("DODO_PAYMENTS_API_KEY")
        ?? throw new DodoPaymentsInvalidDataException(
            string.Format("{0} cannot be null", nameof(BearerToken)),
            new ArgumentNullException(nameof(BearerToken))
        )
    );

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    public string BearerToken
    {
        readonly get { return _bearerToken.Value; }
        set
        {
            if (_workloadIdentity != null)
            {
                throw WorkloadIdentityOptions.ConflictException();
            }
            _bearerToken = new(() => value);
            _bearerTokenSet = true;
        }
    }

    bool _bearerTokenSet = false;

    WorkloadIdentityOptions? _workloadIdentity = null;

    /// <summary>
    /// Workload identity configuration. The client exchanges a subject token for a short-lived
    /// access token and sends the access token instead of <see cref="BearerToken"/>.
    ///
    /// <para>You cannot set this option and <see cref="BearerToken"/> together. If you set
    /// neither option and <c>DODO_PAYMENTS_API_KEY</c> is not set, the client uses workload identity
    /// when <c>DODO_PAYMENTS_IDENTITY_PROVIDER_ID</c> is set and a subject token source is found.</para>
    /// </summary>
    public WorkloadIdentityOptions? WorkloadIdentity
    {
        readonly get { return _workloadIdentity; }
        set
        {
            if (value != null && _bearerTokenSet)
            {
                throw WorkloadIdentityOptions.ConflictException();
            }
            _workloadIdentity = value;
        }
    }

    readonly Lazy<WorkloadIdentityOptions?> _environmentWorkloadIdentity = new(() =>
        WorkloadIdentityOptions.FromEnvironment()
    );

    internal readonly WorkloadIdentityOptions? ResolvedWorkloadIdentity
    {
        get
        {
            return _workloadIdentity
                ?? (_bearerTokenSet ? null : _environmentWorkloadIdentity.Value);
        }
    }

    Lazy<string?> _webhookKey = new(() =>
        Environment.GetEnvironmentVariable("DODO_PAYMENTS_WEBHOOK_KEY")
    );
    public string? WebhookKey
    {
        readonly get { return _webhookKey.Value; }
        set { _webhookKey = new(() => value); }
    }
}
