using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Licenses;

[JsonConverter(typeof(ModelConverter<LicenseActivateResponse, LicenseActivateResponseFromRaw>))]
public sealed record class LicenseActivateResponse : ModelBase
{
    /// <summary>
    /// License key instance ID
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Business ID
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Limited customer details associated with the license key.
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerLimitedDetails>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Associated license key ID
    /// </summary>
    public required string LicenseKeyID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "license_key_id"); }
        init { ModelBase.Set(this._rawData, "license_key_id", value); }
    }

    /// <summary>
    /// Instance name
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Related product info. Present if the license key is tied to a product.
    /// </summary>
    public required Product Product
    {
        get { return ModelBase.GetNotNullClass<Product>(this.RawData, "product"); }
        init { ModelBase.Set(this._rawData, "product", value); }
    }

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

    public LicenseActivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseActivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LicenseActivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseActivateResponseFromRaw : IFromRaw<LicenseActivateResponse>
{
    public LicenseActivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseActivateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Related product info. Present if the license key is tied to a product.
/// </summary>
[JsonConverter(typeof(ModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : ModelBase
{
    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { ModelBase.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// Name of the product, if set by the merchant.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Name;
    }

    public Product() { }

    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class ProductFromRaw : IFromRaw<Product>
{
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}
