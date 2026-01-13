using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents;

/// <summary>
/// Fetch events from your account with powerful filtering capabilities. This endpoint
/// is ideal for: - Debugging event ingestion issues - Analyzing customer usage patterns
/// - Building custom analytics dashboards - Auditing billing-related events
///
/// <para>## Filtering Options: - **Customer filtering**: Filter by specific customer
/// ID - **Event name filtering**: Filter by event type/name - **Meter-based filtering**:
/// Use a meter ID to apply the meter's event name and filter criteria automatically
/// - **Time range filtering**: Filter events within a specific date range - **Pagination**:
/// Navigate through large result sets</para>
///
/// <para>## Meter Integration: When using `meter_id`, the endpoint automatically
/// applies: - The meter's configured `event_name` filter - The meter's custom filter
/// criteria (if any) - If you also provide `event_name`, it must match the meter's
/// event name</para>
///
/// <para>## Example Queries: - Get all events for a customer: `?customer_id=cus_abc123`
/// - Get API request events: `?event_name=api_request` - Get events from last 24
/// hours: `?start=2024-01-14T10:30:00Z&end=2024-01-15T10:30:00Z` - Get events with
/// meter filtering: `?meter_id=mtr_xyz789` - Paginate results: `?page_size=50&page_number=2`</para>
/// </summary>
public sealed record class UsageEventListParams : ParamsBase
{
    /// <summary>
    /// Filter events by customer ID
    /// </summary>
    public string? CustomerID
    {
        get { return this._rawQueryData.GetNullableClass<string>("customer_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("customer_id", value);
        }
    }

    /// <summary>
    /// Filter events created before this timestamp
    /// </summary>
    public DateTimeOffset? End
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("end"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("end", value);
        }
    }

    /// <summary>
    /// Filter events by event name. If both event_name and meter_id are provided,
    /// they must match the meter's configured event_name
    /// </summary>
    public string? EventName
    {
        get { return this._rawQueryData.GetNullableClass<string>("event_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("event_name", value);
        }
    }

    /// <summary>
    /// Filter events by meter ID. When provided, only events that match the meter's
    /// event_name and filter criteria will be returned
    /// </summary>
    public string? MeterID
    {
        get { return this._rawQueryData.GetNullableClass<string>("meter_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("meter_id", value);
        }
    }

    /// <summary>
    /// Page number (0-based, default: 0)
    /// </summary>
    public int? PageNumber
    {
        get { return this._rawQueryData.GetNullableStruct<int>("page_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_number", value);
        }
    }

    /// <summary>
    /// Number of events to return per page (default: 10)
    /// </summary>
    public int? PageSize
    {
        get { return this._rawQueryData.GetNullableStruct<int>("page_size"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Filter events created after this timestamp
    /// </summary>
    public DateTimeOffset? Start
    {
        get { return this._rawQueryData.GetNullableStruct<DateTimeOffset>("start"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("start", value);
        }
    }

    public UsageEventListParams() { }

    public UsageEventListParams(UsageEventListParams usageEventListParams)
        : base(usageEventListParams) { }

    public UsageEventListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static UsageEventListParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events")
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
