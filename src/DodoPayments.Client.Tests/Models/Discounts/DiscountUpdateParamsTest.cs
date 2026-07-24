using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Discounts;

public class DiscountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DiscountUpdateParams
        {
            DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9",
            Amount = 0,
            Code = "code",
            CurrencyOptions =
            [
                new()
                {
                    Currency = Currency.Aed,
                    IsDefault = true,
                    MaxAmountPossible = 0,
                    MinimumSubtotal = 0,
                },
            ],
            CustomerEligibility = DiscountUpdateParamsCustomerEligibility.Any,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            Name = "name",
            PerCustomerUsageLimit = 0,
            PreserveOnPlanChange = true,
            RestrictedTo = ["string"],
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionCycles = 0,
            Type = DiscountType.Flat,
            UsageLimit = 0,
        };

        string expectedDiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9";
        int expectedAmount = 0;
        string expectedCode = "code";
        List<DiscountUpdateParamsCurrencyOption> expectedCurrencyOptions =
        [
            new()
            {
                Currency = Currency.Aed,
                IsDefault = true,
                MaxAmountPossible = 0,
                MinimumSubtotal = 0,
            },
        ];
        ApiEnum<string, DiscountUpdateParamsCustomerEligibility> expectedCustomerEligibility =
            DiscountUpdateParamsCustomerEligibility.Any;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        int expectedPerCustomerUsageLimit = 0;
        bool expectedPreserveOnPlanChange = true;
        List<string> expectedRestrictedTo = ["string"];
        DateTimeOffset expectedStartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedSubscriptionCycles = 0;
        ApiEnum<string, DiscountType> expectedType = DiscountType.Flat;
        int expectedUsageLimit = 0;

        Assert.Equal(expectedDiscountID, parameters.DiscountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCode, parameters.Code);
        Assert.NotNull(parameters.CurrencyOptions);
        Assert.Equal(expectedCurrencyOptions.Count, parameters.CurrencyOptions.Count);
        for (int i = 0; i < expectedCurrencyOptions.Count; i++)
        {
            Assert.Equal(expectedCurrencyOptions[i], parameters.CurrencyOptions[i]);
        }
        Assert.Equal(expectedCustomerEligibility, parameters.CustomerEligibility);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPerCustomerUsageLimit, parameters.PerCustomerUsageLimit);
        Assert.Equal(expectedPreserveOnPlanChange, parameters.PreserveOnPlanChange);
        Assert.NotNull(parameters.RestrictedTo);
        Assert.Equal(expectedRestrictedTo.Count, parameters.RestrictedTo.Count);
        for (int i = 0; i < expectedRestrictedTo.Count; i++)
        {
            Assert.Equal(expectedRestrictedTo[i], parameters.RestrictedTo[i]);
        }
        Assert.Equal(expectedStartsAt, parameters.StartsAt);
        Assert.Equal(expectedSubscriptionCycles, parameters.SubscriptionCycles);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedUsageLimit, parameters.UsageLimit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DiscountUpdateParams { DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9" };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Code);
        Assert.False(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.CurrencyOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_options"));
        Assert.Null(parameters.CustomerEligibility);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_eligibility"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PerCustomerUsageLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("per_customer_usage_limit"));
        Assert.Null(parameters.PreserveOnPlanChange);
        Assert.False(parameters.RawBodyData.ContainsKey("preserve_on_plan_change"));
        Assert.Null(parameters.RestrictedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("restricted_to"));
        Assert.Null(parameters.StartsAt);
        Assert.False(parameters.RawBodyData.ContainsKey("starts_at"));
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
            DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9",

            Amount = null,
            Code = null,
            CurrencyOptions = null,
            CustomerEligibility = null,
            ExpiresAt = null,
            Metadata = null,
            Name = null,
            PerCustomerUsageLimit = null,
            PreserveOnPlanChange = null,
            RestrictedTo = null,
            StartsAt = null,
            SubscriptionCycles = null,
            Type = null,
            UsageLimit = null,
        };

        Assert.Null(parameters.Amount);
        Assert.True(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Code);
        Assert.True(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.CurrencyOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("currency_options"));
        Assert.Null(parameters.CustomerEligibility);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_eligibility"));
        Assert.Null(parameters.ExpiresAt);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PerCustomerUsageLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("per_customer_usage_limit"));
        Assert.Null(parameters.PreserveOnPlanChange);
        Assert.True(parameters.RawBodyData.ContainsKey("preserve_on_plan_change"));
        Assert.Null(parameters.RestrictedTo);
        Assert.True(parameters.RawBodyData.ContainsKey("restricted_to"));
        Assert.Null(parameters.StartsAt);
        Assert.True(parameters.RawBodyData.ContainsKey("starts_at"));
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
        DiscountUpdateParams parameters = new() { DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/discounts/dsc_qxxEmg5PuM1uNTE0LgkP9"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DiscountUpdateParams
        {
            DiscountID = "dsc_qxxEmg5PuM1uNTE0LgkP9",
            Amount = 0,
            Code = "code",
            CurrencyOptions =
            [
                new()
                {
                    Currency = Currency.Aed,
                    IsDefault = true,
                    MaxAmountPossible = 0,
                    MinimumSubtotal = 0,
                },
            ],
            CustomerEligibility = DiscountUpdateParamsCustomerEligibility.Any,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
            Name = "name",
            PerCustomerUsageLimit = 0,
            PreserveOnPlanChange = true,
            RestrictedTo = ["string"],
            StartsAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionCycles = 0,
            Type = DiscountType.Flat,
            UsageLimit = 0,
        };

        DiscountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DiscountUpdateParamsCurrencyOptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MaxAmountPossible = 0,
            MinimumSubtotal = 0,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        bool expectedIsDefault = true;
        int expectedMaxAmountPossible = 0;
        int expectedMinimumSubtotal = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedMaxAmountPossible, model.MaxAmountPossible);
        Assert.Equal(expectedMinimumSubtotal, model.MinimumSubtotal);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MaxAmountPossible = 0,
            MinimumSubtotal = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountUpdateParamsCurrencyOption>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MaxAmountPossible = 0,
            MinimumSubtotal = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountUpdateParamsCurrencyOption>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        bool expectedIsDefault = true;
        int expectedMaxAmountPossible = 0;
        int expectedMinimumSubtotal = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedMaxAmountPossible, deserialized.MaxAmountPossible);
        Assert.Equal(expectedMinimumSubtotal, deserialized.MinimumSubtotal);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MaxAmountPossible = 0,
            MinimumSubtotal = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            MaxAmountPossible = 0,
        };

        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.MinimumSubtotal);
        Assert.False(model.RawData.ContainsKey("minimum_subtotal"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            MaxAmountPossible = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            MaxAmountPossible = 0,

            // Null should be interpreted as omitted for these properties
            IsDefault = null,
            MinimumSubtotal = null,
        };

        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.MinimumSubtotal);
        Assert.False(model.RawData.ContainsKey("minimum_subtotal"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            MaxAmountPossible = 0,

            // Null should be interpreted as omitted for these properties
            IsDefault = null,
            MinimumSubtotal = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiscountUpdateParamsCurrencyOption
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
        var model = new DiscountUpdateParamsCurrencyOption
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
        var model = new DiscountUpdateParamsCurrencyOption
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
        var model = new DiscountUpdateParamsCurrencyOption
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
        var model = new DiscountUpdateParamsCurrencyOption
        {
            Currency = Currency.Aed,
            IsDefault = true,
            MaxAmountPossible = 0,
            MinimumSubtotal = 0,
        };

        DiscountUpdateParamsCurrencyOption copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscountUpdateParamsCustomerEligibilityTest : TestBase
{
    [Theory]
    [InlineData(DiscountUpdateParamsCustomerEligibility.Any)]
    [InlineData(DiscountUpdateParamsCustomerEligibility.FirstTime)]
    [InlineData(DiscountUpdateParamsCustomerEligibility.Existing)]
    [InlineData(DiscountUpdateParamsCustomerEligibility.Specific)]
    public void Validation_Works(DiscountUpdateParamsCustomerEligibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountUpdateParamsCustomerEligibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DiscountUpdateParamsCustomerEligibility>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DiscountUpdateParamsCustomerEligibility.Any)]
    [InlineData(DiscountUpdateParamsCustomerEligibility.FirstTime)]
    [InlineData(DiscountUpdateParamsCustomerEligibility.Existing)]
    [InlineData(DiscountUpdateParamsCustomerEligibility.Specific)]
    public void SerializationRoundtrip_Works(DiscountUpdateParamsCustomerEligibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountUpdateParamsCustomerEligibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DiscountUpdateParamsCustomerEligibility>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DiscountUpdateParamsCustomerEligibility>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DiscountUpdateParamsCustomerEligibility>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
