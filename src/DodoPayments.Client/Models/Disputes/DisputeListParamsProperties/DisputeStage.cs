using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Disputes.DisputeListParamsProperties;

/// <summary>
/// Filter by dispute stage
/// </summary>
[JsonConverter(
    typeof(global::DodoPayments.Client.Models.Disputes.DisputeListParamsProperties.DisputeStageConverter)
)]
public enum DisputeStage
{
    PreDispute,
    Dispute,
    PreArbitration,
}

sealed class DisputeStageConverter
    : JsonConverter<global::DodoPayments.Client.Models.Disputes.DisputeListParamsProperties.DisputeStage>
{
    public override global::DodoPayments.Client.Models.Disputes.DisputeListParamsProperties.DisputeStage Read(
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
            _ =>
                (global::DodoPayments.Client.Models.Disputes.DisputeListParamsProperties.DisputeStage)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Disputes.DisputeListParamsProperties.DisputeStage value,
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
