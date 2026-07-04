using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// Type of capability a `feature_flag` entitlement confers.
/// </summary>
[JsonConverter(typeof(FeatureTypeConverter))]
public enum FeatureType
{
    Boolean,
}

sealed class FeatureTypeConverter : JsonConverter<FeatureType>
{
    public override FeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "boolean" => FeatureType.Boolean,
            _ => (FeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureType.Boolean => "boolean",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
