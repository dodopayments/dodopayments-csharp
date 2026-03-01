using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// Response for a ledger entry
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditLedgerEntry, CreditLedgerEntryFromRaw>))]
public sealed record class CreditLedgerEntry : JsonModel
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

    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
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

    public required ApiEnum<string, TransactionType> TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransactionType>>(
                "transaction_type"
            );
        }
        init { this._rawData.Set("transaction_type", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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

    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    public string? ReferenceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_type");
        }
        init { this._rawData.Set("reference_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.BalanceAfter;
        _ = this.BalanceBefore;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CreditEntitlementID;
        _ = this.CustomerID;
        _ = this.IsCredit;
        _ = this.OverageAfter;
        _ = this.OverageBefore;
        this.TransactionType.Validate();
        _ = this.Description;
        _ = this.GrantID;
        _ = this.ReferenceID;
        _ = this.ReferenceType;
    }

    public CreditLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditLedgerEntry(CreditLedgerEntry creditLedgerEntry)
        : base(creditLedgerEntry) { }
#pragma warning restore CS8618

    public CreditLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditLedgerEntryFromRaw.FromRawUnchecked"/>
    public static CreditLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditLedgerEntryFromRaw : IFromRawJson<CreditLedgerEntry>
{
    /// <inheritdoc/>
    public CreditLedgerEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TransactionTypeConverter))]
public enum TransactionType
{
    CreditAdded,
    CreditDeducted,
    CreditExpired,
    CreditRolledOver,
    RolloverForfeited,
    OverageCharged,
    AutoTopUp,
    ManualAdjustment,
    Refund,
}

sealed class TransactionTypeConverter : JsonConverter<TransactionType>
{
    public override TransactionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit_added" => TransactionType.CreditAdded,
            "credit_deducted" => TransactionType.CreditDeducted,
            "credit_expired" => TransactionType.CreditExpired,
            "credit_rolled_over" => TransactionType.CreditRolledOver,
            "rollover_forfeited" => TransactionType.RolloverForfeited,
            "overage_charged" => TransactionType.OverageCharged,
            "auto_top_up" => TransactionType.AutoTopUp,
            "manual_adjustment" => TransactionType.ManualAdjustment,
            "refund" => TransactionType.Refund,
            _ => (TransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionType.CreditAdded => "credit_added",
                TransactionType.CreditDeducted => "credit_deducted",
                TransactionType.CreditExpired => "credit_expired",
                TransactionType.CreditRolledOver => "credit_rolled_over",
                TransactionType.RolloverForfeited => "rollover_forfeited",
                TransactionType.OverageCharged => "overage_charged",
                TransactionType.AutoTopUp => "auto_top_up",
                TransactionType.ManualAdjustment => "manual_adjustment",
                TransactionType.Refund => "refund",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
