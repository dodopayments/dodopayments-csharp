using Addons = Dodopayments.Services.Addons;
using Brands = Dodopayments.Services.Brands;
using CheckoutSessions = Dodopayments.Services.CheckoutSessions;
using Customers = Dodopayments.Services.Customers;
using Discounts = Dodopayments.Services.Discounts;
using Disputes = Dodopayments.Services.Disputes;
using Http = System.Net.Http;
using Invoices = Dodopayments.Services.Invoices;
using LicenseKeyInstances = Dodopayments.Services.LicenseKeyInstances;
using LicenseKeys = Dodopayments.Services.LicenseKeys;
using Licenses = Dodopayments.Services.Licenses;
using Meters = Dodopayments.Services.Meters;
using Misc = Dodopayments.Services.Misc;
using Payments = Dodopayments.Services.Payments;
using Payouts = Dodopayments.Services.Payouts;
using Products = Dodopayments.Services.Products;
using Refunds = Dodopayments.Services.Refunds;
using Subscriptions = Dodopayments.Services.Subscriptions;
using System = System;
using UsageEvents = Dodopayments.Services.UsageEvents;
using WebhookEvents = Dodopayments.Services.WebhookEvents;
using Webhooks = Dodopayments.Services.Webhooks;

namespace Dodopayments;

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
