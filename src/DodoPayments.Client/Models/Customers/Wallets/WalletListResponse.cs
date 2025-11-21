using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Customers.Wallets;

[JsonConverter(typeof(ModelConverter<WalletListResponse>))]
public sealed record class WalletListResponse : ModelBase, IFromRaw<WalletListResponse>
{
    public required List<CustomerWallet> Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<CustomerWallet>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("total_balance_usd", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'total_balance_usd' cannot be null",
                    new ArgumentOutOfRangeException(
                        "total_balance_usd",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["total_balance_usd"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
