using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Tests.Models.Webhooks.Headers;

public class HeaderRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HeaderRetrieveParams { WebhookID = "webhook_id" };

        string expectedWebhookID = "webhook_id";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }
}
