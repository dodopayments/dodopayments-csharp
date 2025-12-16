using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class EventInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Metadata = new Dictionary<string, MetadataModel>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCustomerID = "customer_id";
        string expectedEventID = "event_id";
        string expectedEventName = "event_name";
        Dictionary<string, MetadataModel> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }
}
