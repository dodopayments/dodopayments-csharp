using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        AbandonedCheckoutDetectedWebhookEvent,
        AbandonedCheckoutDetectedWebhookEventFromRaw
    >)
)]
public sealed record class AbandonedCheckoutDetectedWebhookEvent : JsonModel
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

    /// <summary>
    /// Webhook payload for abandoned_checkout.detected and abandoned_checkout.recovered events
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("abandoned_checkout.detected")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public AbandonedCheckoutDetectedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("abandoned_checkout.detected");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AbandonedCheckoutDetectedWebhookEvent(
        AbandonedCheckoutDetectedWebhookEvent abandonedCheckoutDetectedWebhookEvent
    )
        : base(abandonedCheckoutDetectedWebhookEvent) { }
#pragma warning restore CS8618

    public AbandonedCheckoutDetectedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("abandoned_checkout.detected");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AbandonedCheckoutDetectedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AbandonedCheckoutDetectedWebhookEventFromRaw.FromRawUnchecked"/>
    public static AbandonedCheckoutDetectedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AbandonedCheckoutDetectedWebhookEventFromRaw
    : IFromRawJson<AbandonedCheckoutDetectedWebhookEvent>
{
    /// <inheritdoc/>
    public AbandonedCheckoutDetectedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AbandonedCheckoutDetectedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Webhook payload for abandoned_checkout.detected and abandoned_checkout.recovered events
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required DateTimeOffset AbandonedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("abandoned_at");
        }
        init { this._rawData.Set("abandoned_at", value); }
    }

    public required ApiEnum<string, AbandonmentReason> AbandonmentReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AbandonmentReason>>(
                "abandonment_reason"
            );
        }
        init { this._rawData.Set("abandonment_reason", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? RecoveredPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recovered_payment_id");
        }
        init { this._rawData.Set("recovered_payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AbandonedAt;
        this.AbandonmentReason.Validate();
        _ = this.CustomerID;
        _ = this.PaymentID;
        this.Status.Validate();
        _ = this.RecoveredPaymentID;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AbandonmentReasonConverter))]
public enum AbandonmentReason
{
    PaymentFailed,
    CheckoutIncomplete,
}

sealed class AbandonmentReasonConverter : JsonConverter<AbandonmentReason>
{
    public override AbandonmentReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_failed" => AbandonmentReason.PaymentFailed,
            "checkout_incomplete" => AbandonmentReason.CheckoutIncomplete,
            _ => (AbandonmentReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AbandonmentReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AbandonmentReason.PaymentFailed => "payment_failed",
                AbandonmentReason.CheckoutIncomplete => "checkout_incomplete",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Abandoned,
    Recovering,
    Recovered,
    Exhausted,
    OptedOut,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "abandoned" => Status.Abandoned,
            "recovering" => Status.Recovering,
            "recovered" => Status.Recovered,
            "exhausted" => Status.Exhausted,
            "opted_out" => Status.OptedOut,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Abandoned => "abandoned",
                Status.Recovering => "recovering",
                Status.Recovered => "recovered",
                Status.Exhausted => "exhausted",
                Status.OptedOut => "opted_out",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
