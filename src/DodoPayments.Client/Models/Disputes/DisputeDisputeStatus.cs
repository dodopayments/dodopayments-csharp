using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(DisputeDisputeStatusConverter))]
public enum DisputeDisputeStatus
{
    DisputeOpened,
    DisputeExpired,
    DisputeAccepted,
    DisputeCancelled,
    DisputeChallenged,
    DisputeWon,
    DisputeLost,
}

sealed class DisputeDisputeStatusConverter : JsonConverter<DisputeDisputeStatus>
{
    public override DisputeDisputeStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute_opened" => DisputeDisputeStatus.DisputeOpened,
            "dispute_expired" => DisputeDisputeStatus.DisputeExpired,
            "dispute_accepted" => DisputeDisputeStatus.DisputeAccepted,
            "dispute_cancelled" => DisputeDisputeStatus.DisputeCancelled,
            "dispute_challenged" => DisputeDisputeStatus.DisputeChallenged,
            "dispute_won" => DisputeDisputeStatus.DisputeWon,
            "dispute_lost" => DisputeDisputeStatus.DisputeLost,
            _ => (DisputeDisputeStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeDisputeStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeDisputeStatus.DisputeOpened => "dispute_opened",
                DisputeDisputeStatus.DisputeExpired => "dispute_expired",
                DisputeDisputeStatus.DisputeAccepted => "dispute_accepted",
                DisputeDisputeStatus.DisputeCancelled => "dispute_cancelled",
                DisputeDisputeStatus.DisputeChallenged => "dispute_challenged",
                DisputeDisputeStatus.DisputeWon => "dispute_won",
                DisputeDisputeStatus.DisputeLost => "dispute_lost",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
