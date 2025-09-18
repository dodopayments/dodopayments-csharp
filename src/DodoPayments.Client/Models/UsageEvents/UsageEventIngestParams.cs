using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DodoPayments.Client.Models.UsageEvents;

/// <summary>
/// This endpoint allows you to ingest custom events that can be used for: - Usage-based
/// billing and metering - Analytics and reporting - Customer behavior tracking
///
/// ## Important Notes: - **Duplicate Prevention**:   - Duplicate `event_id` values
/// within the same request are rejected (entire request fails)   - Subsequent requests
/// with existing `event_id` values are ignored (idempotent behavior) - **Rate Limiting**:
/// Maximum 1000 events per request - **Time Validation**: Events with timestamps
/// older than 1 hour or more than 5 minutes in the future will be rejected - **Metadata
/// Limits**: Maximum 50 key-value pairs per event, keys max 100 chars, values max
/// 500 chars
///
/// ## Example Usage: ```json {   "events": [     {       "event_id": "api_call_12345",
///       "customer_id": "cus_abc123",       "event_name": "api_request",       "timestamp":
/// "2024-01-15T10:30:00Z",       "metadata": {         "endpoint": "/api/v1/users",
///         "method": "GET",         "tokens_used": "150"       }     }   ] } ```
/// </summary>
public sealed record class UsageEventIngestParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// List of events to be pushed
    /// </summary>
    public required List<EventInput> Events
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("events", out JsonElement element))
                throw new ArgumentOutOfRangeException("events", "Missing required argument");

            return JsonSerializer.Deserialize<List<EventInput>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("events");
        }
        set
        {
            this.BodyProperties["events"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/events/ingest")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IDodoPaymentsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
