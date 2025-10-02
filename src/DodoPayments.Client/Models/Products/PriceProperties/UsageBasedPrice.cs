using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using UsageBasedPriceProperties = DodoPayments.Client.Models.Products.PriceProperties.UsageBasedPriceProperties;

namespace DodoPayments.Client.Models.Products.PriceProperties;

/// <summary>
/// Usage Based price details.
/// </summary>
[JsonConverter(typeof(ModelConverter<UsageBasedPrice>))]
public sealed record class UsageBasedPrice : ModelBase, IFromRaw<UsageBasedPrice>
{
    /// <summary>
    /// The currency in which the payment is made.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

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
                throw new DodoPaymentsInvalidDataException(
                    "'discount' cannot be null",
                    new ArgumentOutOfRangeException("discount", "Missing required argument")
                );

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
    /// The fixed payment amount. Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public required int FixedPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'fixed_price' cannot be null",
                    new ArgumentOutOfRangeException("fixed_price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fixed_price"] = JsonSerializer.SerializeToElement(
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
                throw new DodoPaymentsInvalidDataException(
                    "'payment_frequency_count' cannot be null",
                    new ArgumentOutOfRangeException(
                        "payment_frequency_count",
                        "Missing required argument"
                    )
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
        set
        {
            this.Properties["payment_frequency_interval"] = JsonSerializer.SerializeToElement(
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
                throw new DodoPaymentsInvalidDataException(
                    "'purchasing_power_parity' cannot be null",
                    new ArgumentOutOfRangeException(
                        "purchasing_power_parity",
                        "Missing required argument"
                    )
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
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_period_count' cannot be null",
                    new ArgumentOutOfRangeException(
                        "subscription_period_count",
                        "Missing required argument"
                    )
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
        set
        {
            this.Properties["subscription_period_interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, UsageBasedPriceProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, UsageBasedPriceProperties::Type>>(
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

    public List<AddMeterToPrice>? Meters
    {
        get
        {
            if (!this.Properties.TryGetValue("meters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddMeterToPrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["meters"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.Discount;
        _ = this.FixedPrice;
        _ = this.PaymentFrequencyCount;
        this.PaymentFrequencyInterval.Validate();
        _ = this.PurchasingPowerParity;
        _ = this.SubscriptionPeriodCount;
        this.SubscriptionPeriodInterval.Validate();
        this.Type.Validate();
        foreach (var item in this.Meters ?? [])
        {
            item.Validate();
        }
        _ = this.TaxInclusive;
    }

    public UsageBasedPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageBasedPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UsageBasedPrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
