using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries.CustomerWalletTransactionProperties;

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
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
