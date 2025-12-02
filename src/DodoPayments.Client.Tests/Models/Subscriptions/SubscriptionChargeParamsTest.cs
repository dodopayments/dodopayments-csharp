using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class CustomerBalanceConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        bool expectedAllowCustomerCreditsPurchase = true;
        bool expectedAllowCustomerCreditsUsage = true;

        Assert.Equal(expectedAllowCustomerCreditsPurchase, model.AllowCustomerCreditsPurchase);
        Assert.Equal(expectedAllowCustomerCreditsUsage, model.AllowCustomerCreditsUsage);
    }
}
