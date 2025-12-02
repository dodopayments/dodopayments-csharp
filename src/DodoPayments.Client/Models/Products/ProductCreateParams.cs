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
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Price configuration for the product
    /// </summary>
    public required Price Price
    {
        get { return ModelBase.GetNotNullClass<Price>(this.RawBodyData, "price"); }
        init { ModelBase.Set(this._rawBodyData, "price", value); }
    }

    /// <summary>
    /// Tax category applied to this product
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TaxCategory>>(
                this.RawBodyData,
                "tax_category"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "tax_category", value); }
    }

    /// <summary>
    /// Addons available for subscription product
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "addons"); }
        init { ModelBase.Set(this._rawBodyData, "addons", value); }
    }

    /// <summary>
    /// Brand id for the product, if not provided will default to primary brand
    /// </summary>
    public string? BrandID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "brand_id"); }
        init { ModelBase.Set(this._rawBodyData, "brand_id", value); }
    }

    /// <summary>
    /// Optional description of the product
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// Choose how you would like you digital product delivered
    /// </summary>
    public DigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            return ModelBase.GetNullableClass<DigitalProductDelivery>(
                this.RawBodyData,
                "digital_product_delivery"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "digital_product_delivery", value); }
    }

    /// <summary>
    /// Optional message displayed during license key activation
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
    /// The number of times the license key can be activated. Must be 0 or greater
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
    /// Duration configuration for the license key. Set to null if you don't want
    /// the license key to expire. For subscriptions, the lifetime of the license
    /// key is tied to the subscription period
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
    /// When true, generates and sends a license key to your customer. Defaults to false
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
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "metadata", value);
        }
    }

    public ProductCreateParams() { }

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
[JsonConverter(typeof(ModelConverter<DigitalProductDelivery, DigitalProductDeliveryFromRaw>))]
public sealed record class DigitalProductDelivery : ModelBase
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
        _ = this.Instructions;
    }

    public DigitalProductDelivery() { }

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

    public static DigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalProductDeliveryFromRaw : IFromRaw<DigitalProductDelivery>
{
    public DigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalProductDelivery.FromRawUnchecked(rawData);
}
