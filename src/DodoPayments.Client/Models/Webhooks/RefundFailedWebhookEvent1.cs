using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Refunds;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<RefundFailedWebhookEvent, RefundFailedWebhookEventFromRaw1>)
)]
public sealed record class RefundFailedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    public required Refund Data
    {
        get { return this._rawData.GetNotNullClass<Refund>("data"); }
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
    public required ApiEnum<string, Type11> Type
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Type11>>("type"); }
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

    public RefundFailedWebhookEvent() { }

    public RefundFailedWebhookEvent(RefundFailedWebhookEvent refundFailedWebhookEvent)
        : base(refundFailedWebhookEvent) { }

    public RefundFailedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundFailedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundFailedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static RefundFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundFailedWebhookEventFromRaw1 : IFromRawJson<RefundFailedWebhookEvent>
{
    /// <inheritdoc/>
    public RefundFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundFailedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(Type11Converter))]
public enum Type11
{
    RefundFailed,
}

sealed class Type11Converter : JsonConverter<Type11>
{
    public override Type11 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund.failed" => Type11.RefundFailed,
            _ => (Type11)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type11 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type11.RefundFailed => "refund.failed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
