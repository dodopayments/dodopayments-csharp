using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Services;

namespace DodoPayments.Client;

/// <summary>
/// A client for interacting with the Dodo Payments REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDodoPaymentsClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    string BearerToken { get; init; }

    string? WebhookKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDodoPaymentsClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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
}

/// <summary>
/// A view of <see cref="IDodoPaymentsClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IDodoPaymentsClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Bearer Token for API authentication
    /// </summary>
    string BearerToken { get; init; }

    string? WebhookKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDodoPaymentsClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICheckoutSessionServiceWithRawResponse CheckoutSessions { get; }

    IPaymentServiceWithRawResponse Payments { get; }

    ISubscriptionServiceWithRawResponse Subscriptions { get; }

    IInvoiceServiceWithRawResponse Invoices { get; }

    ILicenseServiceWithRawResponse Licenses { get; }

    ILicenseKeyServiceWithRawResponse LicenseKeys { get; }

    ILicenseKeyInstanceServiceWithRawResponse LicenseKeyInstances { get; }

    ICustomerServiceWithRawResponse Customers { get; }

    IRefundServiceWithRawResponse Refunds { get; }

    IDisputeServiceWithRawResponse Disputes { get; }

    IPayoutServiceWithRawResponse Payouts { get; }

    IProductServiceWithRawResponse Products { get; }

    IMiscServiceWithRawResponse Misc { get; }

    IDiscountServiceWithRawResponse Discounts { get; }

    IAddonServiceWithRawResponse Addons { get; }

    IBrandServiceWithRawResponse Brands { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    IWebhookEventServiceWithRawResponse WebhookEvents { get; }

    IUsageEventServiceWithRawResponse UsageEvents { get; }

    IMeterServiceWithRawResponse Meters { get; }

    /// <summary>
    /// Sends a request to the Dodo Payments REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
