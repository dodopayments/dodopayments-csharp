using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

[JsonConverter(typeof(Dodopayments::EnumConverter<Conjunction2, string>))]
public sealed record class Conjunction2(string value) : Dodopayments::IEnum<Conjunction2, string>
{
    public static readonly Conjunction2 And = new("and");

    public static readonly Conjunction2 Or = new("or");

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

    public static Conjunction2 FromRaw(string value)
    {
        return new(value);
    }
}
