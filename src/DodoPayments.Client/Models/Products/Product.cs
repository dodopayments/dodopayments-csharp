using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(ModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : ModelBase
{
    public required string BrandID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "is_recurring"); }
        init { ModelBase.Set(this._rawData, "is_recurring", value); }
    }

    /// <summary>
    /// Indicates whether the product requires a license key.
    /// </summary>
    public required bool LicenseKeyEnabled
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "license_key_enabled"); }
        init { ModelBase.Set(this._rawData, "license_key_enabled", value); }
    }

    /// <summary>
    /// Additional custom data associated with the product
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
    /// Pricing information for the product.
    /// </summary>
    public required Price Price
    {
        get { return ModelBase.GetNotNullClass<Price>(this.RawData, "price"); }
        init { ModelBase.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { ModelBase.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// Tax category associated with the product.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TaxCategory>>(
                this.RawData,
                "tax_category"
            );
        }
        init { ModelBase.Set(this._rawData, "tax_category", value); }
    }

    /// <summary>
    /// Timestamp when the product was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "updated_at"); }
        init { ModelBase.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "addons"); }
        init { ModelBase.Set(this._rawData, "addons", value); }
    }

    /// <summary>
    /// Description of the product, optional.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public ProductDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            return ModelBase.GetNullableClass<ProductDigitalProductDelivery>(
                this.RawData,
                "digital_product_delivery"
            );
        }
        init { ModelBase.Set(this._rawData, "digital_product_delivery", value); }
    }

    /// <summary>
    /// URL of the product image, optional.
    /// </summary>
    public string? Image
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "image"); }
        init { ModelBase.Set(this._rawData, "image", value); }
    }

    /// <summary>
    /// Message sent upon license key activation, if applicable.
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawData,
                "license_key_activation_message"
            );
        }
        init { ModelBase.Set(this._rawData, "license_key_activation_message", value); }
    }

    /// <summary>
    /// Limit on the number of activations for the license key, if enabled.
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            return ModelBase.GetNullableStruct<int>(this.RawData, "license_key_activations_limit");
        }
        init { ModelBase.Set(this._rawData, "license_key_activations_limit", value); }
    }

    /// <summary>
    /// Duration of the license key validity, if enabled.
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            return ModelBase.GetNullableClass<LicenseKeyDuration>(
                this.RawData,
                "license_key_duration"
            );
        }
        init { ModelBase.Set(this._rawData, "license_key_duration", value); }
    }

    /// <summary>
    /// Name of the product, optional.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsRecurring;
        _ = this.LicenseKeyEnabled;
        _ = this.Metadata;
        this.Price.Validate();
        _ = this.ProductID;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        _ = this.Addons;
        _ = this.Description;
        this.DigitalProductDelivery?.Validate();
        _ = this.Image;
        _ = this.LicenseKeyActivationMessage;
        _ = this.LicenseKeyActivationsLimit;
        this.LicenseKeyDuration?.Validate();
        _ = this.Name;
    }

    public Product() { }

    public Product(Product product)
        : base(product) { }

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

    /// <inheritdoc cref="ProductFromRaw.FromRawUnchecked"/>
    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductFromRaw : IFromRaw<Product>
{
    /// <inheritdoc/>
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<ProductDigitalProductDelivery, ProductDigitalProductDeliveryFromRaw>)
)]
public sealed record class ProductDigitalProductDelivery : ModelBase
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_url"); }
        init { ModelBase.Set(this._rawData, "external_url", value); }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public IReadOnlyList<File>? Files
    {
        get { return ModelBase.GetNullableClass<List<File>>(this.RawData, "files"); }
        init { ModelBase.Set(this._rawData, "files", value); }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
    public string? Instructions
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "instructions"); }
        init { ModelBase.Set(this._rawData, "instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalURL;
        foreach (var item in this.Files ?? [])
        {
            item.Validate();
        }
        _ = this.Instructions;
    }

    public ProductDigitalProductDelivery() { }

    public ProductDigitalProductDelivery(
        ProductDigitalProductDelivery productDigitalProductDelivery
    )
        : base(productDigitalProductDelivery) { }

    public ProductDigitalProductDelivery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductDigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductDigitalProductDeliveryFromRaw.FromRawUnchecked"/>
    public static ProductDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductDigitalProductDeliveryFromRaw : IFromRaw<ProductDigitalProductDelivery>
{
    /// <inheritdoc/>
    public ProductDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDigitalProductDelivery.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<File, FileFromRaw>))]
public sealed record class File : ModelBase
{
    public required string FileID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
    }

    public required string FileName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "file_name"); }
        init { ModelBase.Set(this._rawData, "file_name", value); }
    }

    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
        _ = this.URL;
    }

    public File() { }

    public File(File file)
        : base(file) { }

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRaw<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}
