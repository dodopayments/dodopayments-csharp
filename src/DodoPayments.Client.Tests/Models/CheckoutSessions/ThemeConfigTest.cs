using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class ThemeConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThemeConfig
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

        ThemeModeConfig expectedDark = new()
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
        };
        string expectedFontPrimaryUrl = "font_primary_url";
        string expectedFontSecondaryUrl = "font_secondary_url";
        ApiEnum<string, FontSize> expectedFontSize = FontSize.Xs;
        ApiEnum<string, FontWeight> expectedFontWeight = FontWeight.Normal;
        ThemeModeConfig expectedLight = new()
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
        };
        string expectedPayButtonText = "pay_button_text";
        string expectedRadius = "radius";

        Assert.Equal(expectedDark, model.Dark);
        Assert.Equal(expectedFontPrimaryUrl, model.FontPrimaryUrl);
        Assert.Equal(expectedFontSecondaryUrl, model.FontSecondaryUrl);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.Equal(expectedFontWeight, model.FontWeight);
        Assert.Equal(expectedLight, model.Light);
        Assert.Equal(expectedPayButtonText, model.PayButtonText);
        Assert.Equal(expectedRadius, model.Radius);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThemeConfig
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThemeConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThemeConfig
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThemeConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ThemeModeConfig expectedDark = new()
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
        };
        string expectedFontPrimaryUrl = "font_primary_url";
        string expectedFontSecondaryUrl = "font_secondary_url";
        ApiEnum<string, FontSize> expectedFontSize = FontSize.Xs;
        ApiEnum<string, FontWeight> expectedFontWeight = FontWeight.Normal;
        ThemeModeConfig expectedLight = new()
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
        };
        string expectedPayButtonText = "pay_button_text";
        string expectedRadius = "radius";

        Assert.Equal(expectedDark, deserialized.Dark);
        Assert.Equal(expectedFontPrimaryUrl, deserialized.FontPrimaryUrl);
        Assert.Equal(expectedFontSecondaryUrl, deserialized.FontSecondaryUrl);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.Equal(expectedFontWeight, deserialized.FontWeight);
        Assert.Equal(expectedLight, deserialized.Light);
        Assert.Equal(expectedPayButtonText, deserialized.PayButtonText);
        Assert.Equal(expectedRadius, deserialized.Radius);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThemeConfig
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThemeConfig { };

        Assert.Null(model.Dark);
        Assert.False(model.RawData.ContainsKey("dark"));
        Assert.Null(model.FontPrimaryUrl);
        Assert.False(model.RawData.ContainsKey("font_primary_url"));
        Assert.Null(model.FontSecondaryUrl);
        Assert.False(model.RawData.ContainsKey("font_secondary_url"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.FontWeight);
        Assert.False(model.RawData.ContainsKey("font_weight"));
        Assert.Null(model.Light);
        Assert.False(model.RawData.ContainsKey("light"));
        Assert.Null(model.PayButtonText);
        Assert.False(model.RawData.ContainsKey("pay_button_text"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThemeConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ThemeConfig
        {
            Dark = null,
            FontPrimaryUrl = null,
            FontSecondaryUrl = null,
            FontSize = null,
            FontWeight = null,
            Light = null,
            PayButtonText = null,
            Radius = null,
        };

        Assert.Null(model.Dark);
        Assert.True(model.RawData.ContainsKey("dark"));
        Assert.Null(model.FontPrimaryUrl);
        Assert.True(model.RawData.ContainsKey("font_primary_url"));
        Assert.Null(model.FontSecondaryUrl);
        Assert.True(model.RawData.ContainsKey("font_secondary_url"));
        Assert.Null(model.FontSize);
        Assert.True(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.FontWeight);
        Assert.True(model.RawData.ContainsKey("font_weight"));
        Assert.Null(model.Light);
        Assert.True(model.RawData.ContainsKey("light"));
        Assert.Null(model.PayButtonText);
        Assert.True(model.RawData.ContainsKey("pay_button_text"));
        Assert.Null(model.Radius);
        Assert.True(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThemeConfig
        {
            Dark = null,
            FontPrimaryUrl = null,
            FontSecondaryUrl = null,
            FontSize = null,
            FontWeight = null,
            Light = null,
            PayButtonText = null,
            Radius = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThemeConfig
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

        ThemeConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FontSizeTest : TestBase
{
    [Theory]
    [InlineData(FontSize.Xs)]
    [InlineData(FontSize.Sm)]
    [InlineData(FontSize.Md)]
    [InlineData(FontSize.Lg)]
    [InlineData(FontSize.Xl)]
    [InlineData(FontSize.V2xl)]
    public void Validation_Works(FontSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontSize> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FontSize.Xs)]
    [InlineData(FontSize.Sm)]
    [InlineData(FontSize.Md)]
    [InlineData(FontSize.Lg)]
    [InlineData(FontSize.Xl)]
    [InlineData(FontSize.V2xl)]
    public void SerializationRoundtrip_Works(FontSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontSize> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FontWeightTest : TestBase
{
    [Theory]
    [InlineData(FontWeight.Normal)]
    [InlineData(FontWeight.Medium)]
    [InlineData(FontWeight.Bold)]
    [InlineData(FontWeight.ExtraBold)]
    public void Validation_Works(FontWeight rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontWeight> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FontWeight.Normal)]
    [InlineData(FontWeight.Medium)]
    [InlineData(FontWeight.Bold)]
    [InlineData(FontWeight.ExtraBold)]
    public void SerializationRoundtrip_Works(FontWeight rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FontWeight> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FontWeight>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
