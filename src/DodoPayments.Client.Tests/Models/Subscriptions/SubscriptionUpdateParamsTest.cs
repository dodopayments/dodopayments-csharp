using System;
using System.Text.Json;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class DisableOnDemandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedNextBillingDate, model.NextBillingDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisableOnDemand>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisableOnDemand>(element);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedNextBillingDate, deserialized.NextBillingDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}
