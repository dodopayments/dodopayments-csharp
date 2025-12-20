using DodoPayments.Client.Models.Customers.CustomerPortal;

namespace DodoPayments.Client.Tests.Models.Customers.CustomerPortal;

public class CustomerPortalCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerPortalCreateParams
        {
            CustomerID = "customer_id",
            SendEmail = true,
        };

        string expectedCustomerID = "customer_id";
        bool expectedSendEmail = true;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedSendEmail, parameters.SendEmail);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerPortalCreateParams { CustomerID = "customer_id" };

        Assert.Null(parameters.SendEmail);
        Assert.False(parameters.RawQueryData.ContainsKey("send_email"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerPortalCreateParams
        {
            CustomerID = "customer_id",

            // Null should be interpreted as omitted for these properties
            SendEmail = null,
        };

        Assert.Null(parameters.SendEmail);
        Assert.False(parameters.RawQueryData.ContainsKey("send_email"));
    }
}
