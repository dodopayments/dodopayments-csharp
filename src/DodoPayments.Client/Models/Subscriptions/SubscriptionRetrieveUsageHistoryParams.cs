using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Get detailed usage history for a subscription that includes usage-based billing
/// (metered components). This endpoint provides insights into customer usage patterns
/// and billing calculations over time.
///
/// <para>## What You'll Get: - **Billing periods**: Each item represents a billing
/// cycle with start and end dates - **Meter usage**: Detailed breakdown of usage
/// for each meter configured on the subscription - **Usage calculations**: Total
/// units consumed, free threshold units, and chargeable units - **Historical tracking**:
/// Complete audit trail of usage-based charges</para>
///
/// <para>## Use Cases: - **Customer support**: Investigate billing questions and
/// usage discrepancies - **Usage analytics**: Analyze customer consumption patterns
/// over time - **Billing transparency**: Provide customers with detailed usage breakdowns
/// - **Revenue optimization**: Identify usage trends to optimize pricing strategies</para>
///
/// <para>## Filtering Options: - **Date range filtering**: Get usage history for
/// specific time periods - **Meter-specific filtering**: Focus on usage for a particular
/// meter - **Pagination**: Navigate through large usage histories efficiently</para>
///
/// <para>## Important Notes: - Only returns data for subscriptions with usage-based
/// (metered) components - Usage history is organized by billing periods (subscription
/// cycles) - Free threshold units are calculated and displayed separately from chargeable
/// units - Historical data is preserved even if meter configurations change</para>
///
/// <para>## Example Query Patterns: - Get last 3 months: `?start_date=2024-01-01T00:00:00Z&end_date=2024-03-31T23:59:59Z`
/// - Filter by meter: `?meter_id=mtr_api_requests` - Paginate results: `?page_size=20&page_number=1`
/// - Recent usage: `?start_date=2024-03-01T00:00:00Z` (from March 1st to now)</para>
/// </summary>
public sealed record class SubscriptionRetrieveUsageHistoryParams : ParamsBase
{
    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Filter by end date (inclusive)
    /// </summary>
    public DateTimeOffset? EndDate
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("end_date"); }
        init { this._rawQueryData.Set("end_date", value); }
    }

    /// <summary>
    /// Filter by specific meter ID
    /// </summary>
    public string? MeterID
    {
        get { return this._rawQueryData.GetNullableClass<string>("meter_id"); }
        init { this._rawQueryData.Set("meter_id", value); }
    }

    /// <summary>
    /// Page number (default: 0)
    /// </summary>
    public int? PageNumber
    {
        get { return this._rawQueryData.GetNullableStruct<int>("page_number"); }
        init { this._rawQueryData.Set("page_number", value); }
    }

    /// <summary>
    /// Page size (default: 10, max: 100)
    /// </summary>
    public int? PageSize
    {
        get { return this._rawQueryData.GetNullableStruct<int>("page_size"); }
        init { this._rawQueryData.Set("page_size", value); }
    }

    /// <summary>
    /// Filter by start date (inclusive)
    /// </summary>
    public DateTimeOffset? StartDate
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("start_date"); }
        init { this._rawQueryData.Set("start_date", value); }
    }

    public SubscriptionRetrieveUsageHistoryParams() { }

    public SubscriptionRetrieveUsageHistoryParams(
        SubscriptionRetrieveUsageHistoryParams subscriptionRetrieveUsageHistoryParams
    )
        : base(subscriptionRetrieveUsageHistoryParams)
    {
        this.SubscriptionID = subscriptionRetrieveUsageHistoryParams.SubscriptionID;
    }

    public SubscriptionRetrieveUsageHistoryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionRetrieveUsageHistoryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/usage-history", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
