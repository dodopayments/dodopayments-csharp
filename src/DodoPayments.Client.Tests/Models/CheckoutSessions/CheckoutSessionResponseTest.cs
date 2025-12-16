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
}
