using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Customers.Wallets;

[JsonConverter(typeof(JsonModelConverter<CustomerWallet, CustomerWalletFromRaw>))]
public sealed record class CustomerWallet : JsonModel
{
    public required long Balance
    {
        get { return this._rawData.GetNotNullStruct<long>("balance"); }
        init { this._rawData.Set("balance", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    public required string CustomerID
    {
        get { return this._rawData.GetNotNullClass<string>("customer_id"); }
        init { this._rawData.Set("customer_id", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Balance;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.CustomerID;
        _ = this.UpdatedAt;
    }

    public CustomerWallet() { }

    public CustomerWallet(CustomerWallet customerWallet)
        : base(customerWallet) { }

    public CustomerWallet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerWallet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerWalletFromRaw.FromRawUnchecked"/>
    public static CustomerWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerWalletFromRaw : IFromRawJson<CustomerWallet>
{
    /// <inheritdoc/>
    public CustomerWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerWallet.FromRawUnchecked(rawData);
}
