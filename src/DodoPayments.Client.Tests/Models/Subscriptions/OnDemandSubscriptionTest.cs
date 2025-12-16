using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class OnDemandSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnDemandSubscription
        {
            MandateOnly = true,
            AdaptiveCurrencyFeesInclusive = true,
            ProductCurrency = Currency.Aed,
            ProductDescription = "product_description",
            ProductPrice = 0,
        };

        bool expectedMandateOnly = true;
        bool expectedAdaptiveCurrencyFeesInclusive = true;
        ApiEnum<string, Currency> expectedProductCurrency = Currency.Aed;
        string expectedProductDescription = "product_description";
        int expectedProductPrice = 0;

        Assert.Equal(expectedMandateOnly, model.MandateOnly);
        Assert.Equal(expectedAdaptiveCurrencyFeesInclusive, model.AdaptiveCurrencyFeesInclusive);
        Assert.Equal(expectedProductCurrency, model.ProductCurrency);
        Assert.Equal(expectedProductDescription, model.ProductDescription);
        Assert.Equal(expectedProductPrice, model.ProductPrice);
    }
}
