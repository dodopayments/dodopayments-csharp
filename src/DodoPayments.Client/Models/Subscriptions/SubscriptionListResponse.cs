using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponse, SubscriptionListResponseFromRaw>)
)]
public sealed record class SubscriptionListResponse : JsonModel
{
    /// <summary>
    /// Billing address details for payments
    /// </summary>
    public required BillingAddress Billing
    {
        get { return this._rawData.GetNotNullClass<BillingAddress>("billing"); }
        init { this._rawData.Set("billing", value); }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get { return this._rawData.GetNotNullStruct<bool>("cancel_at_next_billing_date"); }
        init { this._rawData.Set("cancel_at_next_billing_date", value); }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Currency used for the subscription payments
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Customer details associated with the subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get { return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer"); }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get { return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata"); }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required DateTimeOffset NextBillingDate
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("next_billing_date"); }
        init { this._rawData.Set("next_billing_date", value); }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get { return this._rawData.GetNotNullStruct<bool>("on_demand"); }
        init { this._rawData.Set("on_demand", value); }
    }

    /// <summary>
    /// Number of payment frequency intervals
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get { return this._rawData.GetNotNullStruct<int>("payment_frequency_count"); }
        init { this._rawData.Set("payment_frequency_count", value); }
    }

    /// <summary>
    /// Time interval for payment frequency (e.g. month, year)
    /// </summary>
    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
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
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("previous_billing_date"); }
        init { this._rawData.Set("previous_billing_date", value); }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
    /// </summary>
    public required string ProductID
    {
        get { return this._rawData.GetNotNullClass<string>("product_id"); }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Number of units/items included in the subscription
    /// </summary>
    public required int Quantity
    {
        get { return this._rawData.GetNotNullStruct<int>("quantity"); }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get { return this._rawData.GetNotNullStruct<int>("recurring_pre_tax_amount"); }
        init { this._rawData.Set("recurring_pre_tax_amount", value); }
    }

    /// <summary>
    /// Current status of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionStatus>>("status"); }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get { return this._rawData.GetNotNullClass<string>("subscription_id"); }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Number of subscription period intervals
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get { return this._rawData.GetNotNullStruct<int>("subscription_period_count"); }
        init { this._rawData.Set("subscription_period_count", value); }
    }

    /// <summary>
    /// Time interval for the subscription period (e.g. month, year)
    /// </summary>
    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
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
        get { return this._rawData.GetNotNullStruct<bool>("tax_inclusive"); }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get { return this._rawData.GetNotNullStruct<int>("trial_period_days"); }
        init { this._rawData.Set("trial_period_days", value); }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public DateTimeOffset? CancelledAt
    {
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("cancelled_at"); }
        init { this._rawData.Set("cancelled_at", value); }
    }

    /// <summary>
    /// Number of remaining discount cycles if discount is applied
    /// </summary>
    public int? DiscountCyclesRemaining
    {
        get { return this._rawData.GetNullableStruct<int>("discount_cycles_remaining"); }
        init { this._rawData.Set("discount_cycles_remaining", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return this._rawData.GetNullableClass<string>("discount_id"); }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// Saved payment method id used for recurring charges
    /// </summary>
    public string? PaymentMethodID
    {
        get { return this._rawData.GetNullableClass<string>("payment_method_id"); }
        init { this._rawData.Set("payment_method_id", value); }
    }

    /// <summary>
    /// Tax identifier provided for this subscription (if applicable)
    /// </summary>
    public string? TaxID
    {
        get { return this._rawData.GetNullableClass<string>("tax_id"); }
        init { this._rawData.Set("tax_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Billing.Validate();
        _ = this.CancelAtNextBillingDate;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.Metadata;
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
        _ = this.PaymentMethodID;
        _ = this.TaxID;
    }

    public SubscriptionListResponse() { }

    public SubscriptionListResponse(SubscriptionListResponse subscriptionListResponse)
        : base(subscriptionListResponse) { }

    public SubscriptionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseFromRaw : IFromRawJson<SubscriptionListResponse>
{
    /// <inheritdoc/>
    public SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponse.FromRawUnchecked(rawData);
}
