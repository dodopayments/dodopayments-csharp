using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.ShortLinks;

[JsonConverter(
    typeof(JsonModelConverter<ShortLinkListPageResponse, ShortLinkListPageResponseFromRaw>)
)]
public sealed record class ShortLinkListPageResponse : JsonModel
{
    public required IReadOnlyList<ShortLinkListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ShortLinkListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ShortLinkListResponse>>(
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

    public ShortLinkListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShortLinkListPageResponse(ShortLinkListPageResponse shortLinkListPageResponse)
        : base(shortLinkListPageResponse) { }
#pragma warning restore CS8618

    public ShortLinkListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortLinkListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShortLinkListPageResponseFromRaw.FromRawUnchecked"/>
    public static ShortLinkListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ShortLinkListPageResponse(IReadOnlyList<ShortLinkListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class ShortLinkListPageResponseFromRaw : IFromRawJson<ShortLinkListPageResponse>
{
    /// <inheritdoc/>
    public ShortLinkListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShortLinkListPageResponse.FromRawUnchecked(rawData);
}
