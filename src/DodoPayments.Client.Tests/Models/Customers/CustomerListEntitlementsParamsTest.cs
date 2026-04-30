using System;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerListEntitlementsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerListEntitlementsParams { CustomerID = "customer_id" };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerListEntitlementsParams parameters = new() { CustomerID = "customer_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/customers/customer_id/entitlements"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerListEntitlementsParams { CustomerID = "customer_id" };

        CustomerListEntitlementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
