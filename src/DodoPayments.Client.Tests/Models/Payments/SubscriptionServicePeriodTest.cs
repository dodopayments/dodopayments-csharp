using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class SubscriptionServicePeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionServicePeriod
        {
            EndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProrationFactor = "1",
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        DateTimeOffset expectedEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProrationFactor = "1";
        DateTimeOffset expectedStartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedEndsAt, model.EndsAt);
        Assert.Equal(expectedProrationFactor, model.ProrationFactor);
        Assert.Equal(expectedStartsAt, model.StartsAt);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionServicePeriod
        {
            EndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProrationFactor = "1",
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionServicePeriod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionServicePeriod
        {
            EndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProrationFactor = "1",
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionServicePeriod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProrationFactor = "1";
        DateTimeOffset expectedStartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedEndsAt, deserialized.EndsAt);
        Assert.Equal(expectedProrationFactor, deserialized.ProrationFactor);
        Assert.Equal(expectedStartsAt, deserialized.StartsAt);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionServicePeriod
        {
            EndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProrationFactor = "1",
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionServicePeriod
        {
            EndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProrationFactor = "1",
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        SubscriptionServicePeriod copied = new(model);

        Assert.Equal(model, copied);
    }
}
