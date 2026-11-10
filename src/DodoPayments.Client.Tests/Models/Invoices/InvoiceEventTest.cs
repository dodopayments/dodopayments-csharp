using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
            ActorEmail = "actor_email",
        };

        string expectedActor = "actor";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventID = "event_id";
        string expectedEventType = "event_type";
        JsonElement expectedPayload = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedRowVersion = 0;
        string expectedActorEmail = "actor_email";

        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.True(JsonElement.DeepEquals(expectedPayload, model.Payload));
        Assert.Equal(expectedRowVersion, model.RowVersion);
        Assert.Equal(expectedActorEmail, model.ActorEmail);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
            ActorEmail = "actor_email",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
            ActorEmail = "actor_email",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActor = "actor";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventID = "event_id";
        string expectedEventType = "event_type";
        JsonElement expectedPayload = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedRowVersion = 0;
        string expectedActorEmail = "actor_email";

        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.True(JsonElement.DeepEquals(expectedPayload, deserialized.Payload));
        Assert.Equal(expectedRowVersion, deserialized.RowVersion);
        Assert.Equal(expectedActorEmail, deserialized.ActorEmail);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
            ActorEmail = "actor_email",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
        };

        Assert.Null(model.ActorEmail);
        Assert.False(model.RawData.ContainsKey("actor_email"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,

            ActorEmail = null,
        };

        Assert.Null(model.ActorEmail);
        Assert.True(model.RawData.ContainsKey("actor_email"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,

            ActorEmail = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceEvent
        {
            Actor = "actor",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventID = "event_id",
            EventType = "event_type",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
            RowVersion = 0,
            ActorEmail = "actor_email",
        };

        InvoiceEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
