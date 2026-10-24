using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Entitlements.Translations;

public class EntitlementTranslationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationMessage = "activation_message",
            Description = "description",
            Instructions = "instructions",
            Name = "name",
        };

        ApiEnum<string, Locale> expectedLocale = Locale.Ar;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedActivationMessage = "activation_message";
        string expectedDescription = "description";
        string expectedInstructions = "instructions";
        string expectedName = "name";

        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedActivationMessage, model.ActivationMessage);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationMessage = "activation_message",
            Description = "description",
            Instructions = "instructions",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementTranslation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationMessage = "activation_message",
            Description = "description",
            Instructions = "instructions",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementTranslation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Locale> expectedLocale = Locale.Ar;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedActivationMessage = "activation_message";
        string expectedDescription = "description";
        string expectedInstructions = "instructions";
        string expectedName = "name";

        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedActivationMessage, deserialized.ActivationMessage);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationMessage = "activation_message",
            Description = "description",
            Instructions = "instructions",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ActivationMessage);
        Assert.False(model.RawData.ContainsKey("activation_message"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActivationMessage = null,
            Description = null,
            Instructions = null,
            Name = null,
        };

        Assert.Null(model.ActivationMessage);
        Assert.True(model.RawData.ContainsKey("activation_message"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActivationMessage = null,
            Description = null,
            Instructions = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationMessage = "activation_message",
            Description = "description",
            Instructions = "instructions",
            Name = "name",
        };

        EntitlementTranslation copied = new(model);

        Assert.Equal(model, copied);
    }
}
