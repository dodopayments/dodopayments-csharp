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

[JsonConverter(
    typeof(JsonModelConverter<RefundSucceededWebhookEvent, RefundSucceededWebhookEventFromRaw>)
)]
public sealed record class RefundSucceededWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required RefundSucceededWebhookEventData Data
    {
        get
        {
            return JsonModel.GetNotNullClass<RefundSucceededWebhookEventData>(this.RawData, "data");
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, RefundSucceededWebhookEventType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, RefundSucceededWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public RefundSucceededWebhookEvent() { }

    public RefundSucceededWebhookEvent(RefundSucceededWebhookEvent refundSucceededWebhookEvent)
        : base(refundSucceededWebhookEvent) { }

    public RefundSucceededWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundSucceededWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundSucceededWebhookEventFromRaw.FromRawUnchecked"/>
    public static RefundSucceededWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundSucceededWebhookEventFromRaw : IFromRawJson<RefundSucceededWebhookEvent>
{
    /// <inheritdoc/>
    public RefundSucceededWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundSucceededWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RefundSucceededWebhookEventData,
        RefundSucceededWebhookEventDataFromRaw
    >)
)]
public sealed record class RefundSucceededWebhookEventData : JsonModel
{
    /// <summary>
    /// The unique identifier of the business issuing the refund.
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp of when the refund was created in UTC.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            return JsonModel.GetNotNullClass<Payments::CustomerLimitedDetails>(
                this.RawData,
                "customer"
            );
        }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_partial"); }
        init { JsonModel.Set(this._rawData, "is_partial", value); }
    }

    /// <summary>
    /// Additional metadata stored with the refund.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the refund.
    /// </summary>
    public required string PaymentID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { JsonModel.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "refund_id"); }
        init { JsonModel.Set(this._rawData, "refund_id", value); }
    }

    public required ApiEnum<string, RefundStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, RefundStatus>>(this.RawData, "status");
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "currency", value);
        }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reason"); }
        init { JsonModel.Set(this._rawData, "reason", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        RefundSucceededWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, RefundSucceededWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator Refund(
        RefundSucceededWebhookEventData refundSucceededWebhookEventData
    ) =>
        new()
        {
            BusinessID = refundSucceededWebhookEventData.BusinessID,
            CreatedAt = refundSucceededWebhookEventData.CreatedAt,
            Customer = refundSucceededWebhookEventData.Customer,
            IsPartial = refundSucceededWebhookEventData.IsPartial,
            Metadata = refundSucceededWebhookEventData.Metadata,
            PaymentID = refundSucceededWebhookEventData.PaymentID,
            RefundID = refundSucceededWebhookEventData.RefundID,
            Status = refundSucceededWebhookEventData.Status,
            Amount = refundSucceededWebhookEventData.Amount,
            Currency = refundSucceededWebhookEventData.Currency,
            Reason = refundSucceededWebhookEventData.Reason,
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

    public RefundSucceededWebhookEventData() { }

    public RefundSucceededWebhookEventData(
        RefundSucceededWebhookEventData refundSucceededWebhookEventData
    )
        : base(refundSucceededWebhookEventData) { }

    public RefundSucceededWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundSucceededWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundSucceededWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static RefundSucceededWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundSucceededWebhookEventDataFromRaw : IFromRawJson<RefundSucceededWebhookEventData>
{
    /// <inheritdoc/>
    public RefundSucceededWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundSucceededWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        RefundSucceededWebhookEventDataIntersectionMember1,
        RefundSucceededWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class RefundSucceededWebhookEventDataIntersectionMember1 : JsonModel
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        RefundSucceededWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, RefundSucceededWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public RefundSucceededWebhookEventDataIntersectionMember1() { }

    public RefundSucceededWebhookEventDataIntersectionMember1(
        RefundSucceededWebhookEventDataIntersectionMember1 refundSucceededWebhookEventDataIntersectionMember1
    )
        : base(refundSucceededWebhookEventDataIntersectionMember1) { }

    public RefundSucceededWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundSucceededWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundSucceededWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static RefundSucceededWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundSucceededWebhookEventDataIntersectionMember1FromRaw
    : IFromRawJson<RefundSucceededWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public RefundSucceededWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundSucceededWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(RefundSucceededWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum RefundSucceededWebhookEventDataIntersectionMember1PayloadType
{
    Refund,
}

sealed class RefundSucceededWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<RefundSucceededWebhookEventDataIntersectionMember1PayloadType>
{
    public override RefundSucceededWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Refund" => RefundSucceededWebhookEventDataIntersectionMember1PayloadType.Refund,
            _ => (RefundSucceededWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundSucceededWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundSucceededWebhookEventDataIntersectionMember1PayloadType.Refund => "Refund",
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
[JsonConverter(typeof(RefundSucceededWebhookEventTypeConverter))]
public enum RefundSucceededWebhookEventType
{
    RefundSucceeded,
}

sealed class RefundSucceededWebhookEventTypeConverter
    : JsonConverter<RefundSucceededWebhookEventType>
{
    public override RefundSucceededWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund.succeeded" => RefundSucceededWebhookEventType.RefundSucceeded,
            _ => (RefundSucceededWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundSucceededWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundSucceededWebhookEventType.RefundSucceeded => "refund.succeeded",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
