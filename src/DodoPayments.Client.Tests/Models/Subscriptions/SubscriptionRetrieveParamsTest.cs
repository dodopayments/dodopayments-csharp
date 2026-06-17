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
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv"),
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
        };

        SubscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
