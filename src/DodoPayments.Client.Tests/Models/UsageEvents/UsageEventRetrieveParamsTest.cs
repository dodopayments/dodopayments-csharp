using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class UsageEventRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageEventRetrieveParams { EventID = "event_id" };

        string expectedEventID = "event_id";

        Assert.Equal(expectedEventID, parameters.EventID);
    }
}
