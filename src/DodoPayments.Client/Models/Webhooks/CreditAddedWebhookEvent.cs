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

[JsonConverter(typeof(JsonModelConverter<CreditAddedWebhookEvent, CreditAddedWebhookEventFromRaw>))]
public sealed record class CreditAddedWebhookEvent : JsonModel
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
    public required ApiEnum<string, global::DodoPayments.Client.Models.Webhooks.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::DodoPayments.Client.Models.Webhooks.Type>
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

    public CreditAddedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditAddedWebhookEvent(CreditAddedWebhookEvent creditAddedWebhookEvent)
        : base(creditAddedWebhookEvent) { }
#pragma warning restore CS8618

    public CreditAddedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditAddedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditAddedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditAddedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditAddedWebhookEventFromRaw : IFromRawJson<CreditAddedWebhookEvent>
{
    /// <inheritdoc/>
    public CreditAddedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditAddedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CreditAdded,
}

sealed class TypeConverter : JsonConverter<global::DodoPayments.Client.Models.Webhooks.Type>
{
    public override global::DodoPayments.Client.Models.Webhooks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit.added" => global::DodoPayments.Client.Models.Webhooks.Type.CreditAdded,
            _ => (global::DodoPayments.Client.Models.Webhooks.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Webhooks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Webhooks.Type.CreditAdded => "credit.added",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
