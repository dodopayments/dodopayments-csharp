using System.Threading.Tasks;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Services;

public class EntitlementServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var entitlement = await this.client.Entitlements.Create(
            new()
            {
                IntegrationConfig = new GitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
                IntegrationType = EntitlementIntegrationType.Discord,
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        entitlement.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var entitlement = await this.client.Entitlements.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        entitlement.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var entitlement = await this.client.Entitlements.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        entitlement.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Entitlements.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Entitlements.Delete("id", new(), TestContext.Current.CancellationToken);
    }
}
