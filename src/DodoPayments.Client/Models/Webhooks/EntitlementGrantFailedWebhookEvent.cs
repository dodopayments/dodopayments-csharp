using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Grants;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementGrantFailedWebhookEvent,
        EntitlementGrantFailedWebhookEventFromRaw
    >)
)]
public sealed record class EntitlementGrantFailedWebhookEvent : JsonModel
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
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, EntitlementGrantFailedWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementGrantFailedWebhookEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public EntitlementGrantFailedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementGrantFailedWebhookEvent(
        EntitlementGrantFailedWebhookEvent entitlementGrantFailedWebhookEvent
    )
        : base(entitlementGrantFailedWebhookEvent) { }
#pragma warning restore CS8618

    public EntitlementGrantFailedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementGrantFailedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementGrantFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static EntitlementGrantFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementGrantFailedWebhookEventFromRaw : IFromRawJson<EntitlementGrantFailedWebhookEvent>
{
    /// <inheritdoc/>
    public EntitlementGrantFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementGrantFailedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(EntitlementGrantFailedWebhookEventTypeConverter))]
public enum EntitlementGrantFailedWebhookEventType
{
    EntitlementGrantFailed,
}

sealed class EntitlementGrantFailedWebhookEventTypeConverter
    : JsonConverter<EntitlementGrantFailedWebhookEventType>
{
    public override EntitlementGrantFailedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entitlement_grant.failed" =>
                EntitlementGrantFailedWebhookEventType.EntitlementGrantFailed,
            _ => (EntitlementGrantFailedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementGrantFailedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementGrantFailedWebhookEventType.EntitlementGrantFailed =>
                    "entitlement_grant.failed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
