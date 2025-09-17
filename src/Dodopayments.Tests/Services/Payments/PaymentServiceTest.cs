using System.Threading.Tasks;
using Dodopayments.Models.Misc;
using Dodopayments.Models.Payments;

namespace Dodopayments.Tests.Services.Payments;

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
                    City = "city",
                    Country = CountryCode.Af,
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
            }
        );
        payment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var payment = await this.client.Payments.Retrieve(new() { PaymentID = "payment_id" });
        payment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Payments.List(new());
        page.Validate();
    }

    [Fact]
    public async Task RetrieveLineItems_Works()
    {
        var response = await this.client.Payments.RetrieveLineItems(
            new() { PaymentID = "payment_id" }
        );
        response.Validate();
    }
}
