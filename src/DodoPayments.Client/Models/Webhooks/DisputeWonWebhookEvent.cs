using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<DisputeWonWebhookEvent, DisputeWonWebhookEventFromRaw>))]
public sealed record class DisputeWonWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    public required Dispute Data
    {
        get { return this._rawData.GetNotNullClass<Dispute>("data"); }
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
    public required ApiEnum<string, DisputeWonWebhookEventType> Type
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DisputeWonWebhookEventType>>(
                "type"
            );
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

    public DisputeWonWebhookEvent() { }

    public DisputeWonWebhookEvent(DisputeWonWebhookEvent disputeWonWebhookEvent)
        : base(disputeWonWebhookEvent) { }

    public DisputeWonWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeWonWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeWonWebhookEventFromRaw.FromRawUnchecked"/>
    public static DisputeWonWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeWonWebhookEventFromRaw : IFromRawJson<DisputeWonWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeWonWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeWonWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(DisputeWonWebhookEventTypeConverter))]
public enum DisputeWonWebhookEventType
{
    DisputeWon,
}

sealed class DisputeWonWebhookEventTypeConverter : JsonConverter<DisputeWonWebhookEventType>
{
    public override DisputeWonWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.won" => DisputeWonWebhookEventType.DisputeWon,
            _ => (DisputeWonWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeWonWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeWonWebhookEventType.DisputeWon => "dispute.won",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
