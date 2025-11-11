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

[JsonConverter(typeof(ModelConverter<SubscriptionPlanChangedWebhookEvent>))]
public sealed record class SubscriptionPlanChangedWebhookEvent
    : ModelBase,
        IFromRaw<SubscriptionPlanChangedWebhookEvent>
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this._properties.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        init
        {
            this._properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required Data39 Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Data39>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTime Timestamp
    {
        get
        {
            if (!this._properties.TryGetValue("timestamp", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'timestamp' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timestamp",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, Type39> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Type39>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public SubscriptionPlanChangedWebhookEvent() { }

    public SubscriptionPlanChangedWebhookEvent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPlanChangedWebhookEvent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SubscriptionPlanChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(ModelConverter<Data39>))]
public sealed record class Data39 : ModelBase, IFromRaw<Data39>
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required List<AddonCartResponseItem> Addons
    {
        get
        {
            if (!this._properties.TryGetValue("addons", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'addons' cannot be null",
                    new System::ArgumentOutOfRangeException("addons", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<AddonCartResponseItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'addons' cannot be null",
                    new System::ArgumentNullException("addons")
                );
        }
        init
        {
            this._properties["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BillingAddress Billing
    {
        get
        {
            if (!this._properties.TryGetValue("billing", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new System::ArgumentOutOfRangeException("billing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BillingAddress>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'billing' cannot be null",
                    new System::ArgumentNullException("billing")
                );
        }
        init
        {
            this._properties["billing"] = JsonSerializer.SerializeToElement(
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
            if (
                !this._properties.TryGetValue(
                    "cancel_at_next_billing_date",
                    out JsonElement element
                )
            )
                throw new DodoPaymentsInvalidDataException(
                    "'cancel_at_next_billing_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cancel_at_next_billing_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cancel_at_next_billing_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this._properties.TryGetValue("customer", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentNullException("customer")
                );
        }
        init
        {
            this._properties["customer"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("meters", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'meters' cannot be null",
                    new System::ArgumentOutOfRangeException("meters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Meter>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'meters' cannot be null",
                    new System::ArgumentNullException("meters")
                );
        }
        init
        {
            this._properties["meters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required System::DateTime NextBillingDate
    {
        get
        {
            if (!this._properties.TryGetValue("next_billing_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'next_billing_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "next_billing_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["next_billing_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("on_demand", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'on_demand' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "on_demand",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["on_demand"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("payment_frequency_count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_frequency_count' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "payment_frequency_count",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["payment_frequency_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            if (
                !this._properties.TryGetValue("payment_frequency_interval", out JsonElement element)
            )
                throw new DodoPaymentsInvalidDataException(
                    "'payment_frequency_interval' cannot be null",
                    new System::ArgumentOutOfRangeException(
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
            this._properties["payment_frequency_interval"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required System::DateTime PreviousBillingDate
    {
        get
        {
            if (!this._properties.TryGetValue("previous_billing_date", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'previous_billing_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "previous_billing_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["previous_billing_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentNullException("product_id")
                );
        }
        init
        {
            this._properties["product_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("recurring_pre_tax_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'recurring_pre_tax_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "recurring_pre_tax_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["recurring_pre_tax_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("subscription_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "subscription_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'subscription_id' cannot be null",
                    new System::ArgumentNullException("subscription_id")
                );
        }
        init
        {
            this._properties["subscription_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("subscription_period_count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_period_count' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "subscription_period_count",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["subscription_period_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "subscription_period_interval",
                    out JsonElement element
                )
            )
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_period_interval' cannot be null",
                    new System::ArgumentOutOfRangeException(
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
            this._properties["subscription_period_interval"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tax_inclusive", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'tax_inclusive' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_inclusive",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tax_inclusive"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("trial_period_days", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'trial_period_days' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "trial_period_days",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["trial_period_days"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public System::DateTime? CancelledAt
    {
        get
        {
            if (!this._properties.TryGetValue("cancelled_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cancelled_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("discount_cycles_remaining", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["discount_cycles_remaining"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["discount_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the subscription will expire
    /// </summary>
    public System::DateTime? ExpiresAt
    {
        get
        {
            if (!this._properties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["expires_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PayloadType39>? PayloadType
    {
        get
        {
            if (!this._properties.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PayloadType39>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator Subscription(Data39 data39) =>
        new()
        {
            Addons = data39.Addons,
            Billing = data39.Billing,
            CancelAtNextBillingDate = data39.CancelAtNextBillingDate,
            CreatedAt = data39.CreatedAt,
            Currency = data39.Currency,
            Customer = data39.Customer,
            Metadata = data39.Metadata,
            Meters = data39.Meters,
            NextBillingDate = data39.NextBillingDate,
            OnDemand = data39.OnDemand,
            PaymentFrequencyCount = data39.PaymentFrequencyCount,
            PaymentFrequencyInterval = data39.PaymentFrequencyInterval,
            PreviousBillingDate = data39.PreviousBillingDate,
            ProductID = data39.ProductID,
            Quantity = data39.Quantity,
            RecurringPreTaxAmount = data39.RecurringPreTaxAmount,
            Status = data39.Status,
            SubscriptionID = data39.SubscriptionID,
            SubscriptionPeriodCount = data39.SubscriptionPeriodCount,
            SubscriptionPeriodInterval = data39.SubscriptionPeriodInterval,
            TaxInclusive = data39.TaxInclusive,
            TrialPeriodDays = data39.TrialPeriodDays,
            CancelledAt = data39.CancelledAt,
            DiscountCyclesRemaining = data39.DiscountCyclesRemaining,
            DiscountID = data39.DiscountID,
            ExpiresAt = data39.ExpiresAt,
            TaxID = data39.TaxID,
        };

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
        _ = this.TaxID;
        this.PayloadType?.Validate();
    }

    public Data39() { }

    public Data39(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data39(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Data39 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<IntersectionMember139>))]
public sealed record class IntersectionMember139 : ModelBase, IFromRaw<IntersectionMember139>
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, PayloadType39>? PayloadType
    {
        get
        {
            if (!this._properties.TryGetValue("payload_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PayloadType39>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["payload_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public IntersectionMember139() { }

    public IntersectionMember139(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember139(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static IntersectionMember139 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(PayloadType39Converter))]
public enum PayloadType39
{
    Subscription,
}

sealed class PayloadType39Converter : JsonConverter<PayloadType39>
{
    public override PayloadType39 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Subscription" => PayloadType39.Subscription,
            _ => (PayloadType39)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayloadType39 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayloadType39.Subscription => "Subscription",
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
[JsonConverter(typeof(Type39Converter))]
public enum Type39
{
    SubscriptionPlanChanged,
}

sealed class Type39Converter : JsonConverter<Type39>
{
    public override Type39 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.plan_changed" => Type39.SubscriptionPlanChanged,
            _ => (Type39)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type39 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type39.SubscriptionPlanChanged => "subscription.plan_changed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
