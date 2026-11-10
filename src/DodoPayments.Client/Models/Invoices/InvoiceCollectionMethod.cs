using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Invoices;

[JsonConverter(typeof(InvoiceCollectionMethodConverter))]
public enum InvoiceCollectionMethod
{
    AutoCharge,
    Manual,
}

sealed class InvoiceCollectionMethodConverter : JsonConverter<InvoiceCollectionMethod>
{
    public override InvoiceCollectionMethod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_charge" => InvoiceCollectionMethod.AutoCharge,
            "manual" => InvoiceCollectionMethod.Manual,
            _ => (InvoiceCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceCollectionMethod.AutoCharge => "auto_charge",
                InvoiceCollectionMethod.Manual => "manual",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
