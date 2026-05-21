using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(typeof(JsonModelConverter<ProductCollection, ProductCollectionFromRaw>))]
public sealed record class ProductCollection : JsonModel
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
    public required IReadOnlyList<ProductCollectionGroupResponse> Groups
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductCollectionGroupResponse>>(
                "groups"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCollectionGroupResponse>>(
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

    public ProductCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollection(ProductCollection productCollection)
        : base(productCollection) { }
#pragma warning restore CS8618

    public ProductCollection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionFromRaw.FromRawUnchecked"/>
    public static ProductCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionFromRaw : IFromRawJson<ProductCollection>
{
    /// <inheritdoc/>
    public ProductCollection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductCollection.FromRawUnchecked(rawData);
}
