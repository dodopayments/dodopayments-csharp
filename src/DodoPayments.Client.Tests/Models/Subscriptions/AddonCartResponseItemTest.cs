using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class AddonCartResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonCartResponseItem { AddonID = "addon_id", Quantity = 0 };

        string expectedAddonID = "addon_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }
}
