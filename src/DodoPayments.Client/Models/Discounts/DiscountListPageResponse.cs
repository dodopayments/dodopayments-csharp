using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

[JsonConverter(
    typeof(JsonModelConverter<DiscountListPageResponse, DiscountListPageResponseFromRaw>)
)]
public sealed record class DiscountListPageResponse : JsonModel
{
    /// <summary>
    /// Array of active (non-deleted) discounts for the current page.
    /// </summary>
    public required IReadOnlyList<Discount> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Discount>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Discount>>(
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

    public DiscountListPageResponse() { }

    public DiscountListPageResponse(DiscountListPageResponse discountListPageResponse)
        : base(discountListPageResponse) { }

    public DiscountListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountListPageResponseFromRaw.FromRawUnchecked"/>
    public static DiscountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscountListPageResponse(IReadOnlyList<Discount> items)
        : this()
    {
        this.Items = items;
    }
}

class DiscountListPageResponseFromRaw : IFromRawJson<DiscountListPageResponse>
{
    /// <inheritdoc/>
    public DiscountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DiscountListPageResponse.FromRawUnchecked(rawData);
}
