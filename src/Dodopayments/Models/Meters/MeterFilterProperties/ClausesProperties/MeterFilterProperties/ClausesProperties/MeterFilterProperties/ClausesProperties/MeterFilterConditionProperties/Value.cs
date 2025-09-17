using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;
using ValueVariants = Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties.ValueVariants;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public abstract record class Value
{
    internal Value() { }

    public static implicit operator Value(string value) => new ValueVariants::String(value);

    public static implicit operator Value(double value) => new ValueVariants::Double(value);

    public static implicit operator Value(bool value) => new ValueVariants::Bool(value);

    public abstract void Validate();
}

sealed class ValueConverter : JsonConverter<Value>
{
    public override Value? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ValueVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new ValueVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new ValueVariants::Bool(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Value value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ValueVariants::String(var string1) => string1,
            ValueVariants::Double(var double1) => double1,
            ValueVariants::Bool(var bool1) => bool1,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
