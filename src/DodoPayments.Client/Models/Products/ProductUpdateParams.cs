using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products;

public sealed record class ProductUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public List<string>? Addons
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BrandID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["brand_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["description"] = JsonSerializer.SerializeToElement(
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
                !this._bodyProperties.TryGetValue(
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
        init
        {
            this._bodyProperties["digital_product_delivery"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("image_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["image_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Message sent to the customer upon license key activation.
    ///
    /// <para>Only applicable if `license_key_enabled` is `true`. This message contains
    /// instructions for activating the license key.</para>
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "license_key_activation_message",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["license_key_activation_message"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Limit for the number of activations for the license key.
    ///
    /// <para>Only applicable if `license_key_enabled` is `true`. Represents the
    /// maximum number of times the license key can be activated.</para>
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "license_key_activations_limit",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["license_key_activations_limit"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Duration of the license key if enabled.
    ///
    /// <para>Only applicable if `license_key_enabled` is `true`. Represents the
    /// duration in days for which the license key is valid.</para>
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("license_key_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<LicenseKeyDuration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["license_key_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the product requires a license key.
    ///
    /// <para>If `true`, additional fields related to license key (duration, activations
    /// limit, activation message) become applicable.</para>
    /// </summary>
    public bool? LicenseKeyEnabled
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("license_key_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["license_key_enabled"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Price?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["price"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("tax_category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["tax_category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ProductUpdateParams() { }

    public ProductUpdateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static ProductUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/products/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
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
            if (!this._properties.TryGetValue("external_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("files", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["files"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("instructions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["instructions"] = JsonSerializer.SerializeToElement(
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

    public DigitalProductDeliveryModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDeliveryModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DigitalProductDeliveryModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
