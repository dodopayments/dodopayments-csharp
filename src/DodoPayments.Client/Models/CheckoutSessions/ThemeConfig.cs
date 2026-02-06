using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

/// <summary>
/// Custom theme configuration with colors for light and dark modes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThemeConfig, ThemeConfigFromRaw>))]
public sealed record class ThemeConfig : JsonModel
{
    /// <summary>
    /// Dark mode color configuration
    /// </summary>
    public ThemeModeConfig? Dark
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThemeModeConfig>("dark");
        }
        init { this._rawData.Set("dark", value); }
    }

    /// <summary>
    /// URL for the primary font
    /// </summary>
    public string? FontPrimaryUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_primary_url");
        }
        init { this._rawData.Set("font_primary_url", value); }
    }

    /// <summary>
    /// URL for the secondary font
    /// </summary>
    public string? FontSecondaryUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_secondary_url");
        }
        init { this._rawData.Set("font_secondary_url", value); }
    }

    /// <summary>
    /// Font size for the checkout UI
    /// </summary>
    public ApiEnum<string, FontSize>? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FontSize>>("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    /// <summary>
    /// Font weight for the checkout UI
    /// </summary>
    public ApiEnum<string, FontWeight>? FontWeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FontWeight>>("font_weight");
        }
        init { this._rawData.Set("font_weight", value); }
    }

    /// <summary>
    /// Light mode color configuration
    /// </summary>
    public ThemeModeConfig? Light
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThemeModeConfig>("light");
        }
        init { this._rawData.Set("light", value); }
    }

    /// <summary>
    /// Custom text for the pay button (e.g., "Complete Purchase", "Subscribe Now")
    /// </summary>
    public string? PayButtonText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pay_button_text");
        }
        init { this._rawData.Set("pay_button_text", value); }
    }

    /// <summary>
    /// Border radius for UI elements (e.g., "4px", "0.5rem", "8px")
    /// </summary>
    public string? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("radius");
        }
        init { this._rawData.Set("radius", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Dark?.Validate();
        _ = this.FontPrimaryUrl;
        _ = this.FontSecondaryUrl;
        this.FontSize?.Validate();
        this.FontWeight?.Validate();
        this.Light?.Validate();
        _ = this.PayButtonText;
        _ = this.Radius;
    }

    public ThemeConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThemeConfig(ThemeConfig themeConfig)
        : base(themeConfig) { }
#pragma warning restore CS8618

    public ThemeConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThemeConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThemeConfigFromRaw.FromRawUnchecked"/>
    public static ThemeConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThemeConfigFromRaw : IFromRawJson<ThemeConfig>
{
    /// <inheritdoc/>
    public ThemeConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThemeConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Font size for the checkout UI
/// </summary>
[JsonConverter(typeof(FontSizeConverter))]
public enum FontSize
{
    Xs,
    Sm,
    Md,
    Lg,
    Xl,
    V2xl,
}

sealed class FontSizeConverter : JsonConverter<FontSize>
{
    public override FontSize Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "xs" => FontSize.Xs,
            "sm" => FontSize.Sm,
            "md" => FontSize.Md,
            "lg" => FontSize.Lg,
            "xl" => FontSize.Xl,
            "2xl" => FontSize.V2xl,
            _ => (FontSize)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FontSize value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FontSize.Xs => "xs",
                FontSize.Sm => "sm",
                FontSize.Md => "md",
                FontSize.Lg => "lg",
                FontSize.Xl => "xl",
                FontSize.V2xl => "2xl",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Font weight for the checkout UI
/// </summary>
[JsonConverter(typeof(FontWeightConverter))]
public enum FontWeight
{
    Normal,
    Medium,
    Bold,
    ExtraBold,
}

sealed class FontWeightConverter : JsonConverter<FontWeight>
{
    public override FontWeight Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => FontWeight.Normal,
            "medium" => FontWeight.Medium,
            "bold" => FontWeight.Bold,
            "extraBold" => FontWeight.ExtraBold,
            _ => (FontWeight)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FontWeight value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FontWeight.Normal => "normal",
                FontWeight.Medium => "medium",
                FontWeight.Bold => "bold",
                FontWeight.ExtraBold => "extraBold",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
