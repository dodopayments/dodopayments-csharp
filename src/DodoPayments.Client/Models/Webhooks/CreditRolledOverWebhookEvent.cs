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
    typeof(JsonModelConverter<CreditRolledOverWebhookEvent, CreditRolledOverWebhookEventFromRaw>)
)]
public sealed record class CreditRolledOverWebhookEvent : JsonModel
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
    public required ApiEnum<string, CreditRolledOverWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreditRolledOverWebhookEventType>>(
                "type"
            );
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

    public CreditRolledOverWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditRolledOverWebhookEvent(CreditRolledOverWebhookEvent creditRolledOverWebhookEvent)
        : base(creditRolledOverWebhookEvent) { }
#pragma warning restore CS8618

    public CreditRolledOverWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditRolledOverWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditRolledOverWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditRolledOverWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditRolledOverWebhookEventFromRaw : IFromRawJson<CreditRolledOverWebhookEvent>
{
    /// <inheritdoc/>
    public CreditRolledOverWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditRolledOverWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(CreditRolledOverWebhookEventTypeConverter))]
public enum CreditRolledOverWebhookEventType
{
    CreditRolledOver,
}

sealed class CreditRolledOverWebhookEventTypeConverter
    : JsonConverter<CreditRolledOverWebhookEventType>
{
    public override CreditRolledOverWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit.rolled_over" => CreditRolledOverWebhookEventType.CreditRolledOver,
            _ => (CreditRolledOverWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditRolledOverWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditRolledOverWebhookEventType.CreditRolledOver => "credit.rolled_over",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
