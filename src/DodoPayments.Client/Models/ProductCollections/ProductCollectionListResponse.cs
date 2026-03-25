using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(
    typeof(JsonModelConverter<ProductCollectionListResponse, ProductCollectionListResponseFromRaw>)
)]
public sealed record class ProductCollectionListResponse : JsonModel
{
    /// <summary>
    /// Collection ID
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
    /// Timestamp when created
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
    /// Collection name
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
    /// Number of products in the collection
    /// </summary>
    public required long ProductsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("products_count");
        }
        init { this._rawData.Set("products_count", value); }
    }

    /// <summary>
    /// Timestamp when last updated
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
    /// Collection description
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
    /// Collection image URL
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
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.ProductsCount;
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.Image;
    }

    public ProductCollectionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionListResponse(
        ProductCollectionListResponse productCollectionListResponse
    )
        : base(productCollectionListResponse) { }
#pragma warning restore CS8618

    public ProductCollectionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionListResponseFromRaw.FromRawUnchecked"/>
    public static ProductCollectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionListResponseFromRaw : IFromRawJson<ProductCollectionListResponse>
{
    /// <inheritdoc/>
    public ProductCollectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionListResponse.FromRawUnchecked(rawData);
}
