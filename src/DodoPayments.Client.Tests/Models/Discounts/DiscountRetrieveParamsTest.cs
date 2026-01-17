using System;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountRetrieveParams { DiscountID = "discount_id" };

        string expectedDiscountID = "discount_id";

        Assert.Equal(expectedDiscountID, parameters.DiscountID);
    }

    [Fact]
    public void Url_Works()
    {
        DiscountRetrieveParams parameters = new() { DiscountID = "discount_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/discounts/discount_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DiscountRetrieveParams { DiscountID = "discount_id" };

        DiscountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
