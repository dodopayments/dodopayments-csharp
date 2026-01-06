using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUpdateFilesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductUpdateFilesParams { ID = "id", FileName = "file_name" };

        string expectedID = "id";
        string expectedFileName = "file_name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFileName, parameters.FileName);
    }

    [Fact]
    public void Url_Works()
    {
        ProductUpdateFilesParams parameters = new() { ID = "id", FileName = "file_name" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/products/id/files"), url);
    }
}
