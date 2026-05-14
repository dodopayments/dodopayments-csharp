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
        SubscriptionPlanChangedWebhookEvent,
        SubscriptionPlanChangedWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionPlanChangedWebhookEvent : JsonModel
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
                JsonSerializer.SerializeToElement("subscription.plan_changed")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public SubscriptionPlanChangedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("subscription.plan_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPlanChangedWebhookEvent(
        SubscriptionPlanChangedWebhookEvent subscriptionPlanChangedWebhookEvent
    )
        : base(subscriptionPlanChangedWebhookEvent) { }
#pragma warning restore CS8618

    public SubscriptionPlanChangedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("subscription.plan_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPlanChangedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPlanChangedWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionPlanChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPlanChangedWebhookEventFromRaw : IFromRawJson<SubscriptionPlanChangedWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionPlanChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPlanChangedWebhookEvent.FromRawUnchecked(rawData);
}
