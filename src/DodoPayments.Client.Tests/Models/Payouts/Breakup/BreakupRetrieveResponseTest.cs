using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts.Breakup;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup;

public class BreakupRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BreakupRetrieveResponse { EventType = "event_type", Total = 0 };

        string expectedEventType = "event_type";
        long expectedTotal = 0;

        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BreakupRetrieveResponse { EventType = "event_type", Total = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BreakupRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BreakupRetrieveResponse { EventType = "event_type", Total = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BreakupRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventType = "event_type";
        long expectedTotal = 0;

        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BreakupRetrieveResponse { EventType = "event_type", Total = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BreakupRetrieveResponse { EventType = "event_type", Total = 0 };

        BreakupRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
