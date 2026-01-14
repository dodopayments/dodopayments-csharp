using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// One-time price details.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public record class Price : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Currency> Currency
    {
        get
        {
            return Match(
                oneTime: (x) => x.Currency,
                recurring: (x) => x.Currency,
                usageBased: (x) => x.Currency
            );
        }
    }

    public long Discount
    {
        get
        {
            return Match(
                oneTime: (x) => x.Discount,
                recurring: (x) => x.Discount,
                usageBased: (x) => x.Discount
            );
        }
    }

    public int? Price1
    {
        get
        {
            return Match<int?>(
                oneTime: (x) => x.Price,
                recurring: (x) => x.Price,
                usageBased: (_) => null
            );
        }
    }

    public bool PurchasingPowerParity
    {
        get
        {
            return Match(
                oneTime: (x) => x.PurchasingPowerParity,
                recurring: (x) => x.PurchasingPowerParity,
                usageBased: (x) => x.PurchasingPowerParity
            );
        }
    }

    public bool? TaxInclusive
    {
        get
        {
            return Match<bool?>(
                oneTime: (x) => x.TaxInclusive,
                recurring: (x) => x.TaxInclusive,
                usageBased: (x) => x.TaxInclusive
            );
        }
    }

    public int? PaymentFrequencyCount
    {
        get
        {
            return Match<int?>(
                oneTime: (_) => null,
                recurring: (x) => x.PaymentFrequencyCount,
                usageBased: (x) => x.PaymentFrequencyCount
            );
        }
    }

    public ApiEnum<string, TimeInterval>? PaymentFrequencyInterval
    {
        get
        {
            return Match<ApiEnum<string, TimeInterval>?>(
                oneTime: (_) => null,
                recurring: (x) => x.PaymentFrequencyInterval,
                usageBased: (x) => x.PaymentFrequencyInterval
            );
        }
    }

    public int? SubscriptionPeriodCount
    {
        get
        {
            return Match<int?>(
                oneTime: (_) => null,
                recurring: (x) => x.SubscriptionPeriodCount,
                usageBased: (x) => x.SubscriptionPeriodCount
            );
        }
    }

    public ApiEnum<string, TimeInterval>? SubscriptionPeriodInterval
    {
        get
        {
            return Match<ApiEnum<string, TimeInterval>?>(
                oneTime: (_) => null,
                recurring: (x) => x.SubscriptionPeriodInterval,
                usageBased: (x) => x.SubscriptionPeriodInterval
            );
        }
    }

    public Price(OneTimePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(RecurringPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(UsageBasedPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OneTimePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOneTime(out var value)) {
    ///     // `value` is of type `OneTimePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOneTime([NotNullWhen(true)] out OneTimePrice? value)
    {
        value = this.Value as OneTimePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RecurringPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRecurring(out var value)) {
    ///     // `value` is of type `RecurringPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRecurring([NotNullWhen(true)] out RecurringPrice? value)
    {
        value = this.Value as RecurringPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UsageBasedPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUsageBased(out var value)) {
    ///     // `value` is of type `UsageBasedPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUsageBased([NotNullWhen(true)] out UsageBasedPrice? value)
    {
        value = this.Value as UsageBasedPrice;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (OneTimePrice value) => {...},
    ///     (RecurringPrice value) => {...},
    ///     (UsageBasedPrice value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<OneTimePrice> oneTime,
        System::Action<RecurringPrice> recurring,
        System::Action<UsageBasedPrice> usageBased
    )
    {
        switch (this.Value)
        {
            case OneTimePrice value:
                oneTime(value);
                break;
            case RecurringPrice value:
                recurring(value);
                break;
            case UsageBasedPrice value:
                usageBased(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Price"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (OneTimePrice value) => {...},
    ///     (RecurringPrice value) => {...},
    ///     (UsageBasedPrice value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<OneTimePrice, T> oneTime,
        System::Func<RecurringPrice, T> recurring,
        System::Func<UsageBasedPrice, T> usageBased
    )
    {
        return this.Value switch
        {
            OneTimePrice value => oneTime(value),
            RecurringPrice value => recurring(value),
            UsageBasedPrice value => usageBased(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Price"
            ),
        };
    }

    public static implicit operator Price(OneTimePrice value) => new(value);

    public static implicit operator Price(RecurringPrice value) => new(value);

    public static implicit operator Price(UsageBasedPrice value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Price");
        }
        this.Switch(
            (oneTime) => oneTime.Validate(),
            (recurring) => recurring.Validate(),
            (usageBased) => usageBased.Validate()
        );
    }

    public virtual bool Equals(Price? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class PriceConverter : JsonConverter<Price>
{
    public override Price? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<OneTimePrice>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RecurringPrice>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Price value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// One-time price details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OneTimePrice, OneTimePriceFromRaw>))]
public sealed record class OneTimePrice : JsonModel
{
    /// <summary>
    /// The currency in which the payment is made.
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
    /// Discount applied to the price, represented as a percentage (0 to 100).
    /// </summary>
    public required long Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// The payment amount, in the smallest denomination of the currency (e.g., cents
    /// for USD). For example, to charge $1.00, pass `100`.
    ///
    /// <para>If [`pay_what_you_want`](Self::pay_what_you_want) is set to `true`,
    /// this field represents the **minimum** amount the customer must pay.</para>
    /// </summary>
    public required int Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Indicates if purchasing power parity adjustments are applied to the price.
    /// Purchasing power parity feature is not available as of now.
    /// </summary>
    public required bool PurchasingPowerParity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("purchasing_power_parity");
        }
        init { this._rawData.Set("purchasing_power_parity", value); }
    }

    public required ApiEnum<string, global::DodoPayments.Client.Models.Products.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::DodoPayments.Client.Models.Products.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Indicates whether the customer can pay any amount they choose. If set to `true`,
    /// the [`price`](Self::price) field is the minimum amount.
    /// </summary>
    public bool? PayWhatYouWant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("pay_what_you_want");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pay_what_you_want", value);
        }
    }

    /// <summary>
    /// A suggested price for the user to pay. This value is only considered if [`pay_what_you_want`](Self::pay_what_you_want)
    /// is `true`. Otherwise, it is ignored.
    /// </summary>
    public int? SuggestedPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("suggested_price");
        }
        init { this._rawData.Set("suggested_price", value); }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive.
    /// </summary>
    public bool? TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.Discount;
        _ = this.Price;
        _ = this.PurchasingPowerParity;
        this.Type.Validate();
        _ = this.PayWhatYouWant;
        _ = this.SuggestedPrice;
        _ = this.TaxInclusive;
    }

    public OneTimePrice() { }

    public OneTimePrice(OneTimePrice oneTimePrice)
        : base(oneTimePrice) { }

    public OneTimePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OneTimePriceFromRaw.FromRawUnchecked"/>
    public static OneTimePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OneTimePriceFromRaw : IFromRawJson<OneTimePrice>
{
    /// <inheritdoc/>
    public OneTimePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OneTimePrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::DodoPayments.Client.Models.Products.TypeConverter))]
public enum Type
{
    OneTimePrice,
}

sealed class TypeConverter : JsonConverter<global::DodoPayments.Client.Models.Products.Type>
{
    public override global::DodoPayments.Client.Models.Products.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "one_time_price" => global::DodoPayments.Client.Models.Products.Type.OneTimePrice,
            _ => (global::DodoPayments.Client.Models.Products.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Products.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Products.Type.OneTimePrice => "one_time_price",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Recurring price details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RecurringPrice, RecurringPriceFromRaw>))]
public sealed record class RecurringPrice : JsonModel
{
    /// <summary>
    /// The currency in which the payment is made.
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
    /// Discount applied to the price, represented as a percentage (0 to 100).
    /// </summary>
    public required long Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// Number of units for the payment frequency. For example, a value of `1` with
    /// a `payment_frequency_interval` of `month` represents monthly payments.
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
    /// The time interval for the payment frequency (e.g., day, month, year).
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
    /// The payment amount. Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public required int Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Indicates if purchasing power parity adjustments are applied to the price.
    /// Purchasing power parity feature is not available as of now
    /// </summary>
    public required bool PurchasingPowerParity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("purchasing_power_parity");
        }
        init { this._rawData.Set("purchasing_power_parity", value); }
    }

    /// <summary>
    /// Number of units for the subscription period. For example, a value of `12`
    /// with a `subscription_period_interval` of `month` represents a one-year subscription.
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
    /// The time interval for the subscription period (e.g., day, month, year).
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

    public required ApiEnum<string, RecurringPriceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecurringPriceType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive
    /// </summary>
    public bool? TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <summary>
    /// Number of days for the trial period. A value of `0` indicates no trial period.
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("trial_period_days");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trial_period_days", value);
        }
    }

    /// <inheritdoc/>
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

    public RecurringPrice(RecurringPrice recurringPrice)
        : base(recurringPrice) { }

    public RecurringPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringPriceFromRaw.FromRawUnchecked"/>
    public static RecurringPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringPriceFromRaw : IFromRawJson<RecurringPrice>
{
    /// <inheritdoc/>
    public RecurringPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RecurringPrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecurringPriceTypeConverter))]
public enum RecurringPriceType
{
    RecurringPrice,
}

sealed class RecurringPriceTypeConverter : JsonConverter<RecurringPriceType>
{
    public override RecurringPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recurring_price" => RecurringPriceType.RecurringPrice,
            _ => (RecurringPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecurringPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RecurringPriceType.RecurringPrice => "recurring_price",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Usage Based price details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageBasedPrice, UsageBasedPriceFromRaw>))]
public sealed record class UsageBasedPrice : JsonModel
{
    /// <summary>
    /// The currency in which the payment is made.
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
    /// Discount applied to the price, represented as a percentage (0 to 100).
    /// </summary>
    public required long Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// The fixed payment amount. Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public required int FixedPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("fixed_price");
        }
        init { this._rawData.Set("fixed_price", value); }
    }

    /// <summary>
    /// Number of units for the payment frequency. For example, a value of `1` with
    /// a `payment_frequency_interval` of `month` represents monthly payments.
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
    /// The time interval for the payment frequency (e.g., day, month, year).
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
    /// Indicates if purchasing power parity adjustments are applied to the price.
    /// Purchasing power parity feature is not available as of now
    /// </summary>
    public required bool PurchasingPowerParity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("purchasing_power_parity");
        }
        init { this._rawData.Set("purchasing_power_parity", value); }
    }

    /// <summary>
    /// Number of units for the subscription period. For example, a value of `12`
    /// with a `subscription_period_interval` of `month` represents a one-year subscription.
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
    /// The time interval for the subscription period (e.g., day, month, year).
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

    public required ApiEnum<string, UsageBasedPriceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UsageBasedPriceType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<AddMeterToPrice>? Meters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AddMeterToPrice>>("meters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddMeterToPrice>?>(
                "meters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <inheritdoc/>
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

    public UsageBasedPrice(UsageBasedPrice usageBasedPrice)
        : base(usageBasedPrice) { }

    public UsageBasedPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageBasedPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageBasedPriceFromRaw.FromRawUnchecked"/>
    public static UsageBasedPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageBasedPriceFromRaw : IFromRawJson<UsageBasedPrice>
{
    /// <inheritdoc/>
    public UsageBasedPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageBasedPrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UsageBasedPriceTypeConverter))]
public enum UsageBasedPriceType
{
    UsageBasedPrice,
}

sealed class UsageBasedPriceTypeConverter : JsonConverter<UsageBasedPriceType>
{
    public override UsageBasedPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_based_price" => UsageBasedPriceType.UsageBasedPrice,
            _ => (UsageBasedPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageBasedPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageBasedPriceType.UsageBasedPrice => "usage_based_price",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
