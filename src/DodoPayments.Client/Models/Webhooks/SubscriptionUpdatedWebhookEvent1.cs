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
    typeof(ModelConverter<SubscriptionUpdatedWebhookEvent, SubscriptionUpdatedWebhookEventFromRaw1>)
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
    public required Data20 Data
    {
        get { return ModelBase.GetNotNullClass<Data20>(this.RawData, "data"); }
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
    public required ApiEnum<string, Type20> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Type20>>(this.RawData, "type"); }
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

    /// <inheritdoc cref="SubscriptionUpdatedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static SubscriptionUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionUpdatedWebhookEventFromRaw1 : IFromRaw<SubscriptionUpdatedWebhookEvent>
{
    /// <inheritdoc/>
    public SubscriptionUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionUpdatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event-specific data
/// </summary>
[JsonConverter(typeof(ModelConverter<Data20, Data20FromRaw>))]
public sealed record class Data20 : ModelBase
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
    public ApiEnum<string, Data20IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, Data20IntersectionMember1PayloadType>
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

    public static implicit operator Subscription(Data20 data20) =>
        new()
        {
            Addons = data20.Addons,
            Billing = data20.Billing,
            CancelAtNextBillingDate = data20.CancelAtNextBillingDate,
            CreatedAt = data20.CreatedAt,
            Currency = data20.Currency,
            Customer = data20.Customer,
            Metadata = data20.Metadata,
            Meters = data20.Meters,
            NextBillingDate = data20.NextBillingDate,
            OnDemand = data20.OnDemand,
            PaymentFrequencyCount = data20.PaymentFrequencyCount,
            PaymentFrequencyInterval = data20.PaymentFrequencyInterval,
            PreviousBillingDate = data20.PreviousBillingDate,
            ProductID = data20.ProductID,
            Quantity = data20.Quantity,
            RecurringPreTaxAmount = data20.RecurringPreTaxAmount,
            Status = data20.Status,
            SubscriptionID = data20.SubscriptionID,
            SubscriptionPeriodCount = data20.SubscriptionPeriodCount,
            SubscriptionPeriodInterval = data20.SubscriptionPeriodInterval,
            TaxInclusive = data20.TaxInclusive,
            TrialPeriodDays = data20.TrialPeriodDays,
            CancelledAt = data20.CancelledAt,
            DiscountCyclesRemaining = data20.DiscountCyclesRemaining,
            DiscountID = data20.DiscountID,
            ExpiresAt = data20.ExpiresAt,
            PaymentMethodID = data20.PaymentMethodID,
            TaxID = data20.TaxID,
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

    public Data20() { }

    public Data20(Data20 data20)
        : base(data20) { }

    public Data20(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data20(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Data20FromRaw.FromRawUnchecked"/>
    public static Data20 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data20FromRaw : IFromRaw<Data20>
{
    /// <inheritdoc/>
    public Data20 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data20.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Data20IntersectionMember1, Data20IntersectionMember1FromRaw>))]
public sealed record class Data20IntersectionMember1 : ModelBase
{
    /// <summary>
    /// The type of payload in the data field
    /// </summary>
    public ApiEnum<string, Data20IntersectionMember1PayloadType>? PayloadType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, Data20IntersectionMember1PayloadType>
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

    public Data20IntersectionMember1() { }

    public Data20IntersectionMember1(Data20IntersectionMember1 data20IntersectionMember1)
        : base(data20IntersectionMember1) { }

    public Data20IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data20IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Data20IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static Data20IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Data20IntersectionMember1FromRaw : IFromRaw<Data20IntersectionMember1>
{
    /// <inheritdoc/>
    public Data20IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => Data20IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(Data20IntersectionMember1PayloadTypeConverter))]
public enum Data20IntersectionMember1PayloadType
{
    Subscription,
}

sealed class Data20IntersectionMember1PayloadTypeConverter
    : JsonConverter<Data20IntersectionMember1PayloadType>
{
    public override Data20IntersectionMember1PayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Subscription" => Data20IntersectionMember1PayloadType.Subscription,
            _ => (Data20IntersectionMember1PayloadType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Data20IntersectionMember1PayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Data20IntersectionMember1PayloadType.Subscription => "Subscription",
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
[JsonConverter(typeof(Type20Converter))]
public enum Type20
{
    SubscriptionUpdated,
}

sealed class Type20Converter : JsonConverter<Type20>
{
    public override Type20 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription.updated" => Type20.SubscriptionUpdated,
            _ => (Type20)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type20 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type20.SubscriptionUpdated => "subscription.updated",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
