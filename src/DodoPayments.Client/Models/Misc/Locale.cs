using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Misc;

/// <summary>
/// A locale that the checkout and the customer portal can show.
///
/// <para>The codes are a copy of the checkout locales. `GET /locales` lists them.</para>
/// </summary>
[JsonConverter(typeof(LocaleConverter))]
public enum Locale
{
    Ar,
    Ca,
    Zh,
    Nl,
    En,
    Fr,
    De,
    He,
    ID,
    It,
    Ja,
    Ka,
    Ko,
    Ms,
    Pl,
    Pt,
    Ro,
    Ru,
    Es,
    Sv,
    Th,
    Tr,
}

sealed class LocaleConverter : JsonConverter<Locale>
{
    public override Locale Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ar" => Locale.Ar,
            "ca" => Locale.Ca,
            "zh" => Locale.Zh,
            "nl" => Locale.Nl,
            "en" => Locale.En,
            "fr" => Locale.Fr,
            "de" => Locale.De,
            "he" => Locale.He,
            "id" => Locale.ID,
            "it" => Locale.It,
            "ja" => Locale.Ja,
            "ka" => Locale.Ka,
            "ko" => Locale.Ko,
            "ms" => Locale.Ms,
            "pl" => Locale.Pl,
            "pt" => Locale.Pt,
            "ro" => Locale.Ro,
            "ru" => Locale.Ru,
            "es" => Locale.Es,
            "sv" => Locale.Sv,
            "th" => Locale.Th,
            "tr" => Locale.Tr,
            _ => (Locale)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Locale value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Locale.Ar => "ar",
                Locale.Ca => "ca",
                Locale.Zh => "zh",
                Locale.Nl => "nl",
                Locale.En => "en",
                Locale.Fr => "fr",
                Locale.De => "de",
                Locale.He => "he",
                Locale.ID => "id",
                Locale.It => "it",
                Locale.Ja => "ja",
                Locale.Ka => "ka",
                Locale.Ko => "ko",
                Locale.Ms => "ms",
                Locale.Pl => "pl",
                Locale.Pt => "pt",
                Locale.Ro => "ro",
                Locale.Ru => "ru",
                Locale.Es => "es",
                Locale.Sv => "sv",
                Locale.Th => "th",
                Locale.Tr => "tr",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
