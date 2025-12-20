using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<ProductListPageResponse, ProductListPageResponseFromRaw>))]
public sealed record class ProductListPageResponse : JsonModel
{
    public required IReadOnlyList<ProductListResponse> Items
    {
        get { return JsonModel.GetNotNullClass<List<ProductListResponse>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public ProductListPageResponse() { }

    public ProductListPageResponse(ProductListPageResponse productListPageResponse)
        : base(productListPageResponse) { }

    public ProductListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProductListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListPageResponse(List<ProductListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class ProductListPageResponseFromRaw : IFromRawJson<ProductListPageResponse>
{
    /// <inheritdoc/>
    public ProductListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListPageResponse.FromRawUnchecked(rawData);
}
