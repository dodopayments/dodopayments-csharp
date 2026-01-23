using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Wallets;

[JsonConverter(typeof(JsonModelConverter<WalletListResponse, WalletListResponseFromRaw>))]
public sealed record class WalletListResponse : JsonModel
{
    public required IReadOnlyList<CustomerWallet> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerWallet>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerWallet>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sum of all wallet balances converted to USD (in smallest unit)
    /// </summary>
    public required long TotalBalanceUsd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_balance_usd");
        }
        init { this._rawData.Set("total_balance_usd", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.TotalBalanceUsd;
    }

    public WalletListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WalletListResponse(WalletListResponse walletListResponse)
        : base(walletListResponse) { }
#pragma warning restore CS8618

    public WalletListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WalletListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WalletListResponseFromRaw.FromRawUnchecked"/>
    public static WalletListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WalletListResponseFromRaw : IFromRawJson<WalletListResponse>
{
    /// <inheritdoc/>
    public WalletListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WalletListResponse.FromRawUnchecked(rawData);
}
