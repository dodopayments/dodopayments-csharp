using System;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class WebhookEventService : IWebhookEventService
{
    readonly Lazy<IWebhookEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IWebhookEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookEventService(this._client.WithOptions(modifier));
    }

    public WebhookEventService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WebhookEventServiceWithRawResponse(client.WithRawResponse)
        );
    }
}

/// <inheritdoc/>
public sealed class WebhookEventServiceWithRawResponse : IWebhookEventServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WebhookEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookEventServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }
}
