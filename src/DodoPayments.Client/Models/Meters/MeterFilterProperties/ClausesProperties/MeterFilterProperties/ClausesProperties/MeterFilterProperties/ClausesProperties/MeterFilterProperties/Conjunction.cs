using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

[JsonConverter(typeof(ConjunctionConverter))]
public enum Conjunction
{
    And,
    Or,
}

sealed class ConjunctionConverter : JsonConverter<Conjunction>
{
    public override Conjunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => Conjunction.And,
            "or" => Conjunction.Or,
            _ => (Conjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Conjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Conjunction.And => "and",
                Conjunction.Or => "or",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
