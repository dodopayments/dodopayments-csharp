using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Get detailed usage history for a subscription that includes usage-based billing
/// (metered components). This endpoint provides insights into customer usage patterns
/// and billing calculations over time.
///
/// ## What You'll Get: - **Billing periods**: Each item represents a billing cycle
/// with start and end dates - **Meter usage**: Detailed breakdown of usage for each
/// meter configured on the subscription - **Usage calculations**: Total units consumed,
/// free threshold units, and chargeable units - **Historical tracking**: Complete
/// audit trail of usage-based charges
///
/// ## Use Cases: - **Customer support**: Investigate billing questions and usage
/// discrepancies - **Usage analytics**: Analyze customer consumption patterns over
/// time - **Billing transparency**: Provide customers with detailed usage breakdowns
/// - **Revenue optimization**: Identify usage trends to optimize pricing strategies
///
/// ## Filtering Options: - **Date range filtering**: Get usage history for specific
/// time periods - **Meter-specific filtering**: Focus on usage for a particular
/// meter - **Pagination**: Navigate through large usage histories efficiently
///
/// ## Important Notes: - Only returns data for subscriptions with usage-based (metered)
/// components - Usage history is organized by billing periods (subscription cycles)
/// - Free threshold units are calculated and displayed separately from chargeable
/// units - Historical data is preserved even if meter configurations change
///
/// ## Example Query Patterns: - Get last 3 months: `?start_date=2024-01-01T00:00:00Z&end_date=2024-03-31T23:59:59Z`
/// - Filter by meter: `?meter_id=mtr_api_requests` - Paginate results: `?page_size=20&page_number=1`
/// - Recent usage: `?start_date=2024-03-01T00:00:00Z` (from March 1st to now)
/// </summary>
public sealed record class SubscriptionRetrieveUsageHistoryParams : ParamsBase
{
    public required string SubscriptionID;

    /// <summary>
    /// Filter by end date (inclusive)
    /// </summary>
    public DateTime? EndDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by specific meter ID
    /// </summary>
    public string? MeterID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("meter_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["meter_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Page number (default: 0)
    /// </summary>
    public int? PageNumber
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["page_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Page size (default: 10, max: 100)
    /// </summary>
    public int? PageSize
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("page_size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["page_size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by start date (inclusive)
    /// </summary>
    public DateTime? StartDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/usage-history", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDodoPaymentsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
