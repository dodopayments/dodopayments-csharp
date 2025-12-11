using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Misc;

public class TaxCategoryTest : TestBase
{
    [Theory]
    [InlineData(TaxCategory.DigitalProducts)]
    [InlineData(TaxCategory.Saas)]
    [InlineData(TaxCategory.EBook)]
    [InlineData(TaxCategory.Edtech)]
    public void Validation_Works(TaxCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TaxCategory.DigitalProducts)]
    [InlineData(TaxCategory.Saas)]
    [InlineData(TaxCategory.EBook)]
    [InlineData(TaxCategory.Edtech)]
    public void SerializationRoundtrip_Works(TaxCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
