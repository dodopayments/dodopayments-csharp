using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditOverageChargedWebhookEvent,
        CreditOverageChargedWebhookEventFromRaw
    >)
)]
public sealed record class CreditOverageChargedWebhookEvent : JsonModel
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
    /// Response for a ledger entry
    /// </summary>
    public required CreditLedgerEntry Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreditLedgerEntry>("data");
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
                JsonSerializer.SerializeToElement("credit.overage_charged")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public CreditOverageChargedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("credit.overage_charged");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditOverageChargedWebhookEvent(
        CreditOverageChargedWebhookEvent creditOverageChargedWebhookEvent
    )
        : base(creditOverageChargedWebhookEvent) { }
#pragma warning restore CS8618

    public CreditOverageChargedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("credit.overage_charged");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditOverageChargedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditOverageChargedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditOverageChargedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditOverageChargedWebhookEventFromRaw : IFromRawJson<CreditOverageChargedWebhookEvent>
{
    /// <inheritdoc/>
    public CreditOverageChargedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditOverageChargedWebhookEvent.FromRawUnchecked(rawData);
}
