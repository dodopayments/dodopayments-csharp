using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Customers.Wallets.LedgerEntries.CustomerWalletTransactionProperties;

[JsonConverter(typeof(Dodopayments::EnumConverter<EventType, string>))]
public sealed record class EventType(string value) : Dodopayments::IEnum<EventType, string>
{
    public static readonly EventType Payment = new("payment");

    public static readonly EventType PaymentReversal = new("payment_reversal");

    public static readonly EventType Refund = new("refund");

    public static readonly EventType RefundReversal = new("refund_reversal");

    public static readonly EventType Dispute = new("dispute");

    public static readonly EventType DisputeReversal = new("dispute_reversal");

    public static readonly EventType MerchantAdjustment = new("merchant_adjustment");

    readonly string _value = value;

    public enum Value
    {
        Payment,
        PaymentReversal,
        Refund,
        RefundReversal,
        Dispute,
        DisputeReversal,
        MerchantAdjustment,
    }

    public Value Known() =>
        _value switch
        {
            "payment" => Value.Payment,
            "payment_reversal" => Value.PaymentReversal,
            "refund" => Value.Refund,
            "refund_reversal" => Value.RefundReversal,
            "dispute" => Value.Dispute,
            "dispute_reversal" => Value.DisputeReversal,
            "merchant_adjustment" => Value.MerchantAdjustment,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static EventType FromRaw(string value)
    {
        return new(value);
    }
}
