using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CustomFieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        ApiEnum<string, FieldType> expectedFieldType = FieldType.Text;
        string expectedKey = "key";
        string expectedLabel = "label";
        List<string> expectedOptions = ["string"];
        string expectedPlaceholder = "placeholder";
        bool expectedRequired = true;

        Assert.Equal(expectedFieldType, model.FieldType);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLabel, model.Label);
        Assert.NotNull(model.Options);
        Assert.Equal(expectedOptions.Count, model.Options.Count);
        for (int i = 0; i < expectedOptions.Count; i++)
        {
            Assert.Equal(expectedOptions[i], model.Options[i]);
        }
        Assert.Equal(expectedPlaceholder, model.Placeholder);
        Assert.Equal(expectedRequired, model.Required);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomField>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomField>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FieldType> expectedFieldType = FieldType.Text;
        string expectedKey = "key";
        string expectedLabel = "label";
        List<string> expectedOptions = ["string"];
        string expectedPlaceholder = "placeholder";
        bool expectedRequired = true;

        Assert.Equal(expectedFieldType, deserialized.FieldType);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.NotNull(deserialized.Options);
        Assert.Equal(expectedOptions.Count, deserialized.Options.Count);
        for (int i = 0; i < expectedOptions.Count; i++)
        {
            Assert.Equal(expectedOptions[i], deserialized.Options[i]);
        }
        Assert.Equal(expectedPlaceholder, deserialized.Placeholder);
        Assert.Equal(expectedRequired, deserialized.Required);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
        };

        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",

            // Null should be interpreted as omitted for these properties
            Required = null,
        };

        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",

            // Null should be interpreted as omitted for these properties
            Required = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.Placeholder);
        Assert.False(model.RawData.ContainsKey("placeholder"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,

            Options = null,
            Placeholder = null,
        };

        Assert.Null(model.Options);
        Assert.True(model.RawData.ContainsKey("options"));
        Assert.Null(model.Placeholder);
        Assert.True(model.RawData.ContainsKey("placeholder"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Required = true,

            Options = null,
            Placeholder = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomField
        {
            FieldType = FieldType.Text,
            Key = "key",
            Label = "label",
            Options = ["string"],
            Placeholder = "placeholder",
            Required = true,
        };

        CustomField copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTypeTest : TestBase
{
    [Theory]
    [InlineData(FieldType.Text)]
    [InlineData(FieldType.Number)]
    [InlineData(FieldType.Email)]
    [InlineData(FieldType.Url)]
    [InlineData(FieldType.Date)]
    [InlineData(FieldType.Dropdown)]
    [InlineData(FieldType.Boolean)]
    public void Validation_Works(FieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FieldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FieldType.Text)]
    [InlineData(FieldType.Number)]
    [InlineData(FieldType.Email)]
    [InlineData(FieldType.Url)]
    [InlineData(FieldType.Date)]
    [InlineData(FieldType.Dropdown)]
    [InlineData(FieldType.Boolean)]
    public void SerializationRoundtrip_Works(FieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FieldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
