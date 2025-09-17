using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Payments.PaymentListPageResponseProperties;

[JsonConverter(typeof(Client::ModelConverter<Item>))]
public sealed record class Item : Client::ModelBase, Client::IFromRaw<Item>
{
    public required string BrandID
    {
        get
        {
            if (!this.Properties.TryGetValue("brand_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("brand_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("brand_id");
        }
        set { this.Properties["brand_id"] = JsonSerializer.SerializeToElement(value); }
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

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<Payments::CustomerLimitedDetails>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    public required bool DigitalProductsDelivered
    {
        get
        {
            if (!this.Properties.TryGetValue("digital_products_delivered", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "digital_products_delivered",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["digital_products_delivered"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new ArgumentOutOfRangeException("metadata", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string PaymentID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("payment_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("payment_id");
        }
        set { this.Properties["payment_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required int TotalAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("total_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("total_amount", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["total_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? PaymentMethod
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["payment_method"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? PaymentMethodType
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_method_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["payment_method_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public Payments::IntentStatus? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Payments::IntentStatus?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? SubscriptionID
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["subscription_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.DigitalProductsDelivered;
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        _ = this.PaymentID;
        _ = this.TotalAmount;
        _ = this.PaymentMethod;
        _ = this.PaymentMethodType;
        this.Status?.Validate();
        _ = this.SubscriptionID;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
