using System.Text.Json;
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
            CheckoutURL = "checkout_url",
        };

        string expectedSessionID = "session_id";
        string expectedCheckoutURL = "checkout_url";

        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedCheckoutURL, model.CheckoutURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutURL = "checkout_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutURL = "checkout_url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionResponse>(element);
        Assert.NotNull(deserialized);

        string expectedSessionID = "session_id";
        string expectedCheckoutURL = "checkout_url";

        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedCheckoutURL, deserialized.CheckoutURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",
            CheckoutURL = "checkout_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionResponse { SessionID = "session_id" };

        Assert.Null(model.CheckoutURL);
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

            CheckoutURL = null,
        };

        Assert.Null(model.CheckoutURL);
        Assert.True(model.RawData.ContainsKey("checkout_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            SessionID = "session_id",

            CheckoutURL = null,
        };

        model.Validate();
    }
}
