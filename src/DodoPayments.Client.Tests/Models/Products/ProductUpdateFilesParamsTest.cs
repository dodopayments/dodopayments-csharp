using System;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUpdateFilesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductUpdateFilesParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            FileName = "file_name",
        };

        string expectedID = "pdt_R8AWMPiV8RyJElcCKvAID";
        string expectedFileName = "file_name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFileName, parameters.FileName);
    }

    [Fact]
    public void Url_Works()
    {
        ProductUpdateFilesParams parameters = new()
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            FileName = "file_name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID/files"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductUpdateFilesParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            FileName = "file_name",
        };

        ProductUpdateFilesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
