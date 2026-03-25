using System;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/product-collections/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionDeleteParams { ID = "id" };

        ProductCollectionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
