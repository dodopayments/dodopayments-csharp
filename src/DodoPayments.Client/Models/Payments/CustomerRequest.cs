using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(CustomerRequestConverter))]
public record class CustomerRequest
{
    public object Value { get; private init; }

    public CustomerRequest(AttachExistingCustomer value)
    {
        Value = value;
    }

    public CustomerRequest(NewCustomer value)
    {
        Value = value;
    }

    CustomerRequest(UnknownVariant value)
    {
        Value = value;
    }

    public static CustomerRequest CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CustomerRequest"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class CustomerRequestConverter : JsonConverter<CustomerRequest>
{
    public override CustomerRequest? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new CustomerRequest(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'AttachExistingCustomer'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NewCustomer>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new CustomerRequest(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'NewCustomer'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerRequest value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
