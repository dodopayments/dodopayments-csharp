using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class AttachAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachAddon { AddonID = "addon_id", Quantity = 0 };

        string expectedAddonID = "addon_id";
        int expectedQuantity = 0;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }
}
