using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services.Addons;
using DodoPayments.Client.Services.Brands;
using DodoPayments.Client.Services.CheckoutSessions;
using DodoPayments.Client.Services.Customers;
using DodoPayments.Client.Services.Discounts;
using DodoPayments.Client.Services.Disputes;
using DodoPayments.Client.Services.Invoices;
using DodoPayments.Client.Services.LicenseKeyInstances;
using DodoPayments.Client.Services.LicenseKeys;
using DodoPayments.Client.Services.Licenses;
using DodoPayments.Client.Services.Meters;
using DodoPayments.Client.Services.Misc;
using DodoPayments.Client.Services.Payments;
using DodoPayments.Client.Services.Payouts;
using DodoPayments.Client.Services.Products;
using DodoPayments.Client.Services.Refunds;
using DodoPayments.Client.Services.Subscriptions;
using DodoPayments.Client.Services.UsageEvents;
using DodoPayments.Client.Services.WebhookEvents;
using DodoPayments.Client.Services.Webhooks;

namespace DodoPayments.Client;

public interface IDodoPaymentsClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int MaxRetries { get; init; }

    TimeSpan Timeout { get; init; }

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
