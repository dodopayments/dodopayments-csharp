using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandUpdateImagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandUpdateImagesParams { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        string expectedID = "brnd_8dFiAW42v28JzhlVSocjq";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        BrandUpdateImagesParams parameters = new() { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/brands/brnd_8dFiAW42v28JzhlVSocjq/images"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandUpdateImagesParams { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        BrandUpdateImagesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
