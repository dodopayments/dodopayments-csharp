using System;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Discounts;

[JsonConverter(typeof(Dodopayments::EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : Dodopayments::IEnum<DiscountType, string>
{
    public static readonly DiscountType Percentage = new("percentage");

    readonly string _value = value;

    public enum Value
    {
        Percentage,
    }

    public Value Known() =>
        _value switch
        {
            "percentage" => Value.Percentage,
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

    public static DiscountType FromRaw(string value)
    {
        return new(value);
    }
}
