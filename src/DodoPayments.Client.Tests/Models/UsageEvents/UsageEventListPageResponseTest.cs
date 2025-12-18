using System;
using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageEventListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageEventListPageResponse>(element);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }
}
