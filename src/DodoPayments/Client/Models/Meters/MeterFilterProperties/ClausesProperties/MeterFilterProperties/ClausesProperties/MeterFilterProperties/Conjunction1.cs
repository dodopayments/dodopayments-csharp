using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Meters.MeterFilterProperties.ClausesProperties.MeterFilterProperties.ClausesProperties.MeterFilterProperties;

[JsonConverter(typeof(Client::EnumConverter<Conjunction1, string>))]
public sealed record class Conjunction1(string value) : Client::IEnum<Conjunction1, string>
{
    public static readonly Conjunction1 And = new("and");

    public static readonly Conjunction1 Or = new("or");

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

    public static Conjunction1 FromRaw(string value)
    {
        return new(value);
    }
}
