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

[JsonConverter(
    typeof(JsonModelConverter<DisputeLostWebhookEvent, DisputeLostWebhookEventFromRaw1>)
)]
public sealed record class DisputeLostWebhookEvent : JsonModel
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
    public required ApiEnum<string, Type3> Type
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Type3>>("type"); }
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

    public DisputeLostWebhookEvent() { }

    public DisputeLostWebhookEvent(DisputeLostWebhookEvent disputeLostWebhookEvent)
        : base(disputeLostWebhookEvent) { }

    public DisputeLostWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeLostWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeLostWebhookEventFromRaw1.FromRawUnchecked"/>
    public static DisputeLostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeLostWebhookEventFromRaw1 : IFromRawJson<DisputeLostWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeLostWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeLostWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(Type3Converter))]
public enum Type3
{
    DisputeLost,
}

sealed class Type3Converter : JsonConverter<Type3>
{
    public override Type3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute.lost" => Type3.DisputeLost,
            _ => (Type3)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type3 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type3.DisputeLost => "dispute.lost",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
