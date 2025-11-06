using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(DisputeStageModelConverter))]
public enum DisputeStageModel
{
    PreDispute,
    Dispute,
    PreArbitration,
}

sealed class DisputeStageModelConverter : JsonConverter<DisputeStageModel>
{
    public override DisputeStageModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pre_dispute" => DisputeStageModel.PreDispute,
            "dispute" => DisputeStageModel.Dispute,
            "pre_arbitration" => DisputeStageModel.PreArbitration,
            _ => (DisputeStageModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeStageModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeStageModel.PreDispute => "pre_dispute",
                DisputeStageModel.Dispute => "dispute",
                DisputeStageModel.PreArbitration => "pre_arbitration",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
