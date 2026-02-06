using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionCustomizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, Theme> expectedTheme = Theme.Dark;
        ThemeConfig expectedThemeConfig = new()
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontPrimaryUrl = "font_primary_url",
            FontSecondaryUrl = "font_secondary_url",
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        Assert.Equal(expectedForceLanguage, model.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, model.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, model.ShowOrderDetails);
        Assert.Equal(expectedTheme, model.Theme);
        Assert.Equal(expectedThemeConfig, model.ThemeConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionCustomization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionCustomization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedForceLanguage = "force_language";
        bool expectedShowOnDemandTag = true;
        bool expectedShowOrderDetails = true;
        ApiEnum<string, Theme> expectedTheme = Theme.Dark;
        ThemeConfig expectedThemeConfig = new()
        {
            Dark = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            FontPrimaryUrl = "font_primary_url",
            FontSecondaryUrl = "font_secondary_url",
            FontSize = FontSize.Xs,
            FontWeight = FontWeight.Normal,
            Light = new()
            {
                BgPrimary = "bg_primary",
                BgSecondary = "bg_secondary",
                BorderPrimary = "border_primary",
                BorderSecondary = "border_secondary",
                ButtonPrimary = "button_primary",
                ButtonPrimaryHover = "button_primary_hover",
                ButtonSecondary = "button_secondary",
                ButtonSecondaryHover = "button_secondary_hover",
                ButtonTextPrimary = "button_text_primary",
                ButtonTextSecondary = "button_text_secondary",
                InputFocusBorder = "input_focus_border",
                TextError = "text_error",
                TextPlaceholder = "text_placeholder",
                TextPrimary = "text_primary",
                TextSecondary = "text_secondary",
                TextSuccess = "text_success",
            },
            PayButtonText = "pay_button_text",
            Radius = "radius",
        };

        Assert.Equal(expectedForceLanguage, deserialized.ForceLanguage);
        Assert.Equal(expectedShowOnDemandTag, deserialized.ShowOnDemandTag);
        Assert.Equal(expectedShowOrderDetails, deserialized.ShowOrderDetails);
        Assert.Equal(expectedTheme, deserialized.Theme);
        Assert.Equal(expectedThemeConfig, deserialized.ThemeConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        Assert.Null(model.ShowOnDemandTag);
        Assert.False(model.RawData.ContainsKey("show_on_demand_tag"));
        Assert.Null(model.ShowOrderDetails);
        Assert.False(model.RawData.ContainsKey("show_order_details"));
        Assert.Null(model.Theme);
        Assert.False(model.RawData.ContainsKey("theme"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },

            // Null should be interpreted as omitted for these properties
            ShowOnDemandTag = null,
            ShowOrderDetails = null,
            Theme = null,
        };

        Assert.Null(model.ShowOnDemandTag);
        Assert.False(model.RawData.ContainsKey("show_on_demand_tag"));
        Assert.Null(model.ShowOrderDetails);
        Assert.False(model.RawData.ContainsKey("show_order_details"));
        Assert.Null(model.Theme);
        Assert.False(model.RawData.ContainsKey("theme"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },

            // Null should be interpreted as omitted for these properties
            ShowOnDemandTag = null,
            ShowOrderDetails = null,
            Theme = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
        };

        Assert.Null(model.ForceLanguage);
        Assert.False(model.RawData.ContainsKey("force_language"));
        Assert.Null(model.ThemeConfig);
        Assert.False(model.RawData.ContainsKey("theme_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,

            ForceLanguage = null,
            ThemeConfig = null,
        };

        Assert.Null(model.ForceLanguage);
        Assert.True(model.RawData.ContainsKey("force_language"));
        Assert.Null(model.ThemeConfig);
        Assert.True(model.RawData.ContainsKey("theme_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,

            ForceLanguage = null,
            ThemeConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionCustomization
        {
            ForceLanguage = "force_language",
            ShowOnDemandTag = true,
            ShowOrderDetails = true,
            Theme = Theme.Dark,
            ThemeConfig = new()
            {
                Dark = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                FontPrimaryUrl = "font_primary_url",
                FontSecondaryUrl = "font_secondary_url",
                FontSize = FontSize.Xs,
                FontWeight = FontWeight.Normal,
                Light = new()
                {
                    BgPrimary = "bg_primary",
                    BgSecondary = "bg_secondary",
                    BorderPrimary = "border_primary",
                    BorderSecondary = "border_secondary",
                    ButtonPrimary = "button_primary",
                    ButtonPrimaryHover = "button_primary_hover",
                    ButtonSecondary = "button_secondary",
                    ButtonSecondaryHover = "button_secondary_hover",
                    ButtonTextPrimary = "button_text_primary",
                    ButtonTextSecondary = "button_text_secondary",
                    InputFocusBorder = "input_focus_border",
                    TextError = "text_error",
                    TextPlaceholder = "text_placeholder",
                    TextPrimary = "text_primary",
                    TextSecondary = "text_secondary",
                    TextSuccess = "text_success",
                },
                PayButtonText = "pay_button_text",
                Radius = "radius",
            },
        };

        CheckoutSessionCustomization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThemeTest : TestBase
{
    [Theory]
    [InlineData(Theme.Dark)]
    [InlineData(Theme.Light)]
    [InlineData(Theme.System)]
    public void Validation_Works(Theme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Theme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Theme.Dark)]
    [InlineData(Theme.Light)]
    [InlineData(Theme.System)]
    public void SerializationRoundtrip_Works(Theme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Theme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
