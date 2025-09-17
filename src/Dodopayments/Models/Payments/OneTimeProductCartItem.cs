using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Payments;

[JsonConverter(typeof(Dodopayments::ModelConverter<OneTimeProductCartItem>))]
public sealed record class OneTimeProductCartItem
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<OneTimeProductCartItem>
{
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("product_id");
        }
        set { this.Properties["product_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required int Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Amount the customer pays if pay_what_you_want is enabled. If disabled then
    /// amount will be ignored Represented in the lowest denomination of the currency
    /// (e.g., cents for USD). For example, to charge $1.00, pass `100`.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        _ = this.Amount;
    }

    public OneTimeProductCartItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimeProductCartItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OneTimeProductCartItem FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
