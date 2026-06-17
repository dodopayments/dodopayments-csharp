using System;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Tests.Models.Products.Images;

public class ImageUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ImageUpdateParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ForceUpdate = true,
        };

        string expectedID = "pdt_R8AWMPiV8RyJElcCKvAID";
        bool expectedForceUpdate = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedForceUpdate, parameters.ForceUpdate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ImageUpdateParams { ID = "pdt_R8AWMPiV8RyJElcCKvAID" };

        Assert.Null(parameters.ForceUpdate);
        Assert.False(parameters.RawQueryData.ContainsKey("force_update"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ImageUpdateParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",

            // Null should be interpreted as omitted for these properties
            ForceUpdate = null,
        };

        Assert.Null(parameters.ForceUpdate);
        Assert.False(parameters.RawQueryData.ContainsKey("force_update"));
    }

    [Fact]
    public void Url_Works()
    {
        ImageUpdateParams parameters = new()
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ForceUpdate = true,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/products/pdt_R8AWMPiV8RyJElcCKvAID/images?force_update=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ImageUpdateParams
        {
            ID = "pdt_R8AWMPiV8RyJElcCKvAID",
            ForceUpdate = true,
        };

        ImageUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
