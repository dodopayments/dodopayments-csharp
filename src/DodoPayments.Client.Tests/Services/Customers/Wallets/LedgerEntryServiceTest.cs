using System.Threading.Tasks;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Services.Customers.Wallets;

public class LedgerEntryServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customerWallet = await this.client.Customers.Wallets.LedgerEntries.Create(
            "customer_id",
            new()
            {
                Amount = 0,
                Currency = Currency.Aed,
                EntryType = EntryType.Credit,
            }
        );
        customerWallet.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.Wallets.LedgerEntries.List("customer_id");
        page.Validate();
    }
}
