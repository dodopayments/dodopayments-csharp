using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Webhooks;

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
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            }
        );
    }
}
