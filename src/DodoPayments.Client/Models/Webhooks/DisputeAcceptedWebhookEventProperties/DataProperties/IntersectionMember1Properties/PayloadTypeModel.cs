using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Webhooks.DisputeAcceptedWebhookEventProperties.DataProperties.IntersectionMember1Properties;

/// <summary>
/// The type of payload in the data field
/// </summary>
[JsonConverter(typeof(PayloadTypeModelConverter))]
public enum PayloadTypeModel
{
    Dispute,
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
            "Dispute" => PayloadTypeModel.Dispute,
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
                PayloadTypeModel.Dispute => "Dispute",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
