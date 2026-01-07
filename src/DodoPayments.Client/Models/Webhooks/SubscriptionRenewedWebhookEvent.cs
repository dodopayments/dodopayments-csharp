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
        SubscriptionRenewedWebhookEvent,
        SubscriptionRenewedWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionRenewedWebhookEvent : JsonModel
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
    public required ApiEnum<string, SubscriptionRenewedWebhookEventType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, SubscriptionRenewedWebhookEventType>>(
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

    public SubscriptionRenewedWebhookEvent() { }

    public SubscriptionRenewedWebhookEvent(
        SubscriptionRenewedWebhookEvent subscriptionRenewedWebhookEvent
    )
        : base(subscriptionRenewedWebhookEvent) { }

    public SubscriptionRenewedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRenewedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRenewedWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionRenewedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRenewedWebhookEventFromRaw : IFromRawJson<SubscriptionRenewedWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionRenewedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRenewedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(SubscriptionRenewedWebhookEventTypeConverter))]
public enum SubscriptionRenewedWebhookEventType
{
    SubscriptionRenewed,
}

sealed class SubscriptionRenewedWebhookEventTypeConverter
    : JsonConverter<SubscriptionRenewedWebhookEventType>
{
    public override SubscriptionRenewedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.renewed" => SubscriptionRenewedWebhookEventType.SubscriptionRenewed,
            _ => (SubscriptionRenewedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRenewedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRenewedWebhookEventType.SubscriptionRenewed => "subscription.renewed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
