using Addons = DodoPayments.Client.Services.Addons;
using Brands = DodoPayments.Client.Services.Brands;
using CheckoutSessions = DodoPayments.Client.Services.CheckoutSessions;
using Customers = DodoPayments.Client.Services.Customers;
using Discounts = DodoPayments.Client.Services.Discounts;
using Disputes = DodoPayments.Client.Services.Disputes;
using Http = System.Net.Http;
using Invoices = DodoPayments.Client.Services.Invoices;
using LicenseKeyInstances = DodoPayments.Client.Services.LicenseKeyInstances;
using LicenseKeys = DodoPayments.Client.Services.LicenseKeys;
using Licenses = DodoPayments.Client.Services.Licenses;
using Meters = DodoPayments.Client.Services.Meters;
using Misc = DodoPayments.Client.Services.Misc;
using Payments = DodoPayments.Client.Services.Payments;
using Payouts = DodoPayments.Client.Services.Payouts;
using Products = DodoPayments.Client.Services.Products;
using Refunds = DodoPayments.Client.Services.Refunds;
using Subscriptions = DodoPayments.Client.Services.Subscriptions;
using System = System;
using UsageEvents = DodoPayments.Client.Services.UsageEvents;
using WebhookEvents = DodoPayments.Client.Services.WebhookEvents;
using Webhooks = DodoPayments.Client.Services.Webhooks;

namespace DodoPayments.Client;

public interface IDodoPaymentsClient
{
    Http::HttpClient HttpClient { get; init; }

    System::Uri BaseUrl { get; init; }

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    string BearerToken { get; init; }

    CheckoutSessions::ICheckoutSessionService CheckoutSessions { get; }

    Payments::IPaymentService Payments { get; }

    Subscriptions::ISubscriptionService Subscriptions { get; }

    Invoices::IInvoiceService Invoices { get; }

    Licenses::ILicenseService Licenses { get; }

    LicenseKeys::ILicenseKeyService LicenseKeys { get; }

    LicenseKeyInstances::ILicenseKeyInstanceService LicenseKeyInstances { get; }

    Customers::ICustomerService Customers { get; }

    Refunds::IRefundService Refunds { get; }

    Disputes::IDisputeService Disputes { get; }

    Payouts::IPayoutService Payouts { get; }

    WebhookEvents::IWebhookEventService WebhookEvents { get; }

    Products::IProductService Products { get; }

    Misc::IMiscService Misc { get; }

    Discounts::IDiscountService Discounts { get; }

    Addons::IAddonService Addons { get; }

    Brands::IBrandService Brands { get; }

    Webhooks::IWebhookService Webhooks { get; }

    UsageEvents::IUsageEventService UsageEvents { get; }

    Meters::IMeterService Meters { get; }
}
