using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandUpdateImagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandUpdateImagesParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        BrandUpdateImagesParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/brands/id/images"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandUpdateImagesParams { ID = "id" };

        BrandUpdateImagesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
