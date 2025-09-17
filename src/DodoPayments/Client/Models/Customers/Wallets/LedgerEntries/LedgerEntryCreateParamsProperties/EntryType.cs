using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries.LedgerEntryCreateParamsProperties;

/// <summary>
/// Type of ledger entry - credit or debit
/// </summary>
[JsonConverter(typeof(Client::EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : Client::IEnum<EntryType, string>
{
    public static readonly EntryType Credit = new("credit");

    public static readonly EntryType Debit = new("debit");

    readonly string _value = value;

    public enum Value
    {
        Credit,
        Debit,
    }

    public Value Known() =>
        _value switch
        {
            "credit" => Value.Credit,
            "debit" => Value.Debit,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static EntryType FromRaw(string value)
    {
        return new(value);
    }
}
