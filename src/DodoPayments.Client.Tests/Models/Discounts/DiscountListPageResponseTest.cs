using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Discounts;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        List<Discount> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiscountListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DiscountListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiscountListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DiscountListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<Discount> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DiscountListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }
}
