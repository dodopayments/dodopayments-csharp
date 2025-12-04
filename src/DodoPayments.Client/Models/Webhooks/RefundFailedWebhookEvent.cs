using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Refunds;
using Payments = DodoPayments.Client.Models.Payments;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(ModelConverter<RefundFailedWebhookEvent, RefundFailedWebhookEventFromRaw>))]
public sealed record class RefundFailedWebhookEvent : ModelBase
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
    public required RefundFailedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<RefundFailedWebhookEventData>(this.RawData, "data");
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
    public required ApiEnum<string, RefundFailedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, RefundFailedWebhookEventType>>(
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

    public RefundFailedWebhookEvent() { }

    public RefundFailedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundFailedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static RefundFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundFailedWebhookEventFromRaw : IFromRaw<RefundFailedWebhookEvent>
{
    /// <inheritdoc/>
    public RefundFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundFailedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<RefundFailedWebhookEventData, RefundFailedWebhookEventDataFromRaw>)
)]
public sealed record class RefundFailedWebhookEventData : ModelBase
{
    /// <summary>
    /// The unique identifier of the business issuing the refund.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp of when the refund was created in UTC.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            return ModelBase.GetNotNullClass<Payments::CustomerLimitedDetails>(
                this.RawData,
                "customer"
            );
        }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "is_partial"); }
        init { ModelBase.Set(this._rawData, "is_partial", value); }
    }

    /// <summary>
    /// Additional metadata stored with the refund.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the refund.
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "refund_id"); }
        init { ModelBase.Set(this._rawData, "refund_id", value); }
    }

    public required ApiEnum<string, RefundStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, RefundStatus>>(this.RawData, "status");
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "currency", value);
        }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>
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

    public static implicit operator Refund(
        RefundFailedWebhookEventData refundFailedWebhookEventData
    ) =>
        new()
        {
            BusinessID = refundFailedWebhookEventData.BusinessID,
            CreatedAt = refundFailedWebhookEventData.CreatedAt,
            Customer = refundFailedWebhookEventData.Customer,
            IsPartial = refundFailedWebhookEventData.IsPartial,
            Metadata = refundFailedWebhookEventData.Metadata,
            PaymentID = refundFailedWebhookEventData.PaymentID,
            RefundID = refundFailedWebhookEventData.RefundID,
            Status = refundFailedWebhookEventData.Status,
            Amount = refundFailedWebhookEventData.Amount,
            Currency = refundFailedWebhookEventData.Currency,
            Reason = refundFailedWebhookEventData.Reason,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Customer.Validate();
        _ = this.IsPartial;
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.RefundID;
        this.Status.Validate();
        _ = this.Amount;
        this.Currency?.Validate();
        _ = this.Reason;
        this.PayloadType?.Validate();
    }

    public RefundFailedWebhookEventData() { }

    public RefundFailedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundFailedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundFailedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static RefundFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundFailedWebhookEventDataFromRaw : IFromRaw<RefundFailedWebhookEventData>
{
    /// <inheritdoc/>
    public RefundFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundFailedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        RefundFailedWebhookEventDataIntersectionMember1,
        RefundFailedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class RefundFailedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>
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

    public RefundFailedWebhookEventDataIntersectionMember1() { }

    public RefundFailedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundFailedWebhookEventDataIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundFailedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static RefundFailedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundFailedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<RefundFailedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public RefundFailedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundFailedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(RefundFailedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum RefundFailedWebhookEventDataIntersectionMember1PayloadType
{
    Refund,
}

sealed class RefundFailedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<RefundFailedWebhookEventDataIntersectionMember1PayloadType>
{
    public override RefundFailedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Refund" => RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
            _ => (RefundFailedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundFailedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund => "Refund",
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
[JsonConverter(typeof(RefundFailedWebhookEventTypeConverter))]
public enum RefundFailedWebhookEventType
{
    RefundFailed,
}

sealed class RefundFailedWebhookEventTypeConverter : JsonConverter<RefundFailedWebhookEventType>
{
    public override RefundFailedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund.failed" => RefundFailedWebhookEventType.RefundFailed,
            _ => (RefundFailedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundFailedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundFailedWebhookEventType.RefundFailed => "refund.failed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
