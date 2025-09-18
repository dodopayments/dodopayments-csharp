using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(DisputeStatusConverter))]
public enum DisputeStatus
{
    DisputeOpened,
    DisputeExpired,
    DisputeAccepted,
    DisputeCancelled,
    DisputeChallenged,
    DisputeWon,
    DisputeLost,
}

sealed class DisputeStatusConverter : JsonConverter<DisputeStatus>
{
    public override DisputeStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute_opened" => DisputeStatus.DisputeOpened,
            "dispute_expired" => DisputeStatus.DisputeExpired,
            "dispute_accepted" => DisputeStatus.DisputeAccepted,
            "dispute_cancelled" => DisputeStatus.DisputeCancelled,
            "dispute_challenged" => DisputeStatus.DisputeChallenged,
            "dispute_won" => DisputeStatus.DisputeWon,
            "dispute_lost" => DisputeStatus.DisputeLost,
            _ => (DisputeStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeStatus.DisputeOpened => "dispute_opened",
                DisputeStatus.DisputeExpired => "dispute_expired",
                DisputeStatus.DisputeAccepted => "dispute_accepted",
                DisputeStatus.DisputeCancelled => "dispute_cancelled",
                DisputeStatus.DisputeChallenged => "dispute_challenged",
                DisputeStatus.DisputeWon => "dispute_won",
                DisputeStatus.DisputeLost => "dispute_lost",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
