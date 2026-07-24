using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Misc;

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
                    CustomerEligibility = DiscountCustomerEligibility.Any,
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Flat,
                    CurrencyOptions =
                    [
                        new()
                        {
                            Currency = Currency.Aed,
                            IsDefault = true,
                            MinimumSubtotal = 0,
                            MaxAmountPossible = 0,
                        },
                    ],
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PerCustomerUsageLimit = 0,
                    StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                CustomerEligibility = DiscountCustomerEligibility.Any,
                DiscountID = "discount_id",
                Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                PreserveOnPlanChange = true,
                RestrictedTo = ["string"],
                TimesUsed = 0,
                Type = DiscountType.Flat,
                CurrencyOptions =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        IsDefault = true,
                        MinimumSubtotal = 0,
                        MaxAmountPossible = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PerCustomerUsageLimit = 0,
                StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    CustomerEligibility = DiscountCustomerEligibility.Any,
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Flat,
                    CurrencyOptions =
                    [
                        new()
                        {
                            Currency = Currency.Aed,
                            IsDefault = true,
                            MinimumSubtotal = 0,
                            MaxAmountPossible = 0,
                        },
                    ],
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PerCustomerUsageLimit = 0,
                    StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
                    CustomerEligibility = DiscountCustomerEligibility.Any,
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Flat,
                    CurrencyOptions =
                    [
                        new()
                        {
                            Currency = Currency.Aed,
                            IsDefault = true,
                            MinimumSubtotal = 0,
                            MaxAmountPossible = 0,
                        },
                    ],
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PerCustomerUsageLimit = 0,
                    StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Discount> expectedItems =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Code = "code",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerEligibility = DiscountCustomerEligibility.Any,
                DiscountID = "discount_id",
                Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                PreserveOnPlanChange = true,
                RestrictedTo = ["string"],
                TimesUsed = 0,
                Type = DiscountType.Flat,
                CurrencyOptions =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        IsDefault = true,
                        MinimumSubtotal = 0,
                        MaxAmountPossible = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PerCustomerUsageLimit = 0,
                StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    CustomerEligibility = DiscountCustomerEligibility.Any,
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Flat,
                    CurrencyOptions =
                    [
                        new()
                        {
                            Currency = Currency.Aed,
                            IsDefault = true,
                            MinimumSubtotal = 0,
                            MaxAmountPossible = 0,
                        },
                    ],
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PerCustomerUsageLimit = 0,
                    StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
                    CustomerEligibility = DiscountCustomerEligibility.Any,
                    DiscountID = "discount_id",
                    Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
                    PreserveOnPlanChange = true,
                    RestrictedTo = ["string"],
                    TimesUsed = 0,
                    Type = DiscountType.Flat,
                    CurrencyOptions =
                    [
                        new()
                        {
                            Currency = Currency.Aed,
                            IsDefault = true,
                            MinimumSubtotal = 0,
                            MaxAmountPossible = 0,
                        },
                    ],
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PerCustomerUsageLimit = 0,
                    StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SubscriptionCycles = 0,
                    UsageLimit = 0,
                },
            ],
        };

        DiscountListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
