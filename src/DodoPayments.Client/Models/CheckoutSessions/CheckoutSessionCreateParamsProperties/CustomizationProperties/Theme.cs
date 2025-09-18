using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties.CustomizationProperties;

/// <summary>
/// Theme of the page
///
/// Default is `System`.
/// </summary>
[JsonConverter(typeof(ThemeConverter))]
public enum Theme
{
    Dark,
    Light,
    System,
}

sealed class ThemeConverter : JsonConverter<Theme>
{
    public override Theme Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dark" => Theme.Dark,
            "light" => Theme.Light,
            "system" => Theme.System,
            _ => (Theme)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Theme value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Theme.Dark => "dark",
                Theme.Light => "light",
                Theme.System => "system",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
