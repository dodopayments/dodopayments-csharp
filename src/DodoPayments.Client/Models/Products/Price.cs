using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products.PriceProperties;
using PriceVariants = DodoPayments.Client.Models.Products.PriceVariants;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// One-time price details.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(OneTimePrice value) =>
        new PriceVariants::OneTimePrice(value);

    public static implicit operator Price(RecurringPrice value) =>
        new PriceVariants::RecurringPrice(value);

    public static implicit operator Price(UsageBasedPrice value) =>
        new PriceVariants::UsageBasedPrice(value);

    public bool TryPickOneTime([NotNullWhen(true)] out OneTimePrice? value)
    {
        value = (this as PriceVariants::OneTimePrice)?.Value;
        return value != null;
    }

    public bool TryPickRecurring([NotNullWhen(true)] out RecurringPrice? value)
    {
        value = (this as PriceVariants::RecurringPrice)?.Value;
        return value != null;
    }

    public bool TryPickUsageBased([NotNullWhen(true)] out UsageBasedPrice? value)
    {
        value = (this as PriceVariants::UsageBasedPrice)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::OneTimePrice> oneTime,
        Action<PriceVariants::RecurringPrice> recurring,
        Action<PriceVariants::UsageBasedPrice> usageBased
    )
    {
        switch (this)
        {
            case PriceVariants::OneTimePrice inner:
                oneTime(inner);
                break;
            case PriceVariants::RecurringPrice inner:
                recurring(inner);
                break;
            case PriceVariants::UsageBasedPrice inner:
                usageBased(inner);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Price"
                );
        }
    }

    public T Match<T>(
        Func<PriceVariants::OneTimePrice, T> oneTime,
        Func<PriceVariants::RecurringPrice, T> recurring,
        Func<PriceVariants::UsageBasedPrice, T> usageBased
    )
    {
        return this switch
        {
            PriceVariants::OneTimePrice inner => oneTime(inner),
            PriceVariants::RecurringPrice inner => recurring(inner),
            PriceVariants::UsageBasedPrice inner => usageBased(inner),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Price"
            ),
        };
    }

    public abstract void Validate();
}

sealed class PriceConverter : JsonConverter<Price>
{
    public override Price? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<OneTimePrice>(ref reader, options);
            if (deserialized != null)
            {
                return new PriceVariants::OneTimePrice(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant PriceVariants::OneTimePrice",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RecurringPrice>(ref reader, options);
            if (deserialized != null)
            {
                return new PriceVariants::RecurringPrice(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant PriceVariants::RecurringPrice",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(ref reader, options);
            if (deserialized != null)
            {
                return new PriceVariants::UsageBasedPrice(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant PriceVariants::UsageBasedPrice",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Price value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PriceVariants::OneTimePrice(var oneTime) => oneTime,
            PriceVariants::RecurringPrice(var recurring) => recurring,
            PriceVariants::UsageBasedPrice(var usageBased) => usageBased,
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Price"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
