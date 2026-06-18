using System.Threading.Tasks;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Services.CreditEntitlements;

public class BalanceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var customerCreditBalance = await this.client.CreditEntitlements.Balances.Retrieve(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new() { CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM" },
            TestContext.Current.CancellationToken
        );
        customerCreditBalance.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CreditEntitlements.Balances.List(
            "cde_ztxm5XJsKxWucRWA3rjdM",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task CreateLedgerEntry_Works()
    {
        var response = await this.client.CreditEntitlements.Balances.CreateLedgerEntry(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new()
            {
                CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM",
                Amount = "amount",
                EntryType = LedgerEntryType.Credit,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListGrants_Works()
    {
        var page = await this.client.CreditEntitlements.Balances.ListGrants(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new() { CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task ListLedger_Works()
    {
        var page = await this.client.CreditEntitlements.Balances.ListLedger(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new() { CreditEntitlementID = "cde_ztxm5XJsKxWucRWA3rjdM" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
