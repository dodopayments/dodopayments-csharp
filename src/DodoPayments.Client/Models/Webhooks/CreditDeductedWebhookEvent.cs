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
    typeof(JsonModelConverter<CreditDeductedWebhookEvent, CreditDeductedWebhookEventFromRaw>)
)]
public sealed record class CreditDeductedWebhookEvent : JsonModel
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
    public required ApiEnum<string, CreditDeductedWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreditDeductedWebhookEventType>>(
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

    public CreditDeductedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditDeductedWebhookEvent(CreditDeductedWebhookEvent creditDeductedWebhookEvent)
        : base(creditDeductedWebhookEvent) { }
#pragma warning restore CS8618

    public CreditDeductedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditDeductedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditDeductedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditDeductedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditDeductedWebhookEventFromRaw : IFromRawJson<CreditDeductedWebhookEvent>
{
    /// <inheritdoc/>
    public CreditDeductedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditDeductedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(CreditDeductedWebhookEventTypeConverter))]
public enum CreditDeductedWebhookEventType
{
    CreditDeducted,
}

sealed class CreditDeductedWebhookEventTypeConverter : JsonConverter<CreditDeductedWebhookEventType>
{
    public override CreditDeductedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit.deducted" => CreditDeductedWebhookEventType.CreditDeducted,
            _ => (CreditDeductedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditDeductedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditDeductedWebhookEventType.CreditDeducted => "credit.deducted",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
