using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Customers.Wallets;

[JsonConverter(typeof(Dodopayments::ModelConverter<WalletListResponse>))]
public sealed record class WalletListResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<WalletListResponse>
{
    public required List<CustomerWallet> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<CustomerWallet>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Sum of all wallet balances converted to USD (in smallest unit)
    /// </summary>
    public required long TotalBalanceUsd
    {
        get
        {
            if (!this.Properties.TryGetValue("total_balance_usd", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "total_balance_usd",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["total_balance_usd"] = JsonSerializer.SerializeToElement(value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WalletListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WalletListResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
