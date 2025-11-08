using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Meters;

/// <summary>
/// A filter structure that combines multiple conditions with logical conjunctions (AND/OR).
///
/// <para>Supports up to 3 levels of nesting to create complex filter expressions.
/// Each filter has a conjunction (and/or) and clauses that can be either direct conditions
/// or nested filters.</para>
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter>))]
public sealed record class MeterFilter : ModelBase, IFromRaw<MeterFilter>
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required Clauses Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Clauses>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required ApiEnum<string, Conjunction2> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Conjunction2>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter() { }

    public MeterFilter(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public record class Clauses
{
    public object Value { get; private init; }

    public Clauses(IReadOnlyList<MeterFilterCondition> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public Clauses(IReadOnlyList<MeterFilterModel> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
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
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterCondition>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterCondition>;
        return value != null;
    }

    public bool TryPickNestedMeterFilters(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterModel>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterModel>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterCondition>> directFilterConditions,
        System::Action<IReadOnlyList<MeterFilterModel>> nestedMeterFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterCondition> value:
                directFilterConditions(value);
                break;
            case List<MeterFilterModel> value:
                nestedMeterFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterCondition>, T> directFilterConditions,
        System::Func<IReadOnlyList<MeterFilterModel>, T> nestedMeterFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition> value => directFilterConditions(value),
            IReadOnlyList<MeterFilterModel> value => nestedMeterFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public static implicit operator Clauses(List<MeterFilterCondition> value) =>
        new((IReadOnlyList<MeterFilterCondition>)value);

    public static implicit operator Clauses(List<MeterFilterModel> value) =>
        new((IReadOnlyList<MeterFilterModel>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Clauses");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterCondition>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Clauses(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<MeterFilterCondition>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterModel>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Clauses(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<MeterFilterModel>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterCondition>))]
public sealed record class MeterFilterCondition : ModelBase, IFromRaw<MeterFilterCondition>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ValueModel Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ValueModel>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition() { }

    public MeterFilterCondition(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => Operator.Equals,
            "not_equals" => Operator.NotEquals,
            "greater_than" => Operator.GreaterThan,
            "greater_than_or_equals" => Operator.GreaterThanOrEquals,
            "less_than" => Operator.LessThan,
            "less_than_or_equals" => Operator.LessThanOrEquals,
            "contains" => Operator.Contains,
            "does_not_contain" => Operator.DoesNotContain,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.Equals => "equals",
                Operator.NotEquals => "not_equals",
                Operator.GreaterThan => "greater_than",
                Operator.GreaterThanOrEquals => "greater_than_or_equals",
                Operator.LessThan => "less_than",
                Operator.LessThanOrEquals => "less_than_or_equals",
                Operator.Contains => "contains",
                Operator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(ValueModelConverter))]
public record class ValueModel
{
    public object Value { get; private init; }

    public ValueModel(string value)
    {
        Value = value;
    }

    public ValueModel(double value)
    {
        Value = value;
    }

    public ValueModel(bool value)
    {
        Value = value;
    }

    ValueModel(UnknownVariant value)
    {
        Value = value;
    }

    public static ValueModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ValueModel"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ValueModel"
            ),
        };
    }

    public static implicit operator ValueModel(string value) => new(value);

    public static implicit operator ValueModel(double value) => new(value);

    public static implicit operator ValueModel(bool value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ValueModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ValueModelConverter : JsonConverter<ValueModel>
{
    public override ValueModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ValueModel(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new ValueModel(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new ValueModel(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ValueModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Level 1 nested filter - can contain Level 2 filters
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterModel>))]
public sealed record class MeterFilterModel : ModelBase, IFromRaw<MeterFilterModel>
{
    /// <summary>
    /// Level 1: Can be conditions or nested filters (2 more levels allowed)
    /// </summary>
    public required ClausesModel Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ClausesModel>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Conjunction1> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Conjunction1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilterModel() { }

    public MeterFilterModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(ClausesModelConverter))]
public record class ClausesModel
{
    public object Value { get; private init; }

    public ClausesModel(IReadOnlyList<MeterFilterConditionModel> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public ClausesModel(IReadOnlyList<MeterFilter1> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    ClausesModel(UnknownVariant value)
    {
        Value = value;
    }

    public static ClausesModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickLevel1FilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterConditionModel>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterConditionModel>;
        return value != null;
    }

    public bool TryPickLevel1NestedFilters(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilter1>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilter1>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterConditionModel>> level1FilterConditions,
        System::Action<IReadOnlyList<MeterFilter1>> level1NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterConditionModel> value:
                level1FilterConditions(value);
                break;
            case List<MeterFilter1> value:
                level1NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ClausesModel"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterConditionModel>, T> level1FilterConditions,
        System::Func<IReadOnlyList<MeterFilter1>, T> level1NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterConditionModel> value => level1FilterConditions(value),
            IReadOnlyList<MeterFilter1> value => level1NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesModel"
            ),
        };
    }

    public static implicit operator ClausesModel(List<MeterFilterConditionModel> value) =>
        new((IReadOnlyList<MeterFilterConditionModel>)value);

    public static implicit operator ClausesModel(List<MeterFilter1> value) =>
        new((IReadOnlyList<MeterFilter1>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ClausesModelConverter : JsonConverter<ClausesModel>
{
    public override ClausesModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterConditionModel>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ClausesModel(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<MeterFilterConditionModel>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilter1>>(ref reader, options);
            if (deserialized != null)
            {
                return new ClausesModel(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<MeterFilter1>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterConditionModel>))]
public sealed record class MeterFilterConditionModel
    : ModelBase,
        IFromRaw<MeterFilterConditionModel>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, OperatorModel> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, OperatorModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required Value1 Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Value1>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterConditionModel() { }

    public MeterFilterConditionModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterConditionModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterConditionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(OperatorModelConverter))]
public enum OperatorModel
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class OperatorModelConverter : JsonConverter<OperatorModel>
{
    public override OperatorModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => OperatorModel.Equals,
            "not_equals" => OperatorModel.NotEquals,
            "greater_than" => OperatorModel.GreaterThan,
            "greater_than_or_equals" => OperatorModel.GreaterThanOrEquals,
            "less_than" => OperatorModel.LessThan,
            "less_than_or_equals" => OperatorModel.LessThanOrEquals,
            "contains" => OperatorModel.Contains,
            "does_not_contain" => OperatorModel.DoesNotContain,
            _ => (OperatorModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OperatorModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OperatorModel.Equals => "equals",
                OperatorModel.NotEquals => "not_equals",
                OperatorModel.GreaterThan => "greater_than",
                OperatorModel.GreaterThanOrEquals => "greater_than_or_equals",
                OperatorModel.LessThan => "less_than",
                OperatorModel.LessThanOrEquals => "less_than_or_equals",
                OperatorModel.Contains => "contains",
                OperatorModel.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(Value1Converter))]
public record class Value1
{
    public object Value { get; private init; }

    public Value1(string value)
    {
        Value = value;
    }

    public Value1(double value)
    {
        Value = value;
    }

    public Value1(bool value)
    {
        Value = value;
    }

    Value1(UnknownVariant value)
    {
        Value = value;
    }

    public static Value1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Value1"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Value1"
            ),
        };
    }

    public static implicit operator Value1(string value) => new(value);

    public static implicit operator Value1(double value) => new(value);

    public static implicit operator Value1(bool value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Value1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Value1Converter : JsonConverter<Value1>
{
    public override Value1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Value1(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new Value1(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new Value1(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Value1 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Level 2 nested filter
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter1>))]
public sealed record class MeterFilter1 : ModelBase, IFromRaw<MeterFilter1>
{
    /// <summary>
    /// Level 2: Can be conditions or nested filters (1 more level allowed)
    /// </summary>
    public required Clauses1 Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Clauses1>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, ConjunctionModel> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ConjunctionModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter1() { }

    public MeterFilter1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilter1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Level 2: Can be conditions or nested filters (1 more level allowed)
/// </summary>
[JsonConverter(typeof(Clauses1Converter))]
public record class Clauses1
{
    public object Value { get; private init; }

    public Clauses1(IReadOnlyList<MeterFilterCondition1> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public Clauses1(IReadOnlyList<MeterFilter2> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    Clauses1(UnknownVariant value)
    {
        Value = value;
    }

    public static Clauses1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickLevel2FilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterCondition1>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterCondition1>;
        return value != null;
    }

    public bool TryPickLevel2NestedFilters(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilter2>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilter2>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<MeterFilterCondition1>> level2FilterConditions,
        System::Action<IReadOnlyList<MeterFilter2>> level2NestedFilters
    )
    {
        switch (this.Value)
        {
            case List<MeterFilterCondition1> value:
                level2FilterConditions(value);
                break;
            case List<MeterFilter2> value:
                level2NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses1"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterCondition1>, T> level2FilterConditions,
        System::Func<IReadOnlyList<MeterFilter2>, T> level2NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition1> value => level2FilterConditions(value),
            IReadOnlyList<MeterFilter2> value => level2NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses1"
            ),
        };
    }

    public static implicit operator Clauses1(List<MeterFilterCondition1> value) =>
        new((IReadOnlyList<MeterFilterCondition1>)value);

    public static implicit operator Clauses1(List<MeterFilter2> value) =>
        new((IReadOnlyList<MeterFilter2>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses1"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Clauses1Converter : JsonConverter<Clauses1>
{
    public override Clauses1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterCondition1>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Clauses1(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<MeterFilterCondition1>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilter2>>(ref reader, options);
            if (deserialized != null)
            {
                return new Clauses1(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'List<MeterFilter2>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Clauses1 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilterCondition1>))]
public sealed record class MeterFilterCondition1 : ModelBase, IFromRaw<MeterFilterCondition1>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Operator1> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required Value2 Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Value2>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition1() { }

    public MeterFilterCondition1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilterCondition1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Operator1Converter))]
public enum Operator1
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class Operator1Converter : JsonConverter<Operator1>
{
    public override Operator1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => Operator1.Equals,
            "not_equals" => Operator1.NotEquals,
            "greater_than" => Operator1.GreaterThan,
            "greater_than_or_equals" => Operator1.GreaterThanOrEquals,
            "less_than" => Operator1.LessThan,
            "less_than_or_equals" => Operator1.LessThanOrEquals,
            "contains" => Operator1.Contains,
            "does_not_contain" => Operator1.DoesNotContain,
            _ => (Operator1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator1.Equals => "equals",
                Operator1.NotEquals => "not_equals",
                Operator1.GreaterThan => "greater_than",
                Operator1.GreaterThanOrEquals => "greater_than_or_equals",
                Operator1.LessThan => "less_than",
                Operator1.LessThanOrEquals => "less_than_or_equals",
                Operator1.Contains => "contains",
                Operator1.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(Value2Converter))]
public record class Value2
{
    public object Value { get; private init; }

    public Value2(string value)
    {
        Value = value;
    }

    public Value2(double value)
    {
        Value = value;
    }

    public Value2(bool value)
    {
        Value = value;
    }

    Value2(UnknownVariant value)
    {
        Value = value;
    }

    public static Value2 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Value2"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Value2"
            ),
        };
    }

    public static implicit operator Value2(string value) => new(value);

    public static implicit operator Value2(double value) => new(value);

    public static implicit operator Value2(bool value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Value2");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Value2Converter : JsonConverter<Value2>
{
    public override Value2? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Value2(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new Value2(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new Value2(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Value2 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Level 3 nested filter (final nesting level)
/// </summary>
[JsonConverter(typeof(ModelConverter<MeterFilter2>))]
public sealed record class MeterFilter2 : ModelBase, IFromRaw<MeterFilter2>
{
    /// <summary>
    /// Level 3: Filter conditions only (max depth reached)
    /// </summary>
    public required List<Clause> Clauses
    {
        get
        {
            if (!this._properties.TryGetValue("clauses", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentOutOfRangeException("clauses", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Clause>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'clauses' cannot be null",
                    new System::ArgumentNullException("clauses")
                );
        }
        init
        {
            this._properties["clauses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            if (!this._properties.TryGetValue("conjunction", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'conjunction' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conjunction",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conjunction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Clauses)
        {
            item.Validate();
        }
        this.Conjunction.Validate();
    }

    public MeterFilter2() { }

    public MeterFilter2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MeterFilter2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(ModelConverter<Clause>))]
public sealed record class Clause : ModelBase, IFromRaw<Clause>
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            if (!this._properties.TryGetValue("key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentOutOfRangeException("key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'key' cannot be null",
                    new System::ArgumentNullException("key")
                );
        }
        init
        {
            this._properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Operator2> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator2>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required Value3 Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Value3>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public Clause() { }

    public Clause(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clause(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Clause FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Operator2Converter))]
public enum Operator2
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEquals,
    LessThan,
    LessThanOrEquals,
    Contains,
    DoesNotContain,
}

sealed class Operator2Converter : JsonConverter<Operator2>
{
    public override Operator2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => Operator2.Equals,
            "not_equals" => Operator2.NotEquals,
            "greater_than" => Operator2.GreaterThan,
            "greater_than_or_equals" => Operator2.GreaterThanOrEquals,
            "less_than" => Operator2.LessThan,
            "less_than_or_equals" => Operator2.LessThanOrEquals,
            "contains" => Operator2.Contains,
            "does_not_contain" => Operator2.DoesNotContain,
            _ => (Operator2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator2.Equals => "equals",
                Operator2.NotEquals => "not_equals",
                Operator2.GreaterThan => "greater_than",
                Operator2.GreaterThanOrEquals => "greater_than_or_equals",
                Operator2.LessThan => "less_than",
                Operator2.LessThanOrEquals => "less_than_or_equals",
                Operator2.Contains => "contains",
                Operator2.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(Value3Converter))]
public record class Value3
{
    public object Value { get; private init; }

    public Value3(string value)
    {
        Value = value;
    }

    public Value3(double value)
    {
        Value = value;
    }

    public Value3(bool value)
    {
        Value = value;
    }

    Value3(UnknownVariant value)
    {
        Value = value;
    }

    public static Value3 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Value3"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Value3"
            ),
        };
    }

    public static implicit operator Value3(string value) => new(value);

    public static implicit operator Value3(double value) => new(value);

    public static implicit operator Value3(bool value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Value3");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Value3Converter : JsonConverter<Value3>
{
    public override Value3? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Value3(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new Value3(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
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
            return new Value3(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Value3 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ConjunctionConverter))]
public enum Conjunction
{
    And,
    Or,
}

sealed class ConjunctionConverter : JsonConverter<Conjunction>
{
    public override Conjunction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => Conjunction.And,
            "or" => Conjunction.Or,
            _ => (Conjunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Conjunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Conjunction.And => "and",
                Conjunction.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ConjunctionModelConverter))]
public enum ConjunctionModel
{
    And,
    Or,
}

sealed class ConjunctionModelConverter : JsonConverter<ConjunctionModel>
{
    public override ConjunctionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => ConjunctionModel.And,
            "or" => ConjunctionModel.Or,
            _ => (ConjunctionModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConjunctionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConjunctionModel.And => "and",
                ConjunctionModel.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(Conjunction1Converter))]
public enum Conjunction1
{
    And,
    Or,
}

sealed class Conjunction1Converter : JsonConverter<Conjunction1>
{
    public override Conjunction1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => Conjunction1.And,
            "or" => Conjunction1.Or,
            _ => (Conjunction1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Conjunction1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Conjunction1.And => "and",
                Conjunction1.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Logical conjunction to apply between clauses (and/or)
/// </summary>
[JsonConverter(typeof(Conjunction2Converter))]
public enum Conjunction2
{
    And,
    Or,
}

sealed class Conjunction2Converter : JsonConverter<Conjunction2>
{
    public override Conjunction2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "and" => Conjunction2.And,
            "or" => Conjunction2.Or,
            _ => (Conjunction2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Conjunction2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Conjunction2.And => "and",
                Conjunction2.Or => "or",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
