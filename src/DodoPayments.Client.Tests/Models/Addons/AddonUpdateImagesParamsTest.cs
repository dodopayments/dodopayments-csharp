using System;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonUpdateImagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonUpdateImagesParams { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        string expectedID = "adn_NX1zdqW4Hbivsqz8vI9dc";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AddonUpdateImagesParams parameters = new() { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/addons/adn_NX1zdqW4Hbivsqz8vI9dc/images"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonUpdateImagesParams { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        AddonUpdateImagesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
