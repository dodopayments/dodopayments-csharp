using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerRetrievePaymentMethodsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams { CustomerID = "customer_id" };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }
}
