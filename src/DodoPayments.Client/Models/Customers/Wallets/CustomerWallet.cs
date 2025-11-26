using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Customers.Wallets;

[JsonConverter(typeof(ModelConverter<CustomerWallet, CustomerWalletFromRaw>))]
public sealed record class CustomerWallet : ModelBase
{
    public required long Balance
    {
        get
        {
            if (!this._rawData.TryGetValue("balance", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'balance' cannot be null",
                    new ArgumentOutOfRangeException("balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string CustomerID
    {
        get
        {
            if (!this._rawData.TryGetValue("customer_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new ArgumentOutOfRangeException("customer_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new ArgumentNullException("customer_id")
                );
        }
        init
        {
            this._rawData["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updated_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentOutOfRangeException("updated_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Balance;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.CustomerID;
        _ = this.UpdatedAt;
    }

    public CustomerWallet() { }

    public CustomerWallet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerWallet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CustomerWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerWalletFromRaw : IFromRaw<CustomerWallet>
{
    public CustomerWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerWallet.FromRawUnchecked(rawData);
}
