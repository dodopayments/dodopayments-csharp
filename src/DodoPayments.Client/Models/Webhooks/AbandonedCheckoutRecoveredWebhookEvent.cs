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
        AbandonedCheckoutRecoveredWebhookEvent,
        AbandonedCheckoutRecoveredWebhookEventFromRaw
    >)
)]
public sealed record class AbandonedCheckoutRecoveredWebhookEvent : JsonModel
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
    public required AbandonedCheckoutRecoveredWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AbandonedCheckoutRecoveredWebhookEventData>(
                "data"
            );
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
                JsonSerializer.SerializeToElement("abandoned_checkout.recovered")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public AbandonedCheckoutRecoveredWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("abandoned_checkout.recovered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AbandonedCheckoutRecoveredWebhookEvent(
        AbandonedCheckoutRecoveredWebhookEvent abandonedCheckoutRecoveredWebhookEvent
    )
        : base(abandonedCheckoutRecoveredWebhookEvent) { }
#pragma warning restore CS8618

    public AbandonedCheckoutRecoveredWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("abandoned_checkout.recovered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AbandonedCheckoutRecoveredWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AbandonedCheckoutRecoveredWebhookEventFromRaw.FromRawUnchecked"/>
    public static AbandonedCheckoutRecoveredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AbandonedCheckoutRecoveredWebhookEventFromRaw
    : IFromRawJson<AbandonedCheckoutRecoveredWebhookEvent>
{
    /// <inheritdoc/>
    public AbandonedCheckoutRecoveredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AbandonedCheckoutRecoveredWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Webhook payload for abandoned_checkout.detected and abandoned_checkout.recovered events
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AbandonedCheckoutRecoveredWebhookEventData,
        AbandonedCheckoutRecoveredWebhookEventDataFromRaw
    >)
)]
public sealed record class AbandonedCheckoutRecoveredWebhookEventData : JsonModel
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

    public required ApiEnum<
        string,
        AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason
    > AbandonmentReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason>
            >("abandonment_reason");
        }
        init { this._rawData.Set("abandonment_reason", value); }
    }

    /// <summary>
    /// Brand id this abandoned checkout belongs to
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
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

    public required ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AbandonedCheckoutRecoveredWebhookEventDataStatus>
            >("status");
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
        _ = this.BrandID;
        _ = this.CustomerID;
        _ = this.PaymentID;
        this.Status.Validate();
        _ = this.RecoveredPaymentID;
    }

    public AbandonedCheckoutRecoveredWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AbandonedCheckoutRecoveredWebhookEventData(
        AbandonedCheckoutRecoveredWebhookEventData abandonedCheckoutRecoveredWebhookEventData
    )
        : base(abandonedCheckoutRecoveredWebhookEventData) { }
#pragma warning restore CS8618

    public AbandonedCheckoutRecoveredWebhookEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AbandonedCheckoutRecoveredWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AbandonedCheckoutRecoveredWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static AbandonedCheckoutRecoveredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AbandonedCheckoutRecoveredWebhookEventDataFromRaw
    : IFromRawJson<AbandonedCheckoutRecoveredWebhookEventData>
{
    /// <inheritdoc/>
    public AbandonedCheckoutRecoveredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AbandonedCheckoutRecoveredWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReasonConverter))]
public enum AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason
{
    PaymentFailed,
    CheckoutIncomplete,
}

sealed class AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReasonConverter
    : JsonConverter<AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason>
{
    public override AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment_failed" =>
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
            "checkout_incomplete" =>
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.CheckoutIncomplete,
            _ => (AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed =>
                    "payment_failed",
                AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.CheckoutIncomplete =>
                    "checkout_incomplete",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AbandonedCheckoutRecoveredWebhookEventDataStatusConverter))]
public enum AbandonedCheckoutRecoveredWebhookEventDataStatus
{
    Abandoned,
    Recovering,
    Recovered,
    Exhausted,
    OptedOut,
}

sealed class AbandonedCheckoutRecoveredWebhookEventDataStatusConverter
    : JsonConverter<AbandonedCheckoutRecoveredWebhookEventDataStatus>
{
    public override AbandonedCheckoutRecoveredWebhookEventDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "abandoned" => AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
            "recovering" => AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovering,
            "recovered" => AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovered,
            "exhausted" => AbandonedCheckoutRecoveredWebhookEventDataStatus.Exhausted,
            "opted_out" => AbandonedCheckoutRecoveredWebhookEventDataStatus.OptedOut,
            _ => (AbandonedCheckoutRecoveredWebhookEventDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AbandonedCheckoutRecoveredWebhookEventDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned => "abandoned",
                AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovering => "recovering",
                AbandonedCheckoutRecoveredWebhookEventDataStatus.Recovered => "recovered",
                AbandonedCheckoutRecoveredWebhookEventDataStatus.Exhausted => "exhausted",
                AbandonedCheckoutRecoveredWebhookEventDataStatus.OptedOut => "opted_out",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
