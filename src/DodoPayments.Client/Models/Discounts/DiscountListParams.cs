using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// GET /discounts
/// </summary>
public sealed record class DiscountListParams : ParamsBase
{
    /// <summary>
    /// Page number (default = 0).
    /// </summary>
    public int? PageNumber
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawQueryData, "page_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "page_number", value);
        }
    }

    /// <summary>
    /// Page size (default = 10, max = 100).
    /// </summary>
    public int? PageSize
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawQueryData, "page_size"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "page_size", value);
        }
    }

    public DiscountListParams() { }

    public DiscountListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static DiscountListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/discounts")
        {
            Query = this.QueryString(options),
        }.Uri;
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
