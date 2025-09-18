using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Payouts.PayoutListPageResponseProperties.ItemProperties;

/// <summary>
/// The current status of the payout.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    NotInitiated,
    InProgress,
    OnHold,
    Failed,
    Success,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_initiated" => Status.NotInitiated,
            "in_progress" => Status.InProgress,
            "on_hold" => Status.OnHold,
            "failed" => Status.Failed,
            "success" => Status.Success,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.NotInitiated => "not_initiated",
                Status.InProgress => "in_progress",
                Status.OnHold => "on_hold",
                Status.Failed => "failed",
                Status.Success => "success",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
