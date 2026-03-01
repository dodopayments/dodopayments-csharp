using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// For credit entries, a new grant is created. For debit entries, credits are deducted
/// from existing grants using FIFO (oldest first).
///
/// <para># Authentication Requires an API key with `Editor` role.</para>
///
/// <para># Path Parameters - `credit_entitlement_id` - The unique identifier of
/// the credit entitlement - `customer_id` - The unique identifier of the customer</para>
///
/// <para># Request Body - `entry_type` - "credit" or "debit" - `amount` - Amount
/// to credit or debit - `reason` - Optional human-readable reason - `expires_at`
/// - Optional expiration for credited amount (only for credit type) - `idempotency_key`
/// - Optional key to prevent duplicate entries</para>
///
/// <para># Responses - `201 Created` - Ledger entry created successfully - `400
/// Bad Request` - Invalid request (e.g., debit with insufficient balance) - `404
/// Not Found` - Credit entitlement or customer not found - `409 Conflict` - Idempotency
/// key already exists - `500 Internal Server Error` - Database or server error</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BalanceCreateLedgerEntryParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string CreditEntitlementID { get; init; }

    public string? CustomerID { get; init; }

    /// <summary>
    /// Amount to credit or debit
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// Entry type: credit or debit
    /// </summary>
    public required ApiEnum<string, LedgerEntryType> EntryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, LedgerEntryType>>(
                "entry_type"
            );
        }
        init { this._rawBodyData.Set("entry_type", value); }
    }

    /// <summary>
    /// Expiration for credited amount (only for credit type)
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawBodyData.Set("expires_at", value); }
    }

    /// <summary>
    /// Idempotency key to prevent duplicate entries
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawBodyData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// Optional metadata (max 50 key-value pairs, key max 40 chars, value max 500 chars)
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Human-readable reason for the entry
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reason");
        }
        init { this._rawBodyData.Set("reason", value); }
    }

    public BalanceCreateLedgerEntryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceCreateLedgerEntryParams(
        BalanceCreateLedgerEntryParams balanceCreateLedgerEntryParams
    )
        : base(balanceCreateLedgerEntryParams)
    {
        this.CreditEntitlementID = balanceCreateLedgerEntryParams.CreditEntitlementID;
        this.CustomerID = balanceCreateLedgerEntryParams.CustomerID;

        this._rawBodyData = new(balanceCreateLedgerEntryParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BalanceCreateLedgerEntryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceCreateLedgerEntryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BalanceCreateLedgerEntryParams FromRawUnchecked(
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BalanceCreateLedgerEntryParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CreditEntitlementID.Equals(other.CreditEntitlementID)
            && (this.CustomerID?.Equals(other.CustomerID) ?? other.CustomerID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/credit-entitlements/{0}/balances/{1}/ledger-entries",
                    this.CreditEntitlementID,
                    this.CustomerID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
    }
}
