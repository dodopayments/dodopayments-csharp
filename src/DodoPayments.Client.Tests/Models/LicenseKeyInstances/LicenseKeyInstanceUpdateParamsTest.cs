using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyInstanceUpdateParams { ID = "lki_123", Name = "name" };

        string expectedID = "lki_123";
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedName, parameters.Name);
    }
}
