using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyRetrieveParams { ID = "lic_123" };

        string expectedID = "lic_123";

        Assert.Equal(expectedID, parameters.ID);
    }
}
