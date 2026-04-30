using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Entitlements;

public class GrantServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Entitlements.Grants.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Revoke_Works()
    {
        var entitlementGrant = await this.client.Entitlements.Grants.Revoke(
            "grant_id",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        entitlementGrant.Validate();
    }
}
