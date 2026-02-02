using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.WebhookEvents;

namespace DodoPayments.Client.Tests.Models.WebhookEvents;

public class WebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookEventType.PaymentSucceeded)]
    [InlineData(WebhookEventType.PaymentFailed)]
    [InlineData(WebhookEventType.PaymentProcessing)]
    [InlineData(WebhookEventType.PaymentCancelled)]
    [InlineData(WebhookEventType.RefundSucceeded)]
    [InlineData(WebhookEventType.RefundFailed)]
    [InlineData(WebhookEventType.DisputeOpened)]
    [InlineData(WebhookEventType.DisputeExpired)]
    [InlineData(WebhookEventType.DisputeAccepted)]
    [InlineData(WebhookEventType.DisputeCancelled)]
    [InlineData(WebhookEventType.DisputeChallenged)]
    [InlineData(WebhookEventType.DisputeWon)]
    [InlineData(WebhookEventType.DisputeLost)]
    [InlineData(WebhookEventType.SubscriptionActive)]
    [InlineData(WebhookEventType.SubscriptionRenewed)]
    [InlineData(WebhookEventType.SubscriptionOnHold)]
    [InlineData(WebhookEventType.SubscriptionCancelled)]
    [InlineData(WebhookEventType.SubscriptionFailed)]
    [InlineData(WebhookEventType.SubscriptionExpired)]
    [InlineData(WebhookEventType.SubscriptionPlanChanged)]
    [InlineData(WebhookEventType.SubscriptionUpdated)]
    [InlineData(WebhookEventType.LicenseKeyCreated)]
    [InlineData(WebhookEventType.PayoutNotInitiated)]
    [InlineData(WebhookEventType.PayoutOnHold)]
    [InlineData(WebhookEventType.PayoutInProgress)]
    [InlineData(WebhookEventType.PayoutFailed)]
    [InlineData(WebhookEventType.PayoutSuccess)]
    public void Validation_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEventType.PaymentSucceeded)]
    [InlineData(WebhookEventType.PaymentFailed)]
    [InlineData(WebhookEventType.PaymentProcessing)]
    [InlineData(WebhookEventType.PaymentCancelled)]
    [InlineData(WebhookEventType.RefundSucceeded)]
    [InlineData(WebhookEventType.RefundFailed)]
    [InlineData(WebhookEventType.DisputeOpened)]
    [InlineData(WebhookEventType.DisputeExpired)]
    [InlineData(WebhookEventType.DisputeAccepted)]
    [InlineData(WebhookEventType.DisputeCancelled)]
    [InlineData(WebhookEventType.DisputeChallenged)]
    [InlineData(WebhookEventType.DisputeWon)]
    [InlineData(WebhookEventType.DisputeLost)]
    [InlineData(WebhookEventType.SubscriptionActive)]
    [InlineData(WebhookEventType.SubscriptionRenewed)]
    [InlineData(WebhookEventType.SubscriptionOnHold)]
    [InlineData(WebhookEventType.SubscriptionCancelled)]
    [InlineData(WebhookEventType.SubscriptionFailed)]
    [InlineData(WebhookEventType.SubscriptionExpired)]
    [InlineData(WebhookEventType.SubscriptionPlanChanged)]
    [InlineData(WebhookEventType.SubscriptionUpdated)]
    [InlineData(WebhookEventType.LicenseKeyCreated)]
    [InlineData(WebhookEventType.PayoutNotInitiated)]
    [InlineData(WebhookEventType.PayoutOnHold)]
    [InlineData(WebhookEventType.PayoutInProgress)]
    [InlineData(WebhookEventType.PayoutFailed)]
    [InlineData(WebhookEventType.PayoutSuccess)]
    public void SerializationRoundtrip_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
