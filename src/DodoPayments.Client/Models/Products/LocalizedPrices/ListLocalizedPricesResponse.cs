using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.LocalizedPrices;

[JsonConverter(
    typeof(JsonModelConverter<ListLocalizedPricesResponse, ListLocalizedPricesResponseFromRaw>)
)]
public sealed record class ListLocalizedPricesResponse : JsonModel
{
    public required IReadOnlyList<LocalizedPrice> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LocalizedPrice>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LocalizedPrice>>(
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

    public ListLocalizedPricesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListLocalizedPricesResponse(ListLocalizedPricesResponse listLocalizedPricesResponse)
        : base(listLocalizedPricesResponse) { }
#pragma warning restore CS8618

    public ListLocalizedPricesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListLocalizedPricesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListLocalizedPricesResponseFromRaw.FromRawUnchecked"/>
    public static ListLocalizedPricesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ListLocalizedPricesResponse(IReadOnlyList<LocalizedPrice> items)
        : this()
    {
        this.Items = items;
    }
}

class ListLocalizedPricesResponseFromRaw : IFromRawJson<ListLocalizedPricesResponse>
{
    /// <inheritdoc/>
    public ListLocalizedPricesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListLocalizedPricesResponse.FromRawUnchecked(rawData);
}
