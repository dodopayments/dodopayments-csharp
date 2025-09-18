using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MetadataVariants = DodoPayments.Client.Models.UsageEvents.EventProperties.MetadataProperties.MetadataVariants;

namespace DodoPayments.Client.Models.UsageEvents.EventProperties.MetadataProperties;

/// <summary>
/// Metadata value can be a string, integer, number, or boolean
/// </summary>
[JsonConverter(typeof(MetadataConverter))]
public abstract record class Metadata
{
    internal Metadata() { }

    public static implicit operator Metadata(string value) => new MetadataVariants::String(value);

    public static implicit operator Metadata(double value) => new MetadataVariants::Number(value);

    public static implicit operator Metadata(bool value) => new MetadataVariants::Boolean(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as MetadataVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickNumber([NotNullWhen(true)] out double? value)
    {
        value = (this as MetadataVariants::Number)?.Value;
        return value != null;
    }

    public bool TryPickBoolean([NotNullWhen(true)] out bool? value)
    {
        value = (this as MetadataVariants::Boolean)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MetadataVariants::String> @string,
        Action<MetadataVariants::Number> @number,
        Action<MetadataVariants::Boolean> @boolean
    )
    {
        switch (this)
        {
            case MetadataVariants::String inner:
                @string(inner);
                break;
            case MetadataVariants::Number inner:
                @number(inner);
                break;
            case MetadataVariants::Boolean inner:
                @boolean(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<MetadataVariants::String, T> @string,
        Func<MetadataVariants::Number, T> @number,
        Func<MetadataVariants::Boolean, T> @boolean
    )
    {
        return this switch
        {
            MetadataVariants::String inner => @string(inner),
            MetadataVariants::Number inner => @number(inner),
            MetadataVariants::Boolean inner => @boolean(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new MetadataVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new MetadataVariants::Number(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new MetadataVariants::Boolean(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            MetadataVariants::String(var @string) => @string,
            MetadataVariants::Number(var @number) => @number,
            MetadataVariants::Boolean(var @boolean) => @boolean,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
