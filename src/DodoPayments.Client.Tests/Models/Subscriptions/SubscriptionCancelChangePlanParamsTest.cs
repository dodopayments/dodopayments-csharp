using System;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionCancelChangePlanParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCancelChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCancelChangePlanParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv/change-plan/scheduled"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionCancelChangePlanParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
        };

        SubscriptionCancelChangePlanParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
