using System;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterArchiveParams { ID = "mtr_h5tgTWL55OyMO0L2Q9w9v" };

        string expectedID = "mtr_h5tgTWL55OyMO0L2Q9w9v";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MeterArchiveParams parameters = new() { ID = "mtr_h5tgTWL55OyMO0L2Q9w9v" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/meters/mtr_h5tgTWL55OyMO0L2Q9w9v"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MeterArchiveParams { ID = "mtr_h5tgTWL55OyMO0L2Q9w9v" };

        MeterArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
