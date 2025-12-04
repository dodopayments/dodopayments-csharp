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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "addons"); }
        init { ModelBase.Set(this._rawBodyData, "addons", value); }
    }

    public string? BrandID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "brand_id"); }
        init { ModelBase.Set(this._rawBodyData, "brand_id", value); }
    }

    /// <summary>
    /// Description of the product, optional and must be at most 1000 characters.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// Choose how you would like you digital product delivered
    /// </summary>
    public ProductUpdateParamsDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            return ModelBase.GetNullableClass<ProductUpdateParamsDigitalProductDelivery>(
                this.RawBodyData,
                "digital_product_delivery"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "digital_product_delivery", value); }
    }

    /// <summary>
    /// Product image id after its uploaded to S3
    /// </summary>
    public string? ImageID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "image_id"); }
        init { ModelBase.Set(this._rawBodyData, "image_id", value); }
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
            return ModelBase.GetNullableClass<string>(
                this.RawBodyData,
                "license_key_activation_message"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "license_key_activation_message", value); }
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
            return ModelBase.GetNullableStruct<int>(
                this.RawBodyData,
                "license_key_activations_limit"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "license_key_activations_limit", value); }
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
            return ModelBase.GetNullableClass<LicenseKeyDuration>(
                this.RawBodyData,
                "license_key_duration"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "license_key_duration", value); }
    }

    /// <summary>
    /// Whether the product requires a license key.
    ///
    /// <para>If `true`, additional fields related to license key (duration, activations
    /// limit, activation message) become applicable.</para>
    /// </summary>
    public bool? LicenseKeyEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "license_key_enabled"); }
        init { ModelBase.Set(this._rawBodyData, "license_key_enabled", value); }
    }

    /// <summary>
    /// Additional metadata for the product
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "metadata", value); }
    }

    /// <summary>
    /// Name of the product, optional and must be at most 100 characters.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Price details of the product.
    /// </summary>
    public Price? Price
    {
        get { return ModelBase.GetNullableClass<Price>(this.RawBodyData, "price"); }
        init { ModelBase.Set(this._rawBodyData, "price", value); }
    }

    /// <summary>
    /// Tax category of the product.
    /// </summary>
    public ApiEnum<string, TaxCategory>? TaxCategory
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, TaxCategory>>(
                this.RawBodyData,
                "tax_category"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "tax_category", value); }
    }

    public ProductUpdateParams() { }

    public ProductUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
    typeof(ModelConverter<
        ProductUpdateParamsDigitalProductDelivery,
        ProductUpdateParamsDigitalProductDeliveryFromRaw
    >)
)]
public sealed record class ProductUpdateParamsDigitalProductDelivery : ModelBase
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_url"); }
        init { ModelBase.Set(this._rawData, "external_url", value); }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public IReadOnlyList<string>? Files
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "files"); }
        init { ModelBase.Set(this._rawData, "files", value); }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
    public string? Instructions
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "instructions"); }
        init { ModelBase.Set(this._rawData, "instructions", value); }
    }

    public override void Validate()
    {
        _ = this.ExternalURL;
        _ = this.Files;
        _ = this.Instructions;
    }

    public ProductUpdateParamsDigitalProductDelivery() { }

    public ProductUpdateParamsDigitalProductDelivery(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParamsDigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ProductUpdateParamsDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateParamsDigitalProductDeliveryFromRaw
    : IFromRaw<ProductUpdateParamsDigitalProductDelivery>
{
    public ProductUpdateParamsDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateParamsDigitalProductDelivery.FromRawUnchecked(rawData);
}
