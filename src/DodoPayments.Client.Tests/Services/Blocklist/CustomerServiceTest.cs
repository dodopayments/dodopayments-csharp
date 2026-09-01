using System.Threading.Tasks;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Services.Blocklist;

public class CustomerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var blockedCustomer = await this.client.Blocklist.Customers.Create(
            new()
            {
                CreateBlockedCustomerRequest = new BlocklistCustomersBlockByCustomerID()
                {
                    CustomerID = "customer_id",
                    Reason = "reason",
                    Source = BlockedCustomerSource.BlocklistPage,
                },
            },
            TestContext.Current.CancellationToken
        );
        blockedCustomer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var blockedCustomer = await this.client.Blocklist.Customers.Retrieve(
            "entry_id",
            new(),
            TestContext.Current.CancellationToken
        );
        blockedCustomer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Blocklist.Customers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Blocklist.Customers.Delete(
            "entry_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
