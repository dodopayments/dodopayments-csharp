using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<DisputeCancelledWebhookEvent, DisputeCancelledWebhookEventFromRaw>)
)]
public sealed record class DisputeCancelledWebhookEvent : JsonModel
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

    public required Dispute Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Dispute>("data");
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
                JsonSerializer.SerializeToElement("dispute.cancelled")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public DisputeCancelledWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("dispute.cancelled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DisputeCancelledWebhookEvent(DisputeCancelledWebhookEvent disputeCancelledWebhookEvent)
        : base(disputeCancelledWebhookEvent) { }
#pragma warning restore CS8618

    public DisputeCancelledWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("dispute.cancelled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeCancelledWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DisputeCancelledWebhookEventFromRaw.FromRawUnchecked"/>
    public static DisputeCancelledWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DisputeCancelledWebhookEventFromRaw : IFromRawJson<DisputeCancelledWebhookEvent>
{
    /// <inheritdoc/>
    public DisputeCancelledWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DisputeCancelledWebhookEvent.FromRawUnchecked(rawData);
}
