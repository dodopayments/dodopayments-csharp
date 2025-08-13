using Addons = DodoPayments.Services.Addons;
using Brands = DodoPayments.Services.Brands;
using Customers = DodoPayments.Services.Customers;
using Discounts = DodoPayments.Services.Discounts;
using Disputes = DodoPayments.Services.Disputes;
using Http = System.Net.Http;
using Invoices = DodoPayments.Services.Invoices;
using LicenseKeyInstances = DodoPayments.Services.LicenseKeyInstances;
using LicenseKeys = DodoPayments.Services.LicenseKeys;
using Licenses = DodoPayments.Services.Licenses;
using Misc = DodoPayments.Services.Misc;
using Payments = DodoPayments.Services.Payments;
using Payouts = DodoPayments.Services.Payouts;
using Products = DodoPayments.Services.Products;
using Refunds = DodoPayments.Services.Refunds;
using Subscriptions = DodoPayments.Services.Subscriptions;
using System = System;
using WebhookEvents = DodoPayments.Services.WebhookEvents;
using Webhooks = DodoPayments.Services.Webhooks;
using YourWebhookURL = DodoPayments.Services.YourWebhookURL;

namespace DodoPayments;

public interface IDodoPaymentsClient
{
    Http::HttpClient HttpClient { get; init; }

    System::Uri BaseUrl { get; init; }

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    string BearerToken { get; init; }

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

    YourWebhookURL::IYourWebhookURLService YourWebhookURL { get; }
}
