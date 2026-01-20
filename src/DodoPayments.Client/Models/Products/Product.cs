using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : JsonModel
{
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_recurring");
        }
        init { this._rawData.Set("is_recurring", value); }
    }

    /// <summary>
    /// Indicates whether the product requires a license key.
    /// </summary>
    public required bool LicenseKeyEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("license_key_enabled");
        }
        init { this._rawData.Set("license_key_enabled", value); }
    }

    /// <summary>
    /// Additional custom data associated with the product
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Pricing information for the product.
    /// </summary>
    public required Price Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Price>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Unique identifier for the product.
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
    /// Tax category associated with the product.
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
    /// Timestamp when the product was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Description of the product, optional.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public ProductDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductDigitalProductDelivery>(
                "digital_product_delivery"
            );
        }
        init { this._rawData.Set("digital_product_delivery", value); }
    }

    /// <summary>
    /// URL of the product image, optional.
    /// </summary>
    public string? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image");
        }
        init { this._rawData.Set("image", value); }
    }

    /// <summary>
    /// Message sent upon license key activation, if applicable.
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_key_activation_message");
        }
        init { this._rawData.Set("license_key_activation_message", value); }
    }

    /// <summary>
    /// Limit on the number of activations for the license key, if enabled.
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("license_key_activations_limit");
        }
        init { this._rawData.Set("license_key_activations_limit", value); }
    }

    /// <summary>
    /// Duration of the license key validity, if enabled.
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LicenseKeyDuration>("license_key_duration");
        }
        init { this._rawData.Set("license_key_duration", value); }
    }

    /// <summary>
    /// Name of the product, optional.
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
    /// The product collection ID this product belongs to, if any
    /// </summary>
    public string? ProductCollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_collection_id");
        }
        init { this._rawData.Set("product_collection_id", value); }
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
        _ = this.ProductCollectionID;
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
}

class ProductFromRaw : IFromRawJson<Product>
{
    /// <inheritdoc/>
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ProductDigitalProductDelivery, ProductDigitalProductDeliveryFromRaw>)
)]
public sealed record class ProductDigitalProductDelivery : JsonModel
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public IReadOnlyList<File>? Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>?>(
                "files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalUrl;
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductDigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ProductDigitalProductDeliveryFromRaw : IFromRawJson<ProductDigitalProductDelivery>
{
    /// <inheritdoc/>
    public ProductDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDigitalProductDelivery.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_name");
        }
        init { this._rawData.Set("file_name", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
        _ = this.Url;
    }

    public File() { }

    public File(File file)
        : base(file) { }

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}
