using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            BusinessID = "business_id",
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, Metadata>() { { "foo", "string" } },
        };

        string expectedBusinessID = "business_id";
        string expectedCustomerID = "customer_id";
        string expectedEventID = "event_id";
        string expectedEventName = "event_name";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, Metadata> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }
}
