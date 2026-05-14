using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

public class PriceTest : TestBase
{
    [Fact]
    public void OneTimeValidationWorks()
    {
        Price value = new OneTimePrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };
        value.Validate();
    }

    [Fact]
    public void RecurringValidationWorks()
    {
        Price value = new RecurringPrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };
        value.Validate();
    }

    [Fact]
    public void UsageBasedValidationWorks()
    {
        Price value = new UsageBasedPrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
                },
            ],
            TaxInclusive = true,
        };
        value.Validate();
    }

    [Fact]
    public void OneTimeSerializationRoundtripWorks()
    {
        Price value = new OneTimePrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RecurringSerializationRoundtripWorks()
    {
        Price value = new RecurringPrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UsageBasedSerializationRoundtripWorks()
    {
        Price value = new UsageBasedPrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
                },
            ],
            TaxInclusive = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);

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
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPriceValue = 0;
        bool expectedPurchasingPowerParity = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("one_time_price");
        bool expectedPayWhatYouWant = true;
        int expectedSuggestedPrice = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedPriceValue, model.PriceValue);
        Assert.Equal(expectedPurchasingPowerParity, model.PurchasingPowerParity);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OneTimePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OneTimePrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPriceValue = 0;
        bool expectedPurchasingPowerParity = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("one_time_price");
        bool expectedPayWhatYouWant = true;
        int expectedSuggestedPrice = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedPriceValue, deserialized.PriceValue);
        Assert.Equal(expectedPurchasingPowerParity, deserialized.PurchasingPowerParity);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
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
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,

            SuggestedPrice = null,
            TaxInclusive = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OneTimePrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PriceValue = 0,
            PurchasingPowerParity = true,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };

        OneTimePrice copied = new(model);

        Assert.Equal(model, copied);
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, TimeInterval> expectedPaymentFrequencyInterval = TimeInterval.Day;
        int expectedPrice = 0;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, TimeInterval> expectedSubscriptionPeriodInterval = TimeInterval.Day;
        JsonElement expectedType = JsonSerializer.SerializeToElement("recurring_price");
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
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringPrice>(
            json,
            ModelBase.SerializerOptions
        );

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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, TimeInterval> expectedPaymentFrequencyInterval = TimeInterval.Day;
        int expectedPrice = 0;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, TimeInterval> expectedSubscriptionPeriodInterval = TimeInterval.Day;
        JsonElement expectedType = JsonSerializer.SerializeToElement("recurring_price");
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
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TrialPeriodDays = 0,

            TaxInclusive = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurringPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            Price = 0,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
        };

        RecurringPrice copied = new(model);

        Assert.Equal(model, copied);
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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
                },
            ],
            TaxInclusive = true,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedFixedPrice = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, TimeInterval> expectedPaymentFrequencyInterval = TimeInterval.Day;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, TimeInterval> expectedSubscriptionPeriodInterval = TimeInterval.Day;
        JsonElement expectedType = JsonSerializer.SerializeToElement("usage_based_price");
        List<AddMeterToPrice> expectedMeters =
        [
            new()
            {
                MeterID = "meter_id",
                CreditEntitlementID = "credit_entitlement_id",
                Description = "description",
                FreeThreshold = 0,
                MeasurementUnit = "measurement_unit",
                MeterUnitsPerCredit = "meter_units_per_credit",
                Name = "name",
                PricePerUnit = "10.50",
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
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
                },
            ],
            TaxInclusive = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(
            json,
            ModelBase.SerializerOptions
        );

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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
                },
            ],
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageBasedPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedDiscount = 0;
        int expectedFixedPrice = 0;
        int expectedPaymentFrequencyCount = 0;
        ApiEnum<string, TimeInterval> expectedPaymentFrequencyInterval = TimeInterval.Day;
        bool expectedPurchasingPowerParity = true;
        int expectedSubscriptionPeriodCount = 0;
        ApiEnum<string, TimeInterval> expectedSubscriptionPeriodInterval = TimeInterval.Day;
        JsonElement expectedType = JsonSerializer.SerializeToElement("usage_based_price");
        List<AddMeterToPrice> expectedMeters =
        [
            new()
            {
                MeterID = "meter_id",
                CreditEntitlementID = "credit_entitlement_id",
                Description = "description",
                FreeThreshold = 0,
                MeasurementUnit = "measurement_unit",
                MeterUnitsPerCredit = "meter_units_per_credit",
                Name = "name",
                PricePerUnit = "10.50",
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
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,

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
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,

            Meters = null,
            TaxInclusive = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageBasedPrice
        {
            Currency = Currency.Aed,
            Discount = 0,
            FixedPrice = 0,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            PurchasingPowerParity = true,
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            Meters =
            [
                new()
                {
                    MeterID = "meter_id",
                    CreditEntitlementID = "credit_entitlement_id",
                    Description = "description",
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterUnitsPerCredit = "meter_units_per_credit",
                    Name = "name",
                    PricePerUnit = "10.50",
                },
            ],
            TaxInclusive = true,
        };

        UsageBasedPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}
