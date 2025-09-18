using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using RecurringPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.RecurringPriceProperties;

namespace DodoPayments.Client.Models.Products.PriceProperties;

/// <summary>
/// Recurring price details.
/// </summary>
[JsonConverter(typeof(ModelConverter<RecurringPrice>))]
public sealed record class RecurringPrice : ModelBase, IFromRaw<RecurringPrice>
{
    /// <summary>
    /// The currency in which the payment is made.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Discount applied to the price, represented as a percentage (0 to 100).
    /// </summary>
    public required long Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new ArgumentOutOfRangeException("discount", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of units for the payment frequency. For example, a value of `1` with
    /// a `payment_frequency_interval` of `month` represents monthly payments.
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_frequency_count", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "payment_frequency_count",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_frequency_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time interval for the payment frequency (e.g., day, month, year).
    /// </summary>
    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_frequency_interval", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "payment_frequency_interval",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["payment_frequency_interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The payment amount. Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public required int Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if purchasing power parity adjustments are applied to the price.
    /// Purchasing power parity feature is not available as of now
    /// </summary>
    public required bool PurchasingPowerParity
    {
        get
        {
            if (!this.Properties.TryGetValue("purchasing_power_parity", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "purchasing_power_parity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["purchasing_power_parity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of units for the subscription period. For example, a value of `12`
    /// with a `subscription_period_interval` of `month` represents a one-year subscription.
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_period_count", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "subscription_period_count",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["subscription_period_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time interval for the subscription period (e.g., day, month, year).
    /// </summary>
    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "subscription_period_interval",
                    out JsonElement element
                )
            )
                throw new ArgumentOutOfRangeException(
                    "subscription_period_interval",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TimeInterval>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["subscription_period_interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, RecurringPriceProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, RecurringPriceProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive
    /// </summary>
    public bool? TaxInclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_inclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax_inclusive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of days for the trial period. A value of `0` indicates no trial period.
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trial_period_days"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.Discount;
        _ = this.PaymentFrequencyCount;
        this.PaymentFrequencyInterval.Validate();
        _ = this.Price;
        _ = this.PurchasingPowerParity;
        _ = this.SubscriptionPeriodCount;
        this.SubscriptionPeriodInterval.Validate();
        this.Type.Validate();
        _ = this.TaxInclusive;
        _ = this.TrialPeriodDays;
    }

    public RecurringPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RecurringPrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
