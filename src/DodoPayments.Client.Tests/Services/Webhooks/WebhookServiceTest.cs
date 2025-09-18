using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Webhooks;

public class WebhookServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var webhookDetails = await this.client.Webhooks.Create(new() { URL = "url" });
        webhookDetails.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var webhookDetails = await this.client.Webhooks.Retrieve(
            new() { WebhookID = "webhook_id" }
        );
        webhookDetails.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var webhookDetails = await this.client.Webhooks.Update(new() { WebhookID = "webhook_id" });
        webhookDetails.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Webhooks.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Delete(new() { WebhookID = "webhook_id" });
    }

    [Fact]
    public async Task RetrieveSecret_Works()
    {
        var response = await this.client.Webhooks.RetrieveSecret(
            new() { WebhookID = "webhook_id" }
        );
        response.Validate();
    }
}
