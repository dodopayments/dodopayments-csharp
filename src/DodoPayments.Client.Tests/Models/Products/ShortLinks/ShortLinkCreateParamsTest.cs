using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Products.ShortLinks;

namespace DodoPayments.Client.Tests.Models.Products.ShortLinks;

public class ShortLinkCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShortLinkCreateParams
        {
            ID = "id",
            Slug = "slug",
            StaticCheckoutParams = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedID = "id";
        string expectedSlug = "slug";
        Dictionary<string, string> expectedStaticCheckoutParams = new() { { "foo", "string" } };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSlug, parameters.Slug);
        Assert.NotNull(parameters.StaticCheckoutParams);
        Assert.Equal(expectedStaticCheckoutParams.Count, parameters.StaticCheckoutParams.Count);
        foreach (var item in expectedStaticCheckoutParams)
        {
            Assert.True(parameters.StaticCheckoutParams.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.StaticCheckoutParams[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ShortLinkCreateParams { ID = "id", Slug = "slug" };

        Assert.Null(parameters.StaticCheckoutParams);
        Assert.False(parameters.RawBodyData.ContainsKey("static_checkout_params"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ShortLinkCreateParams
        {
            ID = "id",
            Slug = "slug",

            StaticCheckoutParams = null,
        };

        Assert.Null(parameters.StaticCheckoutParams);
        Assert.True(parameters.RawBodyData.ContainsKey("static_checkout_params"));
    }

    [Fact]
    public void Url_Works()
    {
        ShortLinkCreateParams parameters = new() { ID = "id", Slug = "slug" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/products/id/short_links"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ShortLinkCreateParams
        {
            ID = "id",
            Slug = "slug",
            StaticCheckoutParams = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ShortLinkCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
