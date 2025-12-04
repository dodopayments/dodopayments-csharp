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

[JsonConverter(typeof(ModelConverter<DisputeOpenedWebhookEvent, DisputeOpenedWebhookEventFromRaw>))]
public sealed record class DisputeOpenedWebhookEvent : ModelBase
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
    public required DisputeOpenedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<DisputeOpenedWebhookEventData>(this.RawData, "data");
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
    public required ApiEnum<string, DisputeOpenedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DisputeOpenedWebhookEventType>>(
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

    public DisputeOpenedWebhookEvent() { }

    public DisputeOpenedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeOpenedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeOpenedWebhookEventFromRaw.FromRawUnchecked"/>
    public static DisputeOpenedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeOpenedWebhookEventFromRaw : IFromRaw<DisputeOpenedWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeOpenedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeOpenedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<DisputeOpenedWebhookEventData, DisputeOpenedWebhookEventDataFromRaw>)
)]
public sealed record class DisputeOpenedWebhookEventData : ModelBase
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
    public ApiEnum<string, DisputeOpenedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DisputeOpenedWebhookEventDataIntersectionMember1PayloadType>
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
        DisputeOpenedWebhookEventData disputeOpenedWebhookEventData
    ) =>
        new()
        {
            Amount = disputeOpenedWebhookEventData.Amount,
            BusinessID = disputeOpenedWebhookEventData.BusinessID,
            CreatedAt = disputeOpenedWebhookEventData.CreatedAt,
            Currency = disputeOpenedWebhookEventData.Currency,
            DisputeID = disputeOpenedWebhookEventData.DisputeID,
            DisputeStage = disputeOpenedWebhookEventData.DisputeStage,
            DisputeStatus = disputeOpenedWebhookEventData.DisputeStatus,
            PaymentID = disputeOpenedWebhookEventData.PaymentID,
            Remarks = disputeOpenedWebhookEventData.Remarks,
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

    public DisputeOpenedWebhookEventData() { }

    public DisputeOpenedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeOpenedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeOpenedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static DisputeOpenedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeOpenedWebhookEventDataFromRaw : IFromRaw<DisputeOpenedWebhookEventData>
{
    /// <inheritdoc/>
    public DisputeOpenedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeOpenedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        DisputeOpenedWebhookEventDataIntersectionMember1,
        DisputeOpenedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class DisputeOpenedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, DisputeOpenedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DisputeOpenedWebhookEventDataIntersectionMember1PayloadType>
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

    public DisputeOpenedWebhookEventDataIntersectionMember1() { }

    public DisputeOpenedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeOpenedWebhookEventDataIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeOpenedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DisputeOpenedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeOpenedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<DisputeOpenedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public DisputeOpenedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeOpenedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(DisputeOpenedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum DisputeOpenedWebhookEventDataIntersectionMember1PayloadType
{
    Dispute,
}

sealed class DisputeOpenedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<DisputeOpenedWebhookEventDataIntersectionMember1PayloadType>
{
    public override DisputeOpenedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => DisputeOpenedWebhookEventDataIntersectionMember1PayloadType.Dispute,
            _ => (DisputeOpenedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeOpenedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeOpenedWebhookEventDataIntersectionMember1PayloadType.Dispute => "Dispute",
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
[JsonConverter(typeof(DisputeOpenedWebhookEventTypeConverter))]
public enum DisputeOpenedWebhookEventType
{
    DisputeOpened,
}

sealed class DisputeOpenedWebhookEventTypeConverter : JsonConverter<DisputeOpenedWebhookEventType>
{
    public override DisputeOpenedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.opened" => DisputeOpenedWebhookEventType.DisputeOpened,
            _ => (DisputeOpenedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeOpenedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeOpenedWebhookEventType.DisputeOpened => "dispute.opened",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
