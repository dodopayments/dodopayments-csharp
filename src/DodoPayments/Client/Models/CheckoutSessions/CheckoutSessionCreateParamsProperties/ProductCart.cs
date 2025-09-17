using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Subscriptions;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties;

[JsonConverter(typeof(Client::ModelConverter<ProductCart>))]
public sealed record class ProductCart : Client::ModelBase, Client::IFromRaw<ProductCart>
{
    /// <summary>
    /// unique id of the product
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("product_id");
        }
        set { this.Properties["product_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required int Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// only valid if product is a subscription
    /// </summary>
    public List<AttachAddon>? Addons
    {
        get
        {
            if (!this.Properties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AttachAddon>?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["addons"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Amount the customer pays if pay_what_you_want is enabled. If disabled then
    /// amount will be ignored Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`. Only applicable
    /// for one time payments
    ///
    /// If amount is not set for pay_what_you_want product, customer is allowed to
    /// select the amount.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.Amount;
    }

    public ProductCart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCart(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProductCart FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
