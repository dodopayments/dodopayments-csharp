using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUnarchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductUnarchiveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductUnarchiveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/products/id/unarchive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductUnarchiveParams { ID = "id" };

        ProductUnarchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
