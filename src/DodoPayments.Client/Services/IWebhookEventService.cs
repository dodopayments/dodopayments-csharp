using System;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Services;

public interface IWebhookEventService
{
    IWebhookEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);
}
