using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesVariants;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties;

/// <summary>
/// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public abstract record class Clauses
{
    internal Clauses() { }

    public static implicit operator Clauses(List<ClausesProperties::MeterFilterCondition> value) =>
        new DirectFilterConditions(value);

    public static implicit operator Clauses(List<ClausesProperties::MeterFilter> value) =>
        new NestedMeterFilters(value);

    public bool TryPickDirectFilterConditions(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilterCondition>? value
    )
    {
        value = (this as DirectFilterConditions)?.Value;
        return value != null;
    }

    public bool TryPickNestedMeterFilters(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilter>? value
    )
    {
        value = (this as NestedMeterFilters)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DirectFilterConditions> directFilterConditions,
        Action<NestedMeterFilters> nestedMeterFilters
    )
    {
        switch (this)
        {
            case DirectFilterConditions inner:
                directFilterConditions(inner);
                break;
            case NestedMeterFilters inner:
                nestedMeterFilters(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DirectFilterConditions, T> directFilterConditions,
        Func<NestedMeterFilters, T> nestedMeterFilters
    )
    {
        return this switch
        {
            DirectFilterConditions inner => directFilterConditions(inner),
            NestedMeterFilters inner => nestedMeterFilters(inner),
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
                return new DirectFilterConditions(deserialized);
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
                return new NestedMeterFilters(deserialized);
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
            DirectFilterConditions(var directFilterConditions) => directFilterConditions,
            NestedMeterFilters(var nestedMeterFilters) => nestedMeterFilters,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
