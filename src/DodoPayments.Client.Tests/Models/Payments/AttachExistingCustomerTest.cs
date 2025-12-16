using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class AttachExistingCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachExistingCustomer { CustomerID = "customer_id" };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, model.CustomerID);
    }
}
