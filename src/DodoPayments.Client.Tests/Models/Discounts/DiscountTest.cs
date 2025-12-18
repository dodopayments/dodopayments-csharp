using System;
using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Discount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Discount>(element);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedRestrictedTo.Count, deserialized.RestrictedTo.Count);
        for (int i = 0; i < expectedRestrictedTo.Count; i++)
        {
            Assert.Equal(expectedRestrictedTo[i], deserialized.RestrictedTo[i]);
        }
        Assert.Equal(expectedTimesUsed, deserialized.TimesUsed);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSubscriptionCycles, deserialized.SubscriptionCycles);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SubscriptionCycles);
        Assert.False(model.RawData.ContainsKey("subscription_cycles"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usage_limit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            ExpiresAt = null,
            Name = null,
            SubscriptionCycles = null,
            UsageLimit = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.SubscriptionCycles);
        Assert.True(model.RawData.ContainsKey("subscription_cycles"));
        Assert.Null(model.UsageLimit);
        Assert.True(model.RawData.ContainsKey("usage_limit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            ExpiresAt = null,
            Name = null,
            SubscriptionCycles = null,
            UsageLimit = null,
        };

        model.Validate();
    }
}
