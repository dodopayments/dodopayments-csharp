using System;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerListParams
        {
            Email = "email",
            PageNumber = 0,
            PageSize = 0,
        };

        string expectedEmail = "email";
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerListParams { };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerListParams
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerListParams parameters = new()
        {
            Email = "email",
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/customers?email=email&page_number=0&page_size=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerListParams
        {
            Email = "email",
            PageNumber = 0,
            PageSize = 0,
        };

        CustomerListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
