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
        SubscriptionActiveWebhookEvent,
        SubscriptionActiveWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionActiveWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Response struct representing subscription details
    /// </summary>
    public required Subscription Data
    {
        get { return JsonModel.GetNotNullClass<Subscription>(this.RawData, "data"); }
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
    public required ApiEnum<string, SubscriptionActiveWebhookEventType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, SubscriptionActiveWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
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

    public SubscriptionActiveWebhookEvent() { }

    public SubscriptionActiveWebhookEvent(
        SubscriptionActiveWebhookEvent subscriptionActiveWebhookEvent
    )
        : base(subscriptionActiveWebhookEvent) { }

    public SubscriptionActiveWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionActiveWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionActiveWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionActiveWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionActiveWebhookEventFromRaw : IFromRawJson<SubscriptionActiveWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionActiveWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionActiveWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(SubscriptionActiveWebhookEventTypeConverter))]
public enum SubscriptionActiveWebhookEventType
{
    SubscriptionActive,
}

sealed class SubscriptionActiveWebhookEventTypeConverter
    : JsonConverter<SubscriptionActiveWebhookEventType>
{
    public override SubscriptionActiveWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.active" => SubscriptionActiveWebhookEventType.SubscriptionActive,
            _ => (SubscriptionActiveWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionActiveWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionActiveWebhookEventType.SubscriptionActive => "subscription.active",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
