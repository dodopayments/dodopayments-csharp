using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Misc;

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
        };

        int expectedAmount = 0;
        string expectedBusinessID = "business_id";
        string expectedCode = "code";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DiscountCustomerEligibility> expectedCustomerEligibility =
            DiscountCustomerEligibility.Any;
        string expectedDiscountID = "discount_id";
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        bool expectedPreserveOnPlanChange = true;
        List<string> expectedRestrictedTo = ["string"];
        int expectedTimesUsed = 0;
        ApiEnum<string, DiscountType> expectedType = DiscountType.Flat;
        List<DiscountCurrencyOption> expectedCurrencyOptions =
        [
            new()
            {
                Currency = Currency.Aed,
                IsDefault = true,
                MinimumSubtotal = 0,
                MaxAmountPossible = 0,
            },
        ];
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        int expectedPerCustomerUsageLimit = 0;
        DateTimeOffset expectedStartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedSubscriptionCycles = 0;
        int expectedUsageLimit = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerEligibility, model.CustomerEligibility);
        Assert.Equal(expectedDiscountID, model.DiscountID);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPreserveOnPlanChange, model.PreserveOnPlanChange);
        Assert.Equal(expectedRestrictedTo.Count, model.RestrictedTo.Count);
        for (int i = 0; i < expectedRestrictedTo.Count; i++)
        {
            Assert.Equal(expectedRestrictedTo[i], model.RestrictedTo[i]);
        }
        Assert.Equal(expectedTimesUsed, model.TimesUsed);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.CurrencyOptions);
        Assert.Equal(expectedCurrencyOptions.Count, model.CurrencyOptions.Count);
        for (int i = 0; i < expectedCurrencyOptions.Count; i++)
        {
            Assert.Equal(expectedCurrencyOptions[i], model.CurrencyOptions[i]);
        }
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPerCustomerUsageLimit, model.PerCustomerUsageLimit);
        Assert.Equal(expectedStartsAt, model.StartsAt);
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Discount>(json, ModelBase.SerializerOptions);

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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Discount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedAmount = 0;
        string expectedBusinessID = "business_id";
        string expectedCode = "code";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DiscountCustomerEligibility> expectedCustomerEligibility =
            DiscountCustomerEligibility.Any;
        string expectedDiscountID = "discount_id";
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        bool expectedPreserveOnPlanChange = true;
        List<string> expectedRestrictedTo = ["string"];
        int expectedTimesUsed = 0;
        ApiEnum<string, DiscountType> expectedType = DiscountType.Flat;
        List<DiscountCurrencyOption> expectedCurrencyOptions =
        [
            new()
            {
                Currency = Currency.Aed,
                IsDefault = true,
                MinimumSubtotal = 0,
                MaxAmountPossible = 0,
            },
        ];
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        int expectedPerCustomerUsageLimit = 0;
        DateTimeOffset expectedStartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedSubscriptionCycles = 0;
        int expectedUsageLimit = 0;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerEligibility, deserialized.CustomerEligibility);
        Assert.Equal(expectedDiscountID, deserialized.DiscountID);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPreserveOnPlanChange, deserialized.PreserveOnPlanChange);
        Assert.Equal(expectedRestrictedTo.Count, deserialized.RestrictedTo.Count);
        for (int i = 0; i < expectedRestrictedTo.Count; i++)
        {
            Assert.Equal(expectedRestrictedTo[i], deserialized.RestrictedTo[i]);
        }
        Assert.Equal(expectedTimesUsed, deserialized.TimesUsed);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.CurrencyOptions);
        Assert.Equal(expectedCurrencyOptions.Count, deserialized.CurrencyOptions.Count);
        for (int i = 0; i < expectedCurrencyOptions.Count; i++)
        {
            Assert.Equal(expectedCurrencyOptions[i], deserialized.CurrencyOptions[i]);
        }
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPerCustomerUsageLimit, deserialized.PerCustomerUsageLimit);
        Assert.Equal(expectedStartsAt, deserialized.StartsAt);
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Discount
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PerCustomerUsageLimit = 0,
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionCycles = 0,
            UsageLimit = 0,
        };

        Assert.Null(model.CurrencyOptions);
        Assert.False(model.RawData.ContainsKey("currency_options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Discount
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PerCustomerUsageLimit = 0,
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionCycles = 0,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Discount
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PerCustomerUsageLimit = 0,
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionCycles = 0,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrencyOptions = null,
        };

        Assert.Null(model.CurrencyOptions);
        Assert.False(model.RawData.ContainsKey("currency_options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Discount
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PerCustomerUsageLimit = 0,
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionCycles = 0,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrencyOptions = null,
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
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PerCustomerUsageLimit);
        Assert.False(model.RawData.ContainsKey("per_customer_usage_limit"));
        Assert.Null(model.StartsAt);
        Assert.False(model.RawData.ContainsKey("starts_at"));
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

            ExpiresAt = null,
            Name = null,
            PerCustomerUsageLimit = null,
            StartsAt = null,
            SubscriptionCycles = null,
            UsageLimit = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.PerCustomerUsageLimit);
        Assert.True(model.RawData.ContainsKey("per_customer_usage_limit"));
        Assert.Null(model.StartsAt);
        Assert.True(model.RawData.ContainsKey("starts_at"));
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

            ExpiresAt = null,
            Name = null,
            PerCustomerUsageLimit = null,
            StartsAt = null,
            SubscriptionCycles = null,
            UsageLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Discount
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
        };

        Discount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscountCustomerEligibilityTest : TestBase
{
    [Theory]
    [InlineData(DiscountCustomerEligibility.Any)]
    [InlineData(DiscountCustomerEligibility.FirstTime)]
    [InlineData(DiscountCustomerEligibility.Existing)]
    [InlineData(DiscountCustomerEligibility.Specific)]
    public void Validation_Works(DiscountCustomerEligibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountCustomerEligibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountCustomerEligibility>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DiscountCustomerEligibility.Any)]
    [InlineData(DiscountCustomerEligibility.FirstTime)]
    [InlineData(DiscountCustomerEligibility.Existing)]
    [InlineData(DiscountCustomerEligibility.Specific)]
    public void SerializationRoundtrip_Works(DiscountCustomerEligibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountCustomerEligibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountCustomerEligibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountCustomerEligibility>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountCustomerEligibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DiscountCurrencyOptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
            MaxAmountPossible = 0,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        bool expectedIsDefault = true;
        int expectedMinimumSubtotal = 0;
        int expectedMaxAmountPossible = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedMinimumSubtotal, model.MinimumSubtotal);
        Assert.Equal(expectedMaxAmountPossible, model.MaxAmountPossible);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
            MaxAmountPossible = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountCurrencyOption>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
            MaxAmountPossible = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountCurrencyOption>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        bool expectedIsDefault = true;
        int expectedMinimumSubtotal = 0;
        int expectedMaxAmountPossible = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedMinimumSubtotal, deserialized.MinimumSubtotal);
        Assert.Equal(expectedMaxAmountPossible, deserialized.MaxAmountPossible);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
            MaxAmountPossible = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
        };

        Assert.Null(model.MaxAmountPossible);
        Assert.False(model.RawData.ContainsKey("max_amount_possible"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,

            MaxAmountPossible = null,
        };

        Assert.Null(model.MaxAmountPossible);
        Assert.True(model.RawData.ContainsKey("max_amount_possible"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,

            MaxAmountPossible = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DiscountCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MinimumSubtotal = 0,
            MaxAmountPossible = 0,
        };

        DiscountCurrencyOption copied = new(model);

        Assert.Equal(model, copied);
    }
}
