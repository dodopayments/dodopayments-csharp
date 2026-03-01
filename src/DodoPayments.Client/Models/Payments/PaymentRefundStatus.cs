using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(PaymentRefundStatusConverter))]
public enum PaymentRefundStatus
{
    Partial,
    Full,
}

sealed class PaymentRefundStatusConverter : JsonConverter<PaymentRefundStatus>
{
    public override PaymentRefundStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "partial" => PaymentRefundStatus.Partial,
            "full" => PaymentRefundStatus.Full,
            _ => (PaymentRefundStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentRefundStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentRefundStatus.Partial => "partial",
                PaymentRefundStatus.Full => "full",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
