using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

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
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, CreditBalanceLowWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreditBalanceLowWebhookEventType>>(
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

    public CreditBalanceLowWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBalanceLowWebhookEvent(CreditBalanceLowWebhookEvent creditBalanceLowWebhookEvent)
        : base(creditBalanceLowWebhookEvent) { }
#pragma warning restore CS8618

    public CreditBalanceLowWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(CreditBalanceLowWebhookEventTypeConverter))]
public enum CreditBalanceLowWebhookEventType
{
    CreditBalanceLow,
}

sealed class CreditBalanceLowWebhookEventTypeConverter
    : JsonConverter<CreditBalanceLowWebhookEventType>
{
    public override CreditBalanceLowWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit.balance_low" => CreditBalanceLowWebhookEventType.CreditBalanceLow,
            _ => (CreditBalanceLowWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditBalanceLowWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditBalanceLowWebhookEventType.CreditBalanceLow => "credit.balance_low",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
