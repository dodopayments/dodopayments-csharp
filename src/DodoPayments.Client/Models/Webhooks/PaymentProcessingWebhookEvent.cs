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
    typeof(JsonModelConverter<PaymentProcessingWebhookEvent, PaymentProcessingWebhookEventFromRaw>)
)]
public sealed record class PaymentProcessingWebhookEvent : JsonModel
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
    public required ApiEnum<string, PaymentProcessingWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PaymentProcessingWebhookEventType>
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

    public PaymentProcessingWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentProcessingWebhookEvent(
        PaymentProcessingWebhookEvent paymentProcessingWebhookEvent
    )
        : base(paymentProcessingWebhookEvent) { }
#pragma warning restore CS8618

    public PaymentProcessingWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentProcessingWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentProcessingWebhookEventFromRaw.FromRawUnchecked"/>
    public static PaymentProcessingWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentProcessingWebhookEventFromRaw : IFromRawJson<PaymentProcessingWebhookEvent>
{
    /// <inheritdoc/>
    public PaymentProcessingWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentProcessingWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(PaymentProcessingWebhookEventTypeConverter))]
public enum PaymentProcessingWebhookEventType
{
    PaymentProcessing,
}

sealed class PaymentProcessingWebhookEventTypeConverter
    : JsonConverter<PaymentProcessingWebhookEventType>
{
    public override PaymentProcessingWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.processing" => PaymentProcessingWebhookEventType.PaymentProcessing,
            _ => (PaymentProcessingWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentProcessingWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentProcessingWebhookEventType.PaymentProcessing => "payment.processing",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
