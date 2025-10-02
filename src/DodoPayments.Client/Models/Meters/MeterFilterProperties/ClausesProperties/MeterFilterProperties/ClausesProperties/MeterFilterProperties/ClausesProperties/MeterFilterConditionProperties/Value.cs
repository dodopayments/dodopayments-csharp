using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using ValueVariants = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties.ValueVariants;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterConditionProperties;

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

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ValueVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as ValueVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as ValueVariants::Bool)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ValueVariants::String> @string,
        Action<ValueVariants::Double> @double,
        Action<ValueVariants::Bool> @bool
    )
    {
        switch (this)
        {
            case ValueVariants::String inner:
                @string(inner);
                break;
            case ValueVariants::Double inner:
                @double(inner);
                break;
            case ValueVariants::Bool inner:
                @bool(inner);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Value"
                );
        }
    }

    public T Match<T>(
        Func<ValueVariants::String, T> @string,
        Func<ValueVariants::Double, T> @double,
        Func<ValueVariants::Bool, T> @bool
    )
    {
        return this switch
        {
            ValueVariants::String inner => @string(inner),
            ValueVariants::Double inner => @double(inner),
            ValueVariants::Bool inner => @bool(inner),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Value"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ValueConverter : JsonConverter<Value>
{
    public override Value? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

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
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant ValueVariants::String",
                    e
                )
            );
        }

        try
        {
            return new ValueVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant ValueVariants::Double",
                    e
                )
            );
        }

        try
        {
            return new ValueVariants::Bool(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant ValueVariants::Bool",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Value value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ValueVariants::String(var @string) => @string,
            ValueVariants::Double(var @double) => @double,
            ValueVariants::Bool(var @bool) => @bool,
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Value"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
