using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// Response for a customer's credit balance
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerCreditBalance, CustomerCreditBalanceFromRaw>))]
public sealed record class CustomerCreditBalance : JsonModel
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

    public required string Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance");
        }
        init { this._rawData.Set("balance", value); }
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

    public required string Overage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("overage");
        }
        init { this._rawData.Set("overage", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public DateTimeOffset? LastTransactionAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_transaction_at");
        }
        init { this._rawData.Set("last_transaction_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Balance;
        _ = this.CreatedAt;
        _ = this.CreditEntitlementID;
        _ = this.CustomerID;
        _ = this.Overage;
        _ = this.UpdatedAt;
        _ = this.LastTransactionAt;
    }

    public CustomerCreditBalance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerCreditBalance(CustomerCreditBalance customerCreditBalance)
        : base(customerCreditBalance) { }
#pragma warning restore CS8618

    public CustomerCreditBalance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerCreditBalance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerCreditBalanceFromRaw.FromRawUnchecked"/>
    public static CustomerCreditBalance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerCreditBalanceFromRaw : IFromRawJson<CustomerCreditBalance>
{
    /// <inheritdoc/>
    public CustomerCreditBalance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerCreditBalance.FromRawUnchecked(rawData);
}
