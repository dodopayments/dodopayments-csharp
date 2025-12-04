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
    typeof(ModelConverter<DisputeAcceptedWebhookEvent, DisputeAcceptedWebhookEventFromRaw1>)
)]
public sealed record class DisputeAcceptedWebhookEvent : ModelBase
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
    public required DisputeAcceptedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<DisputeAcceptedWebhookEventData>(this.RawData, "data");
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
    public required ApiEnum<string, DisputeAcceptedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DisputeAcceptedWebhookEventType>>(
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

    public DisputeAcceptedWebhookEvent() { }

    public DisputeAcceptedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeAcceptedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeAcceptedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static DisputeAcceptedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeAcceptedWebhookEventFromRaw1 : IFromRaw<DisputeAcceptedWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeAcceptedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeAcceptedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<DisputeAcceptedWebhookEventData, DisputeAcceptedWebhookEventDataFromRaw>)
)]
public sealed record class DisputeAcceptedWebhookEventData : ModelBase
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
        DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType>
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
        DisputeAcceptedWebhookEventData disputeAcceptedWebhookEventData
    ) =>
        new()
        {
            Amount = disputeAcceptedWebhookEventData.Amount,
            BusinessID = disputeAcceptedWebhookEventData.BusinessID,
            CreatedAt = disputeAcceptedWebhookEventData.CreatedAt,
            Currency = disputeAcceptedWebhookEventData.Currency,
            DisputeID = disputeAcceptedWebhookEventData.DisputeID,
            DisputeStage = disputeAcceptedWebhookEventData.DisputeStage,
            DisputeStatus = disputeAcceptedWebhookEventData.DisputeStatus,
            PaymentID = disputeAcceptedWebhookEventData.PaymentID,
            Remarks = disputeAcceptedWebhookEventData.Remarks,
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

    public DisputeAcceptedWebhookEventData() { }

    public DisputeAcceptedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeAcceptedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeAcceptedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static DisputeAcceptedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeAcceptedWebhookEventDataFromRaw : IFromRaw<DisputeAcceptedWebhookEventData>
{
    /// <inheritdoc/>
    public DisputeAcceptedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeAcceptedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        DisputeAcceptedWebhookEventDataIntersectionMember1,
        DisputeAcceptedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class DisputeAcceptedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType>
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

    public DisputeAcceptedWebhookEventDataIntersectionMember1() { }

    public DisputeAcceptedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeAcceptedWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeAcceptedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DisputeAcceptedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeAcceptedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<DisputeAcceptedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public DisputeAcceptedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeAcceptedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(DisputeAcceptedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType
{
    Dispute,
}

sealed class DisputeAcceptedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType>
{
    public override DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType.Dispute,
            _ => (DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeAcceptedWebhookEventDataIntersectionMember1PayloadType.Dispute => "Dispute",
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
[JsonConverter(typeof(DisputeAcceptedWebhookEventTypeConverter))]
public enum DisputeAcceptedWebhookEventType
{
    DisputeAccepted,
}

sealed class DisputeAcceptedWebhookEventTypeConverter
    : JsonConverter<DisputeAcceptedWebhookEventType>
{
    public override DisputeAcceptedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.accepted" => DisputeAcceptedWebhookEventType.DisputeAccepted,
            _ => (DisputeAcceptedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeAcceptedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeAcceptedWebhookEventType.DisputeAccepted => "dispute.accepted",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
