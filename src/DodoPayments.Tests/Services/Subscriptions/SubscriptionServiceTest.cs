using System.Threading.Tasks;
using DodoPayments.Models.Misc;
using DodoPayments.Models.Payments;
using DodoPayments.Models.Subscriptions.SubscriptionChangePlanParamsProperties;

namespace DodoPayments.Tests.Services.Subscriptions;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var subscription = await this.client.Subscriptions.Create(
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
                ProductID = "product_id",
                Quantity = 0,
            }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var subscription = await this.client.Subscriptions.Retrieve(
            new() { SubscriptionID = "subscription_id" }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var subscription = await this.client.Subscriptions.Update(
            new() { SubscriptionID = "subscription_id" }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Subscriptions.List(new());
        page.Validate();
    }

    [Fact]
    public async Task ChangePlan_Works()
    {
        await this.client.Subscriptions.ChangePlan(
            new()
            {
                SubscriptionID = "subscription_id",
                ProductID = "product_id",
                ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
                Quantity = 0,
            }
        );
    }

    [Fact]
    public async Task Charge_Works()
    {
        var response = await this.client.Subscriptions.Charge(
            new() { SubscriptionID = "subscription_id", ProductPrice = 0 }
        );
        response.Validate();
    }
}
