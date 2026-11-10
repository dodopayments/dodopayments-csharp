using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Invoices;

[JsonConverter(typeof(JsonModelConverter<InvoiceEvent, InvoiceEventFromRaw>))]
public sealed record class InvoiceEvent : JsonModel
{
    /// <summary>
    /// A user ID, `api_key`, `customer` or `system`.
    /// </summary>
    public required string Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    public required JsonElement Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("payload");
        }
        init { this._rawData.Set("payload", value); }
    }

    public required long RowVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("row_version");
        }
        init { this._rawData.Set("row_version", value); }
    }

    public string? ActorEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actor_email");
        }
        init { this._rawData.Set("actor_email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Actor;
        _ = this.CreatedAt;
        _ = this.EventID;
        _ = this.EventType;
        _ = this.Payload;
        _ = this.RowVersion;
        _ = this.ActorEmail;
    }

    public InvoiceEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceEvent(InvoiceEvent invoiceEvent)
        : base(invoiceEvent) { }
#pragma warning restore CS8618

    public InvoiceEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceEventFromRaw.FromRawUnchecked"/>
    public static InvoiceEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceEventFromRaw : IFromRawJson<InvoiceEvent>
{
    /// <inheritdoc/>
    public InvoiceEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceEvent.FromRawUnchecked(rawData);
}
