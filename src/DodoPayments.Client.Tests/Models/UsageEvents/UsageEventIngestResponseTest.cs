using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.UsageEvents;

namespace DodoPayments.Client.Tests.Models.UsageEvents;

public class UsageEventIngestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageEventIngestResponse { IngestedCount = 0 };

        long expectedIngestedCount = 0;

        Assert.Equal(expectedIngestedCount, model.IngestedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageEventIngestResponse { IngestedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageEventIngestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageEventIngestResponse { IngestedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageEventIngestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedIngestedCount = 0;

        Assert.Equal(expectedIngestedCount, deserialized.IngestedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageEventIngestResponse { IngestedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageEventIngestResponse { IngestedCount = 0 };

        UsageEventIngestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
