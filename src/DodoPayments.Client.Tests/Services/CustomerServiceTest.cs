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
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new(),
            TestContext.Current.CancellationToken
        );
        customer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var customer = await this.client.Customers.Update(
            "cus_TV52uJWWXt2yIoBBxpjaa",
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
    public async Task DeletePaymentMethod_Works()
    {
        await this.client.Customers.DeletePaymentMethod(
            "payment_method_id",
            new() { CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task ListCreditEntitlements_Works()
    {
        var response = await this.client.Customers.ListCreditEntitlements(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task ListEntitlements_Works()
    {
        var response = await this.client.Customers.ListEntitlements(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task RetrievePaymentMethods_Works()
    {
        var response = await this.client.Customers.RetrievePaymentMethods(
            "cus_TV52uJWWXt2yIoBBxpjaa",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
