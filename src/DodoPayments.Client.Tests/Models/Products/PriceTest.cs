using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Products;

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
        Assert.Equal(expectedMeters.Count, model.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], model.Meters[i]);
        }
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }
}
