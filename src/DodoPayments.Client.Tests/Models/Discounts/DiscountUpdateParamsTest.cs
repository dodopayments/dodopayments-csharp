using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountUpdateParams
        {
            DiscountID = "discount_id",
            Amount = 0,
            Code = "code",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            RestrictedTo = ["string"],
            SubscriptionCycles = 0,
            Type = DiscountType.Percentage,
            UsageLimit = 0,
        };

        string expectedDiscountID = "discount_id";
        int expectedAmount = 0;
        string expectedCode = "code";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        List<string> expectedRestrictedTo = ["string"];
        int expectedSubscriptionCycles = 0;
        ApiEnum<string, DiscountType> expectedType = DiscountType.Percentage;
        int expectedUsageLimit = 0;

        Assert.Equal(expectedDiscountID, parameters.DiscountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.RestrictedTo);
        Assert.Equal(expectedRestrictedTo.Count, parameters.RestrictedTo.Count);
        for (int i = 0; i < expectedRestrictedTo.Count; i++)
        {
            Assert.Equal(expectedRestrictedTo[i], parameters.RestrictedTo[i]);
        }
        Assert.Equal(expectedSubscriptionCycles, parameters.SubscriptionCycles);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedUsageLimit, parameters.UsageLimit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DiscountUpdateParams { DiscountID = "discount_id" };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Code);
        Assert.False(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.RestrictedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("restricted_to"));
        Assert.Null(parameters.SubscriptionCycles);
        Assert.False(parameters.RawBodyData.ContainsKey("subscription_cycles"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.UsageLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("usage_limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DiscountUpdateParams
        {
            DiscountID = "discount_id",

            Amount = null,
            Code = null,
            ExpiresAt = null,
            Name = null,
            RestrictedTo = null,
            SubscriptionCycles = null,
            Type = null,
            UsageLimit = null,
        };

        Assert.Null(parameters.Amount);
        Assert.True(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Code);
        Assert.True(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.ExpiresAt);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.RestrictedTo);
        Assert.True(parameters.RawBodyData.ContainsKey("restricted_to"));
        Assert.Null(parameters.SubscriptionCycles);
        Assert.True(parameters.RawBodyData.ContainsKey("subscription_cycles"));
        Assert.Null(parameters.Type);
        Assert.True(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.UsageLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("usage_limit"));
    }

    [Fact]
    public void Url_Works()
    {
        DiscountUpdateParams parameters = new() { DiscountID = "discount_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/discounts/discount_id"), url);
    }
}
