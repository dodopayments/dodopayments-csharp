using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.CheckoutSessions;

/// <summary>
/// Data returned by the calculate checkout session API
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionPreviewResponse,
        CheckoutSessionPreviewResponseFromRaw
    >)
)]
public sealed record class CheckoutSessionPreviewResponse : JsonModel
{
    /// <summary>
    /// Billing country
    /// </summary>
    public required ApiEnum<string, CountryCode> BillingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CountryCode>>("billing_country");
        }
        init { this._rawData.Set("billing_country", value); }
    }

    /// <summary>
    /// Currency in which the calculations were made
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
    /// Breakup of the current payment
    /// </summary>
    public required CurrentBreakup CurrentBreakup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CurrentBreakup>("current_breakup");
        }
        init { this._rawData.Set("current_breakup", value); }
    }

    /// <summary>
    /// The total product cart
    /// </summary>
    public required IReadOnlyList<CheckoutSessionPreviewResponseProductCart> ProductCart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CheckoutSessionPreviewResponseProductCart>
            >("product_cart");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckoutSessionPreviewResponseProductCart>>(
                "product_cart",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total calculate price of the product cart
    /// </summary>
    public required int TotalPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_price");
        }
        init { this._rawData.Set("total_price", value); }
    }

    /// <summary>
    /// Breakup of recurring payments (None for one-time only)
    /// </summary>
    public RecurringBreakup? RecurringBreakup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecurringBreakup>("recurring_breakup");
        }
        init { this._rawData.Set("recurring_breakup", value); }
    }

    /// <summary>
    /// Total tax
    /// </summary>
    public int? TotalTax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_tax");
        }
        init { this._rawData.Set("total_tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingCountry.Validate();
        this.Currency.Validate();
        this.CurrentBreakup.Validate();
        foreach (var item in this.ProductCart)
        {
            item.Validate();
        }
        _ = this.TotalPrice;
        this.RecurringBreakup?.Validate();
        _ = this.TotalTax;
    }

    public CheckoutSessionPreviewResponse() { }

    public CheckoutSessionPreviewResponse(
        CheckoutSessionPreviewResponse checkoutSessionPreviewResponse
    )
        : base(checkoutSessionPreviewResponse) { }

    public CheckoutSessionPreviewResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionPreviewResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionPreviewResponseFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionPreviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionPreviewResponseFromRaw : IFromRawJson<CheckoutSessionPreviewResponse>
{
    /// <inheritdoc/>
    public CheckoutSessionPreviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionPreviewResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Breakup of the current payment
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CurrentBreakup, CurrentBreakupFromRaw>))]
public sealed record class CurrentBreakup : JsonModel
{
    /// <summary>
    /// Total discount amount
    /// </summary>
    public required int Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// Subtotal before discount (pre-tax original prices)
    /// </summary>
    public required int Subtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("subtotal");
        }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// Total amount to be charged (final amount after all calculations)
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    /// <summary>
    /// Total tax amount
    /// </summary>
    public int? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Discount;
        _ = this.Subtotal;
        _ = this.TotalAmount;
        _ = this.Tax;
    }

    public CurrentBreakup() { }

    public CurrentBreakup(CurrentBreakup currentBreakup)
        : base(currentBreakup) { }

    public CurrentBreakup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrentBreakup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrentBreakupFromRaw.FromRawUnchecked"/>
    public static CurrentBreakup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrentBreakupFromRaw : IFromRawJson<CurrentBreakup>
{
    /// <inheritdoc/>
    public CurrentBreakup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CurrentBreakup.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CheckoutSessionPreviewResponseProductCart,
        CheckoutSessionPreviewResponseProductCartFromRaw
    >)
)]
public sealed record class CheckoutSessionPreviewResponseProductCart : JsonModel
{
    /// <summary>
    /// the currency in which the calculatiosn were made
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
    /// discounted price
    /// </summary>
    public required int DiscountedPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("discounted_price");
        }
        init { this._rawData.Set("discounted_price", value); }
    }

    /// <summary>
    /// Whether this is a subscription product (affects tax calculation in breakup)
    /// </summary>
    public required bool IsSubscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_subscription");
        }
        init { this._rawData.Set("is_subscription", value); }
    }

    public required bool IsUsageBased
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_usage_based");
        }
        init { this._rawData.Set("is_usage_based", value); }
    }

    public required IReadOnlyList<Meter> Meters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Meter>>("meters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Meter>>(
                "meters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// the product currency
    /// </summary>
    public required ApiEnum<string, Currency> OgCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("og_currency");
        }
        init { this._rawData.Set("og_currency", value); }
    }

    /// <summary>
    /// original price of the product
    /// </summary>
    public required int OgPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("og_price");
        }
        init { this._rawData.Set("og_price", value); }
    }

    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Quanitity
    /// </summary>
    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// tax category
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawData.Set("tax_category", value); }
    }

    /// <summary>
    /// Whether tax is included in the price
    /// </summary>
    public required bool TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <summary>
    /// tax rate
    /// </summary>
    public required int TaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("tax_rate");
        }
        init { this._rawData.Set("tax_rate", value); }
    }

    public IReadOnlyList<Addon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Addon>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Addon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// discount percentage
    /// </summary>
    public int? DiscountAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("discount_amount");
        }
        init { this._rawData.Set("discount_amount", value); }
    }

    /// <summary>
    /// number of cycles the discount will apply
    /// </summary>
    public int? DiscountCycle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("discount_cycle");
        }
        init { this._rawData.Set("discount_cycle", value); }
    }

    /// <summary>
    /// name of the product
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// total tax
    /// </summary>
    public int? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.DiscountedPrice;
        _ = this.IsSubscription;
        _ = this.IsUsageBased;
        foreach (var item in this.Meters)
        {
            item.Validate();
        }
        this.OgCurrency.Validate();
        _ = this.OgPrice;
        _ = this.ProductID;
        _ = this.Quantity;
        this.TaxCategory.Validate();
        _ = this.TaxInclusive;
        _ = this.TaxRate;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.DiscountAmount;
        _ = this.DiscountCycle;
        _ = this.Name;
        _ = this.Tax;
    }

    public CheckoutSessionPreviewResponseProductCart() { }

    public CheckoutSessionPreviewResponseProductCart(
        CheckoutSessionPreviewResponseProductCart checkoutSessionPreviewResponseProductCart
    )
        : base(checkoutSessionPreviewResponseProductCart) { }

    public CheckoutSessionPreviewResponseProductCart(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionPreviewResponseProductCart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionPreviewResponseProductCartFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionPreviewResponseProductCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionPreviewResponseProductCartFromRaw
    : IFromRawJson<CheckoutSessionPreviewResponseProductCart>
{
    /// <inheritdoc/>
    public CheckoutSessionPreviewResponseProductCart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionPreviewResponseProductCart.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : JsonModel
{
    public required string MeasurementUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("measurement_unit");
        }
        init { this._rawData.Set("measurement_unit", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string PricePerUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("price_per_unit");
        }
        init { this._rawData.Set("price_per_unit", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public long? FreeThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("free_threshold");
        }
        init { this._rawData.Set("free_threshold", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MeasurementUnit;
        _ = this.Name;
        _ = this.PricePerUnit;
        _ = this.Description;
        _ = this.FreeThreshold;
    }

    public Meter() { }

    public Meter(Meter meter)
        : base(meter) { }

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFromRaw.FromRawUnchecked"/>
    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRawJson<Meter>
{
    /// <inheritdoc/>
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Addon, AddonFromRaw>))]
public sealed record class Addon : JsonModel
{
    public required string AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("addon_id");
        }
        init { this._rawData.Set("addon_id", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required int DiscountedPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("discounted_price");
        }
        init { this._rawData.Set("discounted_price", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, Currency> OgCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("og_currency");
        }
        init { this._rawData.Set("og_currency", value); }
    }

    public required int OgPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("og_price");
        }
        init { this._rawData.Set("og_price", value); }
    }

    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Represents the different categories of taxation applicable to various products
    /// and services.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawData.Set("tax_category", value); }
    }

    public required bool TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    public required int TaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("tax_rate");
        }
        init { this._rawData.Set("tax_rate", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public int? DiscountAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("discount_amount");
        }
        init { this._rawData.Set("discount_amount", value); }
    }

    public int? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        this.Currency.Validate();
        _ = this.DiscountedPrice;
        _ = this.Name;
        this.OgCurrency.Validate();
        _ = this.OgPrice;
        _ = this.Quantity;
        this.TaxCategory.Validate();
        _ = this.TaxInclusive;
        _ = this.TaxRate;
        _ = this.Description;
        _ = this.DiscountAmount;
        _ = this.Tax;
    }

    public Addon() { }

    public Addon(Addon addon)
        : base(addon) { }

    public Addon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Addon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonFromRaw.FromRawUnchecked"/>
    public static Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonFromRaw : IFromRawJson<Addon>
{
    /// <inheritdoc/>
    public Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addon.FromRawUnchecked(rawData);
}

/// <summary>
/// Breakup of recurring payments (None for one-time only)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RecurringBreakup, RecurringBreakupFromRaw>))]
public sealed record class RecurringBreakup : JsonModel
{
    /// <summary>
    /// Total discount amount
    /// </summary>
    public required int Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// Subtotal before discount (pre-tax original prices)
    /// </summary>
    public required int Subtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("subtotal");
        }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// Total recurring amount including tax
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    /// <summary>
    /// Total tax on recurring payments
    /// </summary>
    public int? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Discount;
        _ = this.Subtotal;
        _ = this.TotalAmount;
        _ = this.Tax;
    }

    public RecurringBreakup() { }

    public RecurringBreakup(RecurringBreakup recurringBreakup)
        : base(recurringBreakup) { }

    public RecurringBreakup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringBreakup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringBreakupFromRaw.FromRawUnchecked"/>
    public static RecurringBreakup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringBreakupFromRaw : IFromRawJson<RecurringBreakup>
{
    /// <inheritdoc/>
    public RecurringBreakup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RecurringBreakup.FromRawUnchecked(rawData);
}
