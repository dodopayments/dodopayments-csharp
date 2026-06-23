using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Tests.Models.Products.LocalizedPrices;

public class PricingModeTest : TestBase
{
    [Theory]
    [InlineData(PricingMode.ByCurrency)]
    [InlineData(PricingMode.ByCountry)]
    public void Validation_Works(PricingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingMode.ByCurrency)]
    [InlineData(PricingMode.ByCountry)]
    public void SerializationRoundtrip_Works(PricingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
