using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products.PriceProperties;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// One-time price details.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public record class Price
{
    public object Value { get; private init; }

    public ApiEnum<string, Currency> Currency
    {
        get
        {
            return Match(
                oneTime: (x) => x.Currency,
                recurring: (x) => x.Currency,
                usageBased: (x) => x.Currency
            );
        }
    }

    public long Discount
    {
        get
        {
            return Match(
                oneTime: (x) => x.Discount,
                recurring: (x) => x.Discount,
                usageBased: (x) => x.Discount
            );
        }
    }

    public int? Price1
    {
        get
        {
            return Match<int?>(
                oneTime: (x) => x.Price,
                recurring: (x) => x.Price,
                usageBased: (_) => null
            );
        }
    }

    public bool PurchasingPowerParity
    {
        get
        {
            return Match(
                oneTime: (x) => x.PurchasingPowerParity,
                recurring: (x) => x.PurchasingPowerParity,
                usageBased: (x) => x.PurchasingPowerParity
            );
        }
    }

    public bool? TaxInclusive
    {
        get
        {
            return Match<bool?>(
                oneTime: (x) => x.TaxInclusive,
                recurring: (x) => x.TaxInclusive,
                usageBased: (x) => x.TaxInclusive
            );
        }
    }

    public int? PaymentFrequencyCount
    {
        get
        {
            return Match<int?>(
                oneTime: (_) => null,
                recurring: (x) => x.PaymentFrequencyCount,
                usageBased: (x) => x.PaymentFrequencyCount
            );
        }
    }

    public ApiEnum<string, TimeInterval>? PaymentFrequencyInterval
    {
        get
        {
            return Match<ApiEnum<string, TimeInterval>?>(
                oneTime: (_) => null,
                recurring: (x) => x.PaymentFrequencyInterval,
                usageBased: (x) => x.PaymentFrequencyInterval
            );
        }
    }

    public int? SubscriptionPeriodCount
    {
        get
        {
            return Match<int?>(
                oneTime: (_) => null,
                recurring: (x) => x.SubscriptionPeriodCount,
                usageBased: (x) => x.SubscriptionPeriodCount
            );
        }
    }

    public ApiEnum<string, TimeInterval>? SubscriptionPeriodInterval
    {
        get
        {
            return Match<ApiEnum<string, TimeInterval>?>(
                oneTime: (_) => null,
                recurring: (x) => x.SubscriptionPeriodInterval,
                usageBased: (x) => x.SubscriptionPeriodInterval
            );
        }
    }

    public Price(OneTimePrice value)
    {
        Value = value;
    }

    public Price(RecurringPrice value)
    {
        Value = value;
    }

    public Price(UsageBasedPrice value)
    {
        Value = value;
    }

    Price(UnknownVariant value)
    {
        Value = value;
    }

    public static Price CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickOneTime([NotNullWhen(true)] out OneTimePrice? value)
    {
        value = this.Value as OneTimePrice;
        return value != null;
    }

    public bool TryPickRecurring([NotNullWhen(true)] out RecurringPrice? value)
    {
        value = this.Value as RecurringPrice;
        return value != null;
    }

    public bool TryPickUsageBased([NotNullWhen(true)] out UsageBasedPrice? value)
    {
        value = this.Value as UsageBasedPrice;
        return value != null;
    }

    public void Switch(
        Action<OneTimePrice> oneTime,
        Action<RecurringPrice> recurring,
        Action<UsageBasedPrice> usageBased
    )
    {
        switch (this.Value)
        {
            case OneTimePrice value:
                oneTime(value);
                break;
            case RecurringPrice value:
                recurring(value);
                break;
            case UsageBasedPrice value:
                usageBased(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Price"
                );
        }
    }

    public T Match<T>(
        Func<OneTimePrice, T> oneTime,
        Func<RecurringPrice, T> recurring,
        Func<UsageBasedPrice, T> usageBased
    )
    {
        return this.Value switch
        {
            OneTimePrice value => oneTime(value),
            RecurringPrice value => recurring(value),
            UsageBasedPrice value => usageBased(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Price"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Price");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new Price(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'OneTimePrice'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RecurringPrice>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Price(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'RecurringPrice'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Price(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'UsageBasedPrice'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Price value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
