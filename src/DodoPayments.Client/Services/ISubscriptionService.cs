using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>post /subscriptions<c/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<SubscriptionCreateResponse> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /subscriptions/{subscription_id}<c/>.
    /// </summary>
    Task<Subscription> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>
    Task<Subscription> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>patch /subscriptions/{subscription_id}<c/>.
    /// </summary>
    Task<Subscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<Subscription> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /subscriptions<c/>.
    /// </summary>
    Task<SubscriptionListPage> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /subscriptions/{subscription_id}/change-plan<c/>.
    /// </summary>
    Task ChangePlan(
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChangePlan(SubscriptionChangePlanParams, CancellationToken)"/>
    Task ChangePlan(
        string subscriptionID,
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /subscriptions/{subscription_id}/charge<c/>.
    /// </summary>
    Task<SubscriptionChargeResponse> Charge(
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Charge(SubscriptionChargeParams, CancellationToken)"/>
    Task<SubscriptionChargeResponse> Charge(
        string subscriptionID,
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /subscriptions/{subscription_id}/change-plan/preview<c/>.
    /// </summary>
    Task<SubscriptionPreviewChangePlanResponse> PreviewChangePlan(
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PreviewChangePlan(SubscriptionPreviewChangePlanParams, CancellationToken)"/>
    Task<SubscriptionPreviewChangePlanResponse> PreviewChangePlan(
        string subscriptionID,
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get detailed usage history for a subscription that includes usage-based billing
    /// (metered components). This endpoint provides insights into customer usage
    /// patterns and billing calculations over time.
    ///
    /// <para>## What You'll Get: - **Billing periods**: Each item represents a billing
    /// cycle with start and end dates - **Meter usage**: Detailed breakdown of usage
    /// for each meter configured on the subscription - **Usage calculations**: Total
    /// units consumed, free threshold units, and chargeable units - **Historical
    /// tracking**: Complete audit trail of usage-based charges</para>
    ///
    /// <para>## Use Cases: - **Customer support**: Investigate billing questions
    /// and usage discrepancies - **Usage analytics**: Analyze customer consumption
    /// patterns over time - **Billing transparency**: Provide customers with detailed
    /// usage breakdowns - **Revenue optimization**: Identify usage trends to optimize
    /// pricing strategies</para>
    ///
    /// <para>## Filtering Options: - **Date range filtering**: Get usage history
    /// for specific time periods - **Meter-specific filtering**: Focus on usage
    /// for a particular meter - **Pagination**: Navigate through large usage histories efficiently</para>
    ///
    /// <para>## Important Notes: - Only returns data for subscriptions with usage-based
    /// (metered) components - Usage history is organized by billing periods (subscription
    /// cycles) - Free threshold units are calculated and displayed separately from
    /// chargeable units - Historical data is preserved even if meter configurations change</para>
    ///
    /// <para>## Example Query Patterns: - Get last 3 months: `?start_date=2024-01-01T00:00:00Z&end_date=2024-03-31T23:59:59Z`
    /// - Filter by meter: `?meter_id=mtr_api_requests` - Paginate results: `?page_size=20&page_number=1`
    /// - Recent usage: `?start_date=2024-03-01T00:00:00Z` (from March 1st to now)</para>
    /// </summary>
    Task<SubscriptionRetrieveUsageHistoryPage> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveUsageHistory(SubscriptionRetrieveUsageHistoryParams, CancellationToken)"/>
    Task<SubscriptionRetrieveUsageHistoryPage> RetrieveUsageHistory(
        string subscriptionID,
        SubscriptionRetrieveUsageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>post /subscriptions/{subscription_id}/update-payment-method<c/>.
    /// </summary>
    Task<SubscriptionUpdatePaymentMethodResponse> UpdatePaymentMethod(
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdatePaymentMethod(SubscriptionUpdatePaymentMethodParams, CancellationToken)"/>
    Task<SubscriptionUpdatePaymentMethodResponse> UpdatePaymentMethod(
        string subscriptionID,
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /subscriptions`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Create(SubscriptionCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<SubscriptionCreateResponse>> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /subscriptions/{subscription_id}`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Subscription>> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Subscription>> Retrieve(
        string subscriptionID,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /subscriptions/{subscription_id}`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Update(SubscriptionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Subscription>> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Subscription>> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /subscriptions`, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionListPage>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /subscriptions/{subscription_id}/change-plan`, but is otherwise the
    /// same as <see cref="ISubscriptionService.ChangePlan(SubscriptionChangePlanParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ChangePlan(
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChangePlan(SubscriptionChangePlanParams, CancellationToken)"/>
    Task<HttpResponse> ChangePlan(
        string subscriptionID,
        SubscriptionChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /subscriptions/{subscription_id}/charge`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Charge(SubscriptionChargeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionChargeResponse>> Charge(
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Charge(SubscriptionChargeParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionChargeResponse>> Charge(
        string subscriptionID,
        SubscriptionChargeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /subscriptions/{subscription_id}/change-plan/preview`, but is otherwise the
    /// same as <see cref="ISubscriptionService.PreviewChangePlan(SubscriptionPreviewChangePlanParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionPreviewChangePlanResponse>> PreviewChangePlan(
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PreviewChangePlan(SubscriptionPreviewChangePlanParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionPreviewChangePlanResponse>> PreviewChangePlan(
        string subscriptionID,
        SubscriptionPreviewChangePlanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /subscriptions/{subscription_id}/usage-history`, but is otherwise the
    /// same as <see cref="ISubscriptionService.RetrieveUsageHistory(SubscriptionRetrieveUsageHistoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionRetrieveUsageHistoryPage>> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveUsageHistory(SubscriptionRetrieveUsageHistoryParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionRetrieveUsageHistoryPage>> RetrieveUsageHistory(
        string subscriptionID,
        SubscriptionRetrieveUsageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /subscriptions/{subscription_id}/update-payment-method`, but is otherwise the
    /// same as <see cref="ISubscriptionService.UpdatePaymentMethod(SubscriptionUpdatePaymentMethodParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionUpdatePaymentMethodResponse>> UpdatePaymentMethod(
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdatePaymentMethod(SubscriptionUpdatePaymentMethodParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionUpdatePaymentMethodResponse>> UpdatePaymentMethod(
        string subscriptionID,
        SubscriptionUpdatePaymentMethodParams parameters,
        CancellationToken cancellationToken = default
    );
}
