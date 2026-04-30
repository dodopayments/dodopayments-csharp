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
            IntegrationType = EntitlementListParamsIntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
        };

        ApiEnum<string, EntitlementListParamsIntegrationType> expectedIntegrationType =
            EntitlementListParamsIntegrationType.Discord;
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
            IntegrationType = EntitlementListParamsIntegrationType.Discord,
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
            IntegrationType = EntitlementListParamsIntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
        };

        EntitlementListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntitlementListParamsIntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListParamsIntegrationType.Discord)]
    [InlineData(EntitlementListParamsIntegrationType.Telegram)]
    [InlineData(EntitlementListParamsIntegrationType.GitHub)]
    [InlineData(EntitlementListParamsIntegrationType.Figma)]
    [InlineData(EntitlementListParamsIntegrationType.Framer)]
    [InlineData(EntitlementListParamsIntegrationType.Notion)]
    [InlineData(EntitlementListParamsIntegrationType.DigitalFiles)]
    [InlineData(EntitlementListParamsIntegrationType.LicenseKey)]
    public void Validation_Works(EntitlementListParamsIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListParamsIntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListParamsIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListParamsIntegrationType.Discord)]
    [InlineData(EntitlementListParamsIntegrationType.Telegram)]
    [InlineData(EntitlementListParamsIntegrationType.GitHub)]
    [InlineData(EntitlementListParamsIntegrationType.Figma)]
    [InlineData(EntitlementListParamsIntegrationType.Framer)]
    [InlineData(EntitlementListParamsIntegrationType.Notion)]
    [InlineData(EntitlementListParamsIntegrationType.DigitalFiles)]
    [InlineData(EntitlementListParamsIntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(EntitlementListParamsIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListParamsIntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListParamsIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListParamsIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListParamsIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
