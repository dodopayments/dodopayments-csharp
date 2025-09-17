using Dodopayments = Dodopayments;

namespace Dodopayments.Services.WebhookEvents;

public sealed class WebhookEventService : IWebhookEventService
{
    public WebhookEventService(Dodopayments::IDodoPaymentsClient client) { }
}
