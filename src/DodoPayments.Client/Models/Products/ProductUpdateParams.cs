using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("addons");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? BrandID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand_id");
        }
        init { this._rawBodyData.Set("brand_id", value); }
    }

    /// <summary>
    /// Description of the product, optional and must be at most 1000 characters.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Choose how you would like you digital product delivered
    /// </summary>
    public ProductUpdateParamsDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProductUpdateParamsDigitalProductDelivery>(
                "digital_product_delivery"
            );
        }
        init { this._rawBodyData.Set("digital_product_delivery", value); }
    }

    /// <summary>
    /// Product image id after its uploaded to S3
    /// </summary>
    public string? ImageID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("image_id");
        }
        init { this._rawBodyData.Set("image_id", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("license_key_activation_message");
        }
        init { this._rawBodyData.Set("license_key_activation_message", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("license_key_activations_limit");
        }
        init { this._rawBodyData.Set("license_key_activations_limit", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<LicenseKeyDuration>("license_key_duration");
        }
        init { this._rawBodyData.Set("license_key_duration", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("license_key_enabled");
        }
        init { this._rawBodyData.Set("license_key_enabled", value); }
    }

    /// <summary>
    /// Additional metadata for the product
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Price details of the product.
    /// </summary>
    public Price? Price
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Price>("price");
        }
        init { this._rawBodyData.Set("price", value); }
    }

    /// <summary>
    /// Tax category of the product.
    /// </summary>
    public ApiEnum<string, TaxCategory>? TaxCategory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawBodyData.Set("tax_category", value); }
    }

    public ProductUpdateParams() { }

    public ProductUpdateParams(ProductUpdateParams productUpdateParams)
        : base(productUpdateParams)
    {
        this.ID = productUpdateParams.ID;

        this._rawBodyData = new(productUpdateParams._rawBodyData);
    }

    public ProductUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ProductUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Choose how you would like you digital product delivered
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductUpdateParamsDigitalProductDelivery,
        ProductUpdateParamsDigitalProductDeliveryFromRaw
    >)
)]
public sealed record class ProductUpdateParamsDigitalProductDelivery : JsonModel
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public IReadOnlyList<string>? Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalUrl;
        _ = this.Files;
        _ = this.Instructions;
    }

    public ProductUpdateParamsDigitalProductDelivery() { }

    public ProductUpdateParamsDigitalProductDelivery(
        ProductUpdateParamsDigitalProductDelivery productUpdateParamsDigitalProductDelivery
    )
        : base(productUpdateParamsDigitalProductDelivery) { }

    public ProductUpdateParamsDigitalProductDelivery(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParamsDigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateParamsDigitalProductDeliveryFromRaw.FromRawUnchecked"/>
    public static ProductUpdateParamsDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateParamsDigitalProductDeliveryFromRaw
    : IFromRawJson<ProductUpdateParamsDigitalProductDelivery>
{
    /// <inheritdoc/>
    public ProductUpdateParamsDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateParamsDigitalProductDelivery.FromRawUnchecked(rawData);
}
