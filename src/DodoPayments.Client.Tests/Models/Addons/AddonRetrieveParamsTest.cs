using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }
}
