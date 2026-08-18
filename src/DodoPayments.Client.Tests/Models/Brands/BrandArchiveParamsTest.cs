using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandArchiveParams
        {
            ID = "brnd_8dFiAW42v28JzhlVSocjq",
            MoveProductsTo = "move_products_to",
        };

        string expectedID = "brnd_8dFiAW42v28JzhlVSocjq";
        string expectedMoveProductsTo = "move_products_to";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMoveProductsTo, parameters.MoveProductsTo);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandArchiveParams { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        Assert.Null(parameters.MoveProductsTo);
        Assert.False(parameters.RawBodyData.ContainsKey("move_products_to"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandArchiveParams
        {
            ID = "brnd_8dFiAW42v28JzhlVSocjq",

            MoveProductsTo = null,
        };

        Assert.Null(parameters.MoveProductsTo);
        Assert.True(parameters.RawBodyData.ContainsKey("move_products_to"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandArchiveParams parameters = new() { ID = "brnd_8dFiAW42v28JzhlVSocjq" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/brands/brnd_8dFiAW42v28JzhlVSocjq/archive"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandArchiveParams
        {
            ID = "brnd_8dFiAW42v28JzhlVSocjq",
            MoveProductsTo = "move_products_to",
        };

        BrandArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
