using System.Threading.Tasks;

namespace Dodopayments.Tests.Services.CheckoutSessions;

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
                    },
                ],
            }
        );
        checkoutSessionResponse.Validate();
    }
}
