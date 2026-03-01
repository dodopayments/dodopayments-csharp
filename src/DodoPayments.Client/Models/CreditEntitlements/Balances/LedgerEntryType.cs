using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

[JsonConverter(typeof(LedgerEntryTypeConverter))]
public enum LedgerEntryType
{
    Credit,
    Debit,
}

sealed class LedgerEntryTypeConverter : JsonConverter<LedgerEntryType>
{
    public override LedgerEntryType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => LedgerEntryType.Credit,
            "debit" => LedgerEntryType.Debit,
            _ => (LedgerEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LedgerEntryType.Credit => "credit",
                LedgerEntryType.Debit => "debit",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
