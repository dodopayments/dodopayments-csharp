using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Misc;

/// <summary>
/// Represents the different categories of taxation applicable to various products
/// and services.
/// </summary>
[JsonConverter(typeof(DodoPayments::EnumConverter<TaxCategory, string>))]
public sealed record class TaxCategory(string value) : DodoPayments::IEnum<TaxCategory, string>
{
    public static readonly TaxCategory DigitalProducts = new("digital_products");

    public static readonly TaxCategory Saas = new("saas");

    public static readonly TaxCategory EBook = new("e_book");

    public static readonly TaxCategory Edtech = new("edtech");

    readonly string _value = value;

    public enum Value
    {
        DigitalProducts,
        Saas,
        EBook,
        Edtech,
    }

    public Value Known() =>
        _value switch
        {
            "digital_products" => Value.DigitalProducts,
            "saas" => Value.Saas,
            "e_book" => Value.EBook,
            "edtech" => Value.Edtech,
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

    public static TaxCategory FromRaw(string value)
    {
        return new(value);
    }
}
