using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRenewedWebhookEvent,
        SubscriptionRenewedWebhookEventFromRaw
    >)
)]
public sealed record class SubscriptionRenewedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required SubscriptionRenewedWebhookEventData Data
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionRenewedWebhookEventData>(
                this.RawData,
                "data"
            );
        }
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
    public required ApiEnum<string, SubscriptionRenewedWebhookEventType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, SubscriptionRenewedWebhookEventType>>(
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

    public SubscriptionRenewedWebhookEvent() { }

    public SubscriptionRenewedWebhookEvent(
        SubscriptionRenewedWebhookEvent subscriptionRenewedWebhookEvent
    )
        : base(subscriptionRenewedWebhookEvent) { }

    public SubscriptionRenewedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRenewedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRenewedWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionRenewedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRenewedWebhookEventFromRaw : IFromRawJson<SubscriptionRenewedWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionRenewedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRenewedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRenewedWebhookEventData,
        SubscriptionRenewedWebhookEventDataFromRaw
    >)
)]
public sealed record class SubscriptionRenewedWebhookEventData : JsonModel
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required IReadOnlyList<AddonCartResponseItem> Addons
    {
        get
        {
            return JsonModel.GetNotNullClass<List<AddonCartResponseItem>>(this.RawData, "addons");
        }
        init { JsonModel.Set(this._rawData, "addons", value); }
    }

    public required BillingAddress Billing
    {
        get { return JsonModel.GetNotNullClass<BillingAddress>(this.RawData, "billing"); }
        init { JsonModel.Set(this._rawData, "billing", value); }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<bool>(this.RawData, "cancel_at_next_billing_date");
        }
        init { JsonModel.Set(this._rawData, "cancel_at_next_billing_date", value); }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    public required CustomerLimitedDetails Customer
    {
        get { return JsonModel.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Meters associated with this subscription (for usage-based billing)
    /// </summary>
    public required IReadOnlyList<Meter> Meters
    {
        get { return JsonModel.GetNotNullClass<List<Meter>>(this.RawData, "meters"); }
        init { JsonModel.Set(this._rawData, "meters", value); }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required System::DateTimeOffset NextBillingDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "next_billing_date"
            );
        }
        init { JsonModel.Set(this._rawData, "next_billing_date", value); }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "on_demand"); }
        init { JsonModel.Set(this._rawData, "on_demand", value); }
    }

    /// <summary>
    /// Number of payment frequency intervals
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "payment_frequency_count"); }
        init { JsonModel.Set(this._rawData, "payment_frequency_count", value); }
    }

    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                this.RawData,
                "payment_frequency_interval"
            );
        }
        init { JsonModel.Set(this._rawData, "payment_frequency_interval", value); }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required System::DateTimeOffset PreviousBillingDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "previous_billing_date"
            );
        }
        init { JsonModel.Set(this._rawData, "previous_billing_date", value); }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
    /// </summary>
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// Number of units/items included in the subscription
    /// </summary>
    public required int Quantity
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "recurring_pre_tax_amount"); }
        init { JsonModel.Set(this._rawData, "recurring_pre_tax_amount", value); }
    }

    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, SubscriptionStatus>>(
                this.RawData,
                "status"
            );
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "subscription_id"); }
        init { JsonModel.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// Number of subscription period intervals
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "subscription_period_count"); }
        init { JsonModel.Set(this._rawData, "subscription_period_count", value); }
    }

    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                this.RawData,
                "subscription_period_interval"
            );
        }
        init { JsonModel.Set(this._rawData, "subscription_period_interval", value); }
    }

    /// <summary>
    /// Indicates if the recurring_pre_tax_amount is tax inclusive
    /// </summary>
    public required bool TaxInclusive
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "tax_inclusive"); }
        init { JsonModel.Set(this._rawData, "tax_inclusive", value); }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "trial_period_days"); }
        init { JsonModel.Set(this._rawData, "trial_period_days", value); }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public System::DateTimeOffset? CancelledAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "cancelled_at"
            );
        }
        init { JsonModel.Set(this._rawData, "cancelled_at", value); }
    }

    /// <summary>
    /// Number of remaining discount cycles if discount is applied
    /// </summary>
    public int? DiscountCyclesRemaining
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "discount_cycles_remaining"); }
        init { JsonModel.Set(this._rawData, "discount_cycles_remaining", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "discount_id"); }
        init { JsonModel.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// Timestamp when the subscription will expire
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expires_at");
        }
        init { JsonModel.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// Saved payment method id used for recurring charges
    /// </summary>
    public string? PaymentMethodID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_method_id"); }
        init { JsonModel.Set(this._rawData, "payment_method_id", value); }
    }

    /// <summary>
    /// Tax identifier provided for this subscription (if applicable)
    /// </summary>
    public string? TaxID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tax_id"); }
        init { JsonModel.Set(this._rawData, "tax_id", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator Subscription(
        SubscriptionRenewedWebhookEventData subscriptionRenewedWebhookEventData
    ) =>
        new()
        {
            Addons = subscriptionRenewedWebhookEventData.Addons,
            Billing = subscriptionRenewedWebhookEventData.Billing,
            CancelAtNextBillingDate = subscriptionRenewedWebhookEventData.CancelAtNextBillingDate,
            CreatedAt = subscriptionRenewedWebhookEventData.CreatedAt,
            Currency = subscriptionRenewedWebhookEventData.Currency,
            Customer = subscriptionRenewedWebhookEventData.Customer,
            Metadata = subscriptionRenewedWebhookEventData.Metadata,
            Meters = subscriptionRenewedWebhookEventData.Meters,
            NextBillingDate = subscriptionRenewedWebhookEventData.NextBillingDate,
            OnDemand = subscriptionRenewedWebhookEventData.OnDemand,
            PaymentFrequencyCount = subscriptionRenewedWebhookEventData.PaymentFrequencyCount,
            PaymentFrequencyInterval = subscriptionRenewedWebhookEventData.PaymentFrequencyInterval,
            PreviousBillingDate = subscriptionRenewedWebhookEventData.PreviousBillingDate,
            ProductID = subscriptionRenewedWebhookEventData.ProductID,
            Quantity = subscriptionRenewedWebhookEventData.Quantity,
            RecurringPreTaxAmount = subscriptionRenewedWebhookEventData.RecurringPreTaxAmount,
            Status = subscriptionRenewedWebhookEventData.Status,
            SubscriptionID = subscriptionRenewedWebhookEventData.SubscriptionID,
            SubscriptionPeriodCount = subscriptionRenewedWebhookEventData.SubscriptionPeriodCount,
            SubscriptionPeriodInterval =
                subscriptionRenewedWebhookEventData.SubscriptionPeriodInterval,
            TaxInclusive = subscriptionRenewedWebhookEventData.TaxInclusive,
            TrialPeriodDays = subscriptionRenewedWebhookEventData.TrialPeriodDays,
            CancelledAt = subscriptionRenewedWebhookEventData.CancelledAt,
            DiscountCyclesRemaining = subscriptionRenewedWebhookEventData.DiscountCyclesRemaining,
            DiscountID = subscriptionRenewedWebhookEventData.DiscountID,
            ExpiresAt = subscriptionRenewedWebhookEventData.ExpiresAt,
            PaymentMethodID = subscriptionRenewedWebhookEventData.PaymentMethodID,
            TaxID = subscriptionRenewedWebhookEventData.TaxID,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Addons)
        {
            item.Validate();
        }
        this.Billing.Validate();
        _ = this.CancelAtNextBillingDate;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.Metadata;
        foreach (var item in this.Meters)
        {
            item.Validate();
        }
        _ = this.NextBillingDate;
        _ = this.OnDemand;
        _ = this.PaymentFrequencyCount;
        this.PaymentFrequencyInterval.Validate();
        _ = this.PreviousBillingDate;
        _ = this.ProductID;
        _ = this.Quantity;
        _ = this.RecurringPreTaxAmount;
        this.Status.Validate();
        _ = this.SubscriptionID;
        _ = this.SubscriptionPeriodCount;
        this.SubscriptionPeriodInterval.Validate();
        _ = this.TaxInclusive;
        _ = this.TrialPeriodDays;
        _ = this.CancelledAt;
        _ = this.DiscountCyclesRemaining;
        _ = this.DiscountID;
        _ = this.ExpiresAt;
        _ = this.PaymentMethodID;
        _ = this.TaxID;
        this.PayloadType?.Validate();
    }

    public SubscriptionRenewedWebhookEventData() { }

    public SubscriptionRenewedWebhookEventData(
        SubscriptionRenewedWebhookEventData subscriptionRenewedWebhookEventData
    )
        : base(subscriptionRenewedWebhookEventData) { }

    public SubscriptionRenewedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRenewedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRenewedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionRenewedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRenewedWebhookEventDataFromRaw : IFromRawJson<SubscriptionRenewedWebhookEventData>
{
    /// <inheritdoc/>
    public SubscriptionRenewedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRenewedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRenewedWebhookEventDataIntersectionMember1,
        SubscriptionRenewedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class SubscriptionRenewedWebhookEventDataIntersectionMember1 : JsonModel
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public SubscriptionRenewedWebhookEventDataIntersectionMember1() { }

    public SubscriptionRenewedWebhookEventDataIntersectionMember1(
        SubscriptionRenewedWebhookEventDataIntersectionMember1 subscriptionRenewedWebhookEventDataIntersectionMember1
    )
        : base(subscriptionRenewedWebhookEventDataIntersectionMember1) { }

    public SubscriptionRenewedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRenewedWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRenewedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static SubscriptionRenewedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRenewedWebhookEventDataIntersectionMember1FromRaw
    : IFromRawJson<SubscriptionRenewedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public SubscriptionRenewedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRenewedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType
{
    Subscription,
}

sealed class SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType>
{
    public override SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Subscription" =>
                SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType.Subscription,
            _ => (SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRenewedWebhookEventDataIntersectionMember1PayloadType.Subscription =>
                    "Subscription",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(SubscriptionRenewedWebhookEventTypeConverter))]
public enum SubscriptionRenewedWebhookEventType
{
    SubscriptionRenewed,
}

sealed class SubscriptionRenewedWebhookEventTypeConverter
    : JsonConverter<SubscriptionRenewedWebhookEventType>
{
    public override SubscriptionRenewedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.renewed" => SubscriptionRenewedWebhookEventType.SubscriptionRenewed,
            _ => (SubscriptionRenewedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRenewedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRenewedWebhookEventType.SubscriptionRenewed => "subscription.renewed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
