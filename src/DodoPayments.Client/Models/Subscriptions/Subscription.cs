using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(typeof(ModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : ModelBase
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required List<AddonCartResponseItem> Addons
    {
        get
        {
            if (!this._rawData.TryGetValue("addons", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'addons' cannot be null",
                    new ArgumentOutOfRangeException("addons", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<AddonCartResponseItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'addons' cannot be null",
                    new ArgumentNullException("addons")
                );
        }
        init
        {
            this._rawData["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("billing", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new ArgumentOutOfRangeException("billing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BillingAddress>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new ArgumentNullException("billing")
                );
        }
        init
        {
            this._rawData["billing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get
        {
            if (!this._rawData.TryGetValue("cancel_at_next_billing_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'cancel_at_next_billing_date' cannot be null",
                    new ArgumentOutOfRangeException(
                        "cancel_at_next_billing_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cancel_at_next_billing_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customer details associated with the subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this._rawData.TryGetValue("customer", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
                );
        }
        init
        {
            this._rawData["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Meters associated with this subscription (for usage-based billing)
    /// </summary>
    public required List<Meter> Meters
    {
        get
        {
            if (!this._rawData.TryGetValue("meters", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'meters' cannot be null",
                    new ArgumentOutOfRangeException("meters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Meter>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'meters' cannot be null",
                    new ArgumentNullException("meters")
                );
        }
        init
        {
            this._rawData["meters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("next_billing_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'next_billing_date' cannot be null",
                    new ArgumentOutOfRangeException(
                        "next_billing_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["next_billing_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get
        {
            if (!this._rawData.TryGetValue("on_demand", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'on_demand' cannot be null",
                    new ArgumentOutOfRangeException("on_demand", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["on_demand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of payment frequency intervals
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_frequency_count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_frequency_count' cannot be null",
                    new ArgumentOutOfRangeException(
                        "payment_frequency_count",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["payment_frequency_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Time interval for payment frequency (e.g. month, year)
    /// </summary>
    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_frequency_interval", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_frequency_interval' cannot be null",
                    new ArgumentOutOfRangeException(
                        "payment_frequency_interval",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["payment_frequency_interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required DateTimeOffset PreviousBillingDate
    {
        get
        {
            if (!this._rawData.TryGetValue("previous_billing_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'previous_billing_date' cannot be null",
                    new ArgumentOutOfRangeException(
                        "previous_billing_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["previous_billing_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this._rawData.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new ArgumentOutOfRangeException("product_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new ArgumentNullException("product_id")
                );
        }
        init
        {
            this._rawData["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of units/items included in the subscription
    /// </summary>
    public required int Quantity
    {
        get
        {
            if (!this._rawData.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("recurring_pre_tax_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'recurring_pre_tax_amount' cannot be null",
                    new ArgumentOutOfRangeException(
                        "recurring_pre_tax_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["recurring_pre_tax_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current status of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            if (!this._rawData.TryGetValue("subscription_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_id' cannot be null",
                    new ArgumentOutOfRangeException("subscription_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'subscription_id' cannot be null",
                    new ArgumentNullException("subscription_id")
                );
        }
        init
        {
            this._rawData["subscription_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of subscription period intervals
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get
        {
            if (!this._rawData.TryGetValue("subscription_period_count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_period_count' cannot be null",
                    new ArgumentOutOfRangeException(
                        "subscription_period_count",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["subscription_period_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Time interval for the subscription period (e.g. month, year)
    /// </summary>
    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            if (!this._rawData.TryGetValue("subscription_period_interval", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_period_interval' cannot be null",
                    new ArgumentOutOfRangeException(
                        "subscription_period_interval",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["subscription_period_interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if the recurring_pre_tax_amount is tax inclusive
    /// </summary>
    public required bool TaxInclusive
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_inclusive", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'tax_inclusive' cannot be null",
                    new ArgumentOutOfRangeException("tax_inclusive", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tax_inclusive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get
        {
            if (!this._rawData.TryGetValue("trial_period_days", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'trial_period_days' cannot be null",
                    new ArgumentOutOfRangeException(
                        "trial_period_days",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["trial_period_days"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public DateTimeOffset? CancelledAt
    {
        get
        {
            if (!this._rawData.TryGetValue("cancelled_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cancelled_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("discount_cycles_remaining", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["discount_cycles_remaining"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get
        {
            if (!this._rawData.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["discount_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the subscription will expire
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            if (!this._rawData.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Saved payment method id used for recurring charges
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_method_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["payment_method_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax identifier provided for this subscription (if applicable)
    /// </summary>
    public string? TaxID
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    }

    public Subscription() { }

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRaw<Subscription>
{
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Response struct representing usage-based meter cart details for a subscription
/// </summary>
[JsonConverter(typeof(ModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : ModelBase
{
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long FreeThreshold
    {
        get
        {
            if (!this._rawData.TryGetValue("free_threshold", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'free_threshold' cannot be null",
                    new ArgumentOutOfRangeException("free_threshold", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["free_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MeasurementUnit
    {
        get
        {
            if (!this._rawData.TryGetValue("measurement_unit", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'measurement_unit' cannot be null",
                    new ArgumentOutOfRangeException("measurement_unit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'measurement_unit' cannot be null",
                    new ArgumentNullException("measurement_unit")
                );
        }
        init
        {
            this._rawData["measurement_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MeterID
    {
        get
        {
            if (!this._rawData.TryGetValue("meter_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'meter_id' cannot be null",
                    new ArgumentOutOfRangeException("meter_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'meter_id' cannot be null",
                    new ArgumentNullException("meter_id")
                );
        }
        init
        {
            this._rawData["meter_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string PricePerUnit
    {
        get
        {
            if (!this._rawData.TryGetValue("price_per_unit", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'price_per_unit' cannot be null",
                    new ArgumentOutOfRangeException("price_per_unit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'price_per_unit' cannot be null",
                    new ArgumentNullException("price_per_unit")
                );
        }
        init
        {
            this._rawData["price_per_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.MeasurementUnit;
        _ = this.MeterID;
        _ = this.Name;
        _ = this.PricePerUnit;
        _ = this.Description;
    }

    public Meter() { }

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRaw<Meter>
{
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}
