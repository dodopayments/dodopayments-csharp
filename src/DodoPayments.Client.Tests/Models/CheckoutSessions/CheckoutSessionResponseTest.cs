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
        };

        string expectedSessionID = "session_id";
        string expectedCheckoutUrl = "checkout_url";

        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSessionID = "session_id";
        string expectedCheckoutUrl = "checkout_url";

        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutUrl = "checkout_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionResponse { SessionID = "session_id" };

        Assert.Null(model.CheckoutUrl);
        Assert.False(model.RawData.ContainsKey("checkout_url"));
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
        };

        Assert.Null(model.CheckoutUrl);
        Assert.True(model.RawData.ContainsKey("checkout_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",

            CheckoutUrl = null,
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
        };

        CheckoutSessionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
