using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class CustomerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var customer = await this.client.Customers.Create(
            new() { Email = "email", Name = "name" },
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var customer = await this.client.Customers.Retrieve(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var customer = await this.client.Customers.Update(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Customers.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task RetrievePaymentMethods_Works()
    {
        var response = await this.client.Customers.RetrievePaymentMethods(
            "customer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
