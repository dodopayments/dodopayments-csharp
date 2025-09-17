using Client = DodoPayments.Client;

namespace DodoPayments.Client.Services.WebhookEvents;

public sealed class WebhookEventService : IWebhookEventService
{
    public WebhookEventService(Client::IDodoPaymentsClient client) { }
}
