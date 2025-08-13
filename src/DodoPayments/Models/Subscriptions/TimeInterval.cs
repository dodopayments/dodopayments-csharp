using System;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Subscriptions;

[JsonConverter(typeof(DodoPayments::EnumConverter<TimeInterval, string>))]
public sealed record class TimeInterval(string value) : DodoPayments::IEnum<TimeInterval, string>
{
    public static readonly TimeInterval Day = new("Day");

    public static readonly TimeInterval Week = new("Week");

    public static readonly TimeInterval Month = new("Month");

    public static readonly TimeInterval Year = new("Year");

    readonly string _value = value;

    public enum Value
    {
        Day,
        Week,
        Month,
        Year,
    }

    public Value Known() =>
        _value switch
        {
            "Day" => Value.Day,
            "Week" => Value.Week,
            "Month" => Value.Month,
            "Year" => Value.Year,
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

    public static TimeInterval FromRaw(string value)
    {
        return new(value);
    }
}
