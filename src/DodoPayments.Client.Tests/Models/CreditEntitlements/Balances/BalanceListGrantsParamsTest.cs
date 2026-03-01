using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceListGrantsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceListGrantsParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Active,
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedCreditEntitlementID, parameters.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceListGrantsParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
        };

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
        var parameters = new BalanceListGrantsParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",

            // Null should be interpreted as omitted for these properties
            PageNumber = null,
            PageSize = null,
            Status = null,
        };

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
        BalanceListGrantsParams parameters = new()
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Active,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/credit-entitlements/credit_entitlement_id/balances/customer_id/grants?page_number=0&page_size=0&status=active"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceListGrantsParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            PageNumber = 0,
            PageSize = 0,
            Status = Status.Active,
        };

        BalanceListGrantsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Depleted)]
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
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Depleted)]
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
