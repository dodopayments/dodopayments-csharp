using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;
using Misc = DodoPayments.Models.Misc;
using ProductCreateParamsProperties = DodoPayments.Models.Products.ProductCreateParamsProperties;
using System = System;

namespace DodoPayments.Models.Products;

public sealed record class ProductCreateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Price configuration for the product
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<Price>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("price");
        }
        set { this.BodyProperties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Tax category applied to this product
    /// </summary>
    public required Misc::TaxCategory TaxCategory
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_category", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_category",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Misc::TaxCategory>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("tax_category");
        }
        set { this.BodyProperties["tax_category"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Addons available for subscription product
    /// </summary>
    public List<string>? Addons
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["addons"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Brand id for the product, if not provided will default to primary brand
    /// </summary>
    public string? BrandID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["brand_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional description of the product
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Choose how you would like you digital product delivered
    /// </summary>
    public ProductCreateParamsProperties::DigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "digital_product_delivery",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<ProductCreateParamsProperties::DigitalProductDelivery?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["digital_product_delivery"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Optional message displayed during license key activation
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
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
            this.BodyProperties["license_key_activation_message"] =
                JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The number of times the license key can be activated. Must be 0 or greater
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
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
            this.BodyProperties["license_key_activations_limit"] =
                JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Duration configuration for the license key. Set to null if you don't want
    /// the license key to expire. For subscriptions, the lifetime of the license
    /// key is tied to the subscription period
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("license_key_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<LicenseKeyDuration?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["license_key_duration"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// When true, generates and sends a license key to your customer. Defaults to false
    /// </summary>
    public bool? LicenseKeyEnabled
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("license_key_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["license_key_enabled"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Additional metadata for the product
    /// </summary>
    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional name of the product
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/products")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(
        HttpRequestMessage request,
        DodoPayments::IDodoPaymentsClient client
    )
    {
        DodoPayments::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            DodoPayments::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
