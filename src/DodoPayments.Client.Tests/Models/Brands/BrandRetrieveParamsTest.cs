using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandRetrieveParams { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        string expectedID = "brnd_8dFiAW42v28JzhlVSocjq";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        BrandRetrieveParams parameters = new() { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/brands/brnd_8dFiAW42v28JzhlVSocjq"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandRetrieveParams { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        BrandRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
