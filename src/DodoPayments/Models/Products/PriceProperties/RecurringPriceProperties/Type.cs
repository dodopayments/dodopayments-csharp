using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;
using System = System;

namespace DodoPayments.Models.Products.PriceProperties.RecurringPriceProperties;

[JsonConverter(typeof(DodoPayments::EnumConverter<Type, string>))]
public sealed record class Type(string value) : DodoPayments::IEnum<Type, string>
{
    public static readonly Type RecurringPrice = new("recurring_price");

    readonly string _value = value;

    public enum Value
    {
        RecurringPrice,
    }

    public Value Known() =>
        _value switch
        {
            "recurring_price" => Value.RecurringPrice,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
