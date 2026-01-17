using System;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterArchiveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MeterArchiveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/meters/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MeterArchiveParams { ID = "id" };

        MeterArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
