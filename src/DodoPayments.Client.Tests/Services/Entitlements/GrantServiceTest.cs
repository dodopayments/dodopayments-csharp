using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Entitlements;

public class GrantServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Entitlements.Grants.List(
            "ent_jt7jcvI79Xh8eehqgWdcm",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task FulfillLicenseKey_Works()
    {
        var entitlementGrant = await this.client.Entitlements.Grants.FulfillLicenseKey(
            "entg_w0ZCJZgNXuNDdMVzvja6p",
            new() { Key = "key" },
            TestContext.Current.CancellationToken
        );
        entitlementGrant.Validate();
    }

    [Fact]
    public async Task Revoke_Works()
    {
        var entitlementGrant = await this.client.Entitlements.Grants.Revoke(
            "entg_w0ZCJZgNXuNDdMVzvja6p",
            new() { ID = "ent_jt7jcvI79Xh8eehqgWdcm" },
            TestContext.Current.CancellationToken
        );
        entitlementGrant.Validate();
    }
}
