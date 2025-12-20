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
}
