using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<InvoiceSentWebhookEvent, InvoiceSentWebhookEventFromRaw>))]
public sealed record class InvoiceSentWebhookEvent : JsonModel
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
    /// An invoice-led invoice. Every read and every `invoice.*` webhook uses this schema.
    /// </summary>
    public required Invoice Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Invoice>("data");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("invoice.sent")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public InvoiceSentWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("invoice.sent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceSentWebhookEvent(InvoiceSentWebhookEvent invoiceSentWebhookEvent)
        : base(invoiceSentWebhookEvent) { }
#pragma warning restore CS8618

    public InvoiceSentWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("invoice.sent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceSentWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceSentWebhookEventFromRaw.FromRawUnchecked"/>
    public static InvoiceSentWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceSentWebhookEventFromRaw : IFromRawJson<InvoiceSentWebhookEvent>
{
    /// <inheritdoc/>
    public InvoiceSentWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceSentWebhookEvent.FromRawUnchecked(rawData);
}
