using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionUpdatePaymentMethodWebhookEvent,
        SubscriptionUpdatePaymentMethodWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionUpdatePaymentMethodWebhookEvent : JsonModel
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
    /// Response struct representing subscription details
    /// </summary>
    public required Subscription Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Subscription>("data");
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
                JsonSerializer.SerializeToElement("subscription.update_payment_method")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public SubscriptionUpdatePaymentMethodWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("subscription.update_payment_method");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionUpdatePaymentMethodWebhookEvent(
        SubscriptionUpdatePaymentMethodWebhookEvent subscriptionUpdatePaymentMethodWebhookEvent
    )
        : base(subscriptionUpdatePaymentMethodWebhookEvent) { }
#pragma warning restore CS8618

    public SubscriptionUpdatePaymentMethodWebhookEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("subscription.update_payment_method");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatePaymentMethodWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionUpdatePaymentMethodWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionUpdatePaymentMethodWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionUpdatePaymentMethodWebhookEventFromRaw
    : IFromRawJson<SubscriptionUpdatePaymentMethodWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionUpdatePaymentMethodWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionUpdatePaymentMethodWebhookEvent.FromRawUnchecked(rawData);
}
