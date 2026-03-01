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
[JsonConverter(typeof(JsonModelConverter<MeterFilter, MeterFilterFromRaw>))]
public sealed record class MeterFilter : JsonModel
{
    /// <summary>
    /// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
    /// </summary>
    public required Clauses Clauses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Clauses>("clauses");
        }
        init { this._rawData.Set("clauses", value); }
    }

    /// <summary>
    /// Logical conjunction to apply between clauses (and/or)
    /// </summary>
    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Conjunction>>("conjunction");
        }
        init { this._rawData.Set("conjunction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public MeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterFilter(MeterFilter meterFilter)
        : base(meterFilter) { }
#pragma warning restore CS8618

    public MeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFilterFromRaw.FromRawUnchecked"/>
    public static MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFilterFromRaw : IFromRawJson<MeterFilter>
{
    /// <inheritdoc/>
    public MeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter clauses - can be direct conditions or nested filters (up to 3 levels deep)
/// </summary>
[JsonConverter(typeof(ClausesConverter))]
public record class Clauses : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Clauses(IReadOnlyList<MeterFilterCondition> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Clauses(IReadOnlyList<ClausesMeterFilter> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Clauses(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<MeterFilterCondition>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDirectFilterConditions(out var value)) {
    ///     // `value` is of type `IReadOnlyList<MeterFilterCondition>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDirectFilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<MeterFilterCondition>? value
    )
    {
        value = this.Value as IReadOnlyList<MeterFilterCondition>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<ClausesMeterFilter>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNestedMeterFilters(out var value)) {
    ///     // `value` is of type `IReadOnlyList<ClausesMeterFilter>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNestedMeterFilters(
        [NotNullWhen(true)] out IReadOnlyList<ClausesMeterFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilter>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList<MeterFilterCondition> value) => {...},
    ///     (IReadOnlyList<ClausesMeterFilter> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyList<MeterFilterCondition>> directFilterConditions,
        System::Action<IReadOnlyList<ClausesMeterFilter>> nestedMeterFilters
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<MeterFilterCondition> value:
                directFilterConditions(value);
                break;
            case IReadOnlyList<ClausesMeterFilter> value:
                nestedMeterFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Clauses"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList<MeterFilterCondition> value) => {...},
    ///     (IReadOnlyList<ClausesMeterFilter> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyList<MeterFilterCondition>, T> directFilterConditions,
        System::Func<IReadOnlyList<ClausesMeterFilter>, T> nestedMeterFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition> value => directFilterConditions(value),
            IReadOnlyList<ClausesMeterFilter> value => nestedMeterFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Clauses"
            ),
        };
    }

    public static implicit operator Clauses(List<MeterFilterCondition> value) =>
        new((IReadOnlyList<MeterFilterCondition>)value);

    public static implicit operator Clauses(List<ClausesMeterFilter> value) =>
        new((IReadOnlyList<ClausesMeterFilter>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Clauses");
        }
        this.Switch(
            (directFilterConditions) =>
            {
                foreach (var item in directFilterConditions)
                {
                    item.Validate();
                }
            },
            (nestedMeterFilters) =>
            {
                foreach (var item in nestedMeterFilters)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(Clauses? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            IReadOnlyList<MeterFilterCondition> _ => 0,
            IReadOnlyList<ClausesMeterFilter> _ => 1,
            _ => -1,
        };
    }
}

sealed class ClausesConverter : JsonConverter<Clauses>
{
    public override Clauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MeterFilterCondition>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ClausesMeterFilter>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Clauses value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeterFilterCondition, MeterFilterConditionFromRaw>))]
public sealed record class MeterFilterCondition : JsonModel
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required ApiEnum<string, FilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FilterOperator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required MeterFilterConditionValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MeterFilterConditionValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public MeterFilterCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterFilterCondition(MeterFilterCondition meterFilterCondition)
        : base(meterFilterCondition) { }
#pragma warning restore CS8618

    public MeterFilterCondition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterFilterCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFilterConditionFromRaw.FromRawUnchecked"/>
    public static MeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFilterConditionFromRaw : IFromRawJson<MeterFilterCondition>
{
    /// <inheritdoc/>
    public MeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeterFilterCondition.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(MeterFilterConditionValueConverter))]
public record class MeterFilterConditionValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MeterFilterConditionValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MeterFilterConditionValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MeterFilterConditionValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MeterFilterConditionValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of MeterFilterConditionValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of MeterFilterConditionValue"
            ),
        };
    }

    public static implicit operator MeterFilterConditionValue(string value) => new(value);

    public static implicit operator MeterFilterConditionValue(double value) => new(value);

    public static implicit operator MeterFilterConditionValue(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of MeterFilterConditionValue"
            );
        }
    }

    public virtual bool Equals(MeterFilterConditionValue? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class MeterFilterConditionValueConverter : JsonConverter<MeterFilterConditionValue>
{
    public override MeterFilterConditionValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterFilterConditionValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 1 nested filter - can contain Level 2 filters
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClausesMeterFilter, ClausesMeterFilterFromRaw>))]
public sealed record class ClausesMeterFilter : JsonModel
{
    /// <summary>
    /// Level 1: Can be conditions or nested filters (2 more levels allowed)
    /// </summary>
    public required ClausesMeterFilterClauses Clauses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClausesMeterFilterClauses>("clauses");
        }
        init { this._rawData.Set("clauses", value); }
    }

    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Conjunction>>("conjunction");
        }
        init { this._rawData.Set("conjunction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public ClausesMeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClausesMeterFilter(ClausesMeterFilter clausesMeterFilter)
        : base(clausesMeterFilter) { }
#pragma warning restore CS8618

    public ClausesMeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClausesMeterFilterFromRaw.FromRawUnchecked"/>
    public static ClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterFromRaw : IFromRawJson<ClausesMeterFilter>
{
    /// <inheritdoc/>
    public ClausesMeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClausesMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Level 1: Can be conditions or nested filters (2 more levels allowed)
/// </summary>
[JsonConverter(typeof(ClausesMeterFilterClausesConverter))]
public record class ClausesMeterFilterClauses : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ClausesMeterFilterClauses(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLevel1FilterConditions(out var value)) {
    ///     // `value` is of type `IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLevel1FilterConditions(
        [NotNullWhen(true)] out IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<ClausesMeterFilterClausesMeterFilter>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLevel1NestedFilters(out var value)) {
    ///     // `value` is of type `IReadOnlyList<ClausesMeterFilterClausesMeterFilter>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLevel1NestedFilters(
        [NotNullWhen(true)] out IReadOnlyList<ClausesMeterFilterClausesMeterFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilterClausesMeterFilter>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value) => {...},
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>
        > level1FilterConditions,
        System::Action<IReadOnlyList<ClausesMeterFilterClausesMeterFilter>> level1NestedFilters
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value:
                level1FilterConditions(value);
                break;
            case IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value:
                level1NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ClausesMeterFilterClauses"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value) => {...},
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>,
            T
        > level1FilterConditions,
        System::Func<IReadOnlyList<ClausesMeterFilterClausesMeterFilter>, T> level1NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> value =>
                level1FilterConditions(value),
            IReadOnlyList<ClausesMeterFilterClausesMeterFilter> value => level1NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClauses"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilterCondition> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition>)value);

    public static implicit operator ClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilter> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilter>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClauses"
            );
        }
        this.Switch(
            (level1FilterConditions) =>
            {
                foreach (var item in level1FilterConditions)
                {
                    item.Validate();
                }
            },
            (level1NestedFilters) =>
            {
                foreach (var item in level1NestedFilters)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ClausesMeterFilterClauses? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterCondition> _ => 0,
            IReadOnlyList<ClausesMeterFilterClausesMeterFilter> _ => 1,
            _ => -1,
        };
    }
}

sealed class ClausesMeterFilterClausesConverter : JsonConverter<ClausesMeterFilterClauses>
{
    public override ClausesMeterFilterClauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilterCondition>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilter>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClauses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClausesMeterFilterClausesMeterFilterCondition,
        ClausesMeterFilterClausesMeterFilterConditionFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilterCondition : JsonModel
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required ApiEnum<string, FilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FilterOperator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClausesMeterFilterClausesMeterFilterConditionValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClausesMeterFilterClausesMeterFilterConditionValue>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public ClausesMeterFilterClausesMeterFilterCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClausesMeterFilterClausesMeterFilterCondition(
        ClausesMeterFilterClausesMeterFilterCondition clausesMeterFilterClausesMeterFilterCondition
    )
        : base(clausesMeterFilterClausesMeterFilterCondition) { }
#pragma warning restore CS8618

    public ClausesMeterFilterClausesMeterFilterCondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilterCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClausesMeterFilterClausesMeterFilterConditionFromRaw.FromRawUnchecked"/>
    public static ClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterConditionFromRaw
    : IFromRawJson<ClausesMeterFilterClausesMeterFilterCondition>
{
    /// <inheritdoc/>
    public ClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilterCondition.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(ClausesMeterFilterClausesMeterFilterConditionValueConverter))]
public record class ClausesMeterFilterClausesMeterFilterConditionValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterConditionValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of ClausesMeterFilterClausesMeterFilterConditionValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterConditionValue"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClausesMeterFilterConditionValue(
        string value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterConditionValue(
        double value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterConditionValue(
        bool value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterConditionValue"
            );
        }
    }

    public virtual bool Equals(ClausesMeterFilterClausesMeterFilterConditionValue? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class ClausesMeterFilterClausesMeterFilterConditionValueConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterConditionValue>
{
    public override ClausesMeterFilterClausesMeterFilterConditionValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClausesMeterFilterConditionValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 2 nested filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClausesMeterFilterClausesMeterFilter,
        ClausesMeterFilterClausesMeterFilterFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilter : JsonModel
{
    /// <summary>
    /// Level 2: Can be conditions or nested filters (1 more level allowed)
    /// </summary>
    public required ClausesMeterFilterClausesMeterFilterClauses Clauses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClausesMeterFilterClausesMeterFilterClauses>(
                "clauses"
            );
        }
        init { this._rawData.Set("clauses", value); }
    }

    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Conjunction>>("conjunction");
        }
        init { this._rawData.Set("conjunction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Clauses.Validate();
        this.Conjunction.Validate();
    }

    public ClausesMeterFilterClausesMeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClausesMeterFilterClausesMeterFilter(
        ClausesMeterFilterClausesMeterFilter clausesMeterFilterClausesMeterFilter
    )
        : base(clausesMeterFilterClausesMeterFilter) { }
#pragma warning restore CS8618

    public ClausesMeterFilterClausesMeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClausesMeterFilterClausesMeterFilterFromRaw.FromRawUnchecked"/>
    public static ClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterFromRaw
    : IFromRawJson<ClausesMeterFilterClausesMeterFilter>
{
    /// <inheritdoc/>
    public ClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Level 2: Can be conditions or nested filters (1 more level allowed)
/// </summary>
[JsonConverter(typeof(ClausesMeterFilterClausesMeterFilterClausesConverter))]
public record class ClausesMeterFilterClausesMeterFilterClauses : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ClausesMeterFilterClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterClauses(
        IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterClauses(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLevel2FilterConditions(out var value)) {
    ///     // `value` is of type `IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLevel2FilterConditions(
        [NotNullWhen(true)]
            out IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>? value
    )
    {
        value =
            this.Value
            as IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLevel2NestedFilters(out var value)) {
    ///     // `value` is of type `IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLevel2NestedFilters(
        [NotNullWhen(true)]
            out IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>? value
    )
    {
        value = this.Value as IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value) => {...},
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>
        > level2FilterConditions,
        System::Action<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>
        > level2NestedFilters
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value:
                level2FilterConditions(value);
                break;
            case IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value:
                level2NestedFilters(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClauses"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value) => {...},
    ///     (IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>,
            T
        > level2FilterConditions,
        System::Func<
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>,
            T
        > level2NestedFilters
    )
    {
        return this.Value switch
        {
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value =>
                level2FilterConditions(value),
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value =>
                level2NestedFilters(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClauses"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>)value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterClauses(
        List<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> value
    ) => new((IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClauses"
            );
        }
        this.Switch(
            (level2FilterConditions) =>
            {
                foreach (var item in level2FilterConditions)
                {
                    item.Validate();
                }
            },
            (level2NestedFilters) =>
            {
                foreach (var item in level2NestedFilters)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ClausesMeterFilterClausesMeterFilterClauses? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition> _ => 0,
            IReadOnlyList<ClausesMeterFilterClausesMeterFilterClausesMeterFilter> _ => 1,
            _ => -1,
        };
    }
}

sealed class ClausesMeterFilterClausesMeterFilterClausesConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterClauses>
{
    public override ClausesMeterFilterClausesMeterFilterClauses? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClausesMeterFilterClauses value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
    : JsonModel
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required ApiEnum<string, FilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FilterOperator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition clausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
    )
        : base(clausesMeterFilterClausesMeterFilterClausesMeterFilterCondition) { }
#pragma warning restore CS8618

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionFromRaw.FromRawUnchecked"/>
    public static ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionFromRaw
    : IFromRawJson<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>
{
    /// <inheritdoc/>
    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(
    typeof(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValueConverter)
)]
public record class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue"
            ),
        };
    }

    public static implicit operator ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        string value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        double value
    ) => new(value);

    public static implicit operator ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue(
        bool value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue"
            );
        }
    }

    public virtual bool Equals(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValueConverter
    : JsonConverter<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>
{
    public override ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Level 3 nested filter (final nesting level)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClausesMeterFilterClausesMeterFilterClausesMeterFilter,
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterFromRaw
    >)
)]
public sealed record class ClausesMeterFilterClausesMeterFilterClausesMeterFilter : JsonModel
{
    /// <summary>
    /// Level 3: Filter conditions only (max depth reached)
    /// </summary>
    public required IReadOnlyList<Clause> Clauses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Clause>>("clauses");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Clause>>(
                "clauses",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, Conjunction> Conjunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Conjunction>>("conjunction");
        }
        init { this._rawData.Set("conjunction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Clauses)
        {
            item.Validate();
        }
        this.Conjunction.Validate();
    }

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilter clausesMeterFilterClausesMeterFilterClausesMeterFilter
    )
        : base(clausesMeterFilterClausesMeterFilterClausesMeterFilter) { }
#pragma warning restore CS8618

    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClausesMeterFilterClausesMeterFilterClausesMeterFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClausesMeterFilterClausesMeterFilterClausesMeterFilterFromRaw.FromRawUnchecked"/>
    public static ClausesMeterFilterClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClausesMeterFilterClausesMeterFilterClausesMeterFilterFromRaw
    : IFromRawJson<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>
{
    /// <inheritdoc/>
    public ClausesMeterFilterClausesMeterFilterClausesMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClausesMeterFilterClausesMeterFilterClausesMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter condition with key, operator, and value
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Clause, ClauseFromRaw>))]
public sealed record class Clause : JsonModel
{
    /// <summary>
    /// Filter key to apply
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required ApiEnum<string, FilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FilterOperator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// Filter value - can be string, number, or boolean
    /// </summary>
    public required ClauseValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClauseValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        this.Operator.Validate();
        this.Value.Validate();
    }

    public Clause() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Clause(Clause clause)
        : base(clause) { }
#pragma warning restore CS8618

    public Clause(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Clause(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClauseFromRaw.FromRawUnchecked"/>
    public static Clause FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClauseFromRaw : IFromRawJson<Clause>
{
    /// <inheritdoc/>
    public Clause FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Clause.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter value - can be string, number, or boolean
/// </summary>
[JsonConverter(typeof(ClauseValueConverter))]
public record class ClauseValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ClauseValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClauseValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClauseValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClauseValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of ClauseValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of ClauseValue"
            ),
        };
    }

    public static implicit operator ClauseValue(string value) => new(value);

    public static implicit operator ClauseValue(double value) => new(value);

    public static implicit operator ClauseValue(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ClauseValue"
            );
        }
    }

    public virtual bool Equals(ClauseValue? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class ClauseValueConverter : JsonConverter<ClauseValue>
{
    public override ClauseValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClauseValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
