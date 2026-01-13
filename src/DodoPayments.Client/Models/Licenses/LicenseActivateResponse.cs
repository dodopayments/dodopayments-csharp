using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Licenses;

[JsonConverter(typeof(JsonModelConverter<LicenseActivateResponse, LicenseActivateResponseFromRaw>))]
public sealed record class LicenseActivateResponse : JsonModel
{
    /// <summary>
    /// License key instance ID
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Business ID
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Limited customer details associated with the license key.
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get { return this._rawData.GetNotNullClass<CustomerLimitedDetails>("customer"); }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Associated license key ID
    /// </summary>
    public required string LicenseKeyID
    {
        get { return this._rawData.GetNotNullClass<string>("license_key_id"); }
        init { this._rawData.Set("license_key_id", value); }
    }

    /// <summary>
    /// Instance name
    /// </summary>
    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Related product info. Present if the license key is tied to a product.
    /// </summary>
    public required Product Product
    {
        get { return this._rawData.GetNotNullClass<Product>("product"); }
        init { this._rawData.Set("product", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Customer.Validate();
        _ = this.LicenseKeyID;
        _ = this.Name;
        this.Product.Validate();
    }

    public LicenseActivateResponse() { }

    public LicenseActivateResponse(LicenseActivateResponse licenseActivateResponse)
        : base(licenseActivateResponse) { }

    public LicenseActivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseActivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseActivateResponseFromRaw.FromRawUnchecked"/>
    public static LicenseActivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseActivateResponseFromRaw : IFromRawJson<LicenseActivateResponse>
{
    /// <inheritdoc/>
    public LicenseActivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseActivateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Related product info. Present if the license key is tied to a product.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : JsonModel
{
    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get { return this._rawData.GetNotNullClass<string>("product_id"); }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Name of the product, if set by the merchant.
    /// </summary>
    public string? Name
    {
        get { return this._rawData.GetNullableClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Name;
    }

    public Product() { }

    public Product(Product product)
        : base(product) { }

    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductFromRaw.FromRawUnchecked"/>
    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Product(string productID)
        : this()
    {
        this.ProductID = productID;
    }
}

class ProductFromRaw : IFromRawJson<Product>
{
    /// <inheritdoc/>
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}
