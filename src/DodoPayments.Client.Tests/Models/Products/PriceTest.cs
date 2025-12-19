using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

public class PriceTest : TestBase
{
    [Fact]
    public void OneTimeValidationWorks()
    {
        Price value = new(
            new OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                Price = 0,
                PurchasingPowerParity = true,
                Type = Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void RecurringValidationWorks()
    {
        Price value = new(
            new RecurringPrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
                Price = 0,
                PurchasingPowerParity = true,
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
                Type = RecurringPriceType.RecurringPrice,
                TaxInclusive = true,
                TrialPeriodDays = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void UsageBasedValidationWorks()
    {
        Price value = new(
            new UsageBasedPrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                FixedPrice = 0,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
                PurchasingPowerParity = true,
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
                Type = UsageBasedPriceType.UsageBasedPrice,
                Meters =
                [
                    new()
                    {
                        MeterID = "meter_id",
                        PricePerUnit = "10.50",
                        Description = "description",
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        Name = "name",
                    },
                ],
                TaxInclusive = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void OneTimeSerializationRoundtripWorks()
    {
        Price value = new(
            new OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                Price = 0,
                PurchasingPowerParity = true,
                Type = Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RecurringSerializationRoundtripWorks()
    {
        Price value = new(
            new RecurringPrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
                Price = 0,
                PurchasingPowerParity = true,
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
                Type = RecurringPriceType.RecurringPrice,
                TaxInclusive = true,
                TrialPeriodDays = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UsageBasedSerializationRoundtripWorks()
    {
        Price value = new(
            new UsageBasedPrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                FixedPrice = 0,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
                PurchasingPowerParity = true,
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
                Type = UsageBasedPriceType.UsageBasedPrice,
                Meters =
                [
                    new()
                    {
                        MeterID = "meter_id",
                        PricePerUnit = "10.50",
                        Description = "description",
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        Name = "name",
                    },
                ],
                TaxInclusive = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(element);

        Assert.Equal(value, deserialized);
    }
}

public class OneTimePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPrice = 0;
        bool expectedPurchasingPowerParity = true;
        ApiEnum<string, Type> expectedType = Type.OneTimePrice;
        bool expectedPayWhatYouWant = true;
        int expectedSuggestedPrice = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPurchasingPowerParity, model.PurchasingPowerParity);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedPayWhatYouWant, model.PayWhatYouWant);
        Assert.Equal(expectedSuggestedPrice, model.SuggestedPrice);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<OneTimePrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<OneTimePrice>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPrice = 0;
        bool expectedPurchasingPowerParity = true;
        ApiEnum<string, Type> expectedType = Type.OneTimePrice;
        bool expectedPayWhatYouWant = true;
        int expectedSuggestedPrice = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPurchasingPowerParity, deserialized.PurchasingPowerParity);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedPayWhatYouWant, deserialized.PayWhatYouWant);
        Assert.Equal(expectedSuggestedPrice, deserialized.SuggestedPrice);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        Assert.Null(model.PayWhatYouWant);
        Assert.False(model.RawData.ContainsKey("pay_what_you_want"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            SuggestedPrice = 0,
            TaxInclusive = true,

            // Null should be interpreted as omitted for these properties
            PayWhatYouWant = null,
        };

        Assert.Null(model.PayWhatYouWant);
        Assert.False(model.RawData.ContainsKey("pay_what_you_want"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            SuggestedPrice = 0,
            TaxInclusive = true,

            // Null should be interpreted as omitted for these properties
            PayWhatYouWant = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,
        };

        Assert.Null(model.SuggestedPrice);
        Assert.False(model.RawData.ContainsKey("suggested_price"));
        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,

            SuggestedPrice = null,
            TaxInclusive = null,
        };

        Assert.Null(model.SuggestedPrice);
        Assert.True(model.RawData.ContainsKey("suggested_price"));
        Assert.Null(model.TaxInclusive);
        Assert.True(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Type.OneTimePrice,
            PayWhatYouWant = true,

            SuggestedPrice = null,
            TaxInclusive = null,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.OneTimePrice)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.OneTimePrice)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RecurringPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedPaymentFrequencyInterval =
            Subscriptions::TimeInterval.Day;
        int expectedPrice = 0;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedSubscriptionPeriodInterval =
            Subscriptions::TimeInterval.Day;
        ApiEnum<string, RecurringPriceType> expectedType = RecurringPriceType.RecurringPrice;
        bool expectedTaxInclusive = true;
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedPaymentFrequencyCount, model.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, model.PaymentFrequencyInterval);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPurchasingPowerParity, model.PurchasingPowerParity);
        Assert.Equal(expectedSubscriptionPeriodCount, model.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, model.SubscriptionPeriodInterval);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTrialPeriodDays, model.TrialPeriodDays);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RecurringPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RecurringPrice>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedPaymentFrequencyInterval =
            Subscriptions::TimeInterval.Day;
        int expectedPrice = 0;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedSubscriptionPeriodInterval =
            Subscriptions::TimeInterval.Day;
        ApiEnum<string, RecurringPriceType> expectedType = RecurringPriceType.RecurringPrice;
        bool expectedTaxInclusive = true;
        int expectedTrialPeriodDays = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedPaymentFrequencyCount, deserialized.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, deserialized.PaymentFrequencyInterval);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPurchasingPowerParity, deserialized.PurchasingPowerParity);
        Assert.Equal(expectedSubscriptionPeriodCount, deserialized.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, deserialized.SubscriptionPeriodInterval);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTrialPeriodDays, deserialized.TrialPeriodDays);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,
        };

        Assert.Null(model.TrialPeriodDays);
        Assert.False(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,

            // Null should be interpreted as omitted for these properties
            TrialPeriodDays = null,
        };

        Assert.Null(model.TrialPeriodDays);
        Assert.False(model.RawData.ContainsKey("trial_period_days"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TaxInclusive = true,

            // Null should be interpreted as omitted for these properties
            TrialPeriodDays = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TrialPeriodDays = 0,
        };

        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TrialPeriodDays = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TrialPeriodDays = 0,

            TaxInclusive = null,
        };

        Assert.Null(model.TaxInclusive);
        Assert.True(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = RecurringPriceType.RecurringPrice,
            TrialPeriodDays = 0,

            TaxInclusive = null,
        };

        model.Validate();
    }
}

public class RecurringPriceTypeTest : TestBase
{
    [Theory]
    [InlineData(RecurringPriceType.RecurringPrice)]
    public void Validation_Works(RecurringPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecurringPriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecurringPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RecurringPriceType.RecurringPrice)]
    public void SerializationRoundtrip_Works(RecurringPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecurringPriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecurringPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecurringPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecurringPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UsageBasedPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                },
            ],
            TaxInclusive = true,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedFixedPrice = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedPaymentFrequencyInterval =
            Subscriptions::TimeInterval.Day;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedSubscriptionPeriodInterval =
            Subscriptions::TimeInterval.Day;
        ApiEnum<string, UsageBasedPriceType> expectedType = UsageBasedPriceType.UsageBasedPrice;
        List<AddMeterToPrice> expectedMeters =
        [
            new()
            {
                MeterID = "meter_id",
                PricePerUnit = "10.50",
                Description = "description",
                FreeThreshold = 0,
                MeasurementUnit = "measurement_unit",
                Name = "name",
            },
        ];
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedFixedPrice, model.FixedPrice);
        Assert.Equal(expectedPaymentFrequencyCount, model.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, model.PaymentFrequencyInterval);
        Assert.Equal(expectedPurchasingPowerParity, model.PurchasingPowerParity);
        Assert.Equal(expectedSubscriptionPeriodCount, model.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, model.SubscriptionPeriodInterval);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Meters);
        Assert.Equal(expectedMeters.Count, model.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], model.Meters[i]);
        }
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                },
            ],
            TaxInclusive = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                },
            ],
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedFixedPrice = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedPaymentFrequencyInterval =
            Subscriptions::TimeInterval.Day;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, Subscriptions::TimeInterval> expectedSubscriptionPeriodInterval =
            Subscriptions::TimeInterval.Day;
        ApiEnum<string, UsageBasedPriceType> expectedType = UsageBasedPriceType.UsageBasedPrice;
        List<AddMeterToPrice> expectedMeters =
        [
            new()
            {
                MeterID = "meter_id",
                PricePerUnit = "10.50",
                Description = "description",
                FreeThreshold = 0,
                MeasurementUnit = "measurement_unit",
                Name = "name",
            },
        ];
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedFixedPrice, deserialized.FixedPrice);
        Assert.Equal(expectedPaymentFrequencyCount, deserialized.PaymentFrequencyCount);
        Assert.Equal(expectedPaymentFrequencyInterval, deserialized.PaymentFrequencyInterval);
        Assert.Equal(expectedPurchasingPowerParity, deserialized.PurchasingPowerParity);
        Assert.Equal(expectedSubscriptionPeriodCount, deserialized.SubscriptionPeriodCount);
        Assert.Equal(expectedSubscriptionPeriodInterval, deserialized.SubscriptionPeriodInterval);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Meters);
        Assert.Equal(expectedMeters.Count, deserialized.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], deserialized.Meters[i]);
        }
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                },
            ],
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,
        };

        Assert.Null(model.Meters);
        Assert.False(model.RawData.ContainsKey("meters"));
        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,

            Meters = null,
            TaxInclusive = null,
        };

        Assert.Null(model.Meters);
        Assert.True(model.RawData.ContainsKey("meters"));
        Assert.Null(model.TaxInclusive);
        Assert.True(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = Subscriptions::TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = Subscriptions::TimeInterval.Day,
            Type = UsageBasedPriceType.UsageBasedPrice,

            Meters = null,
            TaxInclusive = null,
        };

        model.Validate();
    }
}

public class UsageBasedPriceTypeTest : TestBase
{
    [Theory]
    [InlineData(UsageBasedPriceType.UsageBasedPrice)]
    public void Validation_Works(UsageBasedPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageBasedPriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageBasedPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageBasedPriceType.UsageBasedPrice)]
    public void SerializationRoundtrip_Works(UsageBasedPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageBasedPriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageBasedPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageBasedPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UsageBasedPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
