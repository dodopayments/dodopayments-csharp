using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantRevokedWebhookEvent,
        EntitlementGrantRevokedWebhookEventFromRaw
    >)
)]
public sealed record class EntitlementGrantRevokedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Detailed view of a single entitlement grant: who it's for, its lifecycle
    /// state, and any integration-specific delivery payload.
    /// </summary>
    public required EntitlementGrant Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementGrant>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("entitlement_grant.revoked")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public EntitlementGrantRevokedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("entitlement_grant.revoked");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantRevokedWebhookEvent(
        EntitlementGrantRevokedWebhookEvent entitlementGrantRevokedWebhookEvent
    )
        : base(entitlementGrantRevokedWebhookEvent) { }
#pragma warning restore CS8618

    public EntitlementGrantRevokedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("entitlement_grant.revoked");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantRevokedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantRevokedWebhookEventFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantRevokedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantRevokedWebhookEventFromRaw : IFromRawJson<EntitlementGrantRevokedWebhookEvent>
{
    /// <inheritdoc/>
    public EntitlementGrantRevokedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantRevokedWebhookEvent.FromRawUnchecked(rawData);
}
