using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Tests.Models.Products.ShortLinks;

public class ShortLinkListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShortLinkListParams
        {
            PageNumber = 0,
            PageSize = 0,
            ProductID = "product_id",
        };

        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        string expectedProductID = "product_id";

        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedProductID, parameters.ProductID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ShortLinkListParams { };

        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.ProductID);
        Assert.False(parameters.RawQueryData.ContainsKey("product_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ShortLinkListParams
        {
            // Null should be interpreted as omitted for these properties
            PageNumber = null,
            PageSize = null,
            ProductID = null,
        };

        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.ProductID);
        Assert.False(parameters.RawQueryData.ContainsKey("product_id"));
    }
}
