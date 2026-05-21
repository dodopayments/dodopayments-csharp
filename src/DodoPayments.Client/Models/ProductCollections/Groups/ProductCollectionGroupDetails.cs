using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.ProductCollections.Groups;

[JsonConverter(
    typeof(JsonModelConverter<ProductCollectionGroupDetails, ProductCollectionGroupDetailsFromRaw>)
)]
public sealed record class ProductCollectionGroupDetails : JsonModel
{
    /// <summary>
    /// Products in this group
    /// </summary>
    public required IReadOnlyList<GroupProduct> Products
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GroupProduct>>("products");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroupProduct>>(
                "products",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional group name. Multiple groups can have null names, but named groups
    /// must be unique per collection
    /// </summary>
    public string? GroupName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group_name");
        }
        init { this._rawData.Set("group_name", value); }
    }

    /// <summary>
    /// Status of the group (defaults to true if not provided)
    /// </summary>
    public bool? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Products)
        {
            item.Validate();
        }
        _ = this.GroupName;
        _ = this.Status;
    }

    public ProductCollectionGroupDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionGroupDetails(
        ProductCollectionGroupDetails productCollectionGroupDetails
    )
        : base(productCollectionGroupDetails) { }
#pragma warning restore CS8618

    public ProductCollectionGroupDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionGroupDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionGroupDetailsFromRaw.FromRawUnchecked"/>
    public static ProductCollectionGroupDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductCollectionGroupDetails(IReadOnlyList<GroupProduct> products)
        : this()
    {
        this.Products = products;
    }
}

class ProductCollectionGroupDetailsFromRaw : IFromRawJson<ProductCollectionGroupDetails>
{
    /// <inheritdoc/>
    public ProductCollectionGroupDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionGroupDetails.FromRawUnchecked(rawData);
}
