using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class UsageEventIngestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageEventIngestResponse { IngestedCount = 0 };

        long expectedIngestedCount = 0;

        Assert.Equal(expectedIngestedCount, model.IngestedCount);
    }
}
