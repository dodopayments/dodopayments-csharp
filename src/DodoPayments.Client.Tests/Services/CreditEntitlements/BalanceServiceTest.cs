using System.Threading.Tasks;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Services.CreditEntitlements;

public class BalanceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var customerCreditBalance = await this.client.CreditEntitlements.Balances.Retrieve(
            "customer_id",
            new() { CreditEntitlementID = "credit_entitlement_id" },
            TestContext.Current.CancellationToken
        );
        customerCreditBalance.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CreditEntitlements.Balances.List(
            "credit_entitlement_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task CreateLedgerEntry_Works()
    {
        var response = await this.client.CreditEntitlements.Balances.CreateLedgerEntry(
            "customer_id",
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
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
            "customer_id",
            new() { CreditEntitlementID = "credit_entitlement_id" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task ListLedger_Works()
    {
        var page = await this.client.CreditEntitlements.Balances.ListLedger(
            "customer_id",
            new() { CreditEntitlementID = "credit_entitlement_id" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
