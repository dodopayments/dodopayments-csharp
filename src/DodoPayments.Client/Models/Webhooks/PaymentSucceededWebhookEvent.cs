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
    typeof(JsonModelConverter<PaymentSucceededWebhookEvent, PaymentSucceededWebhookEventFromRaw>)
)]
public sealed record class PaymentSucceededWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    public required Payment Data
    {
        get { return this._rawData.GetNotNullClass<Payment>("data"); }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get { return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp"); }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, PaymentSucceededWebhookEventType> Type
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentSucceededWebhookEventType>>(
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

    public PaymentSucceededWebhookEvent() { }

    public PaymentSucceededWebhookEvent(PaymentSucceededWebhookEvent paymentSucceededWebhookEvent)
        : base(paymentSucceededWebhookEvent) { }

    public PaymentSucceededWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentSucceededWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentSucceededWebhookEventFromRaw.FromRawUnchecked"/>
    public static PaymentSucceededWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentSucceededWebhookEventFromRaw : IFromRawJson<PaymentSucceededWebhookEvent>
{
    /// <inheritdoc/>
    public PaymentSucceededWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentSucceededWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(PaymentSucceededWebhookEventTypeConverter))]
public enum PaymentSucceededWebhookEventType
{
    PaymentSucceeded,
}

sealed class PaymentSucceededWebhookEventTypeConverter
    : JsonConverter<PaymentSucceededWebhookEventType>
{
    public override PaymentSucceededWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.succeeded" => PaymentSucceededWebhookEventType.PaymentSucceeded,
            _ => (PaymentSucceededWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentSucceededWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentSucceededWebhookEventType.PaymentSucceeded => "payment.succeeded",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
