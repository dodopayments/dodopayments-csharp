using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using CustomerRequestVariants = DodoPayments.Client.Models.Payments.CustomerRequestVariants;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(CustomerRequestConverter))]
public abstract record class CustomerRequest
{
    internal CustomerRequest() { }

    public static implicit operator CustomerRequest(AttachExistingCustomer value) =>
        new CustomerRequestVariants::AttachExistingCustomer(value);

    public static implicit operator CustomerRequest(NewCustomer value) =>
        new CustomerRequestVariants::NewCustomer(value);

    public bool TryPickAttachExistingCustomer([NotNullWhen(true)] out AttachExistingCustomer? value)
    {
        value = (this as CustomerRequestVariants::AttachExistingCustomer)?.Value;
        return value != null;
    }

    public bool TryPickNewCustomer([NotNullWhen(true)] out NewCustomer? value)
    {
        value = (this as CustomerRequestVariants::NewCustomer)?.Value;
        return value != null;
    }

    public void Switch(
        Action<CustomerRequestVariants::AttachExistingCustomer> attachExistingCustomer,
        Action<CustomerRequestVariants::NewCustomer> newCustomer
    )
    {
        switch (this)
        {
            case CustomerRequestVariants::AttachExistingCustomer inner:
                attachExistingCustomer(inner);
                break;
            case CustomerRequestVariants::NewCustomer inner:
                newCustomer(inner);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of CustomerRequest"
                );
        }
    }

    public T Match<T>(
        Func<CustomerRequestVariants::AttachExistingCustomer, T> attachExistingCustomer,
        Func<CustomerRequestVariants::NewCustomer, T> newCustomer
    )
    {
        return this switch
        {
            CustomerRequestVariants::AttachExistingCustomer inner => attachExistingCustomer(inner),
            CustomerRequestVariants::NewCustomer inner => newCustomer(inner),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CustomerRequest"
            ),
        };
    }

    public abstract void Validate();
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
                return new CustomerRequestVariants::AttachExistingCustomer(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant CustomerRequestVariants::AttachExistingCustomer",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NewCustomer>(ref reader, options);
            if (deserialized != null)
            {
                return new CustomerRequestVariants::NewCustomer(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant CustomerRequestVariants::NewCustomer",
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
        object variant = value switch
        {
            CustomerRequestVariants::AttachExistingCustomer(var attachExistingCustomer) =>
                attachExistingCustomer,
            CustomerRequestVariants::NewCustomer(var newCustomer) => newCustomer,
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CustomerRequest"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
