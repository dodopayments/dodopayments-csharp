using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterAggregation { Type = Type.Count, Key = "key" };

        ApiEnum<string, Type> expectedType = Type.Count;
        string expectedKey = "key";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedKey, model.Key);
    }
}
