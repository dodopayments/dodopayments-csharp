using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookDeleteParams { WebhookID = "webhook_id" };

        string expectedWebhookID = "webhook_id";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }
}
