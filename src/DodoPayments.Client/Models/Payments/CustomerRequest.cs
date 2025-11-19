using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(CustomerRequestConverter))]
public record class CustomerRequest
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public CustomerRequest(AttachExistingCustomer value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CustomerRequest(NewCustomer value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CustomerRequest(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickAttachExistingCustomer([NotNullWhen(true)] out AttachExistingCustomer? value)
    {
        value = this.Value as AttachExistingCustomer;
        return value != null;
    }

    public bool TryPickNewCustomer([NotNullWhen(true)] out NewCustomer? value)
    {
        value = this.Value as NewCustomer;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CustomerRequest"
            );
        }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NewCustomer>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(json);
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
