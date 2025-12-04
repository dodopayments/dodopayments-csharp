using System;
using System.Collections.Generic;
using System.Text.Json;
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
            Metadata = new Dictionary<string, EventInputMetadata>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCustomerID = "customer_id";
        string expectedEventID = "event_id";
        string expectedEventName = "event_name";
        Dictionary<string, EventInputMetadata> expectedMetadata = new() { { "foo", "string" } };
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Metadata = new Dictionary<string, EventInputMetadata>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EventInput>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Metadata = new Dictionary<string, EventInputMetadata>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EventInput>(json);
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customer_id";
        string expectedEventID = "event_id";
        string expectedEventName = "event_name";
        Dictionary<string, EventInputMetadata> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventName, deserialized.EventName);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Metadata = new Dictionary<string, EventInputMetadata>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",

            Metadata = null,
            Timestamp = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Timestamp);
        Assert.True(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventInput
        {
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",

            Metadata = null,
            Timestamp = null,
        };

        model.Validate();
    }
}
