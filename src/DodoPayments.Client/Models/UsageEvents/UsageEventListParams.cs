using System;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents;

/// <summary>
/// Fetch events from your account with powerful filtering capabilities. This endpoint
/// is ideal for: - Debugging event ingestion issues - Analyzing customer usage patterns
/// - Building custom analytics dashboards - Auditing billing-related events
///
/// ## Filtering Options: - **Customer filtering**: Filter by specific customer ID
/// - **Event name filtering**: Filter by event type/name - **Meter-based filtering**:
/// Use a meter ID to apply the meter's event name and filter criteria automatically
/// - **Time range filtering**: Filter events within a specific date range - **Pagination**:
/// Navigate through large result sets
///
/// ## Meter Integration: When using `meter_id`, the endpoint automatically applies:
/// - The meter's configured `event_name` filter - The meter's custom filter criteria
/// (if any) - If you also provide `event_name`, it must match the meter's event name
///
/// ## Example Queries: - Get all events for a customer: `?customer_id=cus_abc123`
/// - Get API request events: `?event_name=api_request` - Get events from last 24
/// hours: `?start=2024-01-14T10:30:00Z&end=2024-01-15T10:30:00Z` - Get events with
/// meter filtering: `?meter_id=mtr_xyz789` - Paginate results: `?page_size=50&page_number=2`
/// </summary>
public sealed record class UsageEventListParams : ParamsBase
{
    /// <summary>
    /// Filter events by customer ID
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter events created before this timestamp
    /// </summary>
    public DateTime? End
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter events by event name. If both event_name and meter_id are provided,
    /// they must match the meter's configured event_name
    /// </summary>
    public string? EventName
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("event_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["event_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter events by meter ID. When provided, only events that match the meter's
    /// event_name and filter criteria will be returned
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
    /// Page number (0-based, default: 0)
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
    /// Number of events to return per page (default: 10)
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
    /// Filter events created after this timestamp
    /// </summary>
    public DateTime? Start
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events")
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
