using System;
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

    [Fact]
    public void Url_Works()
    {
        UsageEventRetrieveParams parameters = new() { EventID = "event_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/events/event_id"), url);
    }
}
