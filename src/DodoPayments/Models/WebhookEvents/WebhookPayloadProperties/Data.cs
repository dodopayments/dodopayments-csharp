using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataProperties = DodoPayments.Models.WebhookEvents.WebhookPayloadProperties.DataProperties;
using DataVariants = DodoPayments.Models.WebhookEvents.WebhookPayloadProperties.DataVariants;

namespace DodoPayments.Models.WebhookEvents.WebhookPayloadProperties;

/// <summary>
/// The latest data at the time of delivery attempt
/// </summary>
[JsonConverter(typeof(DataConverter))]
public abstract record class Data
{
    internal Data() { }

    public static implicit operator Data(DataProperties::Payment value) =>
        new DataVariants::Payment(value);

    public static implicit operator Data(DataProperties::Subscription value) =>
        new DataVariants::Subscription(value);

    public static implicit operator Data(DataProperties::Refund value) =>
        new DataVariants::Refund(value);

    public static implicit operator Data(DataProperties::Dispute value) =>
        new DataVariants::Dispute(value);

    public static implicit operator Data(DataProperties::LicenseKey value) =>
        new DataVariants::LicenseKey(value);

    public abstract void Validate();
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Payment>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DataVariants::Payment(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Subscription>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DataVariants::Subscription(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Refund>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DataVariants::Refund(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::Dispute>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DataVariants::Dispute(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DataProperties::LicenseKey>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DataVariants::LicenseKey(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
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
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
