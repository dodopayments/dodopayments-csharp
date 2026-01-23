using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

public class LicenseKeyDurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyDuration { Count = 0, Interval = TimeInterval.Day };

        int expectedCount = 0;
        ApiEnum<string, TimeInterval> expectedInterval = TimeInterval.Day;

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedInterval, model.Interval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyDuration { Count = 0, Interval = TimeInterval.Day };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyDuration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyDuration { Count = 0, Interval = TimeInterval.Day };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyDuration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedCount = 0;
        ApiEnum<string, TimeInterval> expectedInterval = TimeInterval.Day;

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedInterval, deserialized.Interval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyDuration { Count = 0, Interval = TimeInterval.Day };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseKeyDuration { Count = 0, Interval = TimeInterval.Day };

        LicenseKeyDuration copied = new(model);

        Assert.Equal(model, copied);
    }
}
