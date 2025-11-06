using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(ModelConverter<Product>))]
public sealed record class Product : ModelBase, IFromRaw<Product>
{
    public required string BrandID
    {
        get
        {
            if (!this.Properties.TryGetValue("brand_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new System::ArgumentOutOfRangeException("brand_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new System::ArgumentNullException("brand_id")
                );
        }
        set
        {
            this.Properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get
        {
            if (!this.Properties.TryGetValue("is_recurring", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'is_recurring' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "is_recurring",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_recurring"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the product requires a license key.
    /// </summary>
    public required bool LicenseKeyEnabled
    {
        get
        {
            if (!this.Properties.TryGetValue("license_key_enabled", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'license_key_enabled' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "license_key_enabled",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["license_key_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional custom data associated with the product
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Pricing information for the product.
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'price' cannot be null",
                    new System::ArgumentOutOfRangeException("price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'price' cannot be null",
                    new System::ArgumentNullException("price")
                );
        }
        set
        {
            this.Properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this.Properties.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentNullException("product_id")
                );
        }
        set
        {
            this.Properties["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax category associated with the product.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_category", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'tax_category' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_category",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["tax_category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the product was last updated.
    /// </summary>
    public required System::DateTime UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'updated_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "updated_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DigitalProductDelivery1? DigitalProductDelivery
    {
        get
        {
            if (!this.Properties.TryGetValue("digital_product_delivery", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DigitalProductDelivery1?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["digital_product_delivery"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["license_key_activation_message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["license_key_activations_limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["license_key_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsRecurring;
        _ = this.LicenseKeyEnabled;
        _ = this.Metadata;
        this.Price.Validate();
        _ = this.ProductID;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        _ = this.Addons;
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

[JsonConverter(typeof(ModelConverter<DigitalProductDelivery1>))]
public sealed record class DigitalProductDelivery1 : ModelBase, IFromRaw<DigitalProductDelivery1>
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalURL
    {
        get
        {
            if (!this.Properties.TryGetValue("external_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public List<File>? Files
    {
        get
        {
            if (!this.Properties.TryGetValue("files", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<File>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["files"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
    public string? Instructions
    {
        get
        {
            if (!this.Properties.TryGetValue("instructions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["instructions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ExternalURL;
        foreach (var item in this.Files ?? [])
        {
            item.Validate();
        }
        _ = this.Instructions;
    }

    public DigitalProductDelivery1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDelivery1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DigitalProductDelivery1 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<File>))]
public sealed record class File : ModelBase, IFromRaw<File>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'file_id' cannot be null",
                    new System::ArgumentOutOfRangeException("file_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'file_id' cannot be null",
                    new System::ArgumentNullException("file_id")
                );
        }
        set
        {
            this.Properties["file_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string FileName
    {
        get
        {
            if (!this.Properties.TryGetValue("file_name", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'file_name' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "file_name",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'file_name' cannot be null",
                    new System::ArgumentNullException("file_name")
                );
        }
        set
        {
            this.Properties["file_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentNullException("url")
                );
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
        _ = this.URL;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static File FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
