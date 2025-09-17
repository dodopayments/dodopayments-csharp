using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Licenses.LicenseActivateResponseProperties;

/// <summary>
/// Related product info. Present if the license key is tied to a product.
/// </summary>
[JsonConverter(typeof(Dodopayments::ModelConverter<Product>))]
public sealed record class Product : Dodopayments::ModelBase, Dodopayments::IFromRaw<Product>
{
    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
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

    /// <summary>
    /// Name of the product, if set by the merchant.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Name;
    }

    public Product() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Product FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Product(string productID)
        : this()
    {
        this.ProductID = productID;
    }
}
