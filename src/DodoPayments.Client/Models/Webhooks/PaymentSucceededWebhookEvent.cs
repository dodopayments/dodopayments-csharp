using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

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
                JsonSerializer.SerializeToElement("payment.succeeded")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public PaymentSucceededWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("payment.succeeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentSucceededWebhookEvent(PaymentSucceededWebhookEvent paymentSucceededWebhookEvent)
        : base(paymentSucceededWebhookEvent) { }
#pragma warning restore CS8618

    public PaymentSucceededWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("payment.succeeded");
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
