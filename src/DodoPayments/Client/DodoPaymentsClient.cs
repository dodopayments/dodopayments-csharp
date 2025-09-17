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

public sealed class DodoPaymentsClient : IDodoPaymentsClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

    System::Lazy<System::Uri> _baseUrl = new(() =>
        new System::Uri(
            System::Environment.GetEnvironmentVariable("DODO_PAYMENTS_BASE_URL")
                ?? "https://live.dodopayments.com"
        )
    );
    public System::Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    System::Lazy<string> _bearerToken = new(() =>
        System::Environment.GetEnvironmentVariable("DODO_PAYMENTS_API_KEY")
        ?? throw new System::ArgumentNullException(nameof(BearerToken))
    );
    public string BearerToken
    {
        get { return _bearerToken.Value; }
        init { _bearerToken = new(() => value); }
    }

    readonly System::Lazy<CheckoutSessions::ICheckoutSessionService> _checkoutSessions;
    public CheckoutSessions::ICheckoutSessionService CheckoutSessions
    {
        get { return _checkoutSessions.Value; }
    }

    readonly System::Lazy<Payments::IPaymentService> _payments;
    public Payments::IPaymentService Payments
    {
        get { return _payments.Value; }
    }

    readonly System::Lazy<Subscriptions::ISubscriptionService> _subscriptions;
    public Subscriptions::ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly System::Lazy<Invoices::IInvoiceService> _invoices;
    public Invoices::IInvoiceService Invoices
    {
        get { return _invoices.Value; }
    }

    readonly System::Lazy<Licenses::ILicenseService> _licenses;
    public Licenses::ILicenseService Licenses
    {
        get { return _licenses.Value; }
    }

    readonly System::Lazy<LicenseKeys::ILicenseKeyService> _licenseKeys;
    public LicenseKeys::ILicenseKeyService LicenseKeys
    {
        get { return _licenseKeys.Value; }
    }

    readonly System::Lazy<LicenseKeyInstances::ILicenseKeyInstanceService> _licenseKeyInstances;
    public LicenseKeyInstances::ILicenseKeyInstanceService LicenseKeyInstances
    {
        get { return _licenseKeyInstances.Value; }
    }

    readonly System::Lazy<Customers::ICustomerService> _customers;
    public Customers::ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly System::Lazy<Refunds::IRefundService> _refunds;
    public Refunds::IRefundService Refunds
    {
        get { return _refunds.Value; }
    }

    readonly System::Lazy<Disputes::IDisputeService> _disputes;
    public Disputes::IDisputeService Disputes
    {
        get { return _disputes.Value; }
    }

    readonly System::Lazy<Payouts::IPayoutService> _payouts;
    public Payouts::IPayoutService Payouts
    {
        get { return _payouts.Value; }
    }

    readonly System::Lazy<WebhookEvents::IWebhookEventService> _webhookEvents;
    public WebhookEvents::IWebhookEventService WebhookEvents
    {
        get { return _webhookEvents.Value; }
    }

    readonly System::Lazy<Products::IProductService> _products;
    public Products::IProductService Products
    {
        get { return _products.Value; }
    }

    readonly System::Lazy<Misc::IMiscService> _misc;
    public Misc::IMiscService Misc
    {
        get { return _misc.Value; }
    }

    readonly System::Lazy<Discounts::IDiscountService> _discounts;
    public Discounts::IDiscountService Discounts
    {
        get { return _discounts.Value; }
    }

    readonly System::Lazy<Addons::IAddonService> _addons;
    public Addons::IAddonService Addons
    {
        get { return _addons.Value; }
    }

    readonly System::Lazy<Brands::IBrandService> _brands;
    public Brands::IBrandService Brands
    {
        get { return _brands.Value; }
    }

    readonly System::Lazy<Webhooks::IWebhookService> _webhooks;
    public Webhooks::IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly System::Lazy<UsageEvents::IUsageEventService> _usageEvents;
    public UsageEvents::IUsageEventService UsageEvents
    {
        get { return _usageEvents.Value; }
    }

    readonly System::Lazy<Meters::IMeterService> _meters;
    public Meters::IMeterService Meters
    {
        get { return _meters.Value; }
    }

    public DodoPaymentsClient()
    {
        _checkoutSessions = new(() => new CheckoutSessions::CheckoutSessionService(this));
        _payments = new(() => new Payments::PaymentService(this));
        _subscriptions = new(() => new Subscriptions::SubscriptionService(this));
        _invoices = new(() => new Invoices::InvoiceService(this));
        _licenses = new(() => new Licenses::LicenseService(this));
        _licenseKeys = new(() => new LicenseKeys::LicenseKeyService(this));
        _licenseKeyInstances = new(() => new LicenseKeyInstances::LicenseKeyInstanceService(this));
        _customers = new(() => new Customers::CustomerService(this));
        _refunds = new(() => new Refunds::RefundService(this));
        _disputes = new(() => new Disputes::DisputeService(this));
        _payouts = new(() => new Payouts::PayoutService(this));
        _webhookEvents = new(() => new WebhookEvents::WebhookEventService(this));
        _products = new(() => new Products::ProductService(this));
        _misc = new(() => new Misc::MiscService(this));
        _discounts = new(() => new Discounts::DiscountService(this));
        _addons = new(() => new Addons::AddonService(this));
        _brands = new(() => new Brands::BrandService(this));
        _webhooks = new(() => new Webhooks::WebhookService(this));
        _usageEvents = new(() => new UsageEvents::UsageEventService(this));
        _meters = new(() => new Meters::MeterService(this));
    }
}
