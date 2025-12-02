using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerPortalSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerPortalSession { Link = "link" };

        string expectedLink = "link";

        Assert.Equal(expectedLink, model.Link);
    }
}
