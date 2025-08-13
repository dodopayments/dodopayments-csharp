using System.Threading.Tasks;

namespace DodoPayments.Tests.Services.Webhooks;

public class WebhookServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var webhook = await this.client.Webhooks.Create(new() { URL = "url" });
        webhook.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var webhook = await this.client.Webhooks.Retrieve(new() { WebhookID = "webhook_id" });
        webhook.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var webhook = await this.client.Webhooks.Update(new() { WebhookID = "webhook_id" });
        webhook.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Webhooks.List(new());
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Delete(new() { WebhookID = "webhook_id" });
    }
}
