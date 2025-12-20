using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckoutSessionRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }
}
