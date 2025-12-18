using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

[JsonConverter(
    typeof(JsonModelConverter<CustomerWalletTransaction, CustomerWalletTransactionFromRaw>)
)]
public sealed record class CustomerWalletTransaction : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required long AfterBalance
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "after_balance"); }
        init { JsonModel.Set(this._rawData, "after_balance", value); }
    }

    public required long Amount
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    public required long BeforeBalance
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "before_balance"); }
        init { JsonModel.Set(this._rawData, "before_balance", value); }
    }

    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    public required string CustomerID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { JsonModel.Set(this._rawData, "customer_id", value); }
    }

    public required ApiEnum<string, EventType> EventType
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, EventType>>(
                this.RawData,
                "event_type"
            );
        }
        init { JsonModel.Set(this._rawData, "event_type", value); }
    }

    public required bool IsCredit
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_credit"); }
        init { JsonModel.Set(this._rawData, "is_credit", value); }
    }

    public string? Reason
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reason"); }
        init { JsonModel.Set(this._rawData, "reason", value); }
    }

    public string? ReferenceObjectID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reference_object_id"); }
        init { JsonModel.Set(this._rawData, "reference_object_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AfterBalance;
        _ = this.Amount;
        _ = this.BeforeBalance;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.CustomerID;
        this.EventType.Validate();
        _ = this.IsCredit;
        _ = this.Reason;
        _ = this.ReferenceObjectID;
    }

    public CustomerWalletTransaction() { }

    public CustomerWalletTransaction(CustomerWalletTransaction customerWalletTransaction)
        : base(customerWalletTransaction) { }

    public CustomerWalletTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerWalletTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerWalletTransactionFromRaw.FromRawUnchecked"/>
    public static CustomerWalletTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerWalletTransactionFromRaw : IFromRawJson<CustomerWalletTransaction>
{
    /// <inheritdoc/>
    public CustomerWalletTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerWalletTransaction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    Payment,
    PaymentReversal,
    Refund,
    RefundReversal,
    Dispute,
    DisputeReversal,
    MerchantAdjustment,
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment" => EventType.Payment,
            "payment_reversal" => EventType.PaymentReversal,
            "refund" => EventType.Refund,
            "refund_reversal" => EventType.RefundReversal,
            "dispute" => EventType.Dispute,
            "dispute_reversal" => EventType.DisputeReversal,
            "merchant_adjustment" => EventType.MerchantAdjustment,
            _ => (EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventType.Payment => "payment",
                EventType.PaymentReversal => "payment_reversal",
                EventType.Refund => "refund",
                EventType.RefundReversal => "refund_reversal",
                EventType.Dispute => "dispute",
                EventType.DisputeReversal => "dispute_reversal",
                EventType.MerchantAdjustment => "merchant_adjustment",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
