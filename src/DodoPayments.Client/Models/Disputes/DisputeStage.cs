using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(DisputeStageConverter))]
public enum DisputeStage
{
    PreDispute,
    Dispute,
    PreArbitration,
}

sealed class DisputeStageConverter : JsonConverter<DisputeStage>
{
    public override DisputeStage Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pre_dispute" => DisputeStage.PreDispute,
            "dispute" => DisputeStage.Dispute,
            "pre_arbitration" => DisputeStage.PreArbitration,
            _ => (DisputeStage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeStage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeStage.PreDispute => "pre_dispute",
                DisputeStage.Dispute => "dispute",
                DisputeStage.PreArbitration => "pre_arbitration",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
