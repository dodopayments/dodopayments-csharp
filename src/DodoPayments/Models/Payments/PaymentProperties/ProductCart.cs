using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Payments.PaymentProperties;

[JsonConverter(typeof(DodoPayments::ModelConverter<ProductCart>))]
public sealed record class ProductCart
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<ProductCart>
{
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("product_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
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
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
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
