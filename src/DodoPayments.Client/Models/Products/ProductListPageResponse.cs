using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<ProductListPageResponse, ProductListPageResponseFromRaw>))]
public sealed record class ProductListPageResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get { return JsonModel.GetNotNullClass<List<Item>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public ProductListPageResponse() { }

    public ProductListPageResponse(ProductListPageResponse productListPageResponse)
        : base(productListPageResponse) { }

    public ProductListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProductListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListPageResponse(List<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class ProductListPageResponseFromRaw : IFromRawJson<ProductListPageResponse>
{
    /// <inheritdoc/>
    public ProductListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_recurring"); }
        init { JsonModel.Set(this._rawData, "is_recurring", value); }
    }

    /// <summary>
    /// Additional custom data associated with the product
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// Tax category associated with the product.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TaxCategory>>(
                this.RawData,
                "tax_category"
            );
        }
        init { JsonModel.Set(this._rawData, "tax_category", value); }
    }

    /// <summary>
    /// Timestamp when the product was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "updated_at"); }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// Currency of the price
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Description of the product, optional.
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// URL of the product image, optional.
    /// </summary>
    public string? Image
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "image"); }
        init { JsonModel.Set(this._rawData, "image", value); }
    }

    /// <summary>
    /// Name of the product, optional.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Price of the product, optional.
    ///
    /// <para>The price is represented in the lowest denomination of the currency.
    /// For example: - In USD, a price of `$12.34` would be represented as `1234`
    /// (cents). - In JPY, a price of `¥1500` would be represented as `1500` (yen).
    /// - In INR, a price of `₹1234.56` would be represented as `123456` (paise).</para>
    ///
    /// <para>This ensures precision and avoids floating-point rounding errors.</para>
    /// </summary>
    public int? Price
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawData, "price"); }
        init { JsonModel.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// Details of the price
    /// </summary>
    public Price? PriceDetail
    {
        get { return JsonModel.GetNullableClass<Price>(this.RawData, "price_detail"); }
        init { JsonModel.Set(this._rawData, "price_detail", value); }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive
    /// </summary>
    public bool? TaxInclusive
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "tax_inclusive"); }
        init { JsonModel.Set(this._rawData, "tax_inclusive", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsRecurring;
        _ = this.Metadata;
        _ = this.ProductID;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        this.Currency?.Validate();
        _ = this.Description;
        _ = this.Image;
        _ = this.Name;
        _ = this.Price;
        this.PriceDetail?.Validate();
        _ = this.TaxInclusive;
    }

    public Item() { }

    public Item(Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
