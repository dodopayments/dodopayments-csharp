using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Wallets;

[JsonConverter(typeof(ModelConverter<WalletListResponse, WalletListResponseFromRaw>))]
public sealed record class WalletListResponse : ModelBase
{
    public required IReadOnlyList<CustomerWallet> Items
    {
        get { return ModelBase.GetNotNullClass<List<CustomerWallet>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <summary>
    /// Sum of all wallet balances converted to USD (in smallest unit)
    /// </summary>
    public required long TotalBalanceUsd
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total_balance_usd"); }
        init { ModelBase.Set(this._rawData, "total_balance_usd", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.TotalBalanceUsd;
    }

    public WalletListResponse() { }

    public WalletListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WalletListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static WalletListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WalletListResponseFromRaw : IFromRaw<WalletListResponse>
{
    public WalletListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WalletListResponse.FromRawUnchecked(rawData);
}
