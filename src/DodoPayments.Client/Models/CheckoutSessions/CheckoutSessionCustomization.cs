using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(
    typeof(JsonModelConverter<CheckoutSessionCustomization, CheckoutSessionCustomizationFromRaw>)
)]
public sealed record class CheckoutSessionCustomization : JsonModel
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("force_language");
        }
        init { this._rawData.Set("force_language", value); }
    }

    /// <summary>
    /// Show on demand tag
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? ShowOnDemandTag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("show_on_demand_tag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("show_on_demand_tag", value);
        }
    }

    /// <summary>
    /// Show order details by default
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? ShowOrderDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("show_order_details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("show_order_details", value);
        }
    }

    /// <summary>
    /// Theme of the page (determines which mode - light/dark/system - to use)
    ///
    /// <para>Default is `System`.</para>
    /// </summary>
    public ApiEnum<string, Theme>? Theme
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Theme>>("theme");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("theme", value);
        }
    }

    /// <summary>
    /// Optional custom theme configuration with colors for light and dark modes
    /// </summary>
    public ThemeConfig? ThemeConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThemeConfig>("theme_config");
        }
        init { this._rawData.Set("theme_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ForceLanguage;
        _ = this.ShowOnDemandTag;
        _ = this.ShowOrderDetails;
        this.Theme?.Validate();
        this.ThemeConfig?.Validate();
    }

    public CheckoutSessionCustomization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionCustomization(CheckoutSessionCustomization checkoutSessionCustomization)
        : base(checkoutSessionCustomization) { }
#pragma warning restore CS8618

    public CheckoutSessionCustomization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionCustomization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionCustomizationFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionCustomization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionCustomizationFromRaw : IFromRawJson<CheckoutSessionCustomization>
{
    /// <inheritdoc/>
    public CheckoutSessionCustomization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionCustomization.FromRawUnchecked(rawData);
}

/// <summary>
/// Theme of the page (determines which mode - light/dark/system - to use)
///
/// <para>Default is `System`.</para>
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
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
