using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using CustomerRequestVariants = DodoPayments.Models.Payments.CustomerRequestVariants;

namespace DodoPayments.Models.Payments;

[JsonConverter(typeof(CustomerRequestConverter))]
public abstract record class CustomerRequest
{
    internal CustomerRequest() { }

    public static implicit operator CustomerRequest(AttachExistingCustomer value) =>
        new CustomerRequestVariants::AttachExistingCustomerVariant(value);

    public static implicit operator CustomerRequest(NewCustomer value) =>
        new CustomerRequestVariants::NewCustomerVariant(value);

    public abstract void Validate();
}

sealed class CustomerRequestConverter : JsonConverter<CustomerRequest>
{
    public override CustomerRequest? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<AttachExistingCustomer>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new CustomerRequestVariants::AttachExistingCustomerVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NewCustomer>(ref reader, options);
            if (deserialized != null)
            {
                return new CustomerRequestVariants::NewCustomerVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
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
            CustomerRequestVariants::AttachExistingCustomerVariant(var attachExistingCustomer) =>
                attachExistingCustomer,
            CustomerRequestVariants::NewCustomerVariant(var newCustomer) => newCustomer,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
