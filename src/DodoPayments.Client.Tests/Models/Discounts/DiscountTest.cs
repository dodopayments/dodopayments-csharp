using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Discount
        {
            Amount = 0,
            BusinessID = "business_id",
            Code = "code",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DiscountID = "discount_id",
            RestrictedTo = ["string"],
            TimesUsed = 0,
            Type = DiscountType.Percentage,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            SubscriptionCycles = 0,
            UsageLimit = 0,
        };

        int expectedAmount = 0;
        string expectedBusinessID = "business_id";
        string expectedCode = "code";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDiscountID = "discount_id";
        List<string> expectedRestrictedTo = ["string"];
        int expectedTimesUsed = 0;
        ApiEnum<string, DiscountType> expectedType = DiscountType.Percentage;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        int expectedSubscriptionCycles = 0;
        int expectedUsageLimit = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedRestrictedTo.Count, model.RestrictedTo.Count);
        for (int i = 0; i < expectedRestrictedTo.Count; i++)
        {
            Assert.Equal(expectedRestrictedTo[i], model.RestrictedTo[i]);
        }
        Assert.Equal(expectedTimesUsed, model.TimesUsed);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSubscriptionCycles, model.SubscriptionCycles);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }
}
