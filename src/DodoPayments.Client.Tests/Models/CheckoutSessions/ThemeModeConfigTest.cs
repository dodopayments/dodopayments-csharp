using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class ThemeModeConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThemeModeConfig
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

        string expectedBgPrimary = "bg_primary";
        string expectedBgSecondary = "bg_secondary";
        string expectedBorderPrimary = "border_primary";
        string expectedBorderSecondary = "border_secondary";
        string expectedButtonPrimary = "button_primary";
        string expectedButtonPrimaryHover = "button_primary_hover";
        string expectedButtonSecondary = "button_secondary";
        string expectedButtonSecondaryHover = "button_secondary_hover";
        string expectedButtonTextPrimary = "button_text_primary";
        string expectedButtonTextSecondary = "button_text_secondary";
        string expectedInputFocusBorder = "input_focus_border";
        string expectedTextError = "text_error";
        string expectedTextPlaceholder = "text_placeholder";
        string expectedTextPrimary = "text_primary";
        string expectedTextSecondary = "text_secondary";
        string expectedTextSuccess = "text_success";

        Assert.Equal(expectedBgPrimary, model.BgPrimary);
        Assert.Equal(expectedBgSecondary, model.BgSecondary);
        Assert.Equal(expectedBorderPrimary, model.BorderPrimary);
        Assert.Equal(expectedBorderSecondary, model.BorderSecondary);
        Assert.Equal(expectedButtonPrimary, model.ButtonPrimary);
        Assert.Equal(expectedButtonPrimaryHover, model.ButtonPrimaryHover);
        Assert.Equal(expectedButtonSecondary, model.ButtonSecondary);
        Assert.Equal(expectedButtonSecondaryHover, model.ButtonSecondaryHover);
        Assert.Equal(expectedButtonTextPrimary, model.ButtonTextPrimary);
        Assert.Equal(expectedButtonTextSecondary, model.ButtonTextSecondary);
        Assert.Equal(expectedInputFocusBorder, model.InputFocusBorder);
        Assert.Equal(expectedTextError, model.TextError);
        Assert.Equal(expectedTextPlaceholder, model.TextPlaceholder);
        Assert.Equal(expectedTextPrimary, model.TextPrimary);
        Assert.Equal(expectedTextSecondary, model.TextSecondary);
        Assert.Equal(expectedTextSuccess, model.TextSuccess);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThemeModeConfig
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThemeModeConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThemeModeConfig
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThemeModeConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBgPrimary = "bg_primary";
        string expectedBgSecondary = "bg_secondary";
        string expectedBorderPrimary = "border_primary";
        string expectedBorderSecondary = "border_secondary";
        string expectedButtonPrimary = "button_primary";
        string expectedButtonPrimaryHover = "button_primary_hover";
        string expectedButtonSecondary = "button_secondary";
        string expectedButtonSecondaryHover = "button_secondary_hover";
        string expectedButtonTextPrimary = "button_text_primary";
        string expectedButtonTextSecondary = "button_text_secondary";
        string expectedInputFocusBorder = "input_focus_border";
        string expectedTextError = "text_error";
        string expectedTextPlaceholder = "text_placeholder";
        string expectedTextPrimary = "text_primary";
        string expectedTextSecondary = "text_secondary";
        string expectedTextSuccess = "text_success";

        Assert.Equal(expectedBgPrimary, deserialized.BgPrimary);
        Assert.Equal(expectedBgSecondary, deserialized.BgSecondary);
        Assert.Equal(expectedBorderPrimary, deserialized.BorderPrimary);
        Assert.Equal(expectedBorderSecondary, deserialized.BorderSecondary);
        Assert.Equal(expectedButtonPrimary, deserialized.ButtonPrimary);
        Assert.Equal(expectedButtonPrimaryHover, deserialized.ButtonPrimaryHover);
        Assert.Equal(expectedButtonSecondary, deserialized.ButtonSecondary);
        Assert.Equal(expectedButtonSecondaryHover, deserialized.ButtonSecondaryHover);
        Assert.Equal(expectedButtonTextPrimary, deserialized.ButtonTextPrimary);
        Assert.Equal(expectedButtonTextSecondary, deserialized.ButtonTextSecondary);
        Assert.Equal(expectedInputFocusBorder, deserialized.InputFocusBorder);
        Assert.Equal(expectedTextError, deserialized.TextError);
        Assert.Equal(expectedTextPlaceholder, deserialized.TextPlaceholder);
        Assert.Equal(expectedTextPrimary, deserialized.TextPrimary);
        Assert.Equal(expectedTextSecondary, deserialized.TextSecondary);
        Assert.Equal(expectedTextSuccess, deserialized.TextSuccess);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThemeModeConfig
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThemeModeConfig { };

        Assert.Null(model.BgPrimary);
        Assert.False(model.RawData.ContainsKey("bg_primary"));
        Assert.Null(model.BgSecondary);
        Assert.False(model.RawData.ContainsKey("bg_secondary"));
        Assert.Null(model.BorderPrimary);
        Assert.False(model.RawData.ContainsKey("border_primary"));
        Assert.Null(model.BorderSecondary);
        Assert.False(model.RawData.ContainsKey("border_secondary"));
        Assert.Null(model.ButtonPrimary);
        Assert.False(model.RawData.ContainsKey("button_primary"));
        Assert.Null(model.ButtonPrimaryHover);
        Assert.False(model.RawData.ContainsKey("button_primary_hover"));
        Assert.Null(model.ButtonSecondary);
        Assert.False(model.RawData.ContainsKey("button_secondary"));
        Assert.Null(model.ButtonSecondaryHover);
        Assert.False(model.RawData.ContainsKey("button_secondary_hover"));
        Assert.Null(model.ButtonTextPrimary);
        Assert.False(model.RawData.ContainsKey("button_text_primary"));
        Assert.Null(model.ButtonTextSecondary);
        Assert.False(model.RawData.ContainsKey("button_text_secondary"));
        Assert.Null(model.InputFocusBorder);
        Assert.False(model.RawData.ContainsKey("input_focus_border"));
        Assert.Null(model.TextError);
        Assert.False(model.RawData.ContainsKey("text_error"));
        Assert.Null(model.TextPlaceholder);
        Assert.False(model.RawData.ContainsKey("text_placeholder"));
        Assert.Null(model.TextPrimary);
        Assert.False(model.RawData.ContainsKey("text_primary"));
        Assert.Null(model.TextSecondary);
        Assert.False(model.RawData.ContainsKey("text_secondary"));
        Assert.Null(model.TextSuccess);
        Assert.False(model.RawData.ContainsKey("text_success"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThemeModeConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ThemeModeConfig
        {
            BgPrimary = null,
            BgSecondary = null,
            BorderPrimary = null,
            BorderSecondary = null,
            ButtonPrimary = null,
            ButtonPrimaryHover = null,
            ButtonSecondary = null,
            ButtonSecondaryHover = null,
            ButtonTextPrimary = null,
            ButtonTextSecondary = null,
            InputFocusBorder = null,
            TextError = null,
            TextPlaceholder = null,
            TextPrimary = null,
            TextSecondary = null,
            TextSuccess = null,
        };

        Assert.Null(model.BgPrimary);
        Assert.True(model.RawData.ContainsKey("bg_primary"));
        Assert.Null(model.BgSecondary);
        Assert.True(model.RawData.ContainsKey("bg_secondary"));
        Assert.Null(model.BorderPrimary);
        Assert.True(model.RawData.ContainsKey("border_primary"));
        Assert.Null(model.BorderSecondary);
        Assert.True(model.RawData.ContainsKey("border_secondary"));
        Assert.Null(model.ButtonPrimary);
        Assert.True(model.RawData.ContainsKey("button_primary"));
        Assert.Null(model.ButtonPrimaryHover);
        Assert.True(model.RawData.ContainsKey("button_primary_hover"));
        Assert.Null(model.ButtonSecondary);
        Assert.True(model.RawData.ContainsKey("button_secondary"));
        Assert.Null(model.ButtonSecondaryHover);
        Assert.True(model.RawData.ContainsKey("button_secondary_hover"));
        Assert.Null(model.ButtonTextPrimary);
        Assert.True(model.RawData.ContainsKey("button_text_primary"));
        Assert.Null(model.ButtonTextSecondary);
        Assert.True(model.RawData.ContainsKey("button_text_secondary"));
        Assert.Null(model.InputFocusBorder);
        Assert.True(model.RawData.ContainsKey("input_focus_border"));
        Assert.Null(model.TextError);
        Assert.True(model.RawData.ContainsKey("text_error"));
        Assert.Null(model.TextPlaceholder);
        Assert.True(model.RawData.ContainsKey("text_placeholder"));
        Assert.Null(model.TextPrimary);
        Assert.True(model.RawData.ContainsKey("text_primary"));
        Assert.Null(model.TextSecondary);
        Assert.True(model.RawData.ContainsKey("text_secondary"));
        Assert.Null(model.TextSuccess);
        Assert.True(model.RawData.ContainsKey("text_success"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThemeModeConfig
        {
            BgPrimary = null,
            BgSecondary = null,
            BorderPrimary = null,
            BorderSecondary = null,
            ButtonPrimary = null,
            ButtonPrimaryHover = null,
            ButtonSecondary = null,
            ButtonSecondaryHover = null,
            ButtonTextPrimary = null,
            ButtonTextSecondary = null,
            InputFocusBorder = null,
            TextError = null,
            TextPlaceholder = null,
            TextPrimary = null,
            TextSecondary = null,
            TextSuccess = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThemeModeConfig
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

        ThemeModeConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
