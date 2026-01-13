using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<PaymentCancelledWebhookEvent, PaymentCancelledWebhookEventFromRaw>)
)]
public sealed record class PaymentCancelledWebhookEvent : JsonModel
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

    public required Payment Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Payment>("data");
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
    public required ApiEnum<string, PaymentCancelledWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentCancelledWebhookEventType>>(
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

    public PaymentCancelledWebhookEvent() { }

    public PaymentCancelledWebhookEvent(PaymentCancelledWebhookEvent paymentCancelledWebhookEvent)
        : base(paymentCancelledWebhookEvent) { }

    public PaymentCancelledWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentCancelledWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentCancelledWebhookEventFromRaw.FromRawUnchecked"/>
    public static PaymentCancelledWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentCancelledWebhookEventFromRaw : IFromRawJson<PaymentCancelledWebhookEvent>
{
    /// <inheritdoc/>
    public PaymentCancelledWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentCancelledWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(PaymentCancelledWebhookEventTypeConverter))]
public enum PaymentCancelledWebhookEventType
{
    PaymentCancelled,
}

sealed class PaymentCancelledWebhookEventTypeConverter
    : JsonConverter<PaymentCancelledWebhookEventType>
{
    public override PaymentCancelledWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.cancelled" => PaymentCancelledWebhookEventType.PaymentCancelled,
            _ => (PaymentCancelledWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCancelledWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentCancelledWebhookEventType.PaymentCancelled => "payment.cancelled",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
