using System;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class GroupDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupDeleteParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "pdc_8BWv0hojwUH7iCDabr0NI";
        string expectedGroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedGroupID, parameters.GroupID);
    }

    [Fact]
    public void Url_Works()
    {
        GroupDeleteParams parameters = new()
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections/pdc_8BWv0hojwUH7iCDabr0NI/groups/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupDeleteParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        GroupDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
