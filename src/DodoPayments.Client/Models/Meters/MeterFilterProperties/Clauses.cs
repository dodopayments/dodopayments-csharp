using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using ClausesProperties = DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties;

/// <summary>
/// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public record class Clauses
{
    public object Value { get; private init; }

    public Clauses(List<ClausesProperties::MeterFilterCondition> value)
    {
        Value = value;
    }

    public Clauses(List<ClausesProperties::MeterFilter> value)
    {
        Value = value;
    }

    Clauses(UnknownVariant value)
    {
        Value = value;
    }

    public static Clauses CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDirectFilterConditions(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilterCondition>? value
    )
    {
        value = this.Value as List<ClausesProperties::MeterFilterCondition>;
        return value != null;
    }

    public bool TryPickNestedMeterFilters(
        [NotNullWhen(true)] out List<ClausesProperties::MeterFilter>? value
    )
    {
        value = this.Value as List<ClausesProperties::MeterFilter>;
        return value != null;
    }

    public void Switch(
        Action<List<ClausesProperties::MeterFilterCondition>> directFilterConditions,
        Action<List<ClausesProperties::MeterFilter>> nestedMeterFilters
    )
    {
        switch (this.Value)
        {
            case List<ClausesProperties::MeterFilterCondition> value:
                directFilterConditions(value);
                break;
            case List<ClausesProperties::MeterFilter> value:
                nestedMeterFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses"
                );
        }
    }

    public T Match<T>(
        Func<List<ClausesProperties::MeterFilterCondition>, T> directFilterConditions,
        Func<List<ClausesProperties::MeterFilter>, T> nestedMeterFilters
    )
    {
        return this.Value switch
        {
            List<ClausesProperties::MeterFilterCondition> value => directFilterConditions(value),
            List<ClausesProperties::MeterFilter> value => nestedMeterFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Clauses");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesProperties::MeterFilterCondition>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new Clauses(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<ClausesProperties::MeterFilterCondition>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesProperties::MeterFilter>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Clauses(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<ClausesProperties::MeterFilter>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
