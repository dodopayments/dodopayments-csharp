using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements;

/// <summary>
/// Undeletes a soft-deleted credit entitlement by clearing `deleted_at`, making it
/// available again through standard list and get endpoints.
///
/// <para># Authentication Requires an API key with `Editor` role.</para>
///
/// <para># Path Parameters - `id` - The unique identifier of the credit entitlement
/// to restore (format: `cde_...`)</para>
///
/// <para># Responses - `200 OK` - Credit entitlement restored successfully - `500
/// Internal Server Error` - Database error, entitlement not found, or entitlement
/// is not deleted</para>
///
/// <para># Business Logic - Only deleted credit entitlements can be restored - The
/// query filters for `deleted_at IS NOT NULL`, so non-deleted entitlements will
/// result in 0 rows affected - If no rows are affected (entitlement doesn't exist,
/// doesn't belong to business, or is not deleted), returns 500 - The `updated_at`
/// timestamp is automatically updated on successful restoration - Once restored,
/// the entitlement becomes immediately available in the standard list and get endpoints
/// - All configuration settings are preserved during delete/restore operations</para>
///
/// <para># Error Handling This endpoint returns 500 Internal Server Error in several
/// cases: - The credit entitlement does not exist - The credit entitlement belongs
/// to a different business - The credit entitlement is not currently deleted (already active)</para>
///
/// <para>Callers should verify the entitlement exists and is deleted before calling
/// this endpoint.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditEntitlementUndeleteParams : ParamsBase
{
    public string? ID { get; init; }

    public CreditEntitlementUndeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementUndeleteParams(
        CreditEntitlementUndeleteParams creditEntitlementUndeleteParams
    )
        : base(creditEntitlementUndeleteParams)
    {
        this.ID = creditEntitlementUndeleteParams.ID;
    }
#pragma warning restore CS8618

    public CreditEntitlementUndeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementUndeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditEntitlementUndeleteParams FromRawUnchecked(
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

    public virtual bool Equals(CreditEntitlementUndeleteParams? other)
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
                + string.Format("/credit-entitlements/{0}/undelete", this.ID)
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
