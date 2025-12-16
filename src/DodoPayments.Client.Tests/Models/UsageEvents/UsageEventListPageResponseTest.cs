using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class UsageEventListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageEventListPageResponse
        {
            Items =
            [
                new()
                {
                    BusinessID = "business_id",
                    CustomerID = "customer_id",
                    EventID = "event_id",
                    EventName = "event_name",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, Metadata>() { { "foo", "string" } },
                },
            ],
        };

        List<Event> expectedItems =
        [
            new()
            {
                BusinessID = "business_id",
                CustomerID = "customer_id",
                EventID = "event_id",
                EventName = "event_name",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, Metadata>() { { "foo", "string" } },
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}
