using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services;

namespace DodoPayments.Client;

public interface IDodoPaymentsClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    string BearerToken { get; init; }

    string? WebhookKey { get; init; }

    IDodoPaymentsClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICheckoutSessionService CheckoutSessions { get; }

    IPaymentService Payments { get; }

    ISubscriptionService Subscriptions { get; }

    IInvoiceService Invoices { get; }

    ILicenseService Licenses { get; }

    ILicenseKeyService LicenseKeys { get; }

    ILicenseKeyInstanceService LicenseKeyInstances { get; }

    ICustomerService Customers { get; }

    IRefundService Refunds { get; }

    IDisputeService Disputes { get; }

    IPayoutService Payouts { get; }

    IProductService Products { get; }

    IMiscService Misc { get; }

    IDiscountService Discounts { get; }

    IAddonService Addons { get; }

    IBrandService Brands { get; }

    IWebhookService Webhooks { get; }

    IWebhookEventService WebhookEvents { get; }

    IUsageEventService UsageEvents { get; }

    IMeterService Meters { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
