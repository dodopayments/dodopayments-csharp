using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Translations;

public class CreditEntitlementTranslationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Unit = "unit",
        };

        ApiEnum<string, Locale> expectedLocale = Locale.Ar;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedUnit = "unit";

        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUnit, model.Unit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Unit = "unit",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementTranslation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Unit = "unit",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementTranslation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Locale> expectedLocale = Locale.Ar;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedUnit = "unit";

        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUnit, deserialized.Unit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Unit = "unit",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Unit);
        Assert.False(model.RawData.ContainsKey("unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Name = null,
            Unit = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Unit);
        Assert.True(model.RawData.ContainsKey("unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Name = null,
            Unit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditEntitlementTranslation
        {
            Locale = Locale.Ar,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Unit = "unit",
        };

        CreditEntitlementTranslation copied = new(model);

        Assert.Equal(model, copied);
    }
}
