using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.UsageEvents;

/// <summary>
/// Fetch detailed information about a single event using its unique event ID. This
/// endpoint is useful for: - Debugging specific event ingestion issues - Retrieving
/// event details for customer support - Validating that events were processed correctly
/// - Getting the complete metadata for an event
///
/// <para>## Event ID Format: The event ID should be the same value that was provided
/// during event ingestion via the `/events/ingest` endpoint. Event IDs are case-sensitive
/// and must match exactly.</para>
///
/// <para>## Response Details: The response includes all event data including: - Complete
/// metadata key-value pairs - Original timestamp (preserved from ingestion) - Customer
/// and business association - Event name and processing information</para>
///
/// <para>## Example Usage: ```text GET /events/api_call_12345 ```</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageEventRetrieveParams : ParamsBase
{
    public string? EventID { get; init; }

    public UsageEventRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageEventRetrieveParams(UsageEventRetrieveParams usageEventRetrieveParams)
        : base(usageEventRetrieveParams)
    {
        this.EventID = usageEventRetrieveParams.EventID;
    }
#pragma warning restore CS8618

    public UsageEventRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static UsageEventRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["EventID"] = this.EventID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UsageEventRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EventID?.Equals(other.EventID) ?? other.EventID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/events/{0}", this.EventID)
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

    public override int GetHashCode()
    {
        return 0;
    }
}
