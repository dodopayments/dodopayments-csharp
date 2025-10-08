using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;
using DataProperties = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties;

/// <summary>
/// The latest data at the time of delivery attempt
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record class Data
{
    public object Value { get; private init; }

    public BillingAddress? Billing
    {
        get
        {
            return Match<BillingAddress?>(
                payment: (x) => x.Billing,
                subscription: (x) => x.Billing,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null
            );
        }
    }

    public string? BusinessID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.BusinessID,
                subscription: (_) => null,
                refund: (x) => x.BusinessID,
                dispute: (x) => x.BusinessID,
                licenseKey: (x) => x.BusinessID
            );
        }
    }

    public DateTime CreatedAt
    {
        get
        {
            return Match(
                payment: (x) => x.CreatedAt,
                subscription: (x) => x.CreatedAt,
                refund: (x) => x.CreatedAt,
                dispute: (x) => x.CreatedAt,
                licenseKey: (x) => x.CreatedAt
            );
        }
    }

    public CustomerLimitedDetails? Customer
    {
        get
        {
            return Match<CustomerLimitedDetails?>(
                payment: (x) => x.Customer,
                subscription: (x) => x.Customer,
                refund: (x) => x.Customer,
                dispute: (x) => x.Customer,
                licenseKey: (_) => null
            );
        }
    }

    public string? PaymentID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.PaymentID,
                subscription: (_) => null,
                refund: (x) => x.PaymentID,
                dispute: (x) => x.PaymentID,
                licenseKey: (x) => x.PaymentID
            );
        }
    }

    public string? DiscountID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.DiscountID,
                subscription: (x) => x.DiscountID,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (_) => null
            );
        }
    }

    public string? SubscriptionID
    {
        get
        {
            return Match<string?>(
                payment: (x) => x.SubscriptionID,
                subscription: (x) => x.SubscriptionID,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.SubscriptionID
            );
        }
    }

    public string? ProductID
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (x) => x.ProductID,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.ProductID
            );
        }
    }

    public DateTime? ExpiresAt
    {
        get
        {
            return Match<DateTime?>(
                payment: (_) => null,
                subscription: (x) => x.ExpiresAt,
                refund: (_) => null,
                dispute: (_) => null,
                licenseKey: (x) => x.ExpiresAt
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                payment: (_) => null,
                subscription: (_) => null,
                refund: (x) => x.Reason,
                dispute: (x) => x.Reason,
                licenseKey: (_) => null
            );
        }
    }

    public Data(DataProperties::Payment value)
    {
        Value = value;
    }

    public Data(DataProperties::Subscription value)
    {
        Value = value;
    }

    public Data(DataProperties::Refund value)
    {
        Value = value;
    }

    public Data(DataProperties::Dispute value)
    {
        Value = value;
    }

    public Data(DataProperties::LicenseKey value)
    {
        Value = value;
    }

    Data(UnknownVariant value)
    {
        Value = value;
    }

    public static Data CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickPayment([NotNullWhen(true)] out DataProperties::Payment? value)
    {
        value = this.Value as DataProperties::Payment;
        return value != null;
    }

    public bool TryPickSubscription([NotNullWhen(true)] out DataProperties::Subscription? value)
    {
        value = this.Value as DataProperties::Subscription;
        return value != null;
    }

    public bool TryPickRefund([NotNullWhen(true)] out DataProperties::Refund? value)
    {
        value = this.Value as DataProperties::Refund;
        return value != null;
    }

    public bool TryPickDispute([NotNullWhen(true)] out DataProperties::Dispute? value)
    {
        value = this.Value as DataProperties::Dispute;
        return value != null;
    }

    public bool TryPickLicenseKey([NotNullWhen(true)] out DataProperties::LicenseKey? value)
    {
        value = this.Value as DataProperties::LicenseKey;
        return value != null;
    }

    public void Switch(
        Action<DataProperties::Payment> payment,
        Action<DataProperties::Subscription> subscription,
        Action<DataProperties::Refund> refund,
        Action<DataProperties::Dispute> dispute,
        Action<DataProperties::LicenseKey> licenseKey
    )
    {
        switch (this.Value)
        {
            case DataProperties::Payment value:
                payment(value);
                break;
            case DataProperties::Subscription value:
                subscription(value);
                break;
            case DataProperties::Refund value:
                refund(value);
                break;
            case DataProperties::Dispute value:
                dispute(value);
                break;
            case DataProperties::LicenseKey value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Data"
                );
        }
    }

    public T Match<T>(
        Func<DataProperties::Payment, T> payment,
        Func<DataProperties::Subscription, T> subscription,
        Func<DataProperties::Refund, T> refund,
        Func<DataProperties::Dispute, T> dispute,
        Func<DataProperties::LicenseKey, T> licenseKey
    )
    {
        return this.Value switch
        {
            DataProperties::Payment value => payment(value),
            DataProperties::Subscription value => subscription(value),
            DataProperties::Refund value => refund(value),
            DataProperties::Dispute value => dispute(value),
            DataProperties::LicenseKey value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Data"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Data");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            var deserialized = JsonSerializer.Deserialize<DataProperties::Payment>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Data(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DataProperties::Payment'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Subscription>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Data(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DataProperties::Subscription'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Refund>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Data(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DataProperties::Refund'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Dispute>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Data(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DataProperties::Dispute'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::LicenseKey>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Data(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'DataProperties::LicenseKey'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
