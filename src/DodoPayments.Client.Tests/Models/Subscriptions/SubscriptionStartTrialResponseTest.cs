using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionStartTrialResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionStartTrialResponse
        {
            InvoiceID = "invoice_id",
            SubscriptionID = "subscription_id",
            TrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedInvoiceID = "invoice_id";
        string expectedSubscriptionID = "subscription_id";
        DateTimeOffset expectedTrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTrialEndsAt, model.TrialEndsAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionStartTrialResponse
        {
            InvoiceID = "invoice_id",
            SubscriptionID = "subscription_id",
            TrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionStartTrialResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionStartTrialResponse
        {
            InvoiceID = "invoice_id",
            SubscriptionID = "subscription_id",
            TrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionStartTrialResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInvoiceID = "invoice_id";
        string expectedSubscriptionID = "subscription_id";
        DateTimeOffset expectedTrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTrialEndsAt, deserialized.TrialEndsAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionStartTrialResponse
        {
            InvoiceID = "invoice_id",
            SubscriptionID = "subscription_id",
            TrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionStartTrialResponse
        {
            InvoiceID = "invoice_id",
            SubscriptionID = "subscription_id",
            TrialEndsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionStartTrialResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
