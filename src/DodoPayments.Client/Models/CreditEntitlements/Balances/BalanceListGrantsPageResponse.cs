using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

[JsonConverter(
    typeof(JsonModelConverter<BalanceListGrantsPageResponse, BalanceListGrantsPageResponseFromRaw>)
)]
public sealed record class BalanceListGrantsPageResponse : JsonModel
{
    public required IReadOnlyList<BalanceListGrantsResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BalanceListGrantsResponse>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BalanceListGrantsResponse>>(
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

    public BalanceListGrantsPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceListGrantsPageResponse(
        BalanceListGrantsPageResponse balanceListGrantsPageResponse
    )
        : base(balanceListGrantsPageResponse) { }
#pragma warning restore CS8618

    public BalanceListGrantsPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceListGrantsPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceListGrantsPageResponseFromRaw.FromRawUnchecked"/>
    public static BalanceListGrantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BalanceListGrantsPageResponse(IReadOnlyList<BalanceListGrantsResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class BalanceListGrantsPageResponseFromRaw : IFromRawJson<BalanceListGrantsPageResponse>
{
    /// <inheritdoc/>
    public BalanceListGrantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceListGrantsPageResponse.FromRawUnchecked(rawData);
}
