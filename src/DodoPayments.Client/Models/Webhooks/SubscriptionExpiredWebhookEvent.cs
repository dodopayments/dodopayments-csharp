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
        SubscriptionExpiredWebhookEvent,
        SubscriptionExpiredWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionExpiredWebhookEvent : JsonModel
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
    public required ApiEnum<string, SubscriptionExpiredWebhookEventType> Type
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionExpiredWebhookEventType>
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

    public SubscriptionExpiredWebhookEvent() { }

    public SubscriptionExpiredWebhookEvent(
        SubscriptionExpiredWebhookEvent subscriptionExpiredWebhookEvent
    )
        : base(subscriptionExpiredWebhookEvent) { }

    public SubscriptionExpiredWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionExpiredWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionExpiredWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionExpiredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionExpiredWebhookEventFromRaw : IFromRawJson<SubscriptionExpiredWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionExpiredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionExpiredWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(SubscriptionExpiredWebhookEventTypeConverter))]
public enum SubscriptionExpiredWebhookEventType
{
    SubscriptionExpired,
}

sealed class SubscriptionExpiredWebhookEventTypeConverter
    : JsonConverter<SubscriptionExpiredWebhookEventType>
{
    public override SubscriptionExpiredWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.expired" => SubscriptionExpiredWebhookEventType.SubscriptionExpired,
            _ => (SubscriptionExpiredWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionExpiredWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionExpiredWebhookEventType.SubscriptionExpired => "subscription.expired",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
