using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

public sealed record class LicenseKeyInstanceListParams : ParamsBase
{
    /// <summary>
    /// Filter by license key ID
    /// </summary>
    public string? LicenseKeyID
    {
        get { return this._rawQueryData.GetNullableClass<string>("license_key_id"); }
        init { this._rawQueryData.Set("license_key_id", value); }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get { return this._rawQueryData.GetNullableStruct<int>("page_number"); }
        init { this._rawQueryData.Set("page_number", value); }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get { return this._rawQueryData.GetNullableStruct<int>("page_size"); }
        init { this._rawQueryData.Set("page_size", value); }
    }

    public LicenseKeyInstanceListParams() { }

    public LicenseKeyInstanceListParams(LicenseKeyInstanceListParams licenseKeyInstanceListParams)
        : base(licenseKeyInstanceListParams) { }

    public LicenseKeyInstanceListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyInstanceListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static LicenseKeyInstanceListParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/license_key_instances")
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
