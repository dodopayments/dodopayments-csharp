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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required long AfterBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("after_balance");
        }
        init { this._rawData.Set("after_balance", value); }
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

    public required long BeforeBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("before_balance");
        }
        init { this._rawData.Set("before_balance", value); }
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

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
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

    public required ApiEnum<string, EventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>("event_type");
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

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerWalletTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
