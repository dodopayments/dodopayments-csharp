using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceListEventsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListEventsResponse
        {
            Items =
            [
                new()
                {
                    Actor = "actor",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "event_id",
                    EventType = "event_type",
                    Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RowVersion = 0,
                    ActorEmail = "actor_email",
                },
            ],
        };

        List<InvoiceEvent> expectedItems =
        [
            new()
            {
                Actor = "actor",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventID = "event_id",
                EventType = "event_type",
                Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                RowVersion = 0,
                ActorEmail = "actor_email",
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
        var model = new InvoiceListEventsResponse
        {
            Items =
            [
                new()
                {
                    Actor = "actor",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "event_id",
                    EventType = "event_type",
                    Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RowVersion = 0,
                    ActorEmail = "actor_email",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListEventsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListEventsResponse
        {
            Items =
            [
                new()
                {
                    Actor = "actor",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "event_id",
                    EventType = "event_type",
                    Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RowVersion = 0,
                    ActorEmail = "actor_email",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListEventsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<InvoiceEvent> expectedItems =
        [
            new()
            {
                Actor = "actor",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventID = "event_id",
                EventType = "event_type",
                Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                RowVersion = 0,
                ActorEmail = "actor_email",
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
        var model = new InvoiceListEventsResponse
        {
            Items =
            [
                new()
                {
                    Actor = "actor",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "event_id",
                    EventType = "event_type",
                    Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RowVersion = 0,
                    ActorEmail = "actor_email",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceListEventsResponse
        {
            Items =
            [
                new()
                {
                    Actor = "actor",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventID = "event_id",
                    EventType = "event_type",
                    Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RowVersion = 0,
                    ActorEmail = "actor_email",
                },
            ],
        };

        InvoiceListEventsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
