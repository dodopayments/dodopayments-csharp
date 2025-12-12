using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Services;

public class PaymentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var payment = await this.client.Payments.Create(
            new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                Customer = new AttachExistingCustomer("customer_id"),
                ProductCart =
                [
                    new()
                    {
                        ProductID = "product_id",
                        Quantity = 0,
                        Amount = 0,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        payment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var payment = await this.client.Payments.Retrieve(
            "payment_id",
            new(),
            TestContext.Current.CancellationToken
        );
        payment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Payments.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task RetrieveLineItems_Works()
    {
        var response = await this.client.Payments.RetrieveLineItems(
            "payment_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
