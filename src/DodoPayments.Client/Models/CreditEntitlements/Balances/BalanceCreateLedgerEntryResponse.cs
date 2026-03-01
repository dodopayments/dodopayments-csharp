using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// Response for creating a ledger entry
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BalanceCreateLedgerEntryResponse,
        BalanceCreateLedgerEntryResponseFromRaw
    >)
)]
public sealed record class BalanceCreateLedgerEntryResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string BalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance_after");
        }
        init { this._rawData.Set("balance_after", value); }
    }

    public required string BalanceBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance_before");
        }
        init { this._rawData.Set("balance_before", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required ApiEnum<string, LedgerEntryType> EntryType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LedgerEntryType>>("entry_type");
        }
        init { this._rawData.Set("entry_type", value); }
    }

    public required bool IsCredit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_credit");
        }
        init { this._rawData.Set("is_credit", value); }
    }

    public required string OverageAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage_after");
        }
        init { this._rawData.Set("overage_after", value); }
    }

    public required string OverageBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage_before");
        }
        init { this._rawData.Set("overage_before", value); }
    }

    public string? GrantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grant_id");
        }
        init { this._rawData.Set("grant_id", value); }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.BalanceAfter;
        _ = this.BalanceBefore;
        _ = this.CreatedAt;
        _ = this.CreditEntitlementID;
        _ = this.CustomerID;
        this.EntryType.Validate();
        _ = this.IsCredit;
        _ = this.OverageAfter;
        _ = this.OverageBefore;
        _ = this.GrantID;
        _ = this.Reason;
    }

    public BalanceCreateLedgerEntryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceCreateLedgerEntryResponse(
        BalanceCreateLedgerEntryResponse balanceCreateLedgerEntryResponse
    )
        : base(balanceCreateLedgerEntryResponse) { }
#pragma warning restore CS8618

    public BalanceCreateLedgerEntryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceCreateLedgerEntryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceCreateLedgerEntryResponseFromRaw.FromRawUnchecked"/>
    public static BalanceCreateLedgerEntryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceCreateLedgerEntryResponseFromRaw : IFromRawJson<BalanceCreateLedgerEntryResponse>
{
    /// <inheritdoc/>
    public BalanceCreateLedgerEntryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceCreateLedgerEntryResponse.FromRawUnchecked(rawData);
}
