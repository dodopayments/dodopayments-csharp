using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(CustomerRequestConverter))]
public record class CustomerRequest : ModelBase
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

    public CustomerRequest(AttachExistingCustomer value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerRequest(NewCustomer value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerRequest(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AttachExistingCustomer"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAttachExistingCustomer(out var value)) {
    ///     // `value` is of type `AttachExistingCustomer`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAttachExistingCustomer([NotNullWhen(true)] out AttachExistingCustomer? value)
    {
        value = this.Value as AttachExistingCustomer;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewCustomer"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewCustomer(out var value)) {
    ///     // `value` is of type `NewCustomer`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewCustomer([NotNullWhen(true)] out NewCustomer? value)
    {
        value = this.Value as NewCustomer;
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
    ///     (AttachExistingCustomer value) => {...},
    ///     (NewCustomer value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<AttachExistingCustomer> attachExistingCustomer,
        Action<NewCustomer> newCustomer
    )
    {
        switch (this.Value)
        {
            case AttachExistingCustomer value:
                attachExistingCustomer(value);
                break;
            case NewCustomer value:
                newCustomer(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of CustomerRequest"
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
    ///     (AttachExistingCustomer value) => {...},
    ///     (NewCustomer value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<AttachExistingCustomer, T> attachExistingCustomer,
        Func<NewCustomer, T> newCustomer
    )
    {
        return this.Value switch
        {
            AttachExistingCustomer value => attachExistingCustomer(value),
            NewCustomer value => newCustomer(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CustomerRequest"
            ),
        };
    }

    public static implicit operator CustomerRequest(AttachExistingCustomer value) => new(value);

    public static implicit operator CustomerRequest(NewCustomer value) => new(value);

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
                "Data did not match any variant of CustomerRequest"
            );
        }
        this.Switch(
            (attachExistingCustomer) => attachExistingCustomer.Validate(),
            (newCustomer) => newCustomer.Validate()
        );
    }

    public virtual bool Equals(CustomerRequest? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            AttachExistingCustomer _ => 0,
            NewCustomer _ => 1,
            _ => -1,
        };
    }
}

sealed class CustomerRequestConverter : JsonConverter<CustomerRequest>
{
    public override CustomerRequest? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NewCustomer>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerRequest value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
