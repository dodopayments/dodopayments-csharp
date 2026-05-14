using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<CreditBalanceLowWebhookEvent, CreditBalanceLowWebhookEventFromRaw>)
)]
public sealed record class CreditBalanceLowWebhookEvent : JsonModel
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
    /// Webhook payload for credit.balance_low event
    /// </summary>
    public required CreditBalanceLowWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreditBalanceLowWebhookEventData>("data");
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
                JsonSerializer.SerializeToElement("credit.balance_low")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public CreditBalanceLowWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("credit.balance_low");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBalanceLowWebhookEvent(CreditBalanceLowWebhookEvent creditBalanceLowWebhookEvent)
        : base(creditBalanceLowWebhookEvent) { }
#pragma warning restore CS8618

    public CreditBalanceLowWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("credit.balance_low");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBalanceLowWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditBalanceLowWebhookEventFromRaw.FromRawUnchecked"/>
    public static CreditBalanceLowWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditBalanceLowWebhookEventFromRaw : IFromRawJson<CreditBalanceLowWebhookEvent>
{
    /// <inheritdoc/>
    public CreditBalanceLowWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditBalanceLowWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Webhook payload for credit.balance_low event
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreditBalanceLowWebhookEventData,
        CreditBalanceLowWebhookEventDataFromRaw
    >)
)]
public sealed record class CreditBalanceLowWebhookEventData : JsonModel
{
    public required string AvailableBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("available_balance");
        }
        init { this._rawData.Set("available_balance", value); }
    }

    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string CreditEntitlementName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_name");
        }
        init { this._rawData.Set("credit_entitlement_name", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required string SubscriptionCreditsAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_credits_amount");
        }
        init { this._rawData.Set("subscription_credits_amount", value); }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public required string ThresholdAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("threshold_amount");
        }
        init { this._rawData.Set("threshold_amount", value); }
    }

    public required int ThresholdPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("threshold_percent");
        }
        init { this._rawData.Set("threshold_percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvailableBalance;
        _ = this.CreditEntitlementID;
        _ = this.CreditEntitlementName;
        _ = this.CustomerID;
        _ = this.SubscriptionCreditsAmount;
        _ = this.SubscriptionID;
        _ = this.ThresholdAmount;
        _ = this.ThresholdPercent;
    }

    public CreditBalanceLowWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBalanceLowWebhookEventData(
        CreditBalanceLowWebhookEventData creditBalanceLowWebhookEventData
    )
        : base(creditBalanceLowWebhookEventData) { }
#pragma warning restore CS8618

    public CreditBalanceLowWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBalanceLowWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditBalanceLowWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CreditBalanceLowWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditBalanceLowWebhookEventDataFromRaw : IFromRawJson<CreditBalanceLowWebhookEventData>
{
    /// <inheritdoc/>
    public CreditBalanceLowWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditBalanceLowWebhookEventData.FromRawUnchecked(rawData);
}
