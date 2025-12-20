using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class DisputeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DisputeRetrieveParams { DisputeID = "dispute_id" };

        string expectedDisputeID = "dispute_id";

        Assert.Equal(expectedDisputeID, parameters.DisputeID);
    }
}
