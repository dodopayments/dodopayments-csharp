using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Misc;

/// <summary>
/// Represents the different categories of taxation applicable to various products
/// and services.
/// </summary>
[JsonConverter(typeof(TaxCategoryConverter))]
public enum TaxCategory
{
    DigitalProducts,
    Saas,
    EBook,
    Edtech,
}

sealed class TaxCategoryConverter : JsonConverter<TaxCategory>
{
    public override TaxCategory Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "digital_products" => TaxCategory.DigitalProducts,
            "saas" => TaxCategory.Saas,
            "e_book" => TaxCategory.EBook,
            "edtech" => TaxCategory.Edtech,
            _ => (TaxCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxCategory.DigitalProducts => "digital_products",
                TaxCategory.Saas => "saas",
                TaxCategory.EBook => "e_book",
                TaxCategory.Edtech => "edtech",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
