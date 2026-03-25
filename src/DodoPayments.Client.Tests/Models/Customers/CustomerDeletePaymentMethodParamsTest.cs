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
            CustomerID = "customer_id",
            PaymentMethodID = "payment_method_id",
        };

        string expectedCustomerID = "customer_id";
        string expectedPaymentMethodID = "payment_method_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPaymentMethodID, parameters.PaymentMethodID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerDeletePaymentMethodParams parameters = new()
        {
            CustomerID = "customer_id",
            PaymentMethodID = "payment_method_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/customers/customer_id/payment-methods/payment_method_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerDeletePaymentMethodParams
        {
            CustomerID = "customer_id",
            PaymentMethodID = "payment_method_id",
        };

        CustomerDeletePaymentMethodParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
