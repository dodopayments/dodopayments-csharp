using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Products.LocalizedPrices;

[JsonConverter(typeof(PricingModeConverter))]
public enum PricingMode
{
    ByCurrency,
    ByCountry,
}

sealed class PricingModeConverter : JsonConverter<PricingMode>
{
    public override PricingMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "by_currency" => PricingMode.ByCurrency,
            "by_country" => PricingMode.ByCountry,
            _ => (PricingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingMode.ByCurrency => "by_currency",
                PricingMode.ByCountry => "by_country",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
