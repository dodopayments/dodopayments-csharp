using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks.RefundSucceededWebhookEventProperties.DataProperties.IntersectionMember1Properties;

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(PayloadTypeModelConverter))]
public enum PayloadTypeModel
{
    Refund,
}

sealed class PayloadTypeModelConverter : JsonConverter<PayloadTypeModel>
{
    public override PayloadTypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Refund" => PayloadTypeModel.Refund,
            _ => (PayloadTypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayloadTypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PayloadTypeModel.Refund => "Refund",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
