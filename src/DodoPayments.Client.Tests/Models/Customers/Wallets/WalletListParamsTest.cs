using System;
using DodoPayments.Client.Models.Customers.Wallets;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets;

public class WalletListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WalletListParams { CustomerID = "customer_id" };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        WalletListParams parameters = new() { CustomerID = "customer_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/customers/customer_id/wallets"), url);
    }
}
