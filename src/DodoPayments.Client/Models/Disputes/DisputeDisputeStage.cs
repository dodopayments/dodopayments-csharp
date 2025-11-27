using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(DisputeDisputeStageConverter))]
public enum DisputeDisputeStage
{
    PreDispute,
    Dispute,
    PreArbitration,
}

sealed class DisputeDisputeStageConverter : JsonConverter<DisputeDisputeStage>
{
    public override DisputeDisputeStage Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pre_dispute" => DisputeDisputeStage.PreDispute,
            "dispute" => DisputeDisputeStage.Dispute,
            "pre_arbitration" => DisputeDisputeStage.PreArbitration,
            _ => (DisputeDisputeStage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeDisputeStage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeDisputeStage.PreDispute => "pre_dispute",
                DisputeDisputeStage.Dispute => "dispute",
                DisputeDisputeStage.PreArbitration => "pre_arbitration",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
