using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            Amount = 0,
            TaxInclusive = true,
        };

        string expectedItemID = "item_id";
        int expectedAmount = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }
}
