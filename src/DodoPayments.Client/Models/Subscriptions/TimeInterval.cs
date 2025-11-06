using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(TimeIntervalConverter))]
public enum TimeInterval
{
    Day,
    Week,
    Month,
    Year,
}

sealed class TimeIntervalConverter : JsonConverter<TimeInterval>
{
    public override TimeInterval Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Day" => TimeInterval.Day,
            "Week" => TimeInterval.Week,
            "Month" => TimeInterval.Month,
            "Year" => TimeInterval.Year,
            _ => (TimeInterval)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimeInterval value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TimeInterval.Day => "Day",
                TimeInterval.Week => "Week",
                TimeInterval.Month => "Month",
                TimeInterval.Year => "Year",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
