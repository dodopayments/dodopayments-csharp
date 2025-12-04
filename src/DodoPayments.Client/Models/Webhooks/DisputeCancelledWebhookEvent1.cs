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
    typeof(ModelConverter<DisputeCancelledWebhookEvent, DisputeCancelledWebhookEventFromRaw1>)
)]
public sealed record class DisputeCancelledWebhookEvent : ModelBase
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
    public required DataModel Data
    {
        get { return ModelBase.GetNotNullClass<DataModel>(this.RawData, "data"); }
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
    public required ApiEnum<string, TypeModel> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, TypeModel>>(this.RawData, "type"); }
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

    public DisputeCancelledWebhookEvent() { }

    public DisputeCancelledWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeCancelledWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeCancelledWebhookEventFromRaw1.FromRawUnchecked"/>
    public static DisputeCancelledWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeCancelledWebhookEventFromRaw1 : IFromRaw<DisputeCancelledWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeCancelledWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeCancelledWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(ModelConverter<DataModel, DataModelFromRaw>))]
public sealed record class DataModel : ModelBase
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
    public ApiEnum<string, DataModelIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DataModelIntersectionMember1PayloadType>
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

    public static implicit operator Dispute(DataModel dataModel) =>
        new()
        {
            Amount = dataModel.Amount,
            BusinessID = dataModel.BusinessID,
            CreatedAt = dataModel.CreatedAt,
            Currency = dataModel.Currency,
            DisputeID = dataModel.DisputeID,
            DisputeStage = dataModel.DisputeStage,
            DisputeStatus = dataModel.DisputeStatus,
            PaymentID = dataModel.PaymentID,
            Remarks = dataModel.Remarks,
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

    public DataModel() { }

    public DataModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataModelFromRaw.FromRawUnchecked"/>
    public static DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataModelFromRaw : IFromRaw<DataModel>
{
    /// <inheritdoc/>
    public DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataModel.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<DataModelIntersectionMember1, DataModelIntersectionMember1FromRaw>)
)]
public sealed record class DataModelIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, DataModelIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, DataModelIntersectionMember1PayloadType>
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

    public DataModelIntersectionMember1() { }

    public DataModelIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModelIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataModelIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DataModelIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataModelIntersectionMember1FromRaw : IFromRaw<DataModelIntersectionMember1>
{
    /// <inheritdoc/>
    public DataModelIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataModelIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(DataModelIntersectionMember1PayloadTypeConverter))]
public enum DataModelIntersectionMember1PayloadType
{
    Dispute,
}

sealed class DataModelIntersectionMember1PayloadTypeConverter
    : JsonConverter<DataModelIntersectionMember1PayloadType>
{
    public override DataModelIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Dispute" => DataModelIntersectionMember1PayloadType.Dispute,
            _ => (DataModelIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataModelIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataModelIntersectionMember1PayloadType.Dispute => "Dispute",
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
[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    DisputeCancelled,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.cancelled" => TypeModel.DisputeCancelled,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TypeModel.DisputeCancelled => "dispute.cancelled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
