using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesVariants;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

/// <summary>
/// Level 2: Can be conditions or nested filters (1 more level allowed)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public abstract record class Clauses
{
    internal Clauses() { }

    public static implicit operator Clauses(List<ClausesProperties::MeterFilterCondition> value) =>
        new Level2FilterConditions(value);

    public static implicit operator Clauses(List<ClausesProperties::MeterFilter> value) =>
        new Level2NestedFilters(value);

    public bool TryPickLevel2FilterConditions(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilterCondition>? value
    )
    {
        value = (this as Level2FilterConditions)?.Value;
        return value != null;
    }

    public bool TryPickLevel2NestedFilters(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilter>? value
    )
    {
        value = (this as Level2NestedFilters)?.Value;
        return value != null;
    }

    public void Switch(
        Action<Level2FilterConditions> level2FilterConditions,
        Action<Level2NestedFilters> level2NestedFilters
    )
    {
        switch (this)
        {
            case Level2FilterConditions inner:
                level2FilterConditions(inner);
                break;
            case Level2NestedFilters inner:
                level2NestedFilters(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<Level2FilterConditions, T> level2FilterConditions,
        Func<Level2NestedFilters, T> level2NestedFilters
    )
    {
        return this switch
        {
            Level2FilterConditions inner => level2FilterConditions(inner),
            Level2NestedFilters inner => level2NestedFilters(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesProperties::MeterFilterCondition>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new Level2FilterConditions(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesProperties::MeterFilter>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Level2NestedFilters(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            Level2FilterConditions(var level2FilterConditions) => level2FilterConditions,
            Level2NestedFilters(var level2NestedFilters) => level2NestedFilters,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
