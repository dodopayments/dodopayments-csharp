using System;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailRetrieveBodyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EmailRetrieveBodyParams
        {
            CustomerID = "customer_id",
            EmailLogID = "email_log_id",
        };

        string expectedCustomerID = "customer_id";
        string expectedEmailLogID = "email_log_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedEmailLogID, parameters.EmailLogID);
    }

    [Fact]
    public void Url_Works()
    {
        EmailRetrieveBodyParams parameters = new()
        {
            CustomerID = "customer_id",
            EmailLogID = "email_log_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/customers/customer_id/emails/email_log_id/body"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EmailRetrieveBodyParams
        {
            CustomerID = "customer_id",
            EmailLogID = "email_log_id",
        };

        EmailRetrieveBodyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
