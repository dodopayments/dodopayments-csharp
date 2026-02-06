using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Misc = DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Balances;

[JsonConverter(typeof(JsonModelConverter<BalanceLedgerEntry, BalanceLedgerEntryFromRaw>))]
public sealed record class BalanceLedgerEntry : JsonModel
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

    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
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

    public required ApiEnum<string, Misc::Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Misc::Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required ApiEnum<string, BalanceLedgerEntryEventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BalanceLedgerEntryEventType>>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
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

    public required long UsdEquivalentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("usd_equivalent_amount");
        }
        init { this._rawData.Set("usd_equivalent_amount", value); }
    }

    public long? AfterBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("after_balance");
        }
        init { this._rawData.Set("after_balance", value); }
    }

    public long? BeforeBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("before_balance");
        }
        init { this._rawData.Set("before_balance", value); }
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

    public string? ReferenceObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_object_id");
        }
        init { this._rawData.Set("reference_object_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.EventType.Validate();
        _ = this.IsCredit;
        _ = this.UsdEquivalentAmount;
        _ = this.AfterBalance;
        _ = this.BeforeBalance;
        _ = this.Description;
        _ = this.ReferenceObjectID;
    }

    public BalanceLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceLedgerEntry(BalanceLedgerEntry balanceLedgerEntry)
        : base(balanceLedgerEntry) { }
#pragma warning restore CS8618

    public BalanceLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceLedgerEntryFromRaw.FromRawUnchecked"/>
    public static BalanceLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceLedgerEntryFromRaw : IFromRawJson<BalanceLedgerEntry>
{
    /// <inheritdoc/>
    public BalanceLedgerEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BalanceLedgerEntryEventTypeConverter))]
public enum BalanceLedgerEntryEventType
{
    Payment,
    Refund,
    RefundReversal,
    Dispute,
    DisputeReversal,
    Tax,
    TaxReversal,
    PaymentFees,
    RefundFees,
    RefundFeesReversal,
    DisputeFees,
    Payout,
    PayoutFees,
    PayoutReversal,
    PayoutFeesReversal,
    DodoCredits,
    Adjustment,
    CurrencyConversion,
}

sealed class BalanceLedgerEntryEventTypeConverter : JsonConverter<BalanceLedgerEntryEventType>
{
    public override BalanceLedgerEntryEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment" => BalanceLedgerEntryEventType.Payment,
            "refund" => BalanceLedgerEntryEventType.Refund,
            "refund_reversal" => BalanceLedgerEntryEventType.RefundReversal,
            "dispute" => BalanceLedgerEntryEventType.Dispute,
            "dispute_reversal" => BalanceLedgerEntryEventType.DisputeReversal,
            "tax" => BalanceLedgerEntryEventType.Tax,
            "tax_reversal" => BalanceLedgerEntryEventType.TaxReversal,
            "payment_fees" => BalanceLedgerEntryEventType.PaymentFees,
            "refund_fees" => BalanceLedgerEntryEventType.RefundFees,
            "refund_fees_reversal" => BalanceLedgerEntryEventType.RefundFeesReversal,
            "dispute_fees" => BalanceLedgerEntryEventType.DisputeFees,
            "payout" => BalanceLedgerEntryEventType.Payout,
            "payout_fees" => BalanceLedgerEntryEventType.PayoutFees,
            "payout_reversal" => BalanceLedgerEntryEventType.PayoutReversal,
            "payout_fees_reversal" => BalanceLedgerEntryEventType.PayoutFeesReversal,
            "dodo_credits" => BalanceLedgerEntryEventType.DodoCredits,
            "adjustment" => BalanceLedgerEntryEventType.Adjustment,
            "currency_conversion" => BalanceLedgerEntryEventType.CurrencyConversion,
            _ => (BalanceLedgerEntryEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceLedgerEntryEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceLedgerEntryEventType.Payment => "payment",
                BalanceLedgerEntryEventType.Refund => "refund",
                BalanceLedgerEntryEventType.RefundReversal => "refund_reversal",
                BalanceLedgerEntryEventType.Dispute => "dispute",
                BalanceLedgerEntryEventType.DisputeReversal => "dispute_reversal",
                BalanceLedgerEntryEventType.Tax => "tax",
                BalanceLedgerEntryEventType.TaxReversal => "tax_reversal",
                BalanceLedgerEntryEventType.PaymentFees => "payment_fees",
                BalanceLedgerEntryEventType.RefundFees => "refund_fees",
                BalanceLedgerEntryEventType.RefundFeesReversal => "refund_fees_reversal",
                BalanceLedgerEntryEventType.DisputeFees => "dispute_fees",
                BalanceLedgerEntryEventType.Payout => "payout",
                BalanceLedgerEntryEventType.PayoutFees => "payout_fees",
                BalanceLedgerEntryEventType.PayoutReversal => "payout_reversal",
                BalanceLedgerEntryEventType.PayoutFeesReversal => "payout_fees_reversal",
                BalanceLedgerEntryEventType.DodoCredits => "dodo_credits",
                BalanceLedgerEntryEventType.Adjustment => "adjustment",
                BalanceLedgerEntryEventType.CurrencyConversion => "currency_conversion",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
