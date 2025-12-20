using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyInstanceRetrieveParams { ID = "lki_123" };

        string expectedID = "lki_123";

        Assert.Equal(expectedID, parameters.ID);
    }
}
