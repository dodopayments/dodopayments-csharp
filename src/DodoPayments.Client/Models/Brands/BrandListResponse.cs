using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandListResponse, BrandListResponseFromRaw>))]
public sealed record class BrandListResponse : ModelBase
{
    /// <summary>
    /// List of brands for this business
    /// </summary>
    public required IReadOnlyList<Brand> Items
    {
        get { return ModelBase.GetNotNullClass<List<Brand>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public BrandListResponse() { }

    public BrandListResponse(BrandListResponse brandListResponse)
        : base(brandListResponse) { }

    public BrandListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandListResponseFromRaw.FromRawUnchecked"/>
    public static BrandListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandListResponse(List<Brand> items)
        : this()
    {
        this.Items = items;
    }
}

class BrandListResponseFromRaw : IFromRaw<BrandListResponse>
{
    /// <inheritdoc/>
    public BrandListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandListResponse.FromRawUnchecked(rawData);
}
