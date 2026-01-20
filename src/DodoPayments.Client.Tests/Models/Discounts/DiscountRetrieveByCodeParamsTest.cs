using System;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountRetrieveByCodeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountRetrieveByCodeParams { Code = "code" };

        string expectedCode = "code";

        Assert.Equal(expectedCode, parameters.Code);
    }

    [Fact]
    public void Url_Works()
    {
        DiscountRetrieveByCodeParams parameters = new() { Code = "code" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/discounts/code/code"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DiscountRetrieveByCodeParams { Code = "code" };

        DiscountRetrieveByCodeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
