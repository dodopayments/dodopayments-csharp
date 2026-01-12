using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.ShortLinks;

/// <summary>
/// Gives a Short Checkout URL with custom slug for a product. Uses a Static Checkout
/// URL under the hood.
/// </summary>
public sealed record class ShortLinkCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Slug for the short link.
    /// </summary>
    public required string Slug
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "slug"); }
        init { JsonModel.Set(this._rawBodyData, "slug", value); }
    }

    /// <summary>
    /// Static Checkout URL parameters to apply to the resulting short URL.
    /// </summary>
    public IReadOnlyDictionary<string, string>? StaticCheckoutParams
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "static_checkout_params"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "static_checkout_params", value); }
    }

    public ShortLinkCreateParams() { }

    public ShortLinkCreateParams(ShortLinkCreateParams shortLinkCreateParams)
        : base(shortLinkCreateParams)
    {
        this.ID = shortLinkCreateParams.ID;

        this._rawBodyData = [.. shortLinkCreateParams._rawBodyData];
    }

    public ShortLinkCreateParams(
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
    ShortLinkCreateParams(
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
    public static ShortLinkCreateParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/products/{0}/short_links", this.ID)
        )
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
