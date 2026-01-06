using System;
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

    [Fact]
    public void Url_Works()
    {
        DisputeRetrieveParams parameters = new() { DisputeID = "dispute_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/disputes/dispute_id"), url);
    }
}
