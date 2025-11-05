using System;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Services.WebhookEvents;

public sealed class WebhookEventService : IWebhookEventService
{
    public IWebhookEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookEventService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public WebhookEventService(IDodoPaymentsClient client)
    {
        _client = client;
    }
}
