using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.Meters.MeterFilterProperties;

/// <summary>
/// Logical conjunction to apply between clauses (and/or)
/// </summary>
[JsonConverter(typeof(Dodopayments::EnumConverter<Conjunction3, string>))]
public sealed record class Conjunction3(string value) : Dodopayments::IEnum<Conjunction3, string>
{
    public static readonly Conjunction3 And = new("and");

    public static readonly Conjunction3 Or = new("or");

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

    public static Conjunction3 FromRaw(string value)
    {
        return new(value);
    }
}
