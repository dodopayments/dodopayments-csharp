using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(RefundStatusConverter))]
public enum RefundStatus
{
    Succeeded,
    Failed,
    Pending,
    Review,
}

sealed class RefundStatusConverter : JsonConverter<RefundStatus>
{
    public override RefundStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "succeeded" => RefundStatus.Succeeded,
            "failed" => RefundStatus.Failed,
            "pending" => RefundStatus.Pending,
            "review" => RefundStatus.Review,
            _ => (RefundStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefundStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefundStatus.Succeeded => "succeeded",
                RefundStatus.Failed => "failed",
                RefundStatus.Pending => "pending",
                RefundStatus.Review => "review",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
