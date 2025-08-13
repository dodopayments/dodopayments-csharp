using DodoPayments = DodoPayments;

namespace DodoPayments.Services.WebhookEvents;

public sealed class WebhookEventService : IWebhookEventService
{
    public WebhookEventService(DodoPayments::IDodoPaymentsClient client) { }
}
