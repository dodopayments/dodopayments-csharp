using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

[JsonConverter(typeof(JsonModelConverter<BalanceListPageResponse, BalanceListPageResponseFromRaw>))]
public sealed record class BalanceListPageResponse : JsonModel
{
    public required IReadOnlyList<CustomerCreditBalance> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerCreditBalance>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerCreditBalance>>(
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

    public BalanceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceListPageResponse(BalanceListPageResponse balanceListPageResponse)
        : base(balanceListPageResponse) { }
#pragma warning restore CS8618

    public BalanceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceListPageResponseFromRaw.FromRawUnchecked"/>
    public static BalanceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BalanceListPageResponse(IReadOnlyList<CustomerCreditBalance> items)
        : this()
    {
        this.Items = items;
    }
}

class BalanceListPageResponseFromRaw : IFromRawJson<BalanceListPageResponse>
{
    /// <inheritdoc/>
    public BalanceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceListPageResponse.FromRawUnchecked(rawData);
}
