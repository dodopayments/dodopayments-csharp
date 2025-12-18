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
            CheckoutURL = "checkout_url",
            SessionID = "session_id",
        };

        string expectedCheckoutURL = "checkout_url";
        string expectedSessionID = "session_id";

        Assert.Equal(expectedCheckoutURL, model.CheckoutURL);
        Assert.Equal(expectedSessionID, model.SessionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionResponse
        {
            CheckoutURL = "checkout_url",
            SessionID = "session_id",
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
            CheckoutURL = "checkout_url",
            SessionID = "session_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionResponse>(element);
        Assert.NotNull(deserialized);

        string expectedCheckoutURL = "checkout_url";
        string expectedSessionID = "session_id";

        Assert.Equal(expectedCheckoutURL, deserialized.CheckoutURL);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionResponse
        {
            CheckoutURL = "checkout_url",
            SessionID = "session_id",
        };

        model.Validate();
    }
}
