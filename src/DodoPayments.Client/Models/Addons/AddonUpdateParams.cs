using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Addons;

public sealed record class AddonUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The currency of the Addon
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Currency>>(
                this.RawBodyData,
                "currency"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "currency", value); }
    }

    /// <summary>
    /// Description of the Addon, optional and must be at most 1000 characters.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// Addon image id after its uploaded to S3
    /// </summary>
    public string? ImageID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "image_id"); }
        init { ModelBase.Set(this._rawBodyData, "image_id", value); }
    }

    /// <summary>
    /// Name of the Addon, optional and must be at most 100 characters.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public int? Price
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawBodyData, "price"); }
        init { ModelBase.Set(this._rawBodyData, "price", value); }
    }

    /// <summary>
    /// Tax category of the Addon.
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

    public AddonUpdateParams() { }

    public AddonUpdateParams(AddonUpdateParams addonUpdateParams)
        : base(addonUpdateParams)
    {
        this._rawBodyData = [.. addonUpdateParams._rawBodyData];
    }

    public AddonUpdateParams(
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
    AddonUpdateParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static AddonUpdateParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/addons/{0}", this.ID)
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
