using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements;

/// <summary>
/// Returns a paginated list of credit entitlements, allowing filtering of deleted
/// entitlements. By default, only non-deleted entitlements are returned.
///
/// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
///
/// <para># Query Parameters - `page_size` - Number of items per page (default: 10,
/// max: 100) - `page_number` - Zero-based page number (default: 0) - `deleted` -
/// Boolean flag to list deleted entitlements instead of active ones (default: false)</para>
///
/// <para># Responses - `200 OK` - Returns a list of credit entitlements wrapped in
/// a response object - `422 Unprocessable Entity` - Invalid query parameters (e.g.,
/// page_size > 100) - `500 Internal Server Error` - Database or server error</para>
///
/// <para># Business Logic - Results are ordered by creation date in descending order
/// (newest first) - Only entitlements belonging to the authenticated business are
/// returned - The `deleted` parameter controls visibility of soft-deleted entitlements
/// - Pagination uses offset-based pagination (offset = page_number * page_size)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditEntitlementListParams : ParamsBase
{
    /// <summary>
    /// List deleted credit entitlements
    /// </summary>
    public bool? Deleted
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("deleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("deleted", value);
        }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_number", value);
        }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    public CreditEntitlementListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementListParams(CreditEntitlementListParams creditEntitlementListParams)
        : base(creditEntitlementListParams) { }
#pragma warning restore CS8618

    public CreditEntitlementListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditEntitlementListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CreditEntitlementListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/credit-entitlements")
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

    public override int GetHashCode()
    {
        return 0;
    }
}
