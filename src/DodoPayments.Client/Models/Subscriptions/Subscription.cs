using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required IReadOnlyList<AddonCartResponseItem> Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AddonCartResponseItem>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonCartResponseItem>>(
                "addons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Billing address details for payments
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BillingAddress>("billing");
        }
        init { this._rawData.Set("billing", value); }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("cancel_at_next_billing_date");
        }
        init { this._rawData.Set("cancel_at_next_billing_date", value); }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Credit entitlement cart settings for this subscription
    /// </summary>
    public required IReadOnlyList<SubscriptionCreditEntitlementCart> CreditEntitlementCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SubscriptionCreditEntitlementCart>
            >("credit_entitlement_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionCreditEntitlementCart>>(
                "credit_entitlement_cart",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Currency used for the subscription payments
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Customer details associated with the subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Meter credit entitlement cart settings for this subscription
    /// </summary>
    public required IReadOnlyList<MeterCreditEntitlementCart> MeterCreditEntitlementCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MeterCreditEntitlementCart>>(
                "meter_credit_entitlement_cart"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<MeterCreditEntitlementCart>>(
                "meter_credit_entitlement_cart",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Meters associated with this subscription (for usage-based billing)
    /// </summary>
    public required IReadOnlyList<Meter> Meters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Meter>>("meters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Meter>>(
                "meters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required DateTimeOffset NextBillingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("next_billing_date");
        }
        init { this._rawData.Set("next_billing_date", value); }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("on_demand");
        }
        init { this._rawData.Set("on_demand", value); }
    }

    /// <summary>
    /// Number of payment frequency intervals
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("payment_frequency_count");
        }
        init { this._rawData.Set("payment_frequency_count", value); }
    }

    /// <summary>
    /// Time interval for payment frequency (e.g. month, year)
    /// </summary>
    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                "payment_frequency_interval"
            );
        }
        init { this._rawData.Set("payment_frequency_interval", value); }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required DateTimeOffset PreviousBillingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("previous_billing_date");
        }
        init { this._rawData.Set("previous_billing_date", value); }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Number of units/items included in the subscription
    /// </summary>
    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("recurring_pre_tax_amount");
        }
        init { this._rawData.Set("recurring_pre_tax_amount", value); }
    }

    /// <summary>
    /// Current status of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Number of subscription period intervals
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("subscription_period_count");
        }
        init { this._rawData.Set("subscription_period_count", value); }
    }

    /// <summary>
    /// Time interval for the subscription period (e.g. month, year)
    /// </summary>
    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                "subscription_period_interval"
            );
        }
        init { this._rawData.Set("subscription_period_interval", value); }
    }

    /// <summary>
    /// Indicates if the recurring_pre_tax_amount is tax inclusive
    /// </summary>
    public required bool TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("trial_period_days");
        }
        init { this._rawData.Set("trial_period_days", value); }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public DateTimeOffset? CancelledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("cancelled_at");
        }
        init { this._rawData.Set("cancelled_at", value); }
    }

    /// <summary>
    /// Customer's responses to custom fields collected during checkout
    /// </summary>
    public IReadOnlyList<CustomFieldResponse>? CustomFieldResponses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomFieldResponse>>(
                "custom_field_responses"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomFieldResponse>?>(
                "custom_field_responses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of remaining discount cycles if discount is applied
    /// </summary>
    public int? DiscountCyclesRemaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("discount_cycles_remaining");
        }
        init { this._rawData.Set("discount_cycles_remaining", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_id");
        }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// Timestamp when the subscription will expire
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Saved payment method id used for recurring charges
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_method_id");
        }
        init { this._rawData.Set("payment_method_id", value); }
    }

    /// <summary>
    /// Tax identifier provided for this subscription (if applicable)
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

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
        foreach (var item in this.CreditEntitlementCart)
        {
            item.Validate();
        }
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.Metadata;
        foreach (var item in this.MeterCreditEntitlementCart)
        {
            item.Validate();
        }
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
        foreach (var item in this.CustomFieldResponses ?? [])
        {
            item.Validate();
        }
        _ = this.DiscountCyclesRemaining;
        _ = this.DiscountID;
        _ = this.ExpiresAt;
        _ = this.PaymentMethodID;
        _ = this.TaxID;
    }

    public Subscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscription(Subscription subscription)
        : base(subscription) { }
#pragma warning restore CS8618

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Response struct representing credit entitlement cart details for a subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionCreditEntitlementCart,
        SubscriptionCreditEntitlementCartFromRaw
    >)
)]
public sealed record class SubscriptionCreditEntitlementCart : JsonModel
{
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

    public required string CreditsAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits_amount");
        }
        init { this._rawData.Set("credits_amount", value); }
    }

    /// <summary>
    /// Customer's current overage balance for this entitlement
    /// </summary>
    public required string OverageBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage_balance");
        }
        init { this._rawData.Set("overage_balance", value); }
    }

    /// <summary>
    /// Controls how overage is handled at the end of a billing cycle.
    ///
    /// <para>| Preset                  | Charge at billing | Credits reduce overage
    /// | Preserve overage at reset | |-------------------------|:-----------------:|:---------------------:|:-------------------------:|
    /// | `forgive_at_reset`      | No                | No                    | No
    ///                        | | `invoice_at_billing`    | Yes               | No
    ///                    | No                        | | `carry_deficit`
    ///  | No                | No                    | Yes                       |
    /// | `carry_deficit_auto_repay` | No             | Yes                   | Yes
    ///                       |</para>
    /// </summary>
    public required ApiEnum<string, CbbOverageBehavior> OverageBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CbbOverageBehavior>>(
                "overage_behavior"
            );
        }
        init { this._rawData.Set("overage_behavior", value); }
    }

    public required bool OverageEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("overage_enabled");
        }
        init { this._rawData.Set("overage_enabled", value); }
    }

    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Customer's current remaining credit balance for this entitlement
    /// </summary>
    public required string RemainingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("remaining_balance");
        }
        init { this._rawData.Set("remaining_balance", value); }
    }

    public required bool RolloverEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("rollover_enabled");
        }
        init { this._rawData.Set("rollover_enabled", value); }
    }

    /// <summary>
    /// Unit label for the credit entitlement (e.g., "API Calls", "Tokens")
    /// </summary>
    public required string Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit");
        }
        init { this._rawData.Set("unit", value); }
    }

    public int? ExpiresAfterDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("expires_after_days");
        }
        init { this._rawData.Set("expires_after_days", value); }
    }

    public int? LowBalanceThresholdPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("low_balance_threshold_percent");
        }
        init { this._rawData.Set("low_balance_threshold_percent", value); }
    }

    public int? MaxRolloverCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_rollover_count");
        }
        init { this._rawData.Set("max_rollover_count", value); }
    }

    public string? OverageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("overage_limit");
        }
        init { this._rawData.Set("overage_limit", value); }
    }

    public int? RolloverPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_percentage");
        }
        init { this._rawData.Set("rollover_percentage", value); }
    }

    public int? RolloverTimeframeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_timeframe_count");
        }
        init { this._rawData.Set("rollover_timeframe_count", value); }
    }

    public ApiEnum<string, TimeInterval>? RolloverTimeframeInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TimeInterval>>(
                "rollover_timeframe_interval"
            );
        }
        init { this._rawData.Set("rollover_timeframe_interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.CreditEntitlementName;
        _ = this.CreditsAmount;
        _ = this.OverageBalance;
        this.OverageBehavior.Validate();
        _ = this.OverageEnabled;
        _ = this.ProductID;
        _ = this.RemainingBalance;
        _ = this.RolloverEnabled;
        _ = this.Unit;
        _ = this.ExpiresAfterDays;
        _ = this.LowBalanceThresholdPercent;
        _ = this.MaxRolloverCount;
        _ = this.OverageLimit;
        _ = this.RolloverPercentage;
        _ = this.RolloverTimeframeCount;
        this.RolloverTimeframeInterval?.Validate();
    }

    public SubscriptionCreditEntitlementCart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCreditEntitlementCart(
        SubscriptionCreditEntitlementCart subscriptionCreditEntitlementCart
    )
        : base(subscriptionCreditEntitlementCart) { }
#pragma warning restore CS8618

    public SubscriptionCreditEntitlementCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCreditEntitlementCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionCreditEntitlementCartFromRaw.FromRawUnchecked"/>
    public static SubscriptionCreditEntitlementCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionCreditEntitlementCartFromRaw : IFromRawJson<SubscriptionCreditEntitlementCart>
{
    /// <inheritdoc/>
    public SubscriptionCreditEntitlementCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionCreditEntitlementCart.FromRawUnchecked(rawData);
}

/// <summary>
/// Response struct representing meter-credit entitlement mapping cart details for
/// a subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MeterCreditEntitlementCart, MeterCreditEntitlementCartFromRaw>)
)]
public sealed record class MeterCreditEntitlementCart : JsonModel
{
    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string MeterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_id");
        }
        init { this._rawData.Set("meter_id", value); }
    }

    public required string MeterName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_name");
        }
        init { this._rawData.Set("meter_name", value); }
    }

    public required string MeterUnitsPerCredit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_units_per_credit");
        }
        init { this._rawData.Set("meter_units_per_credit", value); }
    }

    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.MeterID;
        _ = this.MeterName;
        _ = this.MeterUnitsPerCredit;
        _ = this.ProductID;
    }

    public MeterCreditEntitlementCart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterCreditEntitlementCart(MeterCreditEntitlementCart meterCreditEntitlementCart)
        : base(meterCreditEntitlementCart) { }
#pragma warning restore CS8618

    public MeterCreditEntitlementCart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterCreditEntitlementCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterCreditEntitlementCartFromRaw.FromRawUnchecked"/>
    public static MeterCreditEntitlementCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterCreditEntitlementCartFromRaw : IFromRawJson<MeterCreditEntitlementCart>
{
    /// <inheritdoc/>
    public MeterCreditEntitlementCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeterCreditEntitlementCart.FromRawUnchecked(rawData);
}

/// <summary>
/// Response struct representing usage-based meter cart details for a subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : JsonModel
{
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required long FreeThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("free_threshold");
        }
        init { this._rawData.Set("free_threshold", value); }
    }

    public required string MeasurementUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("measurement_unit");
        }
        init { this._rawData.Set("measurement_unit", value); }
    }

    public required string MeterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_id");
        }
        init { this._rawData.Set("meter_id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? PricePerUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_per_unit");
        }
        init { this._rawData.Set("price_per_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.MeasurementUnit;
        _ = this.MeterID;
        _ = this.Name;
        _ = this.Description;
        _ = this.PricePerUnit;
    }

    public Meter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meter(Meter meter)
        : base(meter) { }
#pragma warning restore CS8618

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFromRaw.FromRawUnchecked"/>
    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRawJson<Meter>
{
    /// <inheritdoc/>
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}
