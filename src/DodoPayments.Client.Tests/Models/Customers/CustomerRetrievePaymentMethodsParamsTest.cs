using System;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerRetrievePaymentMethodsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        string expectedCustomerID = "cus_TV52uJWWXt2yIoBBxpjaa";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerRetrievePaymentMethodsParams parameters = new()
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/customers/cus_TV52uJWWXt2yIoBBxpjaa/payment-methods"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        CustomerRetrievePaymentMethodsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
