using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementListParams
        {
            IntegrationType = IntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
        };

        ApiEnum<string, IntegrationType> expectedIntegrationType = IntegrationType.Discord;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedIntegrationType, parameters.IntegrationType);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementListParams { };

        Assert.Null(parameters.IntegrationType);
        Assert.False(parameters.RawQueryData.ContainsKey("integration_type"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntitlementListParams
        {
            // Null should be interpreted as omitted for these properties
            IntegrationType = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.IntegrationType);
        Assert.False(parameters.RawQueryData.ContainsKey("integration_type"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementListParams parameters = new()
        {
            IntegrationType = IntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/entitlements?integration_type=discord&page_number=0&page_size=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementListParams
        {
            IntegrationType = IntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
        };

        EntitlementListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(IntegrationType.Discord)]
    [InlineData(IntegrationType.Telegram)]
    [InlineData(IntegrationType.GitHub)]
    [InlineData(IntegrationType.Figma)]
    [InlineData(IntegrationType.Framer)]
    [InlineData(IntegrationType.Notion)]
    [InlineData(IntegrationType.DigitalFiles)]
    [InlineData(IntegrationType.LicenseKey)]
    public void Validation_Works(IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationType.Discord)]
    [InlineData(IntegrationType.Telegram)]
    [InlineData(IntegrationType.GitHub)]
    [InlineData(IntegrationType.Figma)]
    [InlineData(IntegrationType.Framer)]
    [InlineData(IntegrationType.Notion)]
    [InlineData(IntegrationType.DigitalFiles)]
    [InlineData(IntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
