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
        get { return Match(subscription: (x) => x.ID, addon: (x) => x.ID, meter: (x) => x.ID); }
    }

    public ApiEnum<string, Currency> Currency
    {
        get
        {
            return Match(
                subscription: (x) => x.Currency,
                addon: (x) => x.Currency,
                meter: (x) => x.Currency
            );
        }
    }

    public double? ProrationFactor
    {
        get
        {
            return Match<double?>(
                subscription: (x) => x.ProrationFactor,
                addon: (x) => x.ProrationFactor,
                meter: (_) => null
            );
        }
    }

    public int? Quantity
    {
        get
        {
            return Match<int?>(
                subscription: (x) => x.Quantity,
                addon: (x) => x.Quantity,
                meter: (_) => null
            );
        }
    }

    public bool TaxInclusive
    {
        get
        {
            return Match(
                subscription: (x) => x.TaxInclusive,
                addon: (x) => x.TaxInclusive,
                meter: (x) => x.TaxInclusive
            );
        }
    }

    public int? UnitPrice
    {
        get
        {
            return Match<int?>(
                subscription: (x) => x.UnitPrice,
                addon: (x) => x.UnitPrice,
                meter: (_) => null
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                subscription: (x) => x.Description,
                addon: (x) => x.Description,
                meter: (x) => x.Description
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                subscription: (x) => x.Name,
                addon: (x) => x.Name,
                meter: (x) => x.Name
            );
        }
    }

    public int? Tax
    {
        get
        {
            return Match<int?>(
                subscription: (x) => x.Tax,
                addon: (x) => x.Tax,
                meter: (x) => x.Tax
            );
        }
    }

    public float? TaxRate
    {
        get
        {
            return Match<float?>(
                subscription: (x) => x.TaxRate,
                addon: (x) => x.TaxRate,
                meter: (x) => x.TaxRate
            );
        }
    }

    public LineItem(LineItemSubscription value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public LineItem(Addon value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public LineItem(LineItemMeter value, JsonElement? json = null)
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
    /// type <see cref="LineItemSubscription"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubscription(out var value)) {
    ///     // `value` is of type `LineItemSubscription`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubscription([NotNullWhen(true)] out LineItemSubscription? value)
    {
        value = this.Value as LineItemSubscription;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Addon"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAddon(out var value)) {
    ///     // `value` is of type `Addon`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAddon([NotNullWhen(true)] out Addon? value)
    {
        value = this.Value as Addon;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LineItemMeter"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMeter(out var value)) {
    ///     // `value` is of type `LineItemMeter`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMeter([NotNullWhen(true)] out LineItemMeter? value)
    {
        value = this.Value as LineItemMeter;
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
    ///     (LineItemSubscription value) => {...},
    ///     (Addon value) => {...},
    ///     (LineItemMeter value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<LineItemSubscription> subscription,
        System::Action<Addon> addon,
        System::Action<LineItemMeter> meter
    )
    {
        switch (this.Value)
        {
            case LineItemSubscription value:
                subscription(value);
                break;
            case Addon value:
                addon(value);
                break;
            case LineItemMeter value:
                meter(value);
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
    ///     (LineItemSubscription value) => {...},
    ///     (Addon value) => {...},
    ///     (LineItemMeter value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<LineItemSubscription, T> subscription,
        System::Func<Addon, T> addon,
        System::Func<LineItemMeter, T> meter
    )
    {
        return this.Value switch
        {
            LineItemSubscription value => subscription(value),
            Addon value => addon(value),
            LineItemMeter value => meter(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of LineItem"
            ),
        };
    }

    public static implicit operator LineItem(LineItemSubscription value) => new(value);

    public static implicit operator LineItem(Addon value) => new(value);

    public static implicit operator LineItem(LineItemMeter value) => new(value);

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
        this.Switch(
            (subscription) => subscription.Validate(),
            (addon) => addon.Validate(),
            (meter) => meter.Validate()
        );
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
            var deserialized = JsonSerializer.Deserialize<LineItemSubscription>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<Addon>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<LineItemMeter>(json, options);
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

[JsonConverter(typeof(ModelConverter<LineItemSubscription, LineItemSubscriptionFromRaw>))]
public sealed record class LineItemSubscription : ModelBase
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

    public required ApiEnum<string, LineItemSubscriptionType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, LineItemSubscriptionType>>(
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

    public LineItemSubscription() { }

    public LineItemSubscription(LineItemSubscription lineItemSubscription)
        : base(lineItemSubscription) { }

    public LineItemSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItemSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineItemSubscriptionFromRaw.FromRawUnchecked"/>
    public static LineItemSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemSubscriptionFromRaw : IFromRaw<LineItemSubscription>
{
    /// <inheritdoc/>
    public LineItemSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LineItemSubscription.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LineItemSubscriptionTypeConverter))]
public enum LineItemSubscriptionType
{
    Subscription,
}

sealed class LineItemSubscriptionTypeConverter : JsonConverter<LineItemSubscriptionType>
{
    public override LineItemSubscriptionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => LineItemSubscriptionType.Subscription,
            _ => (LineItemSubscriptionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LineItemSubscriptionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LineItemSubscriptionType.Subscription => "subscription",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Addon, AddonFromRaw>))]
public sealed record class Addon : ModelBase
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

    public required ApiEnum<string, AddonType> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, AddonType>>(this.RawData, "type"); }
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

    public Addon() { }

    public Addon(Addon addon)
        : base(addon) { }

    public Addon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Addon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonFromRaw.FromRawUnchecked"/>
    public static Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonFromRaw : IFromRaw<Addon>
{
    /// <inheritdoc/>
    public Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addon.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddonTypeConverter))]
public enum AddonType
{
    Addon,
}

sealed class AddonTypeConverter : JsonConverter<AddonType>
{
    public override AddonType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "addon" => AddonType.Addon,
            _ => (AddonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonType.Addon => "addon",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<LineItemMeter, LineItemMeterFromRaw>))]
public sealed record class LineItemMeter : ModelBase
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

    public required ApiEnum<string, LineItemMeterType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, LineItemMeterType>>(
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

    public LineItemMeter() { }

    public LineItemMeter(LineItemMeter lineItemMeter)
        : base(lineItemMeter) { }

    public LineItemMeter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItemMeter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineItemMeterFromRaw.FromRawUnchecked"/>
    public static LineItemMeter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemMeterFromRaw : IFromRaw<LineItemMeter>
{
    /// <inheritdoc/>
    public LineItemMeter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LineItemMeter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LineItemMeterTypeConverter))]
public enum LineItemMeterType
{
    Meter,
}

sealed class LineItemMeterTypeConverter : JsonConverter<LineItemMeterType>
{
    public override LineItemMeterType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "meter" => LineItemMeterType.Meter,
            _ => (LineItemMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LineItemMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LineItemMeterType.Meter => "meter",
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
