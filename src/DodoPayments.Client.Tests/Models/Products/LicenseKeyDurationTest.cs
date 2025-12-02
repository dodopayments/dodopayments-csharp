using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

public class LicenseKeyDurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyDuration { Count = 0, Interval = TimeInterval.Day };

        int expectedCount = 0;
        ApiEnum<string, TimeInterval> expectedInterval = TimeInterval.Day;

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedInterval, model.Interval);
    }
}
