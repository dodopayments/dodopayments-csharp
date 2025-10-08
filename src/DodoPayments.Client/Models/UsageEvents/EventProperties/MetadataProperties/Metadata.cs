using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.UsageEvents.EventProperties.MetadataProperties;

/// <summary>
/// Metadata value can be a string, integer, number, or boolean
/// </summary>
[JsonConverter(typeof(MetadataConverter))]
public record class Metadata
{
    public object Value { get; private init; }

    public Metadata(string value)
    {
        Value = value;
    }

    public Metadata(double value)
    {
        Value = value;
    }

    public Metadata(bool value)
    {
        Value = value;
    }

    Metadata(UnknownVariant value)
    {
        Value = value;
    }

    public static Metadata CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickNumber([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBoolean([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<double> @number, Action<bool> @boolean)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @number(value);
                break;
            case bool value:
                @boolean(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Metadata"
                );
        }
    }

    public T Match<T>(Func<string, T> @string, Func<double, T> @number, Func<bool, T> @boolean)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @number(value),
            bool value => @boolean(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Metadata"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Metadata"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
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
                return new Metadata(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'string'",
                    e
                )
            );
        }

        try
        {
            return new Metadata(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'double'",
                    e
                )
            );
        }

        try
        {
            return new Metadata(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
