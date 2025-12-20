using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountRetrieveParams { DiscountID = "discount_id" };

        string expectedDiscountID = "discount_id";

        Assert.Equal(expectedDiscountID, parameters.DiscountID);
    }
}
