using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// Returns the credit balance details for a specific customer and credit entitlement.
///
/// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
///
/// <para># Path Parameters - `credit_entitlement_id` - The unique identifier of
/// the credit entitlement - `customer_id` - The unique identifier of the customer</para>
///
/// <para># Responses - `200 OK` - Returns the customer's balance - `404 Not Found`
/// - Credit entitlement or customer balance not found - `500 Internal Server Error`
/// - Database or server error</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BalanceRetrieveParams : ParamsBase
{
    public required string CreditEntitlementID { get; init; }

    public string? CustomerID { get; init; }

    public BalanceRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceRetrieveParams(BalanceRetrieveParams balanceRetrieveParams)
        : base(balanceRetrieveParams)
    {
        this.CreditEntitlementID = balanceRetrieveParams.CreditEntitlementID;
        this.CustomerID = balanceRetrieveParams.CustomerID;
    }
#pragma warning restore CS8618

    public BalanceRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BalanceRetrieveParams FromRawUnchecked(
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
                    ["CreditEntitlementID"] = JsonSerializer.SerializeToElement(
                        this.CreditEntitlementID
                    ),
                    ["CustomerID"] = JsonSerializer.SerializeToElement(this.CustomerID),
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

    public virtual bool Equals(BalanceRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CreditEntitlementID.Equals(other.CreditEntitlementID)
            && (this.CustomerID?.Equals(other.CustomerID) ?? other.CustomerID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/credit-entitlements/{0}/balances/{1}",
                    this.CreditEntitlementID,
                    this.CustomerID
                )
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
