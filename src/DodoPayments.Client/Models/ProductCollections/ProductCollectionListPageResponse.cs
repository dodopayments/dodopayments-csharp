using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionListPageResponse,
        ProductCollectionListPageResponseFromRaw
    >)
)]
public sealed record class ProductCollectionListPageResponse : JsonModel
{
    public required IReadOnlyList<ProductCollectionListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductCollectionListResponse>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCollectionListResponse>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public ProductCollectionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionListPageResponse(
        ProductCollectionListPageResponse productCollectionListPageResponse
    )
        : base(productCollectionListPageResponse) { }
#pragma warning restore CS8618

    public ProductCollectionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProductCollectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductCollectionListPageResponse(IReadOnlyList<ProductCollectionListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class ProductCollectionListPageResponseFromRaw : IFromRawJson<ProductCollectionListPageResponse>
{
    /// <inheritdoc/>
    public ProductCollectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionListPageResponse.FromRawUnchecked(rawData);
}
