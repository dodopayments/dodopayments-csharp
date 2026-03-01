using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// Returns a paginated list of credit transaction history with optional filtering.
///
/// <para># Authentication Requires an API key with `Viewer` role or higher.</para>
///
/// <para># Path Parameters - `credit_entitlement_id` - The unique identifier of
/// the credit entitlement - `customer_id` - The unique identifier of the customer</para>
///
/// <para># Query Parameters - `page_size` - Number of items per page (default: 10,
/// max: 100) - `page_number` - Zero-based page number (default: 0) - `transaction_type`
/// - Filter by transaction type - `start_date` - Filter entries from this date -
/// `end_date` - Filter entries until this date</para>
///
/// <para># Responses - `200 OK` - Returns list of ledger entries - `404 Not Found`
/// - Credit entitlement not found - `500 Internal Server Error` - Database or server error</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BalanceListLedgerParams : ParamsBase
{
    public required string CreditEntitlementID { get; init; }

    public string? CustomerID { get; init; }

    /// <summary>
    /// Filter by end date
    /// </summary>
    public DateTimeOffset? EndDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("end_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("end_date", value);
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

    /// <summary>
    /// Filter by start date
    /// </summary>
    public DateTimeOffset? StartDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("start_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("start_date", value);
        }
    }

    /// <summary>
    /// Filter by transaction type (snake_case: credit_added, credit_deducted, credit_expired, etc.)
    /// </summary>
    public string? TransactionType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("transaction_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("transaction_type", value);
        }
    }

    public BalanceListLedgerParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceListLedgerParams(BalanceListLedgerParams balanceListLedgerParams)
        : base(balanceListLedgerParams)
    {
        this.CreditEntitlementID = balanceListLedgerParams.CreditEntitlementID;
        this.CustomerID = balanceListLedgerParams.CustomerID;
    }
#pragma warning restore CS8618

    public BalanceListLedgerParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceListLedgerParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BalanceListLedgerParams FromRawUnchecked(
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

    public virtual bool Equals(BalanceListLedgerParams? other)
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
                    "/credit-entitlements/{0}/balances/{1}/ledger",
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
