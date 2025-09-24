using System.Threading.Tasks;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Services.Subscriptions;

public interface ISubscriptionService
{
    Task<SubscriptionCreateResponse> Create(SubscriptionCreateParams parameters);

    Task<Subscription> Retrieve(SubscriptionRetrieveParams parameters);

    Task<Subscription> Update(SubscriptionUpdateParams parameters);

    Task<SubscriptionListPageResponse> List(SubscriptionListParams? parameters = null);

    Task ChangePlan(SubscriptionChangePlanParams parameters);

    Task<SubscriptionChargeResponse> Charge(SubscriptionChargeParams parameters);

    /// <summary>
    /// Get detailed usage history for a subscription that includes usage-based billing
    /// (metered components). This endpoint provides insights into customer usage
    /// patterns and billing calculations over time.
    ///
    /// ## What You'll Get: - **Billing periods**: Each item represents a billing
    /// cycle with start and end dates - **Meter usage**: Detailed breakdown of usage
    /// for each meter configured on the subscription - **Usage calculations**: Total
    /// units consumed, free threshold units, and chargeable units - **Historical
    /// tracking**: Complete audit trail of usage-based charges
    ///
    /// ## Use Cases: - **Customer support**: Investigate billing questions and usage
    /// discrepancies - **Usage analytics**: Analyze customer consumption patterns
    /// over time - **Billing transparency**: Provide customers with detailed usage
    /// breakdowns - **Revenue optimization**: Identify usage trends to optimize pricing strategies
    ///
    /// ## Filtering Options: - **Date range filtering**: Get usage history for specific
    /// time periods - **Meter-specific filtering**: Focus on usage for a particular
    /// meter - **Pagination**: Navigate through large usage histories efficiently
    ///
    /// ## Important Notes: - Only returns data for subscriptions with usage-based
    /// (metered) components - Usage history is organized by billing periods (subscription
    /// cycles) - Free threshold units are calculated and displayed separately from
    /// chargeable units - Historical data is preserved even if meter configurations change
    ///
    /// ## Example Query Patterns: - Get last 3 months: `?start_date=2024-01-01T00:00:00Z&end_date=2024-03-31T23:59:59Z`
    /// - Filter by meter: `?meter_id=mtr_api_requests` - Paginate results: `?page_size=20&page_number=1`
    /// - Recent usage: `?start_date=2024-03-01T00:00:00Z` (from March 1st to now)
    /// </summary>
    Task<SubscriptionRetrieveUsageHistoryPageResponse> RetrieveUsageHistory(
        SubscriptionRetrieveUsageHistoryParams parameters
    );
}
