using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using System = System;

namespace DodoPayments.Client.Models.Products;

public sealed record class ProductCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// Price configuration for the product
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("price", out JsonElement element))
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
        init
        {
            this._bodyProperties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax category applied to this product
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("tax_category", out JsonElement element))
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
        init
        {
            this._bodyProperties["tax_category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Addons available for subscription product
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

    /// <summary>
    /// Brand id for the product, if not provided will default to primary brand
    /// </summary>
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
    /// Optional description of the product
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
    public DigitalProductDelivery? DigitalProductDelivery
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

            return JsonSerializer.Deserialize<DigitalProductDelivery?>(
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
    /// Optional message displayed during license key activation
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
    /// The number of times the license key can be activated. Must be 0 or greater
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
    /// Duration configuration for the license key. Set to null if you don't want
    /// the license key to expire. For subscriptions, the lifetime of the license
    /// key is tied to the subscription period
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
    /// When true, generates and sends a license key to your customer. Defaults to false
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
            if (value == null)
            {
                return;
            }

            this._bodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional name of the product
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

    public ProductCreateParams() { }

    public ProductCreateParams(
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
    ProductCreateParams(
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

    public static ProductCreateParams FromRawUnchecked(
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/products")
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
[JsonConverter(typeof(ModelConverter<DigitalProductDelivery>))]
public sealed record class DigitalProductDelivery : ModelBase, IFromRaw<DigitalProductDelivery>
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
        _ = this.Instructions;
    }

    public DigitalProductDelivery() { }

    public DigitalProductDelivery(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDelivery(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
