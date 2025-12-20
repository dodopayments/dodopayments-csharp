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
}
