using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class OneTimeProductCartItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedAmount, model.Amount);
    }
}
