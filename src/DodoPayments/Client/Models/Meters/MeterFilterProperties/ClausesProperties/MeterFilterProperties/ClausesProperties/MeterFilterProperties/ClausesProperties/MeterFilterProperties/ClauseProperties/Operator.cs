using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClauseProperties;

[JsonConverter(typeof(Client::EnumConverter<Operator, string>))]
public sealed record class Operator(string value) : Client::IEnum<Operator, string>
{
    public static readonly Operator Equals = new("equals");

    public static readonly Operator NotEquals = new("not_equals");

    public static readonly Operator GreaterThan = new("greater_than");

    public static readonly Operator GreaterThanOrEquals = new("greater_than_or_equals");

    public static readonly Operator LessThan = new("less_than");

    public static readonly Operator LessThanOrEquals = new("less_than_or_equals");

    public static readonly Operator Contains = new("contains");

    public static readonly Operator DoesNotContain = new("does_not_contain");

    readonly string _value = value;

    public enum Value
    {
        Equals,
        NotEquals,
        GreaterThan,
        GreaterThanOrEquals,
        LessThan,
        LessThanOrEquals,
        Contains,
        DoesNotContain,
    }

    public Value Known() =>
        _value switch
        {
            "equals" => Value.Equals,
            "not_equals" => Value.NotEquals,
            "greater_than" => Value.GreaterThan,
            "greater_than_or_equals" => Value.GreaterThanOrEquals,
            "less_than" => Value.LessThan,
            "less_than_or_equals" => Value.LessThanOrEquals,
            "contains" => Value.Contains,
            "does_not_contain" => Value.DoesNotContain,
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

    public static Operator FromRaw(string value)
    {
        return new(value);
    }
}
