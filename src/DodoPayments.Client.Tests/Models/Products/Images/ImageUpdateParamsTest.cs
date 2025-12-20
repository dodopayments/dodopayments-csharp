using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Tests.Models.Products.Images;

public class ImageUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ImageUpdateParams { ID = "id", ForceUpdate = true };

        string expectedID = "id";
        bool expectedForceUpdate = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedForceUpdate, parameters.ForceUpdate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ImageUpdateParams { ID = "id" };

        Assert.Null(parameters.ForceUpdate);
        Assert.False(parameters.RawQueryData.ContainsKey("force_update"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ImageUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            ForceUpdate = null,
        };

        Assert.Null(parameters.ForceUpdate);
        Assert.False(parameters.RawQueryData.ContainsKey("force_update"));
    }
}
