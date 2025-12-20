using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class UsageEventIngestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageEventIngestParams
        {
            Events =
            [
                new()
                {
                    CustomerID = "customer_id",
                    EventID = "event_id",
                    EventName = "event_name",
                    Metadata = new Dictionary<string, EventInputMetadata>() { { "foo", "string" } },
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<EventInput> expectedEvents =
        [
            new()
            {
                CustomerID = "customer_id",
                EventID = "event_id",
                EventName = "event_name",
                Metadata = new Dictionary<string, EventInputMetadata>() { { "foo", "string" } },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
    }
}
