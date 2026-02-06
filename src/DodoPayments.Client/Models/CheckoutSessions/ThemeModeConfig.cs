using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CheckoutSessions;

/// <summary>
/// Color configuration for a single theme mode (light or dark).
///
/// <para>All color fields accept standard CSS color formats: - Hex: `#fff`, `#ffffff`,
/// `#ffffffff` (with or without # prefix) - RGB/RGBA: `rgb(255, 255, 255)`, `rgba(255,
/// 255, 255, 0.5)` - HSL/HSLA: `hsl(120, 100%, 50%)`, `hsla(120, 100%, 50%, 0.5)`
/// - Named colors: `red`, `blue`, `transparent`, etc. - Advanced: `hwb()`, `lab()`,
/// `lch()`, `oklab()`, `oklch()`, `color()`</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThemeModeConfig, ThemeModeConfigFromRaw>))]
public sealed record class ThemeModeConfig : JsonModel
{
    /// <summary>
    /// Background primary color
    ///
    /// <para>Examples: `"#ffffff"`, `"rgb(255, 255, 255)"`, `"white"`</para>
    /// </summary>
    public string? BgPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_primary");
        }
        init { this._rawData.Set("bg_primary", value); }
    }

    /// <summary>
    /// Background secondary color
    /// </summary>
    public string? BgSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_secondary");
        }
        init { this._rawData.Set("bg_secondary", value); }
    }

    /// <summary>
    /// Border primary color
    /// </summary>
    public string? BorderPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_primary");
        }
        init { this._rawData.Set("border_primary", value); }
    }

    /// <summary>
    /// Border secondary color
    /// </summary>
    public string? BorderSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_secondary");
        }
        init { this._rawData.Set("border_secondary", value); }
    }

    /// <summary>
    /// Primary button background color
    /// </summary>
    public string? ButtonPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_primary");
        }
        init { this._rawData.Set("button_primary", value); }
    }

    /// <summary>
    /// Primary button hover color
    /// </summary>
    public string? ButtonPrimaryHover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_primary_hover");
        }
        init { this._rawData.Set("button_primary_hover", value); }
    }

    /// <summary>
    /// Secondary button background color
    /// </summary>
    public string? ButtonSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_secondary");
        }
        init { this._rawData.Set("button_secondary", value); }
    }

    /// <summary>
    /// Secondary button hover color
    /// </summary>
    public string? ButtonSecondaryHover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_secondary_hover");
        }
        init { this._rawData.Set("button_secondary_hover", value); }
    }

    /// <summary>
    /// Primary button text color
    /// </summary>
    public string? ButtonTextPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_text_primary");
        }
        init { this._rawData.Set("button_text_primary", value); }
    }

    /// <summary>
    /// Secondary button text color
    /// </summary>
    public string? ButtonTextSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("button_text_secondary");
        }
        init { this._rawData.Set("button_text_secondary", value); }
    }

    /// <summary>
    /// Input focus border color
    /// </summary>
    public string? InputFocusBorder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_focus_border");
        }
        init { this._rawData.Set("input_focus_border", value); }
    }

    /// <summary>
    /// Text error color
    /// </summary>
    public string? TextError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_error");
        }
        init { this._rawData.Set("text_error", value); }
    }

    /// <summary>
    /// Text placeholder color
    /// </summary>
    public string? TextPlaceholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_placeholder");
        }
        init { this._rawData.Set("text_placeholder", value); }
    }

    /// <summary>
    /// Text primary color
    /// </summary>
    public string? TextPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_primary");
        }
        init { this._rawData.Set("text_primary", value); }
    }

    /// <summary>
    /// Text secondary color
    /// </summary>
    public string? TextSecondary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_secondary");
        }
        init { this._rawData.Set("text_secondary", value); }
    }

    /// <summary>
    /// Text success color
    /// </summary>
    public string? TextSuccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_success");
        }
        init { this._rawData.Set("text_success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BgPrimary;
        _ = this.BgSecondary;
        _ = this.BorderPrimary;
        _ = this.BorderSecondary;
        _ = this.ButtonPrimary;
        _ = this.ButtonPrimaryHover;
        _ = this.ButtonSecondary;
        _ = this.ButtonSecondaryHover;
        _ = this.ButtonTextPrimary;
        _ = this.ButtonTextSecondary;
        _ = this.InputFocusBorder;
        _ = this.TextError;
        _ = this.TextPlaceholder;
        _ = this.TextPrimary;
        _ = this.TextSecondary;
        _ = this.TextSuccess;
    }

    public ThemeModeConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThemeModeConfig(ThemeModeConfig themeModeConfig)
        : base(themeModeConfig) { }
#pragma warning restore CS8618

    public ThemeModeConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThemeModeConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThemeModeConfigFromRaw.FromRawUnchecked"/>
    public static ThemeModeConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThemeModeConfigFromRaw : IFromRawJson<ThemeModeConfig>
{
    /// <inheritdoc/>
    public ThemeModeConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThemeModeConfig.FromRawUnchecked(rawData);
}
