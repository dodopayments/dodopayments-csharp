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
    typeof(ModelConverter<SubscriptionUpdatedWebhookEvent, SubscriptionUpdatedWebhookEventFromRaw>)
)]
public sealed record class SubscriptionUpdatedWebhookEvent : ModelBase
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Event-specific data
    /// </summary>
    public required SubscriptionUpdatedWebhookEventData Data
    {
        get
        {
            return ModelBase.GetNotNullClass<SubscriptionUpdatedWebhookEventData>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "timestamp");
        }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, SubscriptionUpdatedWebhookEventType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, SubscriptionUpdatedWebhookEventType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public SubscriptionUpdatedWebhookEvent() { }

    public SubscriptionUpdatedWebhookEvent(
        SubscriptionUpdatedWebhookEvent subscriptionUpdatedWebhookEvent
    )
        : base(subscriptionUpdatedWebhookEvent) { }

    public SubscriptionUpdatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionUpdatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static SubscriptionUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionUpdatedWebhookEventFromRaw : IFromRaw<SubscriptionUpdatedWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionUpdatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        SubscriptionUpdatedWebhookEventData,
        SubscriptionUpdatedWebhookEventDataFromRaw
    >)
)]
public sealed record class SubscriptionUpdatedWebhookEventData : ModelBase
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required IReadOnlyList<AddonCartResponseItem> Addons
    {
        get
        {
            return ModelBase.GetNotNullClass<List<AddonCartResponseItem>>(this.RawData, "addons");
        }
        init { ModelBase.Set(this._rawData, "addons", value); }
    }

    public required BillingAddress Billing
    {
        get { return ModelBase.GetNotNullClass<BillingAddress>(this.RawData, "billing"); }
        init { ModelBase.Set(this._rawData, "billing", value); }
    }

    /// <summary>
    /// Indicates if the subscription will cancel at the next billing date
    /// </summary>
    public required bool CancelAtNextBillingDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<bool>(this.RawData, "cancel_at_next_billing_date");
        }
        init { ModelBase.Set(this._rawData, "cancel_at_next_billing_date", value); }
    }

    /// <summary>
    /// Timestamp when the subscription was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required CustomerLimitedDetails Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Additional custom data associated with the subscription
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Meters associated with this subscription (for usage-based billing)
    /// </summary>
    public required IReadOnlyList<Meter> Meters
    {
        get { return ModelBase.GetNotNullClass<List<Meter>>(this.RawData, "meters"); }
        init { ModelBase.Set(this._rawData, "meters", value); }
    }

    /// <summary>
    /// Timestamp of the next scheduled billing. Indicates the end of current billing period
    /// </summary>
    public required System::DateTimeOffset NextBillingDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "next_billing_date"
            );
        }
        init { ModelBase.Set(this._rawData, "next_billing_date", value); }
    }

    /// <summary>
    /// Wether the subscription is on-demand or not
    /// </summary>
    public required bool OnDemand
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "on_demand"); }
        init { ModelBase.Set(this._rawData, "on_demand", value); }
    }

    /// <summary>
    /// Number of payment frequency intervals
    /// </summary>
    public required int PaymentFrequencyCount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "payment_frequency_count"); }
        init { ModelBase.Set(this._rawData, "payment_frequency_count", value); }
    }

    public required ApiEnum<string, TimeInterval> PaymentFrequencyInterval
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                this.RawData,
                "payment_frequency_interval"
            );
        }
        init { ModelBase.Set(this._rawData, "payment_frequency_interval", value); }
    }

    /// <summary>
    /// Timestamp of the last payment. Indicates the start of current billing period
    /// </summary>
    public required System::DateTimeOffset PreviousBillingDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "previous_billing_date"
            );
        }
        init { ModelBase.Set(this._rawData, "previous_billing_date", value); }
    }

    /// <summary>
    /// Identifier of the product associated with this subscription
    /// </summary>
    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { ModelBase.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// Number of units/items included in the subscription
    /// </summary>
    public required int Quantity
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// Amount charged before tax for each recurring payment in smallest currency
    /// unit (e.g. cents)
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "recurring_pre_tax_amount"); }
        init { ModelBase.Set(this._rawData, "recurring_pre_tax_amount", value); }
    }

    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, SubscriptionStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subscription_id"); }
        init { ModelBase.Set(this._rawData, "subscription_id", value); }
    }

    /// <summary>
    /// Number of subscription period intervals
    /// </summary>
    public required int SubscriptionPeriodCount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "subscription_period_count"); }
        init { ModelBase.Set(this._rawData, "subscription_period_count", value); }
    }

    public required ApiEnum<string, TimeInterval> SubscriptionPeriodInterval
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TimeInterval>>(
                this.RawData,
                "subscription_period_interval"
            );
        }
        init { ModelBase.Set(this._rawData, "subscription_period_interval", value); }
    }

    /// <summary>
    /// Indicates if the recurring_pre_tax_amount is tax inclusive
    /// </summary>
    public required bool TaxInclusive
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_inclusive"); }
        init { ModelBase.Set(this._rawData, "tax_inclusive", value); }
    }

    /// <summary>
    /// Number of days in the trial period (0 if no trial)
    /// </summary>
    public required int TrialPeriodDays
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "trial_period_days"); }
        init { ModelBase.Set(this._rawData, "trial_period_days", value); }
    }

    /// <summary>
    /// Cancelled timestamp if the subscription is cancelled
    /// </summary>
    public System::DateTimeOffset? CancelledAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "cancelled_at"
            );
        }
        init { ModelBase.Set(this._rawData, "cancelled_at", value); }
    }

    /// <summary>
    /// Number of remaining discount cycles if discount is applied
    /// </summary>
    public int? DiscountCyclesRemaining
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "discount_cycles_remaining"); }
        init { ModelBase.Set(this._rawData, "discount_cycles_remaining", value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "discount_id"); }
        init { ModelBase.Set(this._rawData, "discount_id", value); }
    }

    /// <summary>
    /// Timestamp when the subscription will expire
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expires_at");
        }
        init { ModelBase.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// Saved payment method id used for recurring charges
    /// </summary>
    public string? PaymentMethodID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_method_id"); }
        init { ModelBase.Set(this._rawData, "payment_method_id", value); }
    }

    /// <summary>
    /// Tax identifier provided for this subscription (if applicable)
    /// </summary>
    public string? TaxID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tax_id"); }
        init { ModelBase.Set(this._rawData, "tax_id", value); }
    }

    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    public static implicit operator Subscription(
        SubscriptionUpdatedWebhookEventData subscriptionUpdatedWebhookEventData
    ) =>
        new()
        {
            Addons = subscriptionUpdatedWebhookEventData.Addons,
            Billing = subscriptionUpdatedWebhookEventData.Billing,
            CancelAtNextBillingDate = subscriptionUpdatedWebhookEventData.CancelAtNextBillingDate,
            CreatedAt = subscriptionUpdatedWebhookEventData.CreatedAt,
            Currency = subscriptionUpdatedWebhookEventData.Currency,
            Customer = subscriptionUpdatedWebhookEventData.Customer,
            Metadata = subscriptionUpdatedWebhookEventData.Metadata,
            Meters = subscriptionUpdatedWebhookEventData.Meters,
            NextBillingDate = subscriptionUpdatedWebhookEventData.NextBillingDate,
            OnDemand = subscriptionUpdatedWebhookEventData.OnDemand,
            PaymentFrequencyCount = subscriptionUpdatedWebhookEventData.PaymentFrequencyCount,
            PaymentFrequencyInterval = subscriptionUpdatedWebhookEventData.PaymentFrequencyInterval,
            PreviousBillingDate = subscriptionUpdatedWebhookEventData.PreviousBillingDate,
            ProductID = subscriptionUpdatedWebhookEventData.ProductID,
            Quantity = subscriptionUpdatedWebhookEventData.Quantity,
            RecurringPreTaxAmount = subscriptionUpdatedWebhookEventData.RecurringPreTaxAmount,
            Status = subscriptionUpdatedWebhookEventData.Status,
            SubscriptionID = subscriptionUpdatedWebhookEventData.SubscriptionID,
            SubscriptionPeriodCount = subscriptionUpdatedWebhookEventData.SubscriptionPeriodCount,
            SubscriptionPeriodInterval =
                subscriptionUpdatedWebhookEventData.SubscriptionPeriodInterval,
            TaxInclusive = subscriptionUpdatedWebhookEventData.TaxInclusive,
            TrialPeriodDays = subscriptionUpdatedWebhookEventData.TrialPeriodDays,
            CancelledAt = subscriptionUpdatedWebhookEventData.CancelledAt,
            DiscountCyclesRemaining = subscriptionUpdatedWebhookEventData.DiscountCyclesRemaining,
            DiscountID = subscriptionUpdatedWebhookEventData.DiscountID,
            ExpiresAt = subscriptionUpdatedWebhookEventData.ExpiresAt,
            PaymentMethodID = subscriptionUpdatedWebhookEventData.PaymentMethodID,
            TaxID = subscriptionUpdatedWebhookEventData.TaxID,
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

    public SubscriptionUpdatedWebhookEventData() { }

    public SubscriptionUpdatedWebhookEventData(
        SubscriptionUpdatedWebhookEventData subscriptionUpdatedWebhookEventData
    )
        : base(subscriptionUpdatedWebhookEventData) { }

    public SubscriptionUpdatedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionUpdatedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionUpdatedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionUpdatedWebhookEventDataFromRaw : IFromRaw<SubscriptionUpdatedWebhookEventData>
{
    /// <inheritdoc/>
    public SubscriptionUpdatedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionUpdatedWebhookEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        SubscriptionUpdatedWebhookEventDataIntersectionMember1,
        SubscriptionUpdatedWebhookEventDataIntersectionMember1FromRaw
    >)
)]
public sealed record class SubscriptionUpdatedWebhookEventDataIntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType
    >? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType>
            >(this.RawData, "payload_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payload_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayloadType?.Validate();
    }

    public SubscriptionUpdatedWebhookEventDataIntersectionMember1() { }

    public SubscriptionUpdatedWebhookEventDataIntersectionMember1(
        SubscriptionUpdatedWebhookEventDataIntersectionMember1 subscriptionUpdatedWebhookEventDataIntersectionMember1
    )
        : base(subscriptionUpdatedWebhookEventDataIntersectionMember1) { }

    public SubscriptionUpdatedWebhookEventDataIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatedWebhookEventDataIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionUpdatedWebhookEventDataIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static SubscriptionUpdatedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionUpdatedWebhookEventDataIntersectionMember1FromRaw
    : IFromRaw<SubscriptionUpdatedWebhookEventDataIntersectionMember1>
{
    /// <inheritdoc/>
    public SubscriptionUpdatedWebhookEventDataIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionUpdatedWebhookEventDataIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadTypeConverter))]
public enum SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType
{
    Subscription,
}

sealed class SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadTypeConverter
    : JsonConverter<SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType>
{
    public override SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Subscription" =>
                SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType.Subscription,
            _ => (SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionUpdatedWebhookEventDataIntersectionMember1PayloadType.Subscription =>
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
[JsonConverter(typeof(SubscriptionUpdatedWebhookEventTypeConverter))]
public enum SubscriptionUpdatedWebhookEventType
{
    SubscriptionUpdated,
}

sealed class SubscriptionUpdatedWebhookEventTypeConverter
    : JsonConverter<SubscriptionUpdatedWebhookEventType>
{
    public override SubscriptionUpdatedWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.updated" => SubscriptionUpdatedWebhookEventType.SubscriptionUpdated,
            _ => (SubscriptionUpdatedWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUpdatedWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionUpdatedWebhookEventType.SubscriptionUpdated => "subscription.updated",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
