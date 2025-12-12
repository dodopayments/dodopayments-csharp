using System.Threading.Tasks;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Services;

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
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                Customer = new AttachExistingCustomer("customer_id"),
                ProductID = "product_id",
                Quantity = 0,
            },
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var subscription = await this.client.Subscriptions.Retrieve(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var subscription = await this.client.Subscriptions.Update(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Subscriptions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task ChangePlan_Works()
    {
        await this.client.Subscriptions.ChangePlan(
            "subscription_id",
            new()
            {
                ProductID = "product_id",
                ProrationBillingMode = ProrationBillingMode.ProratedImmediately,
                Quantity = 0,
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Charge_Works()
    {
        var response = await this.client.Subscriptions.Charge(
            "subscription_id",
            new() { ProductPrice = 0 },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task PreviewChangePlan_Works()
    {
        var response = await this.client.Subscriptions.PreviewChangePlan(
            "subscription_id",
            new()
            {
                ProductID = "product_id",
                ProrationBillingMode =
                    SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
                Quantity = 0,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task RetrieveUsageHistory_Works()
    {
        var page = await this.client.Subscriptions.RetrieveUsageHistory(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task UpdatePaymentMethod_Works()
    {
        var response = await this.client.Subscriptions.UpdatePaymentMethod(
            "subscription_id",
            new()
            {
                Body = new New() { Type = Type.New, ReturnURL = "return_url" },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
