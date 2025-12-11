using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionPreviewChangePlanResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewChangePlanResponse
        {
            ImmediateCharge = new()
            {
                LineItems =
                [
                    new UnionMember0()
                    {
                        ID = "id",
                        Currency = Currency.Aed,
                        ProductID = "product_id",
                        ProrationFactor = 0,
                        Quantity = 0,
                        TaxInclusive = true,
                        Type = UnionMember0Type.Subscription,
                        UnitPrice = 0,
                        Description = "description",
                        Name = "name",
                        Tax = 0,
                        TaxRate = 0,
                    },
                ],
                Summary = new()
                {
                    Currency = Currency.Aed,
                    CustomerCredits = 0,
                    SettlementAmount = 0,
                    SettlementCurrency = Currency.Aed,
                    TotalAmount = 0,
                    SettlementTax = 0,
                    Tax = 0,
                },
            },
            NewPlan = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
        };

        ImmediateCharge expectedImmediateCharge = new()
        {
            LineItems =
            [
                new UnionMember0()
                {
                    ID = "id",
                    Currency = Currency.Aed,
                    ProductID = "product_id",
                    ProrationFactor = 0,
                    Quantity = 0,
                    TaxInclusive = true,
                    Type = UnionMember0Type.Subscription,
                    UnitPrice = 0,
                    Description = "description",
                    Name = "name",
                    Tax = 0,
                    TaxRate = 0,
                },
            ],
            Summary = new()
            {
                Currency = Currency.Aed,
                CustomerCredits = 0,
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                SettlementTax = 0,
                Tax = 0,
            },
        };
        Subscription expectedNewPlan = new()
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CancelAtNextBillingDate = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnDemand = true,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        Assert.Equal(expectedImmediateCharge, model.ImmediateCharge);
        Assert.Equal(expectedNewPlan, model.NewPlan);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewChangePlanResponse
        {
            ImmediateCharge = new()
            {
                LineItems =
                [
                    new UnionMember0()
                    {
                        ID = "id",
                        Currency = Currency.Aed,
                        ProductID = "product_id",
                        ProrationFactor = 0,
                        Quantity = 0,
                        TaxInclusive = true,
                        Type = UnionMember0Type.Subscription,
                        UnitPrice = 0,
                        Description = "description",
                        Name = "name",
                        Tax = 0,
                        TaxRate = 0,
                    },
                ],
                Summary = new()
                {
                    Currency = Currency.Aed,
                    CustomerCredits = 0,
                    SettlementAmount = 0,
                    SettlementCurrency = Currency.Aed,
                    TotalAmount = 0,
                    SettlementTax = 0,
                    Tax = 0,
                },
            },
            NewPlan = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewChangePlanResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewChangePlanResponse
        {
            ImmediateCharge = new()
            {
                LineItems =
                [
                    new UnionMember0()
                    {
                        ID = "id",
                        Currency = Currency.Aed,
                        ProductID = "product_id",
                        ProrationFactor = 0,
                        Quantity = 0,
                        TaxInclusive = true,
                        Type = UnionMember0Type.Subscription,
                        UnitPrice = 0,
                        Description = "description",
                        Name = "name",
                        Tax = 0,
                        TaxRate = 0,
                    },
                ],
                Summary = new()
                {
                    Currency = Currency.Aed,
                    CustomerCredits = 0,
                    SettlementAmount = 0,
                    SettlementCurrency = Currency.Aed,
                    TotalAmount = 0,
                    SettlementTax = 0,
                    Tax = 0,
                },
            },
            NewPlan = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewChangePlanResponse>(json);
        Assert.NotNull(deserialized);

        ImmediateCharge expectedImmediateCharge = new()
        {
            LineItems =
            [
                new UnionMember0()
                {
                    ID = "id",
                    Currency = Currency.Aed,
                    ProductID = "product_id",
                    ProrationFactor = 0,
                    Quantity = 0,
                    TaxInclusive = true,
                    Type = UnionMember0Type.Subscription,
                    UnitPrice = 0,
                    Description = "description",
                    Name = "name",
                    Tax = 0,
                    TaxRate = 0,
                },
            ],
            Summary = new()
            {
                Currency = Currency.Aed,
                CustomerCredits = 0,
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                SettlementTax = 0,
                Tax = 0,
            },
        };
        Subscription expectedNewPlan = new()
        {
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CancelAtNextBillingDate = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meters =
            [
                new()
                {
                    Currency = Currency.Aed,
                    FreeThreshold = 0,
                    MeasurementUnit = "measurement_unit",
                    MeterID = "meter_id",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                },
            ],
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnDemand = true,
            PaymentFrequencyCount = 0,
            PaymentFrequencyInterval = TimeInterval.Day,
            PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            RecurringPreTaxAmount = 0,
            Status = SubscriptionStatus.Pending,
            SubscriptionID = "subscription_id",
            SubscriptionPeriodCount = 0,
            SubscriptionPeriodInterval = TimeInterval.Day,
            TaxInclusive = true,
            TrialPeriodDays = 0,
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DiscountCyclesRemaining = 0,
            DiscountID = "discount_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentMethodID = "payment_method_id",
            TaxID = "tax_id",
        };

        Assert.Equal(expectedImmediateCharge, deserialized.ImmediateCharge);
        Assert.Equal(expectedNewPlan, deserialized.NewPlan);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewChangePlanResponse
        {
            ImmediateCharge = new()
            {
                LineItems =
                [
                    new UnionMember0()
                    {
                        ID = "id",
                        Currency = Currency.Aed,
                        ProductID = "product_id",
                        ProrationFactor = 0,
                        Quantity = 0,
                        TaxInclusive = true,
                        Type = UnionMember0Type.Subscription,
                        UnitPrice = 0,
                        Description = "description",
                        Name = "name",
                        Tax = 0,
                        TaxRate = 0,
                    },
                ],
                Summary = new()
                {
                    Currency = Currency.Aed,
                    CustomerCredits = 0,
                    SettlementAmount = 0,
                    SettlementCurrency = Currency.Aed,
                    TotalAmount = 0,
                    SettlementTax = 0,
                    Tax = 0,
                },
            },
            NewPlan = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                TaxID = "tax_id",
            },
        };

        model.Validate();
    }
}

public class ImmediateChargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImmediateCharge
        {
            LineItems =
            [
                new UnionMember0()
                {
                    ID = "id",
                    Currency = Currency.Aed,
                    ProductID = "product_id",
                    ProrationFactor = 0,
                    Quantity = 0,
                    TaxInclusive = true,
                    Type = UnionMember0Type.Subscription,
                    UnitPrice = 0,
                    Description = "description",
                    Name = "name",
                    Tax = 0,
                    TaxRate = 0,
                },
            ],
            Summary = new()
            {
                Currency = Currency.Aed,
                CustomerCredits = 0,
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                SettlementTax = 0,
                Tax = 0,
            },
        };

        List<LineItem> expectedLineItems =
        [
            new UnionMember0()
            {
                ID = "id",
                Currency = Currency.Aed,
                ProductID = "product_id",
                ProrationFactor = 0,
                Quantity = 0,
                TaxInclusive = true,
                Type = UnionMember0Type.Subscription,
                UnitPrice = 0,
                Description = "description",
                Name = "name",
                Tax = 0,
                TaxRate = 0,
            },
        ];
        Summary expectedSummary = new()
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            SettlementTax = 0,
            Tax = 0,
        };

        Assert.Equal(expectedLineItems.Count, model.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], model.LineItems[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImmediateCharge
        {
            LineItems =
            [
                new UnionMember0()
                {
                    ID = "id",
                    Currency = Currency.Aed,
                    ProductID = "product_id",
                    ProrationFactor = 0,
                    Quantity = 0,
                    TaxInclusive = true,
                    Type = UnionMember0Type.Subscription,
                    UnitPrice = 0,
                    Description = "description",
                    Name = "name",
                    Tax = 0,
                    TaxRate = 0,
                },
            ],
            Summary = new()
            {
                Currency = Currency.Aed,
                CustomerCredits = 0,
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                SettlementTax = 0,
                Tax = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImmediateCharge>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImmediateCharge
        {
            LineItems =
            [
                new UnionMember0()
                {
                    ID = "id",
                    Currency = Currency.Aed,
                    ProductID = "product_id",
                    ProrationFactor = 0,
                    Quantity = 0,
                    TaxInclusive = true,
                    Type = UnionMember0Type.Subscription,
                    UnitPrice = 0,
                    Description = "description",
                    Name = "name",
                    Tax = 0,
                    TaxRate = 0,
                },
            ],
            Summary = new()
            {
                Currency = Currency.Aed,
                CustomerCredits = 0,
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                SettlementTax = 0,
                Tax = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImmediateCharge>(json);
        Assert.NotNull(deserialized);

        List<LineItem> expectedLineItems =
        [
            new UnionMember0()
            {
                ID = "id",
                Currency = Currency.Aed,
                ProductID = "product_id",
                ProrationFactor = 0,
                Quantity = 0,
                TaxInclusive = true,
                Type = UnionMember0Type.Subscription,
                UnitPrice = 0,
                Description = "description",
                Name = "name",
                Tax = 0,
                TaxRate = 0,
            },
        ];
        Summary expectedSummary = new()
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            SettlementTax = 0,
            Tax = 0,
        };

        Assert.Equal(expectedLineItems.Count, deserialized.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], deserialized.LineItems[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImmediateCharge
        {
            LineItems =
            [
                new UnionMember0()
                {
                    ID = "id",
                    Currency = Currency.Aed,
                    ProductID = "product_id",
                    ProrationFactor = 0,
                    Quantity = 0,
                    TaxInclusive = true,
                    Type = UnionMember0Type.Subscription,
                    UnitPrice = 0,
                    Description = "description",
                    Name = "name",
                    Tax = 0,
                    TaxRate = 0,
                },
            ],
            Summary = new()
            {
                Currency = Currency.Aed,
                CustomerCredits = 0,
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                SettlementTax = 0,
                Tax = 0,
            },
        };

        model.Validate();
    }
}

public class UnionMember0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,
            Description = "description",
            Name = "name",
            Tax = 0,
            TaxRate = 0,
        };

        string expectedID = "id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedProductID = "product_id";
        double expectedProrationFactor = 0;
        int expectedQuantity = 0;
        bool expectedTaxInclusive = true;
        ApiEnum<string, UnionMember0Type> expectedType = UnionMember0Type.Subscription;
        int expectedUnitPrice = 0;
        string expectedDescription = "description";
        string expectedName = "name";
        int expectedTax = 0;
        float expectedTaxRate = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedProrationFactor, model.ProrationFactor);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedTaxRate, model.TaxRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,
            Description = "description",
            Name = "name",
            Tax = 0,
            TaxRate = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,
            Description = "description",
            Name = "name",
            Tax = 0,
            TaxRate = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedProductID = "product_id";
        double expectedProrationFactor = 0;
        int expectedQuantity = 0;
        bool expectedTaxInclusive = true;
        ApiEnum<string, UnionMember0Type> expectedType = UnionMember0Type.Subscription;
        int expectedUnitPrice = 0;
        string expectedDescription = "description";
        string expectedName = "name";
        int expectedTax = 0;
        float expectedTaxRate = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedProrationFactor, deserialized.ProrationFactor);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,
            Description = "description",
            Name = "name",
            Tax = 0,
            TaxRate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
        Assert.Null(model.TaxRate);
        Assert.False(model.RawData.ContainsKey("tax_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,

            Description = null,
            Name = null,
            Tax = null,
            TaxRate = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
        Assert.Null(model.TaxRate);
        Assert.True(model.RawData.ContainsKey("tax_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember0
        {
            ID = "id",
            Currency = Currency.Aed,
            ProductID = "product_id",
            ProrationFactor = 0,
            Quantity = 0,
            TaxInclusive = true,
            Type = UnionMember0Type.Subscription,
            UnitPrice = 0,

            Description = null,
            Name = null,
            Tax = null,
            TaxRate = null,
        };

        model.Validate();
    }
}

public class UnionMember0TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember0Type.Subscription)]
    public void Validation_Works(UnionMember0Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember0Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember0Type.Subscription)]
    public void SerializationRoundtrip_Works(UnionMember0Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember0Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,
            Description = "description",
            Tax = 0,
        };

        string expectedID = "id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedName = "name";
        double expectedProrationFactor = 0;
        int expectedQuantity = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;
        float expectedTaxRate = 0;
        ApiEnum<string, UnionMember1Type> expectedType = UnionMember1Type.Addon;
        int expectedUnitPrice = 0;
        string expectedDescription = "description";
        int expectedTax = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProrationFactor, model.ProrationFactor);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTaxRate, model.TaxRate);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,
            Description = "description",
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,
            Description = "description",
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedName = "name";
        double expectedProrationFactor = 0;
        int expectedQuantity = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;
        float expectedTaxRate = 0;
        ApiEnum<string, UnionMember1Type> expectedType = UnionMember1Type.Addon;
        int expectedUnitPrice = 0;
        string expectedDescription = "description";
        int expectedTax = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProrationFactor, deserialized.ProrationFactor);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,
            Description = "description",
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,

            Description = null,
            Tax = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember1
        {
            ID = "id",
            Currency = Currency.Aed,
            Name = "name",
            ProrationFactor = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember1Type.Addon,
            UnitPrice = 0,

            Description = null,
            Tax = null,
        };

        model.Validate();
    }
}

public class UnionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember1Type.Addon)]
    public void Validation_Works(UnionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember1Type.Addon)]
    public void SerializationRoundtrip_Works(UnionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",
            Description = "description",
            Tax = 0,
        };

        string expectedID = "id";
        string expectedChargeableUnits = "chargeable_units";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedName = "name";
        string expectedPricePerUnit = "price_per_unit";
        int expectedSubtotal = 0;
        bool expectedTaxInclusive = true;
        float expectedTaxRate = 0;
        ApiEnum<string, UnionMember2Type> expectedType = UnionMember2Type.Meter;
        string expectedUnitsConsumed = "units_consumed";
        string expectedDescription = "description";
        int expectedTax = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChargeableUnits, model.ChargeableUnits);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFreeThreshold, model.FreeThreshold);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTaxRate, model.TaxRate);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUnitsConsumed, model.UnitsConsumed);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",
            Description = "description",
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",
            Description = "description",
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedChargeableUnits = "chargeable_units";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedName = "name";
        string expectedPricePerUnit = "price_per_unit";
        int expectedSubtotal = 0;
        bool expectedTaxInclusive = true;
        float expectedTaxRate = 0;
        ApiEnum<string, UnionMember2Type> expectedType = UnionMember2Type.Meter;
        string expectedUnitsConsumed = "units_consumed";
        string expectedDescription = "description";
        int expectedTax = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChargeableUnits, deserialized.ChargeableUnits);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFreeThreshold, deserialized.FreeThreshold);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUnitsConsumed, deserialized.UnitsConsumed);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",
            Description = "description",
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",

            Description = null,
            Tax = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember2
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            Subtotal = 0,
            TaxInclusive = true,
            TaxRate = 0,
            Type = UnionMember2Type.Meter,
            UnitsConsumed = "units_consumed",

            Description = null,
            Tax = null,
        };

        model.Validate();
    }
}

public class UnionMember2TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember2Type.Meter)]
    public void Validation_Works(UnionMember2Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember2Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember2Type.Meter)]
    public void SerializationRoundtrip_Works(UnionMember2Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember2Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            SettlementTax = 0,
            Tax = 0,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedCustomerCredits = 0;
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        int expectedSettlementTax = 0;
        int expectedTax = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomerCredits, model.CustomerCredits);
        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
        Assert.Equal(expectedSettlementCurrency, model.SettlementCurrency);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedSettlementTax, model.SettlementTax);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            SettlementTax = 0,
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Summary>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            SettlementTax = 0,
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Summary>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedCustomerCredits = 0;
        int expectedSettlementAmount = 0;
        ApiEnum<string, Currency> expectedSettlementCurrency = Currency.Aed;
        int expectedTotalAmount = 0;
        int expectedSettlementTax = 0;
        int expectedTax = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomerCredits, deserialized.CustomerCredits);
        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
        Assert.Equal(expectedSettlementCurrency, deserialized.SettlementCurrency);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedSettlementTax, deserialized.SettlementTax);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
            SettlementTax = 0,
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
        };

        Assert.Null(model.SettlementTax);
        Assert.False(model.RawData.ContainsKey("settlement_tax"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,

            SettlementTax = null,
            Tax = null,
        };

        Assert.Null(model.SettlementTax);
        Assert.True(model.RawData.ContainsKey("settlement_tax"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Summary
        {
            Currency = Currency.Aed,
            CustomerCredits = 0,
            SettlementAmount = 0,
            SettlementCurrency = Currency.Aed,
            TotalAmount = 0,

            SettlementTax = null,
            Tax = null,
        };

        model.Validate();
    }
}
