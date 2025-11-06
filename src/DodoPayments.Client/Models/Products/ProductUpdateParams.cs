using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using System = System;

namespace DodoPayments.Client.Models.Products;

public sealed record class ProductUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public List<string>? Addons
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BrandID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Description of the product, optional and must be at most 1000 characters.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Choose how you would like you digital product delivered
    /// </summary>
    public DigitalProductDeliveryModel? DigitalProductDelivery
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

            return JsonSerializer.Deserialize<DigitalProductDeliveryModel?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["digital_product_delivery"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Product image id after its uploaded to S3
    /// </summary>
    public string? ImageID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("image_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["image_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Message sent to the customer upon license key activation.
    ///
    /// Only applicable if `license_key_enabled` is `true`. This message contains
    /// instructions for activating the license key.
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["license_key_activation_message"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Limit for the number of activations for the license key.
    ///
    /// Only applicable if `license_key_enabled` is `true`. Represents the maximum
    /// number of times the license key can be activated.
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

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["license_key_activations_limit"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Duration of the license key if enabled.
    ///
    /// Only applicable if `license_key_enabled` is `true`. Represents the duration
    /// in days for which the license key is valid.
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("license_key_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<LicenseKeyDuration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["license_key_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the product requires a license key.
    ///
    /// If `true`, additional fields related to license key (duration, activations
    /// limit, activation message) become applicable.
    /// </summary>
    public bool? LicenseKeyEnabled
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("license_key_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["license_key_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the product, optional and must be at most 100 characters.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Price details of the product.
    /// </summary>
    public Price? Price
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Price?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax category of the product.
    /// </summary>
    public ApiEnum<string, TaxCategory>? TaxCategory
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["tax_category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IDodoPaymentsClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/products/{0}", this.ID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDodoPaymentsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Choose how you would like you digital product delivered
/// </summary>
[JsonConverter(typeof(ModelConverter<DigitalProductDeliveryModel>))]
public sealed record class DigitalProductDeliveryModel
    : ModelBase,
        IFromRaw<DigitalProductDeliveryModel>
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
    public List<string>? Files
    {
        get
        {
            if (!this.Properties.TryGetValue("files", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
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
        _ = this.Files;
        _ = this.Instructions;
    }

    public DigitalProductDeliveryModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDeliveryModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DigitalProductDeliveryModel FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
