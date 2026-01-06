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

public sealed record class ProductCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the product
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { JsonModel.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Price configuration for the product
    /// </summary>
    public required Price Price
    {
        get { return JsonModel.GetNotNullClass<Price>(this.RawBodyData, "price"); }
        init { JsonModel.Set(this._rawBodyData, "price", value); }
    }

    /// <summary>
    /// Tax category applied to this product
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TaxCategory>>(
                this.RawBodyData,
                "tax_category"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "tax_category", value); }
    }

    /// <summary>
    /// Addons available for subscription product
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "addons"); }
        init { JsonModel.Set(this._rawBodyData, "addons", value); }
    }

    /// <summary>
    /// Brand id for the product, if not provided will default to primary brand
    /// </summary>
    public string? BrandID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "brand_id"); }
        init { JsonModel.Set(this._rawBodyData, "brand_id", value); }
    }

    /// <summary>
    /// Optional description of the product
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { JsonModel.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// Choose how you would like you digital product delivered
    /// </summary>
    public DigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            return JsonModel.GetNullableClass<DigitalProductDelivery>(
                this.RawBodyData,
                "digital_product_delivery"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "digital_product_delivery", value); }
    }

    /// <summary>
    /// Optional message displayed during license key activation
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            return JsonModel.GetNullableClass<string>(
                this.RawBodyData,
                "license_key_activation_message"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "license_key_activation_message", value); }
    }

    /// <summary>
    /// The number of times the license key can be activated. Must be 0 or greater
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            return JsonModel.GetNullableStruct<int>(
                this.RawBodyData,
                "license_key_activations_limit"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "license_key_activations_limit", value); }
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
            return JsonModel.GetNullableClass<LicenseKeyDuration>(
                this.RawBodyData,
                "license_key_duration"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "license_key_duration", value); }
    }

    /// <summary>
    /// When true, generates and sends a license key to your customer. Defaults to false
    /// </summary>
    public bool? LicenseKeyEnabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "license_key_enabled"); }
        init { JsonModel.Set(this._rawBodyData, "license_key_enabled", value); }
    }

    /// <summary>
    /// Additional metadata for the product
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "metadata", value);
        }
    }

    public ProductCreateParams() { }

    public ProductCreateParams(ProductCreateParams productCreateParams)
        : base(productCreateParams)
    {
        this._rawBodyData = [.. productCreateParams._rawBodyData];
    }

    public ProductCreateParams(
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
    ProductCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ProductCreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/products")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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
[JsonConverter(typeof(JsonModelConverter<DigitalProductDelivery, DigitalProductDeliveryFromRaw>))]
public sealed record class DigitalProductDelivery : JsonModel
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_url"); }
        init { JsonModel.Set(this._rawData, "external_url", value); }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
    public string? Instructions
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "instructions"); }
        init { JsonModel.Set(this._rawData, "instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalUrl;
        _ = this.Instructions;
    }

    public DigitalProductDelivery() { }

    public DigitalProductDelivery(DigitalProductDelivery digitalProductDelivery)
        : base(digitalProductDelivery) { }

    public DigitalProductDelivery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalProductDeliveryFromRaw.FromRawUnchecked"/>
    public static DigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalProductDeliveryFromRaw : IFromRawJson<DigitalProductDelivery>
{
    /// <inheritdoc/>
    public DigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalProductDelivery.FromRawUnchecked(rawData);
}
