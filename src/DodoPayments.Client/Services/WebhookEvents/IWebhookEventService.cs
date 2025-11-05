using System;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Services.WebhookEvents;

public interface IWebhookEventService
{
    IWebhookEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);
}
