using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups.Items;

namespace DodoPayments.Client.Models.ProductCollections.Groups;

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionGroupResponse,
        ProductCollectionGroupResponseFromRaw
    >)
)]
public sealed record class ProductCollectionGroupResponse : JsonModel
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

    public required IReadOnlyList<ProductCollectionProduct> Products
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductCollectionProduct>>(
                "products"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCollectionProduct>>(
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

    public ProductCollectionGroupResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionGroupResponse(
        ProductCollectionGroupResponse productCollectionGroupResponse
    )
        : base(productCollectionGroupResponse) { }
#pragma warning restore CS8618

    public ProductCollectionGroupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionGroupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionGroupResponseFromRaw.FromRawUnchecked"/>
    public static ProductCollectionGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionGroupResponseFromRaw : IFromRawJson<ProductCollectionGroupResponse>
{
    /// <inheritdoc/>
    public ProductCollectionGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionGroupResponse.FromRawUnchecked(rawData);
}
