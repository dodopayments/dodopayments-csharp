using System.Threading.Tasks;

namespace Dodopayments.Tests.Services.Webhooks.Headers;

public class HeaderServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var header = await this.client.Webhooks.Headers.Retrieve(
            new() { WebhookID = "webhook_id" }
        );
        header.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Webhooks.Headers.Update(
            new()
            {
                WebhookID = "webhook_id",
                Headers = new() { { "foo", "string" } },
            }
        );
    }
}
