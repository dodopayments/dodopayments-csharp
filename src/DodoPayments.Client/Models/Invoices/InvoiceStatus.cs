using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// The `message` of each variant is the label of the invoice document.
/// </summary>
[JsonConverter(typeof(InvoiceStatusConverter))]
public enum InvoiceStatus
{
    Open,
    Paid,
    Void,
    Draft,
    PastDue,
    Uncollectable,
}

sealed class InvoiceStatusConverter : JsonConverter<InvoiceStatus>
{
    public override InvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => InvoiceStatus.Open,
            "paid" => InvoiceStatus.Paid,
            "void" => InvoiceStatus.Void,
            "draft" => InvoiceStatus.Draft,
            "past_due" => InvoiceStatus.PastDue,
            "uncollectable" => InvoiceStatus.Uncollectable,
            _ => (InvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceStatus.Open => "open",
                InvoiceStatus.Paid => "paid",
                InvoiceStatus.Void => "void",
                InvoiceStatus.Draft => "draft",
                InvoiceStatus.PastDue => "past_due",
                InvoiceStatus.Uncollectable => "uncollectable",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
