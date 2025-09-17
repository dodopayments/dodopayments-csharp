using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.Meters.MeterAggregationProperties;

/// <summary>
/// Aggregation type for the meter
/// </summary>
[JsonConverter(typeof(Dodopayments::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Dodopayments::IEnum<Type, string>
{
    public static readonly Type Count = new("count");

    public static readonly Type Sum = new("sum");

    public static readonly Type Max = new("max");

    public static readonly Type Last = new("last");

    readonly string _value = value;

    public enum Value
    {
        Count,
        Sum,
        Max,
        Last,
    }

    public Value Known() =>
        _value switch
        {
            "count" => Value.Count,
            "sum" => Value.Sum,
            "max" => Value.Max,
            "last" => Value.Last,
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
