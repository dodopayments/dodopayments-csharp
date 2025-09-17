using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Subscriptions;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;
using RecurringPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.RecurringPriceProperties;
using System = System;

namespace DodoPayments.Client.Models.Products.PriceProperties;

/// <summary>
/// Recurring price details.
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<RecurringPrice>))]
public sealed record class RecurringPrice : Client::ModelBase, Client::IFromRaw<RecurringPrice>
{
    /// <summary>
    /// The currency in which the payment is made.
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Discount applied to the price, represented as a percentage (0 to 100).
    /// </summary>
    public required long Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["discount"] = JsonSerializer.SerializeToElement(value); }
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
                throw new System::ArgumentOutOfRangeException(
                    "payment_frequency_count",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_frequency_count"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The time interval for the payment frequency (e.g., day, month, year).
    /// </summary>
    public required TimeInterval PaymentFrequencyInterval
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_frequency_interval", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "payment_frequency_interval",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TimeInterval>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("payment_frequency_interval");
        }
        set
        {
            this.Properties["payment_frequency_interval"] = JsonSerializer.SerializeToElement(
                value
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
                throw new System::ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
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
                throw new System::ArgumentOutOfRangeException(
                    "purchasing_power_parity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["purchasing_power_parity"] = JsonSerializer.SerializeToElement(value);
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
                throw new System::ArgumentOutOfRangeException(
                    "subscription_period_count",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["subscription_period_count"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The time interval for the subscription period (e.g., day, month, year).
    /// </summary>
    public required TimeInterval SubscriptionPeriodInterval
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "subscription_period_interval",
                    out JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "subscription_period_interval",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TimeInterval>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("subscription_period_interval");
        }
        set
        {
            this.Properties["subscription_period_interval"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required RecurringPriceProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<RecurringPriceProperties::Type>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["tax_inclusive"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["trial_period_days"] = JsonSerializer.SerializeToElement(value); }
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
