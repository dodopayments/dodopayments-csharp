using System;
using System.Net.Http;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("DODO_PAYMENTS_BASE_URL")
                ?? "https://live.dodopayments.com"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    public bool ResponseValidation { get; set; } = false;

    public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(1);

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
