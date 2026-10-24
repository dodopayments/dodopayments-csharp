using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

/// <summary>
/// How the cardholder completed the 3DS authentication.
/// </summary>
[JsonConverter(typeof(ThreeDSFlowConverter))]
public enum ThreeDSFlow
{
    Challenge,
    Frictionless,
}

sealed class ThreeDSFlowConverter : JsonConverter<ThreeDSFlow>
{
    public override ThreeDSFlow Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "challenge" => ThreeDSFlow.Challenge,
            "frictionless" => ThreeDSFlow.Frictionless,
            _ => (ThreeDSFlow)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThreeDSFlow value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThreeDSFlow.Challenge => "challenge",
                ThreeDSFlow.Frictionless => "frictionless",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
