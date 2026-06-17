using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services;

public class CheckoutSessionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var checkoutSessionResponse = await this.client.CheckoutSessions.Create(
            new()
            {
                ProductCart =
                [
                    new()
                    {
                        ProductID = "product_id",
                        Quantity = 0,
                        Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                        Amount = 0,
                        CreditEntitlements =
                        [
                            new()
                            {
                                CreditEntitlementID = "credit_entitlement_id",
                                CreditsAmount = "credits_amount",
                            },
                        ],
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        checkoutSessionResponse.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var checkoutSessionStatus = await this.client.CheckoutSessions.Retrieve(
            "cks_n010SZaY4NXc7F1ck3Tq1",
            new(),
            TestContext.Current.CancellationToken
        );
        checkoutSessionStatus.Validate();
    }

    [Fact]
    public async Task Preview_Works()
    {
        var response = await this.client.CheckoutSessions.Preview(
            new()
            {
                ProductCart =
                [
                    new()
                    {
                        ProductID = "product_id",
                        Quantity = 0,
                        Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                        Amount = 0,
                        CreditEntitlements =
                        [
                            new()
                            {
                                CreditEntitlementID = "credit_entitlement_id",
                                CreditsAmount = "credits_amount",
                            },
                        ],
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
