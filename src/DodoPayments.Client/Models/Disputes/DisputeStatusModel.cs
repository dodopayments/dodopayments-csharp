using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(DisputeStatusModelConverter))]
public enum DisputeStatusModel
{
    DisputeOpened,
    DisputeExpired,
    DisputeAccepted,
    DisputeCancelled,
    DisputeChallenged,
    DisputeWon,
    DisputeLost,
}

sealed class DisputeStatusModelConverter : JsonConverter<DisputeStatusModel>
{
    public override DisputeStatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute_opened" => DisputeStatusModel.DisputeOpened,
            "dispute_expired" => DisputeStatusModel.DisputeExpired,
            "dispute_accepted" => DisputeStatusModel.DisputeAccepted,
            "dispute_cancelled" => DisputeStatusModel.DisputeCancelled,
            "dispute_challenged" => DisputeStatusModel.DisputeChallenged,
            "dispute_won" => DisputeStatusModel.DisputeWon,
            "dispute_lost" => DisputeStatusModel.DisputeLost,
            _ => (DisputeStatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeStatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeStatusModel.DisputeOpened => "dispute_opened",
                DisputeStatusModel.DisputeExpired => "dispute_expired",
                DisputeStatusModel.DisputeAccepted => "dispute_accepted",
                DisputeStatusModel.DisputeCancelled => "dispute_cancelled",
                DisputeStatusModel.DisputeChallenged => "dispute_challenged",
                DisputeStatusModel.DisputeWon => "dispute_won",
                DisputeStatusModel.DisputeLost => "dispute_lost",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
