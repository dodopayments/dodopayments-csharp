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
        SubscriptionOnHoldWebhookEvent,
        SubscriptionOnHoldWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionOnHoldWebhookEvent : JsonModel
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
    public required ApiEnum<string, SubscriptionOnHoldWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionOnHoldWebhookEventType>
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

    public SubscriptionOnHoldWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionOnHoldWebhookEvent(
        SubscriptionOnHoldWebhookEvent subscriptionOnHoldWebhookEvent
    )
        : base(subscriptionOnHoldWebhookEvent) { }
#pragma warning restore CS8618

    public SubscriptionOnHoldWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionOnHoldWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionOnHoldWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionOnHoldWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionOnHoldWebhookEventFromRaw : IFromRawJson<SubscriptionOnHoldWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionOnHoldWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionOnHoldWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(SubscriptionOnHoldWebhookEventTypeConverter))]
public enum SubscriptionOnHoldWebhookEventType
{
    SubscriptionOnHold,
}

sealed class SubscriptionOnHoldWebhookEventTypeConverter
    : JsonConverter<SubscriptionOnHoldWebhookEventType>
{
    public override SubscriptionOnHoldWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.on_hold" => SubscriptionOnHoldWebhookEventType.SubscriptionOnHold,
            _ => (SubscriptionOnHoldWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionOnHoldWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionOnHoldWebhookEventType.SubscriptionOnHold => "subscription.on_hold",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
