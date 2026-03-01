using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements;

/// <summary>
/// Returns the full details of a single credit entitlement including all configuration
/// settings for expiration, rollover, and overage policies.
///
/// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
///
/// <para># Path Parameters - `id` - The unique identifier of the credit entitlement
/// (format: `cde_...`)</para>
///
/// <para># Responses - `200 OK` - Returns the full credit entitlement object - `404
/// Not Found` - Credit entitlement does not exist or does not belong to the authenticated
/// business - `500 Internal Server Error` - Database or server error</para>
///
/// <para># Business Logic - Only non-deleted credit entitlements can be retrieved
/// through this endpoint - The entitlement must belong to the authenticated business
/// (business_id check) - Deleted entitlements return a 404 error and must be retrieved
/// via the list endpoint with `deleted=true`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditEntitlementRetrieveParams : ParamsBase
{
    public string? ID { get; init; }

    public CreditEntitlementRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementRetrieveParams(
        CreditEntitlementRetrieveParams creditEntitlementRetrieveParams
    )
        : base(creditEntitlementRetrieveParams)
    {
        this.ID = creditEntitlementRetrieveParams.ID;
    }
#pragma warning restore CS8618

    public CreditEntitlementRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditEntitlementRetrieveParams FromRawUnchecked(
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
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(CreditEntitlementRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/credit-entitlements/{0}", this.ID)
        )
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
