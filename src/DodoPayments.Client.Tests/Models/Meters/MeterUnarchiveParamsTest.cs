using System;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterUnarchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterUnarchiveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MeterUnarchiveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/meters/id/unarchive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MeterUnarchiveParams { ID = "id" };

        MeterUnarchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
