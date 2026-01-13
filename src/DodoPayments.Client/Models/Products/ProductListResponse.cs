using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<ProductListResponse, ProductListResponseFromRaw>))]
public sealed record class ProductListResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get { return this._rawData.GetNotNullStruct<bool>("is_recurring"); }
        init { this._rawData.Set("is_recurring", value); }
    }

    /// <summary>
    /// Additional custom data associated with the product
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get { return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata"); }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get { return this._rawData.GetNotNullClass<string>("product_id"); }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Tax category associated with the product.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, TaxCategory>>("tax_category"); }
        init { this._rawData.Set("tax_category", value); }
    }

    /// <summary>
    /// Timestamp when the product was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Currency of the price
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get { return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Description of the product, optional.
    /// </summary>
    public string? Description
    {
        get { return this._rawData.GetNullableClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// URL of the product image, optional.
    /// </summary>
    public string? Image
    {
        get { return this._rawData.GetNullableClass<string>("image"); }
        init { this._rawData.Set("image", value); }
    }

    /// <summary>
    /// Name of the product, optional.
    /// </summary>
    public string? Name
    {
        get { return this._rawData.GetNullableClass<string>("name"); }
        init { this._rawData.Set("name", value); }
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
        get { return this._rawData.GetNullableStruct<int>("price"); }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Details of the price
    /// </summary>
    public Price? PriceDetail
    {
        get { return this._rawData.GetNullableClass<Price>("price_detail"); }
        init { this._rawData.Set("price_detail", value); }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive
    /// </summary>
    public bool? TaxInclusive
    {
        get { return this._rawData.GetNullableStruct<bool>("tax_inclusive"); }
        init { this._rawData.Set("tax_inclusive", value); }
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

    public ProductListResponse() { }

    public ProductListResponse(ProductListResponse productListResponse)
        : base(productListResponse) { }

    public ProductListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseFromRaw.FromRawUnchecked"/>
    public static ProductListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListResponseFromRaw : IFromRawJson<ProductListResponse>
{
    /// <inheritdoc/>
    public ProductListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductListResponse.FromRawUnchecked(rawData);
}
