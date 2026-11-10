using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Invoices;

[JsonConverter(typeof(DunningStateConverter))]
public enum DunningState
{
    NotStarted,
    Active,
    Paused,
    Exhausted,
}

sealed class DunningStateConverter : JsonConverter<DunningState>
{
    public override DunningState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_started" => DunningState.NotStarted,
            "active" => DunningState.Active,
            "paused" => DunningState.Paused,
            "exhausted" => DunningState.Exhausted,
            _ => (DunningState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DunningState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DunningState.NotStarted => "not_started",
                DunningState.Active => "active",
                DunningState.Paused => "paused",
                DunningState.Exhausted => "exhausted",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
