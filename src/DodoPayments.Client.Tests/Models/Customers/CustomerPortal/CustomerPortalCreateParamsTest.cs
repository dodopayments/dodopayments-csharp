using System;
using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Tests.Models.Customers.CustomerPortal;

public class CustomerPortalCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerPortalCreateParams
        {
            CustomerID = "customer_id",
            ReturnUrl = "return_url",
            SendEmail = true,
        };

        string expectedCustomerID = "customer_id";
        string expectedReturnUrl = "return_url";
        bool expectedSendEmail = true;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedReturnUrl, parameters.ReturnUrl);
        Assert.Equal(expectedSendEmail, parameters.SendEmail);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerPortalCreateParams { CustomerID = "customer_id" };

        Assert.Null(parameters.ReturnUrl);
        Assert.False(parameters.RawQueryData.ContainsKey("return_url"));
        Assert.Null(parameters.SendEmail);
        Assert.False(parameters.RawQueryData.ContainsKey("send_email"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerPortalCreateParams
        {
            CustomerID = "customer_id",

            // Null should be interpreted as omitted for these properties
            ReturnUrl = null,
            SendEmail = null,
        };

        Assert.Null(parameters.ReturnUrl);
        Assert.False(parameters.RawQueryData.ContainsKey("return_url"));
        Assert.Null(parameters.SendEmail);
        Assert.False(parameters.RawQueryData.ContainsKey("send_email"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerPortalCreateParams parameters = new()
        {
            CustomerID = "customer_id",
            ReturnUrl = "return_url",
            SendEmail = true,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/customers/customer_id/customer-portal/session?return_url=return_url&send_email=true"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerPortalCreateParams
        {
            CustomerID = "customer_id",
            ReturnUrl = "return_url",
            SendEmail = true,
        };

        CustomerPortalCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
