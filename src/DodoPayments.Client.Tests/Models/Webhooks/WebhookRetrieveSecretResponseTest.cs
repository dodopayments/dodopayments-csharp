using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class WebhookRetrieveSecretResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRetrieveSecretResponse { Secret = "secret" };

        string expectedSecret = "secret";

        Assert.Equal(expectedSecret, model.Secret);
    }
}
