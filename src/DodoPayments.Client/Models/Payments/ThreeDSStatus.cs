using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

/// <summary>
/// The result of the 3DS authentication of a card payment, as the processor reports it.
/// </summary>
[JsonConverter(typeof(ThreeDSStatusConverter))]
public enum ThreeDSStatus
{
    Authenticated,
    AttemptAcknowledged,
    Exempted,
    Failed,
    NotSupported,
    ProcessingError,
}

sealed class ThreeDSStatusConverter : JsonConverter<ThreeDSStatus>
{
    public override ThreeDSStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authenticated" => ThreeDSStatus.Authenticated,
            "attempt_acknowledged" => ThreeDSStatus.AttemptAcknowledged,
            "exempted" => ThreeDSStatus.Exempted,
            "failed" => ThreeDSStatus.Failed,
            "not_supported" => ThreeDSStatus.NotSupported,
            "processing_error" => ThreeDSStatus.ProcessingError,
            _ => (ThreeDSStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThreeDSStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThreeDSStatus.Authenticated => "authenticated",
                ThreeDSStatus.AttemptAcknowledged => "attempt_acknowledged",
                ThreeDSStatus.Exempted => "exempted",
                ThreeDSStatus.Failed => "failed",
                ThreeDSStatus.NotSupported => "not_supported",
                ThreeDSStatus.ProcessingError => "processing_error",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
