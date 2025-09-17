using System.Net.Http;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.UsageEvents;

/// <summary>
/// Fetch detailed information about a single event using its unique event ID. This
/// endpoint is useful for: - Debugging specific event ingestion issues - Retrieving
/// event details for customer support - Validating that events were processed correctly
/// - Getting the complete metadata for an event
///
/// ## Event ID Format: The event ID should be the same value that was provided during
/// event ingestion via the `/events/ingest` endpoint. Event IDs are case-sensitive
/// and must match exactly.
///
/// ## Response Details: The response includes all event data including: - Complete
/// metadata key-value pairs - Original timestamp (preserved from ingestion) - Customer
/// and business association - Event name and processing information
///
/// ## Example Usage: ```text GET /events/api_call_12345 ```
/// </summary>
public sealed record class UsageEventRetrieveParams : Client::ParamsBase
{
    public required string EventID;

    public override System::Uri Url(Client::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/events/{0}", this.EventID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, Client::IDodoPaymentsClient client)
    {
        Client::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Client::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
