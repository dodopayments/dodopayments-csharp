using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MetadataVariants = DodoPayments.Client.Models.UsageEvents.EventInputProperties.MetadataProperties.MetadataVariants;
using System = System;

namespace DodoPayments.Client.Models.UsageEvents.EventInputProperties.MetadataProperties;

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

    public abstract void Validate();
}

sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
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

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            MetadataVariants::String(var string1) => string1,
            MetadataVariants::Number(var number) => number,
            MetadataVariants::Boolean(var boolean) => boolean,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
