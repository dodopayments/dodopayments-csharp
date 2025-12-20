using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentListParams
        {
            BrandID = "brand_id",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Succeeded,
            SubscriptionID = "subscription_id",
        };

        string expectedBrandID = "brand_id";
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        ApiEnum<string, Status> expectedStatus = Status.Succeeded;
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentListParams { };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brand_id"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PaymentListParams
        {
            // Null should be interpreted as omitted for these properties
            BrandID = null,
            CreatedAtGte = null,
            CreatedAtLte = null,
            CustomerID = null,
            PageNumber = null,
            PageSize = null,
            Status = null,
            SubscriptionID = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brand_id"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Succeeded)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Processing)]
    [InlineData(Status.RequiresCustomerAction)]
    [InlineData(Status.RequiresMerchantAction)]
    [InlineData(Status.RequiresPaymentMethod)]
    [InlineData(Status.RequiresConfirmation)]
    [InlineData(Status.RequiresCapture)]
    [InlineData(Status.PartiallyCaptured)]
    [InlineData(Status.PartiallyCapturedAndCapturable)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Succeeded)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Processing)]
    [InlineData(Status.RequiresCustomerAction)]
    [InlineData(Status.RequiresMerchantAction)]
    [InlineData(Status.RequiresPaymentMethod)]
    [InlineData(Status.RequiresConfirmation)]
    [InlineData(Status.RequiresCapture)]
    [InlineData(Status.PartiallyCaptured)]
    [InlineData(Status.PartiallyCapturedAndCapturable)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
