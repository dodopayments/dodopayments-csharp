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
    typeof(ModelConverter<DisputeChallengedWebhookEvent, DisputeChallengedWebhookEventFromRaw>)
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
    public required DisputeChallengedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<DisputeChallengedWebhookEventData>(
                this.RawData,
                "data"
            );
        }
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
    public required ApiEnum<string, DisputeChallengedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DisputeChallengedWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
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

    /// <inheritdoc cref="DisputeChallengedWebhookEventFromRaw.FromRawUnchecked"/>
    public static DisputeChallengedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeChallengedWebhookEventFromRaw : IFromRaw<DisputeChallengedWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeChallengedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeChallengedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        DisputeChallengedWebhookEventData,
        DisputeChallengedWebhookEventDataFromRaw
    >)
)]
public sealed record class DisputeChallengedWebhookEventData : ModelBase
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
    public ApiEnum<
        string,
        DisputeChallengedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DisputeChallengedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
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

    public static implicit operator Dispute(
        DisputeChallengedWebhookEventData disputeChallengedWebhookEventData
    ) =>
        new()
        {
            Amount = disputeChallengedWebhookEventData.Amount,
            BusinessID = disputeChallengedWebhookEventData.BusinessID,
            CreatedAt = disputeChallengedWebhookEventData.CreatedAt,
            Currency = disputeChallengedWebhookEventData.Currency,
            DisputeID = disputeChallengedWebhookEventData.DisputeID,
            DisputeStage = disputeChallengedWebhookEventData.DisputeStage,
            DisputeStatus = disputeChallengedWebhookEventData.DisputeStatus,
            PaymentID = disputeChallengedWebhookEventData.PaymentID,
            Remarks = disputeChallengedWebhookEventData.Remarks,
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

    public DisputeChallengedWebhookEventData() { }

    public DisputeChallengedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeChallengedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeChallengedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static DisputeChallengedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeChallengedWebhookEventDataFromRaw : IFromRaw<DisputeChallengedWebhookEventData>
{
    /// <inheritdoc/>
    public DisputeChallengedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeChallengedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        DisputeChallengedWebhookEventDataIntersectionMember1,
        DisputeChallengedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class DisputeChallengedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        DisputeChallengedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DisputeChallengedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
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

    public DisputeChallengedWebhookEventDataIntersectionMember1() { }

    public DisputeChallengedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeChallengedWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeChallengedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DisputeChallengedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeChallengedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<DisputeChallengedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public DisputeChallengedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeChallengedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(DisputeChallengedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum DisputeChallengedWebhookEventDataIntersectionMember1PayloadType
{
    Dispute,
}

sealed class DisputeChallengedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<DisputeChallengedWebhookEventDataIntersectionMember1PayloadType>
{
    public override DisputeChallengedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
            _ => (DisputeChallengedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeChallengedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute =>
                    "Dispute",
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
[JsonConverter(typeof(DisputeChallengedWebhookEventTypeConverter))]
public enum DisputeChallengedWebhookEventType
{
    DisputeChallenged,
}

sealed class DisputeChallengedWebhookEventTypeConverter
    : JsonConverter<DisputeChallengedWebhookEventType>
{
    public override DisputeChallengedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.challenged" => DisputeChallengedWebhookEventType.DisputeChallenged,
            _ => (DisputeChallengedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeChallengedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeChallengedWebhookEventType.DisputeChallenged => "dispute.challenged",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
