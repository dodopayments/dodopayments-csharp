using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Tests.Models.Entitlements.Grants;

public class GrantListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GrantListParams
        {
            ID = "id",
            CustomerID = "customer_id",
            IntegrationType = IntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Pending,
        };

        string expectedID = "id";
        string expectedCustomerID = "customer_id";
        ApiEnum<string, IntegrationType> expectedIntegrationType = IntegrationType.Discord;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        ApiEnum<string, Status> expectedStatus = Status.Pending;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedIntegrationType, parameters.IntegrationType);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GrantListParams { ID = "id" };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.IntegrationType);
        Assert.False(parameters.RawQueryData.ContainsKey("integration_type"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GrantListParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            IntegrationType = null,
            PageNumber = null,
            PageSize = null,
            Status = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.IntegrationType);
        Assert.False(parameters.RawQueryData.ContainsKey("integration_type"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        GrantListParams parameters = new()
        {
            ID = "id",
            CustomerID = "customer_id",
            IntegrationType = IntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Pending,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/entitlements/id/grants?customer_id=customer_id&integration_type=discord&page_number=0&page_size=0&status=Pending"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GrantListParams
        {
            ID = "id",
            CustomerID = "customer_id",
            IntegrationType = IntegrationType.Discord,
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Pending,
        };

        GrantListParams copied = new(parameters);

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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Revoked)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Revoked)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
