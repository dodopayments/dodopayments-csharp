using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdatePaymentMethodResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
        };

        string expectedClientSecret = "client_secret";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentID = "payment_id";
        string expectedPaymentLink = "payment_link";

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedExpiresOn, model.ExpiresOn);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionUpdatePaymentMethodResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionUpdatePaymentMethodResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientSecret = "client_secret";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentID = "payment_id";
        string expectedPaymentLink = "payment_link";

        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedExpiresOn, deserialized.ExpiresOn);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedPaymentLink, deserialized.PaymentLink);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse { };

        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.ExpiresOn);
        Assert.False(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PaymentLink);
        Assert.False(model.RawData.ContainsKey("payment_link"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = null,
            ExpiresOn = null,
            PaymentID = null,
            PaymentLink = null,
        };

        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.ExpiresOn);
        Assert.True(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PaymentLink);
        Assert.True(model.RawData.ContainsKey("payment_link"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = null,
            ExpiresOn = null,
            PaymentID = null,
            PaymentLink = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionUpdatePaymentMethodResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
        };

        SubscriptionUpdatePaymentMethodResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
