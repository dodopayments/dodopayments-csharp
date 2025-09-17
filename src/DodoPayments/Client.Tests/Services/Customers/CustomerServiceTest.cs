using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Customers;

public class CustomerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customer = await this.client.Customers.Create(new() { Email = "email", Name = "name" });
        customer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var customer = await this.client.Customers.Retrieve(new() { CustomerID = "customer_id" });
        customer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var customer = await this.client.Customers.Update(new() { CustomerID = "customer_id" });
        customer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.List(new());
        page.Validate();
    }
}
