using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionRetrieveResponse,
        ProductCollectionRetrieveResponseFromRaw
    >)
)]
public sealed record class ProductCollectionRetrieveResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the product collection
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Brand ID for the collection
    /// </summary>
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
    /// Timestamp when the collection was created
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
    /// Groups in this collection
    /// </summary>
    public required IReadOnlyList<ProductCollectionRetrieveResponseGroup> Groups
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ProductCollectionRetrieveResponseGroup>
            >("groups");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCollectionRetrieveResponseGroup>>(
                "groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the collection
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Timestamp when the collection was last updated
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
    /// Description of the collection
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

    /// <summary>
    /// URL of the collection image
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BrandID;
        _ = this.CreatedAt;
        foreach (var item in this.Groups)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.Image;
    }

    public ProductCollectionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionRetrieveResponse(
        ProductCollectionRetrieveResponse productCollectionRetrieveResponse
    )
        : base(productCollectionRetrieveResponse) { }
#pragma warning restore CS8618

    public ProductCollectionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ProductCollectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionRetrieveResponseFromRaw : IFromRawJson<ProductCollectionRetrieveResponse>
{
    /// <inheritdoc/>
    public ProductCollectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionRetrieveResponseGroup,
        ProductCollectionRetrieveResponseGroupFromRaw
    >)
)]
public sealed record class ProductCollectionRetrieveResponseGroup : JsonModel
{
    public required string GroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_id");
        }
        init { this._rawData.Set("group_id", value); }
    }

    public required IReadOnlyList<ProductCollectionRetrieveResponseGroupProduct> Products
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ProductCollectionRetrieveResponseGroupProduct>
            >("products");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCollectionRetrieveResponseGroupProduct>>(
                "products",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? GroupName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group_name");
        }
        init { this._rawData.Set("group_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupID;
        foreach (var item in this.Products)
        {
            item.Validate();
        }
        _ = this.Status;
        _ = this.GroupName;
    }

    public ProductCollectionRetrieveResponseGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionRetrieveResponseGroup(
        ProductCollectionRetrieveResponseGroup productCollectionRetrieveResponseGroup
    )
        : base(productCollectionRetrieveResponseGroup) { }
#pragma warning restore CS8618

    public ProductCollectionRetrieveResponseGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionRetrieveResponseGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionRetrieveResponseGroupFromRaw.FromRawUnchecked"/>
    public static ProductCollectionRetrieveResponseGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionRetrieveResponseGroupFromRaw
    : IFromRawJson<ProductCollectionRetrieveResponseGroup>
{
    /// <inheritdoc/>
    public ProductCollectionRetrieveResponseGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionRetrieveResponseGroup.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionRetrieveResponseGroupProduct,
        ProductCollectionRetrieveResponseGroupProductFromRaw
    >)
)]
public sealed record class ProductCollectionRetrieveResponseGroupProduct : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required long AddonsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("addons_count");
        }
        init { this._rawData.Set("addons_count", value); }
    }

    public required long FilesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("files_count");
        }
        init { this._rawData.Set("files_count", value); }
    }

    /// <summary>
    /// Whether this product has any credit entitlements attached
    /// </summary>
    public required bool HasCreditEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_credit_entitlements");
        }
        init { this._rawData.Set("has_credit_entitlements", value); }
    }

    public required bool IsRecurring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_recurring");
        }
        init { this._rawData.Set("is_recurring", value); }
    }

    public required bool LicenseKeyEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("license_key_enabled");
        }
        init { this._rawData.Set("license_key_enabled", value); }
    }

    public required long MetersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("meters_count");
        }
        init { this._rawData.Set("meters_count", value); }
    }

    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public required bool Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
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

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public int? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// One-time price details.
    /// </summary>
    public Price? PriceDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Price>("price_detail");
        }
        init { this._rawData.Set("price_detail", value); }
    }

    /// <summary>
    /// Represents the different categories of taxation applicable to various products
    /// and services.
    /// </summary>
    public ApiEnum<string, TaxCategory>? TaxCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawData.Set("tax_category", value); }
    }

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
        _ = this.ID;
        _ = this.AddonsCount;
        _ = this.FilesCount;
        _ = this.HasCreditEntitlements;
        _ = this.IsRecurring;
        _ = this.LicenseKeyEnabled;
        _ = this.MetersCount;
        _ = this.ProductID;
        _ = this.Status;
        this.Currency?.Validate();
        _ = this.Description;
        _ = this.Name;
        _ = this.Price;
        this.PriceDetail?.Validate();
        this.TaxCategory?.Validate();
        _ = this.TaxInclusive;
    }

    public ProductCollectionRetrieveResponseGroupProduct() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionRetrieveResponseGroupProduct(
        ProductCollectionRetrieveResponseGroupProduct productCollectionRetrieveResponseGroupProduct
    )
        : base(productCollectionRetrieveResponseGroupProduct) { }
#pragma warning restore CS8618

    public ProductCollectionRetrieveResponseGroupProduct(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionRetrieveResponseGroupProduct(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionRetrieveResponseGroupProductFromRaw.FromRawUnchecked"/>
    public static ProductCollectionRetrieveResponseGroupProduct FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionRetrieveResponseGroupProductFromRaw
    : IFromRawJson<ProductCollectionRetrieveResponseGroupProduct>
{
    /// <inheritdoc/>
    public ProductCollectionRetrieveResponseGroupProduct FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionRetrieveResponseGroupProduct.FromRawUnchecked(rawData);
}
