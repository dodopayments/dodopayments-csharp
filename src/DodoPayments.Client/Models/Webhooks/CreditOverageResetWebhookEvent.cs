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
        CreditOverageResetWebhookEvent,
        CreditOverageResetWebhookEventFromRaw
    >)
)]
public sealed record class CreditOverageResetWebhookEvent : JsonModel
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
    public required ApiEnum<string, CreditOverageResetWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditOverageResetWebhookEventType>
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

    public CreditOverageResetWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditOverageResetWebhookEvent(
        CreditOverageResetWebhookEvent creditOverageResetWebhookEvent
    )
        : base(creditOverageResetWebhookEvent) { }
#pragma warning restore CS8618

    public CreditOverageResetWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditOverageResetWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditOverageResetWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditOverageResetWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditOverageResetWebhookEventFromRaw : IFromRawJson<CreditOverageResetWebhookEvent>
{
    /// <inheritdoc/>
    public CreditOverageResetWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditOverageResetWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(CreditOverageResetWebhookEventTypeConverter))]
public enum CreditOverageResetWebhookEventType
{
    CreditOverageReset,
}

sealed class CreditOverageResetWebhookEventTypeConverter
    : JsonConverter<CreditOverageResetWebhookEventType>
{
    public override CreditOverageResetWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit.overage_reset" => CreditOverageResetWebhookEventType.CreditOverageReset,
            _ => (CreditOverageResetWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditOverageResetWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditOverageResetWebhookEventType.CreditOverageReset => "credit.overage_reset",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
