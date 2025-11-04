using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
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
    readonly ClientOptions _options = new();

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string BearerToken
    {
        get { return this._options.BearerToken; }
        init { this._options.BearerToken = value; }
    }

    public string? WebhookKey
    {
        get { return this._options.WebhookKey; }
        init { this._options.WebhookKey = value; }
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

    readonly Lazy<IWebhookEventService> _webhookEvents;
    public IWebhookEventService WebhookEvents
    {
        get { return _webhookEvents.Value; }
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

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource cts = new(this.Timeout);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new DodoPaymentsIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw DodoPaymentsExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new DodoPaymentsIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
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
        _products = new(() => new ProductService(this));
        _misc = new(() => new MiscService(this));
        _discounts = new(() => new DiscountService(this));
        _addons = new(() => new AddonService(this));
        _brands = new(() => new BrandService(this));
        _webhooks = new(() => new WebhookService(this));
        _webhookEvents = new(() => new WebhookEventService(this));
        _usageEvents = new(() => new UsageEventService(this));
        _meters = new(() => new MeterService(this));
    }
}
