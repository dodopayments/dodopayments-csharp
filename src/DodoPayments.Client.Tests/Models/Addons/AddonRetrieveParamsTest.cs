using System;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonRetrieveParams { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        string expectedID = "adn_NX1zdqW4Hbivsqz8vI9dc";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AddonRetrieveParams parameters = new() { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/addons/adn_NX1zdqW4Hbivsqz8vI9dc"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonRetrieveParams { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        AddonRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
