using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Meters.MeterAggregationProperties;

/// <summary>
/// Aggregation type for the meter
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Count,
    Sum,
    Max,
    Last,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "count" => MeterAggregationProperties.Type.Count,
            "sum" => MeterAggregationProperties.Type.Sum,
            "max" => MeterAggregationProperties.Type.Max,
            "last" => MeterAggregationProperties.Type.Last,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterAggregationProperties.Type.Count => "count",
                MeterAggregationProperties.Type.Sum => "sum",
                MeterAggregationProperties.Type.Max => "max",
                MeterAggregationProperties.Type.Last => "last",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
