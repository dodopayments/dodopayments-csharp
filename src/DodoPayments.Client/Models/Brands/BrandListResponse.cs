using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandListResponse, BrandListResponseFromRaw>))]
public sealed record class BrandListResponse : JsonModel
{
    /// <summary>
    /// List of brands for this business
    /// </summary>
    public required IReadOnlyList<Brand> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Brand>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Brand>>(
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

    public BrandListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandListResponse(BrandListResponse brandListResponse)
        : base(brandListResponse) { }
#pragma warning restore CS8618

    public BrandListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public BrandListResponse(IReadOnlyList<Brand> items)
        : this()
    {
        this.Items = items;
    }
}

class BrandListResponseFromRaw : IFromRawJson<BrandListResponse>
{
    /// <inheritdoc/>
    public BrandListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandListResponse.FromRawUnchecked(rawData);
}
