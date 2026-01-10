using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionUpdatePaymentMethodParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    public required Body Body
    {
        get { return JsonModel.GetNotNullClass<Body>(this.RawBodyData, "body"); }
        init { JsonModel.Set(this._rawBodyData, "body", value); }
    }

    public SubscriptionUpdatePaymentMethodParams() { }

    public SubscriptionUpdatePaymentMethodParams(
        SubscriptionUpdatePaymentMethodParams subscriptionUpdatePaymentMethodParams
    )
        : base(subscriptionUpdatePaymentMethodParams)
    {
        this._rawBodyData = [.. subscriptionUpdatePaymentMethodParams._rawBodyData];
    }

    public SubscriptionUpdatePaymentMethodParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatePaymentMethodParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionUpdatePaymentMethodParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update-payment-method", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(BodyConverter))]
public record class Body
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Body(New value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(Existing value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="New"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNew(out var value)) {
    ///     // `value` is of type `New`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNew([NotNullWhen(true)] out New? value)
    {
        value = this.Value as New;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Existing"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExisting(out var value)) {
    ///     // `value` is of type `Existing`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExisting([NotNullWhen(true)] out Existing? value)
    {
        value = this.Value as Existing;
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
    ///     (New value) => {...},
    ///     (Existing value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<New> new_, System::Action<Existing> existing)
    {
        switch (this.Value)
        {
            case New value:
                new_(value);
                break;
            case Existing value:
                existing(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Body"
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
    ///     (New value) => {...},
    ///     (Existing value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<New, T> new_, System::Func<Existing, T> existing)
    {
        return this.Value switch
        {
            New value => new_(value),
            Existing value => existing(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Body"
            ),
        };
    }

    public static implicit operator Body(New value) => new(value);

    public static implicit operator Body(Existing value) => new(value);

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
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch((new_) => new_.Validate(), (existing) => existing.Validate());
    }

    public virtual bool Equals(Body? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<New>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
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
            var deserialized = JsonSerializer.Deserialize<Existing>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
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

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<New, NewFromRaw>))]
public sealed record class New : JsonModel
{
    public required ApiEnum<string, global::DodoPayments.Client.Models.Subscriptions.Type> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::DodoPayments.Client.Models.Subscriptions.Type>
            >(this.RawData, "type");
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public string? ReturnUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "return_url"); }
        init { JsonModel.Set(this._rawData, "return_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ReturnUrl;
    }

    public New() { }

    public New(New new_)
        : base(new_) { }

    public New(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    New(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewFromRaw.FromRawUnchecked"/>
    public static New FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public New(ApiEnum<string, global::DodoPayments.Client.Models.Subscriptions.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class NewFromRaw : IFromRawJson<New>
{
    /// <inheritdoc/>
    public New FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        New.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    New,
}

sealed class TypeConverter : JsonConverter<global::DodoPayments.Client.Models.Subscriptions.Type>
{
    public override global::DodoPayments.Client.Models.Subscriptions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "new" => global::DodoPayments.Client.Models.Subscriptions.Type.New,
            _ => (global::DodoPayments.Client.Models.Subscriptions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Subscriptions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Subscriptions.Type.New => "new",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Existing, ExistingFromRaw>))]
public sealed record class Existing : JsonModel
{
    public required string PaymentMethodID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "payment_method_id"); }
        init { JsonModel.Set(this._rawData, "payment_method_id", value); }
    }

    public required ApiEnum<string, ExistingType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, ExistingType>>(this.RawData, "type");
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PaymentMethodID;
        this.Type.Validate();
    }

    public Existing() { }

    public Existing(Existing existing)
        : base(existing) { }

    public Existing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Existing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExistingFromRaw.FromRawUnchecked"/>
    public static Existing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExistingFromRaw : IFromRawJson<Existing>
{
    /// <inheritdoc/>
    public Existing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Existing.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExistingTypeConverter))]
public enum ExistingType
{
    Existing,
}

sealed class ExistingTypeConverter : JsonConverter<ExistingType>
{
    public override ExistingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "existing" => ExistingType.Existing,
            _ => (ExistingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExistingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExistingType.Existing => "existing",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
