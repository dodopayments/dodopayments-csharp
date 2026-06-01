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
        CreditManualAdjustmentWebhookEvent,
        CreditManualAdjustmentWebhookEventFromRaw
    >)
)]
public sealed record class CreditManualAdjustmentWebhookEvent : JsonModel
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
                JsonSerializer.SerializeToElement("credit.manual_adjustment")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public CreditManualAdjustmentWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("credit.manual_adjustment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditManualAdjustmentWebhookEvent(
        CreditManualAdjustmentWebhookEvent creditManualAdjustmentWebhookEvent
    )
        : base(creditManualAdjustmentWebhookEvent) { }
#pragma warning restore CS8618

    public CreditManualAdjustmentWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("credit.manual_adjustment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditManualAdjustmentWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditManualAdjustmentWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditManualAdjustmentWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditManualAdjustmentWebhookEventFromRaw : IFromRawJson<CreditManualAdjustmentWebhookEvent>
{
    /// <inheritdoc/>
    public CreditManualAdjustmentWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditManualAdjustmentWebhookEvent.FromRawUnchecked(rawData);
}
