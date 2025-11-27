using System;
using System.Net.Http;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public struct ClientOptions()
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
    /// </summary>
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("DODO_PAYMENTS_BASE_URL")
                ?? "https://live.dodopayments.com"
        )
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the live_mode environment: https://live.dodopayments.com</para>
    ///
    /// <para>
    /// The following other environments are available:
    /// <list type="bullet">
    ///   <item>test_mode: https://test.dodopayments.com</item>
    /// </list>
    /// </para>
    /// </summary>
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate every response before returning it.
    ///
    /// <para>Defaults to false, which means the shape of the response will not be
    /// validated upfront. Instead, validation will only occur for the parts of the
    /// response that are accessed.</para>
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
    public int? MaxRetries { get; set; }

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; }

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
        set { _bearerToken = new(() => value); }
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
