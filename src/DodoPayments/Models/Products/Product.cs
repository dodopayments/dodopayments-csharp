using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;
using Misc = DodoPayments.Models.Misc;
using ProductProperties = DodoPayments.Models.Products.ProductProperties;
using System = System;

namespace DodoPayments.Models.Products;

[JsonConverter(typeof(DodoPayments::ModelConverter<Product>))]
public sealed record class Product : DodoPayments::ModelBase, DodoPayments::IFromRaw<Product>
{
    public required string BrandID
    {
        get
        {
            if (!this.Properties.TryGetValue("brand_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "brand_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("brand_id");
        }
        set { this.Properties["brand_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "business_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get
        {
            if (!this.Properties.TryGetValue("is_recurring", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "is_recurring",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["is_recurring"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates whether the product requires a license key.
    /// </summary>
    public required bool LicenseKeyEnabled
    {
        get
        {
            if (!this.Properties.TryGetValue("license_key_enabled", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "license_key_enabled",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["license_key_enabled"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional custom data associated with the product
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Pricing information for the product.
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<Price>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("price");
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "product_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("product_id");
        }
        set { this.Properties["product_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Tax category associated with the product.
    /// </summary>
    public required Misc::TaxCategory TaxCategory
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_category", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_category",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Misc::TaxCategory>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("tax_category");
        }
        set { this.Properties["tax_category"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Timestamp when the product was last updated.
    /// </summary>
    public required System::DateTime UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "updated_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["updated_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public List<string>? Addons
    {
        get
        {
            if (!this.Properties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["addons"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Description of the product, optional.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    public ProductProperties::DigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            if (!this.Properties.TryGetValue("digital_product_delivery", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ProductProperties::DigitalProductDelivery?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["digital_product_delivery"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// URL of the product image, optional.
    /// </summary>
    public string? Image
    {
        get
        {
            if (!this.Properties.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["image"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Message sent upon license key activation, if applicable.
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "license_key_activation_message",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["license_key_activation_message"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Limit on the number of activations for the license key, if enabled.
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "license_key_activations_limit",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["license_key_activations_limit"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Duration of the license key validity, if enabled.
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            if (!this.Properties.TryGetValue("license_key_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<LicenseKeyDuration?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["license_key_duration"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Name of the product, optional.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsRecurring;
        _ = this.LicenseKeyEnabled;
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        this.Price.Validate();
        _ = this.ProductID;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        foreach (var item in this.Addons ?? [])
        {
            _ = item;
        }
        _ = this.Description;
        this.DigitalProductDelivery?.Validate();
        _ = this.Image;
        _ = this.LicenseKeyActivationMessage;
        _ = this.LicenseKeyActivationsLimit;
        this.LicenseKeyDuration?.Validate();
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
}
