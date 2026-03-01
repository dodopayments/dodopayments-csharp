using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditManualAdjustmentWebhookEvent,
        CreditManualAdjustmentWebhookEventFromRaw
    >)
)]
public sealed record class CreditManualAdjustmentWebhookEvent : JsonModel
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
    /// Response for a ledger entry
    /// </summary>
    public required CreditLedgerEntry Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreditLedgerEntry>("data");
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
    public required ApiEnum<string, CreditManualAdjustmentWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditManualAdjustmentWebhookEventType>
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

    public CreditManualAdjustmentWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditManualAdjustmentWebhookEvent(
        CreditManualAdjustmentWebhookEvent creditManualAdjustmentWebhookEvent
    )
        : base(creditManualAdjustmentWebhookEvent) { }
#pragma warning restore CS8618

    public CreditManualAdjustmentWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditManualAdjustmentWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditManualAdjustmentWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditManualAdjustmentWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditManualAdjustmentWebhookEventFromRaw : IFromRawJson<CreditManualAdjustmentWebhookEvent>
{
    /// <inheritdoc/>
    public CreditManualAdjustmentWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditManualAdjustmentWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(CreditManualAdjustmentWebhookEventTypeConverter))]
public enum CreditManualAdjustmentWebhookEventType
{
    CreditManualAdjustment,
}

sealed class CreditManualAdjustmentWebhookEventTypeConverter
    : JsonConverter<CreditManualAdjustmentWebhookEventType>
{
    public override CreditManualAdjustmentWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit.manual_adjustment" =>
                CreditManualAdjustmentWebhookEventType.CreditManualAdjustment,
            _ => (CreditManualAdjustmentWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditManualAdjustmentWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditManualAdjustmentWebhookEventType.CreditManualAdjustment =>
                    "credit.manual_adjustment",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
