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

[JsonConverter(typeof(JsonModelConverter<DisputeLostWebhookEvent, DisputeLostWebhookEventFromRaw>))]
public sealed record class DisputeLostWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    public required Dispute Data
    {
        get { return JsonModel.GetNotNullClass<Dispute>(this.RawData, "data"); }
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
    public required ApiEnum<string, DisputeLostWebhookEventType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, DisputeLostWebhookEventType>>(
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

    public DisputeLostWebhookEvent() { }

    public DisputeLostWebhookEvent(DisputeLostWebhookEvent disputeLostWebhookEvent)
        : base(disputeLostWebhookEvent) { }

    public DisputeLostWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeLostWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeLostWebhookEventFromRaw.FromRawUnchecked"/>
    public static DisputeLostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeLostWebhookEventFromRaw : IFromRawJson<DisputeLostWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeLostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeLostWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(DisputeLostWebhookEventTypeConverter))]
public enum DisputeLostWebhookEventType
{
    DisputeLost,
}

sealed class DisputeLostWebhookEventTypeConverter : JsonConverter<DisputeLostWebhookEventType>
{
    public override DisputeLostWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.lost" => DisputeLostWebhookEventType.DisputeLost,
            _ => (DisputeLostWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeLostWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeLostWebhookEventType.DisputeLost => "dispute.lost",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
