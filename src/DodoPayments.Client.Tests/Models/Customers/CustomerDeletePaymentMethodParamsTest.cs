using System;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerDeletePaymentMethodParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerDeletePaymentMethodParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
            PaymentMethodID = "payment_method_id",
        };

        string expectedCustomerID = "cus_TV52uJWWXt2yIoBBxpjaa";
        string expectedPaymentMethodID = "payment_method_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPaymentMethodID, parameters.PaymentMethodID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerDeletePaymentMethodParams parameters = new()
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
            PaymentMethodID = "payment_method_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/customers/cus_TV52uJWWXt2yIoBBxpjaa/payment-methods/payment_method_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerDeletePaymentMethodParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
            PaymentMethodID = "payment_method_id",
        };

        CustomerDeletePaymentMethodParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
