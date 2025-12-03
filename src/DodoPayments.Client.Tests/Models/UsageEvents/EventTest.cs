using System;
using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Event>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Event>(json);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        string expectedCustomerID = "customer_id";
        string expectedEventID = "event_id";
        string expectedEventName = "event_name";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, Metadata> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventName, deserialized.EventName);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            BusinessID = "business_id",
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            BusinessID = "business_id",
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Event
        {
            BusinessID = "business_id",
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            BusinessID = "business_id",
            CustomerID = "customer_id",
            EventID = "event_id",
            EventName = "event_name",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Metadata = null,
        };

        model.Validate();
    }
}
