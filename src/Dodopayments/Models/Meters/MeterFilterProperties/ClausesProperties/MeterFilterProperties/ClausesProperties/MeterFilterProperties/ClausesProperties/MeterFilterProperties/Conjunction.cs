using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

[JsonConverter(typeof(Dodopayments::EnumConverter<Conjunction, string>))]
public sealed record class Conjunction(string value) : Dodopayments::IEnum<Conjunction, string>
{
    public static readonly Conjunction And = new("and");

    public static readonly Conjunction Or = new("or");

    readonly string _value = value;

    public enum Value
    {
        And,
        Or,
    }

    public Value Known() =>
        _value switch
        {
            "and" => Value.And,
            "or" => Value.Or,
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

    public static Conjunction FromRaw(string value)
    {
        return new(value);
    }
}
