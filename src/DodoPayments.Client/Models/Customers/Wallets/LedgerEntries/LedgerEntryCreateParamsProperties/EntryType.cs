using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries.LedgerEntryCreateParamsProperties;

/// <summary>
/// Type of ledger entry - credit or debit
/// </summary>
[JsonConverter(typeof(EntryTypeConverter))]
public enum EntryType
{
    Credit,
    Debit,
}

sealed class EntryTypeConverter : JsonConverter<EntryType>
{
    public override EntryType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => EntryType.Credit,
            "debit" => EntryType.Debit,
            _ => (EntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryType.Credit => "credit",
                EntryType.Debit => "debit",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
