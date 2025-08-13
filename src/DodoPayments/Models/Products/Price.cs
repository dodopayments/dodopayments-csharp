using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PriceProperties = DodoPayments.Models.Products.PriceProperties;
using PriceVariants = DodoPayments.Models.Products.PriceVariants;
using System = System;

namespace DodoPayments.Models.Products;

/// <summary>
/// One-time price details.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(PriceProperties::OneTimePrice value) =>
        new PriceVariants::OneTimePrice(value);

    public static implicit operator Price(PriceProperties::RecurringPrice value) =>
        new PriceVariants::RecurringPrice(value);

    public abstract void Validate();
}

sealed class PriceConverter : JsonConverter<Price>
{
    public override Price? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<PriceProperties::OneTimePrice>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new PriceVariants::OneTimePrice(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PriceProperties::RecurringPrice>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new PriceVariants::RecurringPrice(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Price value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PriceVariants::OneTimePrice(var oneTimePrice) => oneTimePrice,
            PriceVariants::RecurringPrice(var recurringPrice) => recurringPrice,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
