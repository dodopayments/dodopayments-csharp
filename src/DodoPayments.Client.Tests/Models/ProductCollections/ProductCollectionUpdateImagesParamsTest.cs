using System;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionUpdateImagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionUpdateImagesParams { ID = "id", ForceUpdate = true };

        string expectedID = "id";
        bool expectedForceUpdate = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedForceUpdate, parameters.ForceUpdate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionUpdateImagesParams { ID = "id" };

        Assert.Null(parameters.ForceUpdate);
        Assert.False(parameters.RawQueryData.ContainsKey("force_update"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductCollectionUpdateImagesParams
        {
            ID = "id",

            ForceUpdate = null,
        };

        Assert.Null(parameters.ForceUpdate);
        Assert.True(parameters.RawQueryData.ContainsKey("force_update"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionUpdateImagesParams parameters = new() { ID = "id", ForceUpdate = true };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections/id/images?force_update=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionUpdateImagesParams { ID = "id", ForceUpdate = true };

        ProductCollectionUpdateImagesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
