using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;

[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => Operator.Equals,
            "not_equals" => Operator.NotEquals,
            "greater_than" => Operator.GreaterThan,
            "greater_than_or_equals" => Operator.GreaterThanOrEquals,
            "less_than" => Operator.LessThan,
            "less_than_or_equals" => Operator.LessThanOrEquals,
            "contains" => Operator.Contains,
            "does_not_contain" => Operator.DoesNotContain,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.Equals => "equals",
                Operator.NotEquals => "not_equals",
                Operator.GreaterThan => "greater_than",
                Operator.GreaterThanOrEquals => "greater_than_or_equals",
                Operator.LessThan => "less_than",
                Operator.LessThanOrEquals => "less_than_or_equals",
                Operator.Contains => "contains",
                Operator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
