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
    typeof(JsonModelConverter<PaymentProcessingWebhookEvent, PaymentProcessingWebhookEventFromRaw1>)
)]
public sealed record class PaymentProcessingWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    public required Payment Data
    {
        get { return JsonModel.GetNotNullClass<Payment>(this.RawData, "data"); }
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
    public required ApiEnum<string, Type9> Type
    {
        get { return JsonModel.GetNotNullClass<ApiEnum<string, Type9>>(this.RawData, "type"); }
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

    public PaymentProcessingWebhookEvent() { }

    public PaymentProcessingWebhookEvent(
        PaymentProcessingWebhookEvent paymentProcessingWebhookEvent
    )
        : base(paymentProcessingWebhookEvent) { }

    public PaymentProcessingWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentProcessingWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentProcessingWebhookEventFromRaw1.FromRawUnchecked"/>
    public static PaymentProcessingWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentProcessingWebhookEventFromRaw1 : IFromRawJson<PaymentProcessingWebhookEvent>
{
    /// <inheritdoc/>
    public PaymentProcessingWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentProcessingWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(Type9Converter))]
public enum Type9
{
    PaymentProcessing,
}

sealed class Type9Converter : JsonConverter<Type9>
{
    public override Type9 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment.processing" => Type9.PaymentProcessing,
            _ => (Type9)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type9 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type9.PaymentProcessing => "payment.processing",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
