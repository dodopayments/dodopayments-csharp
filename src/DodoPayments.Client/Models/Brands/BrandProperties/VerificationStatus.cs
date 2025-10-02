using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Brands.BrandProperties;

[JsonConverter(typeof(VerificationStatusConverter))]
public enum VerificationStatus
{
    Success,
    Fail,
    Review,
    Hold,
}

sealed class VerificationStatusConverter : JsonConverter<VerificationStatus>
{
    public override VerificationStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Success" => VerificationStatus.Success,
            "Fail" => VerificationStatus.Fail,
            "Review" => VerificationStatus.Review,
            "Hold" => VerificationStatus.Hold,
            _ => (VerificationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationStatus.Success => "Success",
                VerificationStatus.Fail => "Fail",
                VerificationStatus.Review => "Review",
                VerificationStatus.Hold => "Hold",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
