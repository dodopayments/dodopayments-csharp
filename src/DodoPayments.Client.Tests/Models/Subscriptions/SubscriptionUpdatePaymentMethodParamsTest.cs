using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class NewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new New { Type = Type.New, ReturnURL = "return_url" };

        ApiEnum<string, Type> expectedType = Type.New;
        string expectedReturnURL = "return_url";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedReturnURL, model.ReturnURL);
    }
}

public class ExistingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = ExistingType.Existing,
        };

        string expectedPaymentMethodID = "payment_method_id";
        ApiEnum<string, ExistingType> expectedType = ExistingType.Existing;

        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedType, model.Type);
    }
}
