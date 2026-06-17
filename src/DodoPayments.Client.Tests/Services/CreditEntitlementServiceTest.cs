using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class CreditEntitlementServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var creditEntitlement = await this.client.CreditEntitlements.Create(
            new()
            {
                Name = "name",
                OverageEnabled = true,
                Precision = 0,
                RolloverEnabled = true,
                Unit = "unit",
            },
            TestContext.Current.CancellationToken
        );
        creditEntitlement.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var creditEntitlement = await this.client.CreditEntitlements.Retrieve(
            "cde_ztxm5XJsKxWucRWA3rjdM",
            new(),
            TestContext.Current.CancellationToken
        );
        creditEntitlement.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.CreditEntitlements.Update(
            "cde_ztxm5XJsKxWucRWA3rjdM",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CreditEntitlements.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.CreditEntitlements.Delete(
            "cde_ztxm5XJsKxWucRWA3rjdM",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Undelete_Works()
    {
        await this.client.CreditEntitlements.Undelete(
            "cde_ztxm5XJsKxWucRWA3rjdM",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
