using System;
using System.Net.Http;
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

public sealed class DodoPaymentsClient : IDodoPaymentsClient
{
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("DODO_PAYMENTS_BASE_URL")
                ?? "https://live.dodopayments.com"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string> _bearerToken = new(() =>
        Environment.GetEnvironmentVariable("DODO_PAYMENTS_API_KEY")
        ?? throw new ArgumentNullException(nameof(BearerToken))
    );
    public string BearerToken
    {
        get { return _bearerToken.Value; }
        init { _bearerToken = new(() => value); }
    }

    readonly Lazy<ICheckoutSessionService> _checkoutSessions;
    public ICheckoutSessionService CheckoutSessions
    {
        get { return _checkoutSessions.Value; }
    }

    readonly Lazy<IPaymentService> _payments;
    public IPaymentService Payments
    {
        get { return _payments.Value; }
    }

    readonly Lazy<ISubscriptionService> _subscriptions;
    public ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly Lazy<IInvoiceService> _invoices;
    public IInvoiceService Invoices
    {
        get { return _invoices.Value; }
    }

    readonly Lazy<ILicenseService> _licenses;
    public ILicenseService Licenses
    {
        get { return _licenses.Value; }
    }

    readonly Lazy<ILicenseKeyService> _licenseKeys;
    public ILicenseKeyService LicenseKeys
    {
        get { return _licenseKeys.Value; }
    }

    readonly Lazy<ILicenseKeyInstanceService> _licenseKeyInstances;
    public ILicenseKeyInstanceService LicenseKeyInstances
    {
        get { return _licenseKeyInstances.Value; }
    }

    readonly Lazy<ICustomerService> _customers;
    public ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IRefundService> _refunds;
    public IRefundService Refunds
    {
        get { return _refunds.Value; }
    }

    readonly Lazy<IDisputeService> _disputes;
    public IDisputeService Disputes
    {
        get { return _disputes.Value; }
    }

    readonly Lazy<IPayoutService> _payouts;
    public IPayoutService Payouts
    {
        get { return _payouts.Value; }
    }

    readonly Lazy<IWebhookEventService> _webhookEvents;
    public IWebhookEventService WebhookEvents
    {
        get { return _webhookEvents.Value; }
    }

    readonly Lazy<IProductService> _products;
    public IProductService Products
    {
        get { return _products.Value; }
    }

    readonly Lazy<IMiscService> _misc;
    public IMiscService Misc
    {
        get { return _misc.Value; }
    }

    readonly Lazy<IDiscountService> _discounts;
    public IDiscountService Discounts
    {
        get { return _discounts.Value; }
    }

    readonly Lazy<IAddonService> _addons;
    public IAddonService Addons
    {
        get { return _addons.Value; }
    }

    readonly Lazy<IBrandService> _brands;
    public IBrandService Brands
    {
        get { return _brands.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<IUsageEventService> _usageEvents;
    public IUsageEventService UsageEvents
    {
        get { return _usageEvents.Value; }
    }

    readonly Lazy<IMeterService> _meters;
    public IMeterService Meters
    {
        get { return _meters.Value; }
    }

    public DodoPaymentsClient()
    {
        _checkoutSessions = new(() => new CheckoutSessionService(this));
        _payments = new(() => new PaymentService(this));
        _subscriptions = new(() => new SubscriptionService(this));
        _invoices = new(() => new InvoiceService(this));
        _licenses = new(() => new LicenseService(this));
        _licenseKeys = new(() => new LicenseKeyService(this));
        _licenseKeyInstances = new(() => new LicenseKeyInstanceService(this));
        _customers = new(() => new CustomerService(this));
        _refunds = new(() => new RefundService(this));
        _disputes = new(() => new DisputeService(this));
        _payouts = new(() => new PayoutService(this));
        _webhookEvents = new(() => new WebhookEventService(this));
        _products = new(() => new ProductService(this));
        _misc = new(() => new MiscService(this));
        _discounts = new(() => new DiscountService(this));
        _addons = new(() => new AddonService(this));
        _brands = new(() => new BrandService(this));
        _webhooks = new(() => new WebhookService(this));
        _usageEvents = new(() => new UsageEventService(this));
        _meters = new(() => new MeterService(this));
    }
}
