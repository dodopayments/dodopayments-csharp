using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Customers.Wallets;

[JsonConverter(typeof(Client::ModelConverter<CustomerWallet>))]
public sealed record class CustomerWallet : Client::ModelBase, Client::IFromRaw<CustomerWallet>
{
    public required long Balance
    {
        get
        {
            if (!this.Properties.TryGetValue("balance", out JsonElement element))
                throw new ArgumentOutOfRangeException("balance", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["balance"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("customer_id");
        }
        set { this.Properties["customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("updated_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["updated_at"] = JsonSerializer.SerializeToElement(value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerWallet(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerWallet FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
