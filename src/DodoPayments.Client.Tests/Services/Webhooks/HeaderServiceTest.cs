using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Webhooks;

public class HeaderServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var header = await this.client.Webhooks.Headers.Retrieve(
            "whk_YdWqVEGKmSYKbsIyDxEab",
            new(),
            TestContext.Current.CancellationToken
        );
        header.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Webhooks.Headers.Update(
            "whk_YdWqVEGKmSYKbsIyDxEab",
            new() { Headers = new Dictionary<string, string>() { { "foo", "string" } } },
            TestContext.Current.CancellationToken
        );
    }
}
