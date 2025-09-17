using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Payments;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Subscriptions.SubscriptionListPageResponseProperties;

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<Item>))]
public sealed record class Item : Client::ModelBase, Client::IFromRaw<Item>
{
    /// <summary>
    /// Billing address details for payments
    /// </summary>
    public required BillingAddress Billing
    {
        get
        {
            if (!this.Properties.TryGetValue("billing", out JsonElement element))
                throw new ArgumentOutOfRangeException("billing", "Missing required argument");

            return JsonSerializer.Deserialize<BillingAddress>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("billing");
        }
        set { this.Properties["billing"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue("cancel_at_next_billing_date", out JsonElement element)
            )
                throw new ArgumentOutOfRangeException(
                    "cancel_at_next_billing_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cancel_at_next_billing_date"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Currency used for the subscription payments
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Customer details associated with the subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new ArgumentOutOfRangeException("metadata", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required DateTime NextBillingDate
    {
        get
        {
            if (!this.Properties.TryGetValue("next_billing_date", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "next_billing_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["next_billing_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get
        {
            if (!this.Properties.TryGetValue("on_demand", out JsonElement element))
                throw new ArgumentOutOfRangeException("on_demand", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["on_demand"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of payment frequency intervals
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

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_frequency_count"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Time interval for payment frequency (e.g. month, year)
    /// </summary>
    public required Subscriptions::TimeInterval PaymentFrequencyInterval
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_frequency_interval", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "payment_frequency_interval",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Subscriptions::TimeInterval>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payment_frequency_interval");
        }
        set
        {
            this.Properties["payment_frequency_interval"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required DateTime PreviousBillingDate
    {
        get
        {
            if (!this.Properties.TryGetValue("previous_billing_date", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "previous_billing_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["previous_billing_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("product_id");
        }
        set { this.Properties["product_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of units/items included in the subscription
    /// </summary>
    public required int Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("recurring_pre_tax_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "recurring_pre_tax_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["recurring_pre_tax_amount"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Current status of the subscription
    /// </summary>
    public required Subscriptions::SubscriptionStatus Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<Subscriptions::SubscriptionStatus>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "subscription_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("subscription_id");
        }
        set { this.Properties["subscription_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of subscription period intervals
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

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["subscription_period_count"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Time interval for the subscription period (e.g. month, year)
    /// </summary>
    public required Subscriptions::TimeInterval SubscriptionPeriodInterval
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

            return JsonSerializer.Deserialize<Subscriptions::TimeInterval>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("subscription_period_interval");
        }
        set
        {
            this.Properties["subscription_period_interval"] = JsonSerializer.SerializeToElement(
                value
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
            if (!this.Properties.TryGetValue("tax_inclusive", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_inclusive", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["tax_inclusive"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_days", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "trial_period_days",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["trial_period_days"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public DateTime? CancelledAt
    {
        get
        {
            if (!this.Properties.TryGetValue("cancelled_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["cancelled_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of remaining discount cycles if discount is applied
    /// </summary>
    public int? DiscountCyclesRemaining
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_cycles_remaining", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount_cycles_remaining"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["discount_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Billing.Validate();
        _ = this.CancelAtNextBillingDate;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
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
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
