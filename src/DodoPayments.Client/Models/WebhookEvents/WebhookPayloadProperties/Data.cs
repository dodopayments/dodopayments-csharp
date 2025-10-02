using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties;
using DataVariants = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataVariants;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties;

/// <summary>
/// The latest data at the time of delivery attempt
/// </summary>
[JsonConverter(typeof(DataConverter))]
public abstract record class Data
{
    internal Data() { }

    public static implicit operator Data(Payment value) => new DataVariants::Payment(value);

    public static implicit operator Data(Subscription value) =>
        new DataVariants::Subscription(value);

    public static implicit operator Data(Refund value) => new DataVariants::Refund(value);

    public static implicit operator Data(Dispute value) => new DataVariants::Dispute(value);

    public static implicit operator Data(LicenseKey value) => new DataVariants::LicenseKey(value);

    public bool TryPickPayment([NotNullWhen(true)] out Payment? value)
    {
        value = (this as DataVariants::Payment)?.Value;
        return value != null;
    }

    public bool TryPickSubscription([NotNullWhen(true)] out Subscription? value)
    {
        value = (this as DataVariants::Subscription)?.Value;
        return value != null;
    }

    public bool TryPickRefund([NotNullWhen(true)] out Refund? value)
    {
        value = (this as DataVariants::Refund)?.Value;
        return value != null;
    }

    public bool TryPickDispute([NotNullWhen(true)] out Dispute? value)
    {
        value = (this as DataVariants::Dispute)?.Value;
        return value != null;
    }

    public bool TryPickLicenseKey([NotNullWhen(true)] out LicenseKey? value)
    {
        value = (this as DataVariants::LicenseKey)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DataVariants::Payment> payment,
        Action<DataVariants::Subscription> subscription,
        Action<DataVariants::Refund> refund,
        Action<DataVariants::Dispute> dispute,
        Action<DataVariants::LicenseKey> licenseKey
    )
    {
        switch (this)
        {
            case DataVariants::Payment inner:
                payment(inner);
                break;
            case DataVariants::Subscription inner:
                subscription(inner);
                break;
            case DataVariants::Refund inner:
                refund(inner);
                break;
            case DataVariants::Dispute inner:
                dispute(inner);
                break;
            case DataVariants::LicenseKey inner:
                licenseKey(inner);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Data"
                );
        }
    }

    public T Match<T>(
        Func<DataVariants::Payment, T> payment,
        Func<DataVariants::Subscription, T> subscription,
        Func<DataVariants::Refund, T> refund,
        Func<DataVariants::Dispute, T> dispute,
        Func<DataVariants::LicenseKey, T> licenseKey
    )
    {
        return this switch
        {
            DataVariants::Payment inner => payment(inner),
            DataVariants::Subscription inner => subscription(inner),
            DataVariants::Refund inner => refund(inner),
            DataVariants::Dispute inner => dispute(inner),
            DataVariants::LicenseKey inner => licenseKey(inner),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Data"
            ),
        };
    }

    public abstract void Validate();
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Payment>(ref reader, options);
            if (deserialized != null)
            {
                return new DataVariants::Payment(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant DataVariants::Payment",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Subscription>(ref reader, options);
            if (deserialized != null)
            {
                return new DataVariants::Subscription(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant DataVariants::Subscription",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Refund>(ref reader, options);
            if (deserialized != null)
            {
                return new DataVariants::Refund(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant DataVariants::Refund",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dispute>(ref reader, options);
            if (deserialized != null)
            {
                return new DataVariants::Dispute(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant DataVariants::Dispute",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LicenseKey>(ref reader, options);
            if (deserialized != null)
            {
                return new DataVariants::LicenseKey(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant DataVariants::LicenseKey",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            DataVariants::Payment(var payment) => payment,
            DataVariants::Subscription(var subscription) => subscription,
            DataVariants::Refund(var refund) => refund,
            DataVariants::Dispute(var dispute) => dispute,
            DataVariants::LicenseKey(var licenseKey) => licenseKey,
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Data"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
