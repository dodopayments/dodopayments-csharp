using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(ModelConverter<DisputeChallengedWebhookEvent, DisputeChallengedWebhookEventFromRaw1>)
)]
public sealed record class DisputeChallengedWebhookEvent : ModelBase
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required Data1 Data
    {
        get { return ModelBase.GetNotNullClass<Data1>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, Type1> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Type1>>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public DisputeChallengedWebhookEvent() { }

    public DisputeChallengedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeChallengedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeChallengedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static DisputeChallengedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeChallengedWebhookEventFromRaw1 : IFromRaw<DisputeChallengedWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeChallengedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeChallengedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(ModelConverter<Data1, Data1FromRaw>))]
public sealed record class Data1 : ModelBase
{
    /// <summary>
    /// The amount involved in the dispute, represented as a string to accommodate precision.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The unique identifier of the business involved in the dispute.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp of when the dispute was created, in UTC.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The currency of the disputed amount, represented as an ISO 4217 currency code.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The unique identifier of the dispute.
    /// </summary>
    public required string DisputeID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "dispute_id"); }
        init { ModelBase.Set(this._rawData, "dispute_id", value); }
    }

    public required ApiEnum<string, DisputeDisputeStage> DisputeStage
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DisputeDisputeStage>>(
                this.RawData,
                "dispute_stage"
            );
        }
        init { ModelBase.Set(this._rawData, "dispute_stage", value); }
    }

    public required ApiEnum<string, DisputeDisputeStatus> DisputeStatus
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DisputeDisputeStatus>>(
                this.RawData,
                "dispute_status"
            );
        }
        init { ModelBase.Set(this._rawData, "dispute_status", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the dispute.
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// Remarks
    /// </summary>
    public string? Remarks
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "remarks"); }
        init { ModelBase.Set(this._rawData, "remarks", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, Data1IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Data1IntersectionMember1PayloadType>>(
                this.RawData,
                "payload_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator Dispute(Data1 data1) =>
        new()
        {
            Amount = data1.Amount,
            BusinessID = data1.BusinessID,
            CreatedAt = data1.CreatedAt,
            Currency = data1.Currency,
            DisputeID = data1.DisputeID,
            DisputeStage = data1.DisputeStage,
            DisputeStatus = data1.DisputeStatus,
            PaymentID = data1.PaymentID,
            Remarks = data1.Remarks,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DisputeID;
        this.DisputeStage.Validate();
        this.DisputeStatus.Validate();
        _ = this.PaymentID;
        _ = this.Remarks;
        this.PayloadType?.Validate();
    }

    public Data1() { }

    public Data1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Data1FromRaw.FromRawUnchecked"/>
    public static Data1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data1FromRaw : IFromRaw<Data1>
{
    /// <inheritdoc/>
    public Data1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Data1IntersectionMember1, Data1IntersectionMember1FromRaw>))]
public sealed record class Data1IntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, Data1IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Data1IntersectionMember1PayloadType>>(
                this.RawData,
                "payload_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public Data1IntersectionMember1() { }

    public Data1IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data1IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Data1IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static Data1IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data1IntersectionMember1FromRaw : IFromRaw<Data1IntersectionMember1>
{
    /// <inheritdoc/>
    public Data1IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => Data1IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(Data1IntersectionMember1PayloadTypeConverter))]
public enum Data1IntersectionMember1PayloadType
{
    Dispute,
}

sealed class Data1IntersectionMember1PayloadTypeConverter
    : JsonConverter<Data1IntersectionMember1PayloadType>
{
    public override Data1IntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => Data1IntersectionMember1PayloadType.Dispute,
            _ => (Data1IntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Data1IntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Data1IntersectionMember1PayloadType.Dispute => "Dispute",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(Type1Converter))]
public enum Type1
{
    DisputeChallenged,
}

sealed class Type1Converter : JsonConverter<Type1>
{
    public override Type1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.challenged" => Type1.DisputeChallenged,
            _ => (Type1)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type1.DisputeChallenged => "dispute.challenged",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
