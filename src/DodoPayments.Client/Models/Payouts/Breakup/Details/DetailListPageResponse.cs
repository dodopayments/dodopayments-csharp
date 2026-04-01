using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payouts.Breakup.Details;

/// <summary>
/// Paginated response containing individual payout breakup entries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DetailListPageResponse, DetailListPageResponseFromRaw>))]
public sealed record class DetailListPageResponse : JsonModel
{
    /// <summary>
    /// List of payout breakup detail entries.
    /// </summary>
    public required IReadOnlyList<DetailListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DetailListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DetailListResponse>>(
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

    public DetailListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailListPageResponse(DetailListPageResponse detailListPageResponse)
        : base(detailListPageResponse) { }
#pragma warning restore CS8618

    public DetailListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DetailListPageResponseFromRaw.FromRawUnchecked"/>
    public static DetailListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DetailListPageResponse(IReadOnlyList<DetailListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class DetailListPageResponseFromRaw : IFromRawJson<DetailListPageResponse>
{
    /// <inheritdoc/>
    public DetailListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DetailListPageResponse.FromRawUnchecked(rawData);
}
