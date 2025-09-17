using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;
using ClausesVariants = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;
using System = System;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

/// <summary>
/// Level 2: Can be conditions or nested filters (1 more level allowed)
/// </summary>
[JsonConverter(typeof(Clauses2Converter))]
public abstract record class Clauses2
{
    internal Clauses2() { }

    public static implicit operator Clauses2(
        List<ClausesProperties::MeterFilterCondition2> value
    ) => new ClausesVariants::Level2FilterConditions(value);

    public static implicit operator Clauses2(List<ClausesProperties::MeterFilter3> value) =>
        new ClausesVariants::Level2NestedFilters(value);

    public abstract void Validate();
}

sealed class Clauses2Converter : JsonConverter<Clauses2>
{
    public override Clauses2? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesProperties::MeterFilterCondition2>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new ClausesVariants::Level2FilterConditions(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesProperties::MeterFilter3>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ClausesVariants::Level2NestedFilters(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses2 value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ClausesVariants::Level2FilterConditions(var level2FilterConditions) =>
                level2FilterConditions,
            ClausesVariants::Level2NestedFilters(var level2NestedFilters) => level2NestedFilters,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
