using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string expectedCity = "city";
        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedZipcode, model.Zipcode);
    }
}
