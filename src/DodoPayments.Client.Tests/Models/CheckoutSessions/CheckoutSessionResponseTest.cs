using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
            ClientSecret = "client_secret",
            PaymentID = "payment_id",
            PublishableKey = "publishable_key",
        };

        string expectedSessionID = "session_id";
        string expectedCheckoutUrl = "checkout_url";
        string expectedClientSecret = "client_secret";
        string expectedPaymentID = "payment_id";
        string expectedPublishableKey = "publishable_key";

        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPublishableKey, model.PublishableKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
            ClientSecret = "client_secret",
            PaymentID = "payment_id",
            PublishableKey = "publishable_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
            ClientSecret = "client_secret",
            PaymentID = "payment_id",
            PublishableKey = "publishable_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSessionID = "session_id";
        string expectedCheckoutUrl = "checkout_url";
        string expectedClientSecret = "client_secret";
        string expectedPaymentID = "payment_id";
        string expectedPublishableKey = "publishable_key";

        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedPublishableKey, deserialized.PublishableKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
            ClientSecret = "client_secret",
            PaymentID = "payment_id",
            PublishableKey = "publishable_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionResponse { SessionID = "session_id" };

        Assert.Null(model.CheckoutUrl);
        Assert.False(model.RawData.ContainsKey("checkout_url"));
        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PublishableKey);
        Assert.False(model.RawData.ContainsKey("publishable_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionResponse { SessionID = "session_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",

            CheckoutUrl = null,
            ClientSecret = null,
            PaymentID = null,
            PublishableKey = null,
        };

        Assert.Null(model.CheckoutUrl);
        Assert.True(model.RawData.ContainsKey("checkout_url"));
        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PublishableKey);
        Assert.True(model.RawData.ContainsKey("publishable_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",

            CheckoutUrl = null,
            ClientSecret = null,
            PaymentID = null,
            PublishableKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
            ClientSecret = "client_secret",
            PaymentID = "payment_id",
            PublishableKey = "publishable_key",
        };

        CheckoutSessionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
