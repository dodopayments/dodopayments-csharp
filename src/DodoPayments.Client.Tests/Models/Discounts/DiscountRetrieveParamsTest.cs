using System;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountRetrieveParams { DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9" };

        string expectedDiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9";

        Assert.Equal(expectedDiscountID, parameters.DiscountID);
    }

    [Fact]
    public void Url_Works()
    {
        DiscountRetrieveParams parameters = new() { DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/discounts/dsc_qxxEmg5PuM1uNTE0LgkP9"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DiscountRetrieveParams { DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9" };

        DiscountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
