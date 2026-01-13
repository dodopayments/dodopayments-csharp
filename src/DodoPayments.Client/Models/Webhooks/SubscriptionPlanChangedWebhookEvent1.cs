using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPlanChangedWebhookEvent,
        SubscriptionPlanChangedWebhookEventFromRaw1
    >)
)]
public sealed record class SubscriptionPlanChangedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Response struct representing subscription details
    /// </summary>
    public required Subscription Data
    {
        get { return this._rawData.GetNotNullClass<Subscription>("data"); }
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
    public required ApiEnum<string, Type18> Type
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Type18>>("type"); }
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

    public SubscriptionPlanChangedWebhookEvent() { }

    public SubscriptionPlanChangedWebhookEvent(
        SubscriptionPlanChangedWebhookEvent subscriptionPlanChangedWebhookEvent
    )
        : base(subscriptionPlanChangedWebhookEvent) { }

    public SubscriptionPlanChangedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPlanChangedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPlanChangedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static SubscriptionPlanChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPlanChangedWebhookEventFromRaw1
    : IFromRawJson<SubscriptionPlanChangedWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionPlanChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPlanChangedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(Type18Converter))]
public enum Type18
{
    SubscriptionPlanChanged,
}

sealed class Type18Converter : JsonConverter<Type18>
{
    public override Type18 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.plan_changed" => Type18.SubscriptionPlanChanged,
            _ => (Type18)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type18 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type18.SubscriptionPlanChanged => "subscription.plan_changed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
