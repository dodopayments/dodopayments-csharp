using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// How a score was measured. `targeted` means a check for that one category measured
/// it. `broad` means the general check that covers all categories measured it.
/// </summary>
[JsonConverter(typeof(ModerationProvenanceConverter))]
public enum ModerationProvenance
{
    Targeted,
    Broad,
}

sealed class ModerationProvenanceConverter : JsonConverter<ModerationProvenance>
{
    public override ModerationProvenance Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "targeted" => ModerationProvenance.Targeted,
            "broad" => ModerationProvenance.Broad,
            _ => (ModerationProvenance)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModerationProvenance value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModerationProvenance.Targeted => "targeted",
                ModerationProvenance.Broad => "broad",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
