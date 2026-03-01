using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(FilterOperatorConverter))]
public enum FilterOperator
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

sealed class FilterOperatorConverter : JsonConverter<FilterOperator>
{
    public override FilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => FilterOperator.Equals,
            "not_equals" => FilterOperator.NotEquals,
            "greater_than" => FilterOperator.GreaterThan,
            "greater_than_or_equals" => FilterOperator.GreaterThanOrEquals,
            "less_than" => FilterOperator.LessThan,
            "less_than_or_equals" => FilterOperator.LessThanOrEquals,
            "contains" => FilterOperator.Contains,
            "does_not_contain" => FilterOperator.DoesNotContain,
            _ => (FilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FilterOperator.Equals => "equals",
                FilterOperator.NotEquals => "not_equals",
                FilterOperator.GreaterThan => "greater_than",
                FilterOperator.GreaterThanOrEquals => "greater_than_or_equals",
                FilterOperator.LessThan => "less_than",
                FilterOperator.LessThanOrEquals => "less_than_or_equals",
                FilterOperator.Contains => "contains",
                FilterOperator.DoesNotContain => "does_not_contain",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
