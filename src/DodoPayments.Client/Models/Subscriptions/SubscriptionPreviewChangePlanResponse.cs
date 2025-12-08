using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<
        SubscriptionPreviewChangePlanResponse,
        SubscriptionPreviewChangePlanResponseFromRaw
    >)
)]
public sealed record class SubscriptionPreviewChangePlanResponse : ModelBase
{
    public required ImmediateCharge ImmediateCharge
    {
        get { return ModelBase.GetNotNullClass<ImmediateCharge>(this.RawData, "immediate_charge"); }
        init { ModelBase.Set(this._rawData, "immediate_charge", value); }
    }

    /// <summary>
    /// Response struct representing subscription details
    /// </summary>
    public required Subscription NewPlan
    {
        get { return ModelBase.GetNotNullClass<Subscription>(this.RawData, "new_plan"); }
        init { ModelBase.Set(this._rawData, "new_plan", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ImmediateCharge.Validate();
        this.NewPlan.Validate();
    }

    public SubscriptionPreviewChangePlanResponse() { }

    public SubscriptionPreviewChangePlanResponse(
        SubscriptionPreviewChangePlanResponse subscriptionPreviewChangePlanResponse
    )
        : base(subscriptionPreviewChangePlanResponse) { }

    public SubscriptionPreviewChangePlanResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewChangePlanResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewChangePlanResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewChangePlanResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewChangePlanResponseFromRaw : IFromRaw<SubscriptionPreviewChangePlanResponse>
{
    /// <inheritdoc/>
    public SubscriptionPreviewChangePlanResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewChangePlanResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ImmediateCharge, ImmediateChargeFromRaw>))]
public sealed record class ImmediateCharge : ModelBase
{
    public required IReadOnlyList<LineItem> LineItems
    {
        get { return ModelBase.GetNotNullClass<List<LineItem>>(this.RawData, "line_items"); }
        init { ModelBase.Set(this._rawData, "line_items", value); }
    }

    public required Summary Summary
    {
        get { return ModelBase.GetNotNullClass<Summary>(this.RawData, "summary"); }
        init { ModelBase.Set(this._rawData, "summary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.LineItems)
        {
            item.Validate();
        }
        this.Summary.Validate();
    }

    public ImmediateCharge() { }

    public ImmediateCharge(ImmediateCharge immediateCharge)
        : base(immediateCharge) { }

    public ImmediateCharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImmediateCharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImmediateChargeFromRaw.FromRawUnchecked"/>
    public static ImmediateCharge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImmediateChargeFromRaw : IFromRaw<ImmediateCharge>
{
    /// <inheritdoc/>
    public ImmediateCharge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImmediateCharge.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LineItemConverter))]
public record class LineItem
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string ID
    {
        get
        {
            return Match(
                unionMember0: (x) => x.ID,
                unionMember1: (x) => x.ID,
                unionMember2: (x) => x.ID
            );
        }
    }

    public ApiEnum<string, Currency> Currency
    {
        get
        {
            return Match(
                unionMember0: (x) => x.Currency,
                unionMember1: (x) => x.Currency,
                unionMember2: (x) => x.Currency
            );
        }
    }

    public double? ProrationFactor
    {
        get
        {
            return Match<double?>(
                unionMember0: (x) => x.ProrationFactor,
                unionMember1: (x) => x.ProrationFactor,
                unionMember2: (_) => null
            );
        }
    }

    public int? Quantity
    {
        get
        {
            return Match<int?>(
                unionMember0: (x) => x.Quantity,
                unionMember1: (x) => x.Quantity,
                unionMember2: (_) => null
            );
        }
    }

    public bool TaxInclusive
    {
        get
        {
            return Match(
                unionMember0: (x) => x.TaxInclusive,
                unionMember1: (x) => x.TaxInclusive,
                unionMember2: (x) => x.TaxInclusive
            );
        }
    }

    public int? UnitPrice
    {
        get
        {
            return Match<int?>(
                unionMember0: (x) => x.UnitPrice,
                unionMember1: (x) => x.UnitPrice,
                unionMember2: (_) => null
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.Description,
                unionMember1: (x) => x.Description,
                unionMember2: (x) => x.Description
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.Name,
                unionMember1: (x) => x.Name,
                unionMember2: (x) => x.Name
            );
        }
    }

    public int? Tax
    {
        get
        {
            return Match<int?>(
                unionMember0: (x) => x.Tax,
                unionMember1: (x) => x.Tax,
                unionMember2: (x) => x.Tax
            );
        }
    }

    public float? TaxRate
    {
        get
        {
            return Match<float?>(
                unionMember0: (x) => x.TaxRate,
                unionMember1: (x) => x.TaxRate,
                unionMember2: (x) => x.TaxRate
            );
        }
    }

    public LineItem(UnionMember0 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public LineItem(UnionMember1 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public LineItem(UnionMember2 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public LineItem(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember0(out var value)) {
    ///     // `value` is of type `UnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember2"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember2(out var value)) {
    ///     // `value` is of type `UnionMember2`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = this.Value as UnionMember2;
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
    ///     (UnionMember0 value) => {...},
    ///     (UnionMember1 value) => {...},
    ///     (UnionMember2 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UnionMember0> unionMember0,
        System::Action<UnionMember1> unionMember1,
        System::Action<UnionMember2> unionMember2
    )
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                unionMember0(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            case UnionMember2 value:
                unionMember2(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of LineItem"
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
    ///     (UnionMember0 value) => {...},
    ///     (UnionMember1 value) => {...},
    ///     (UnionMember2 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UnionMember0, T> unionMember0,
        System::Func<UnionMember1, T> unionMember1,
        System::Func<UnionMember2, T> unionMember2
    )
    {
        return this.Value switch
        {
            UnionMember0 value => unionMember0(value),
            UnionMember1 value => unionMember1(value),
            UnionMember2 value => unionMember2(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of LineItem"
            ),
        };
    }

    public static implicit operator LineItem(UnionMember0 value) => new(value);

    public static implicit operator LineItem(UnionMember1 value) => new(value);

    public static implicit operator LineItem(UnionMember2 value) => new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of LineItem"
            );
        }
    }

    public virtual bool Equals(LineItem? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class LineItemConverter : JsonConverter<LineItem>
{
    public override LineItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, LineItem value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<UnionMember0, UnionMember0FromRaw>))]
public sealed record class UnionMember0 : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { ModelBase.Set(this._rawData, "product_id", value); }
    }

    public required double ProrationFactor
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "proration_factor"); }
        init { ModelBase.Set(this._rawData, "proration_factor", value); }
    }

    public required int Quantity
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public required bool TaxInclusive
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_inclusive"); }
        init { ModelBase.Set(this._rawData, "tax_inclusive", value); }
    }

    public required ApiEnum<string, UnionMember0Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, UnionMember0Type>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required int UnitPrice
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "unit_price"); }
        init { ModelBase.Set(this._rawData, "unit_price", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public int? Tax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "tax"); }
        init { ModelBase.Set(this._rawData, "tax", value); }
    }

    public float? TaxRate
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "tax_rate"); }
        init { ModelBase.Set(this._rawData, "tax_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Currency.Validate();
        _ = this.ProductID;
        _ = this.ProrationFactor;
        _ = this.Quantity;
        _ = this.TaxInclusive;
        this.Type.Validate();
        _ = this.UnitPrice;
        _ = this.Description;
        _ = this.Name;
        _ = this.Tax;
        _ = this.TaxRate;
    }

    public UnionMember0() { }

    public UnionMember0(UnionMember0 unionMember0)
        : base(unionMember0) { }

    public UnionMember0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember0FromRaw.FromRawUnchecked"/>
    public static UnionMember0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember0FromRaw : IFromRaw<UnionMember0>
{
    /// <inheritdoc/>
    public UnionMember0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember0.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember0TypeConverter))]
public enum UnionMember0Type
{
    Subscription,
}

sealed class UnionMember0TypeConverter : JsonConverter<UnionMember0Type>
{
    public override UnionMember0Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => UnionMember0Type.Subscription,
            _ => (UnionMember0Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember0Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember0Type.Subscription => "subscription",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required double ProrationFactor
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "proration_factor"); }
        init { ModelBase.Set(this._rawData, "proration_factor", value); }
    }

    public required int Quantity
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// Represents the different categories of taxation applicable to various products
    /// and services.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TaxCategory>>(
                this.RawData,
                "tax_category"
            );
        }
        init { ModelBase.Set(this._rawData, "tax_category", value); }
    }

    public required bool TaxInclusive
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_inclusive"); }
        init { ModelBase.Set(this._rawData, "tax_inclusive", value); }
    }

    public required float TaxRate
    {
        get { return ModelBase.GetNotNullStruct<float>(this.RawData, "tax_rate"); }
        init { ModelBase.Set(this._rawData, "tax_rate", value); }
    }

    public required ApiEnum<string, UnionMember1Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, UnionMember1Type>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required int UnitPrice
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "unit_price"); }
        init { ModelBase.Set(this._rawData, "unit_price", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public int? Tax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "tax"); }
        init { ModelBase.Set(this._rawData, "tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Currency.Validate();
        _ = this.Name;
        _ = this.ProrationFactor;
        _ = this.Quantity;
        this.TaxCategory.Validate();
        _ = this.TaxInclusive;
        _ = this.TaxRate;
        this.Type.Validate();
        _ = this.UnitPrice;
        _ = this.Description;
        _ = this.Tax;
    }

    public UnionMember1() { }

    public UnionMember1(UnionMember1 unionMember1)
        : base(unionMember1) { }

    public UnionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember1FromRaw : IFromRaw<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember1TypeConverter))]
public enum UnionMember1Type
{
    Addon,
}

sealed class UnionMember1TypeConverter : JsonConverter<UnionMember1Type>
{
    public override UnionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "addon" => UnionMember1Type.Addon,
            _ => (UnionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember1Type.Addon => "addon",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<UnionMember2, UnionMember2FromRaw>))]
public sealed record class UnionMember2 : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string ChargeableUnits
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "chargeable_units"); }
        init { ModelBase.Set(this._rawData, "chargeable_units", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required long FreeThreshold
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "free_threshold"); }
        init { ModelBase.Set(this._rawData, "free_threshold", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required string PricePerUnit
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_per_unit"); }
        init { ModelBase.Set(this._rawData, "price_per_unit", value); }
    }

    public required int Subtotal
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "subtotal"); }
        init { ModelBase.Set(this._rawData, "subtotal", value); }
    }

    public required bool TaxInclusive
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_inclusive"); }
        init { ModelBase.Set(this._rawData, "tax_inclusive", value); }
    }

    public required float TaxRate
    {
        get { return ModelBase.GetNotNullStruct<float>(this.RawData, "tax_rate"); }
        init { ModelBase.Set(this._rawData, "tax_rate", value); }
    }

    public required ApiEnum<string, UnionMember2Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, UnionMember2Type>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required string UnitsConsumed
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "units_consumed"); }
        init { ModelBase.Set(this._rawData, "units_consumed", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public int? Tax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "tax"); }
        init { ModelBase.Set(this._rawData, "tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChargeableUnits;
        this.Currency.Validate();
        _ = this.FreeThreshold;
        _ = this.Name;
        _ = this.PricePerUnit;
        _ = this.Subtotal;
        _ = this.TaxInclusive;
        _ = this.TaxRate;
        this.Type.Validate();
        _ = this.UnitsConsumed;
        _ = this.Description;
        _ = this.Tax;
    }

    public UnionMember2() { }

    public UnionMember2(UnionMember2 unionMember2)
        : base(unionMember2) { }

    public UnionMember2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember2FromRaw.FromRawUnchecked"/>
    public static UnionMember2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember2FromRaw : IFromRaw<UnionMember2>
{
    /// <inheritdoc/>
    public UnionMember2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember2.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember2TypeConverter))]
public enum UnionMember2Type
{
    Meter,
}

sealed class UnionMember2TypeConverter : JsonConverter<UnionMember2Type>
{
    public override UnionMember2Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "meter" => UnionMember2Type.Meter,
            _ => (UnionMember2Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember2Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember2Type.Meter => "meter",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : ModelBase
{
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required long CustomerCredits
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "customer_credits"); }
        init { ModelBase.Set(this._rawData, "customer_credits", value); }
    }

    public required int SettlementAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "settlement_amount"); }
        init { ModelBase.Set(this._rawData, "settlement_amount", value); }
    }

    public required ApiEnum<string, Currency> SettlementCurrency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(
                this.RawData,
                "settlement_currency"
            );
        }
        init { ModelBase.Set(this._rawData, "settlement_currency", value); }
    }

    public required int TotalAmount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "total_amount"); }
        init { ModelBase.Set(this._rawData, "total_amount", value); }
    }

    public int? SettlementTax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "settlement_tax"); }
        init { ModelBase.Set(this._rawData, "settlement_tax", value); }
    }

    public int? Tax
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "tax"); }
        init { ModelBase.Set(this._rawData, "tax", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.CustomerCredits;
        _ = this.SettlementAmount;
        this.SettlementCurrency.Validate();
        _ = this.TotalAmount;
        _ = this.SettlementTax;
        _ = this.Tax;
    }

    public Summary() { }

    public Summary(Summary summary)
        : base(summary) { }

    public Summary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryFromRaw : IFromRaw<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Summary.FromRawUnchecked(rawData);
}
