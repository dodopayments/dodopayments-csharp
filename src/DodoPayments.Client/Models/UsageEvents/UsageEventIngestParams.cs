using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents;

/// <summary>
/// This endpoint allows you to ingest custom events that can be used for: - Usage-based
/// billing and metering - Analytics and reporting - Customer behavior tracking
///
/// <para>## Important Notes: - **Duplicate Prevention**:   - Duplicate `event_id`
/// values within the same request are rejected (entire request fails)   - Subsequent
/// requests with existing `event_id` values are ignored (idempotent behavior) - **Rate
/// Limiting**: Maximum 1000 events per request - **Time Validation**: Events with
/// timestamps older than 1 hour or more than 5 minutes in the future will be rejected
/// - **Metadata Limits**: Maximum 50 key-value pairs per event, keys max 100 chars,
/// values max 500 chars</para>
///
/// <para>## Example Usage: ```json {   "events": [     {       "event_id": "api_call_12345",
///       "customer_id": "cus_abc123",       "event_name": "api_request",       "timestamp":
/// "2024-01-15T10:30:00Z",       "metadata": {         "endpoint": "/api/v1/users",
///         "method": "GET",         "tokens_used": "150"       }     }   ] } ```</para>
/// </summary>
public sealed record class UsageEventIngestParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of events to be pushed
    /// </summary>
    public required IReadOnlyList<EventInput> Events
    {
        get { return this._rawBodyData.GetNotNullStruct<ImmutableArray<EventInput>>("events"); }
        init
        {
            this._rawBodyData.Set<ImmutableArray<EventInput>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public UsageEventIngestParams() { }

    public UsageEventIngestParams(UsageEventIngestParams usageEventIngestParams)
        : base(usageEventIngestParams)
    {
        this._rawBodyData = new(usageEventIngestParams._rawBodyData);
    }

    public UsageEventIngestParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventIngestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static UsageEventIngestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events/ingest")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
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
