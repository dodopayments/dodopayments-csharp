using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRetrieveParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            Locale = "locale",
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";
        string expectedLocale = "locale";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionRetrieveParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionRetrieveParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionRetrieveParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            Locale = "locale",
        };

        SubscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
