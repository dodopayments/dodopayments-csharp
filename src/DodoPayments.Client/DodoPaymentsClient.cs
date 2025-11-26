using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Services;

namespace DodoPayments.Client;

public sealed class DodoPaymentsClient : IDodoPaymentsClient
{
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }

    readonly ClientOptions _options;

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

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    public TimeSpan? Timeout
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

    public IDodoPaymentsClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DodoPaymentsClient(modifier(this._options));
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

    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        if (maxRetries <= 0)
        {
            return await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
        }

        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.Message.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw DodoPaymentsExceptionFactory.CreateApiException(
                        response.Message.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new DodoPaymentsIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
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
        catch (HttpRequestException e)
        {
            throw new DodoPaymentsIOException("I/O exception", e);
        }
        return new() { Message = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.Message.Headers.TryGetValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.Message.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is DodoPaymentsIOException;
    }

    public DodoPaymentsClient()
    {
        _options = new();

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

    public DodoPaymentsClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
