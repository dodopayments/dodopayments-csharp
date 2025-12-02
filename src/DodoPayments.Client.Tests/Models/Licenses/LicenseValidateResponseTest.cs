using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Tests.Models.Licenses;

public class LicenseValidateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseValidateResponse { Valid = true };

        bool expectedValid = true;

        Assert.Equal(expectedValid, model.Valid);
    }
}
