using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionPreviewResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,
            RecurringBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            TotalTax = 0,
        };

        ApiEnum<string, CountryCode> expectedBillingCountry = CountryCode.Af;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        CurrentBreakup expectedCurrentBreakup = new()
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };
        List<CheckoutSessionPreviewResponseProductCart> expectedProductCart =
        [
            new()
            {
                Currency = Currency.Aed,
                DiscountedPrice = 0,
                IsSubscription = true,
                IsUsageBased = true,
                Meters =
                [
                    new()
                    {
                        MeasurementUnit = "measurement_unit",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
                        FreeThreshold = 0,
                    },
                ],
                OgCurrency = Currency.Aed,
                OgPrice = 0,
                ProductID = "product_id",
                Quantity = 0,
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
                TaxRate = 0,
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Currency = Currency.Aed,
                        DiscountedPrice = 0,
                        Name = "name",
                        OgCurrency = Currency.Aed,
                        OgPrice = 0,
                        Quantity = 0,
                        TaxCategory = TaxCategory.DigitalProducts,
                        TaxInclusive = true,
                        TaxRate = 0,
                        Description = "description",
                        DiscountAmount = 0,
                        Tax = 0,
                    },
                ],
                Description = "description",
                DiscountAmount = 0,
                DiscountCycle = 0,
                Name = "name",
                Tax = 0,
            },
        ];
        int expectedTotalPrice = 0;
        RecurringBreakup expectedRecurringBreakup = new()
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };
        int expectedTotalTax = 0;

        Assert.Equal(expectedBillingCountry, model.BillingCountry);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCurrentBreakup, model.CurrentBreakup);
        Assert.Equal(expectedProductCart.Count, model.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], model.ProductCart[i]);
        }
        Assert.Equal(expectedTotalPrice, model.TotalPrice);
        Assert.Equal(expectedRecurringBreakup, model.RecurringBreakup);
        Assert.Equal(expectedTotalTax, model.TotalTax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,
            RecurringBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            TotalTax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,
            RecurringBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            TotalTax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CountryCode> expectedBillingCountry = CountryCode.Af;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        CurrentBreakup expectedCurrentBreakup = new()
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };
        List<CheckoutSessionPreviewResponseProductCart> expectedProductCart =
        [
            new()
            {
                Currency = Currency.Aed,
                DiscountedPrice = 0,
                IsSubscription = true,
                IsUsageBased = true,
                Meters =
                [
                    new()
                    {
                        MeasurementUnit = "measurement_unit",
                        Name = "name",
                        PricePerUnit = "10.50",
                        Description = "description",
                        FreeThreshold = 0,
                    },
                ],
                OgCurrency = Currency.Aed,
                OgPrice = 0,
                ProductID = "product_id",
                Quantity = 0,
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
                TaxRate = 0,
                Addons =
                [
                    new()
                    {
                        AddonID = "addon_id",
                        Currency = Currency.Aed,
                        DiscountedPrice = 0,
                        Name = "name",
                        OgCurrency = Currency.Aed,
                        OgPrice = 0,
                        Quantity = 0,
                        TaxCategory = TaxCategory.DigitalProducts,
                        TaxInclusive = true,
                        TaxRate = 0,
                        Description = "description",
                        DiscountAmount = 0,
                        Tax = 0,
                    },
                ],
                Description = "description",
                DiscountAmount = 0,
                DiscountCycle = 0,
                Name = "name",
                Tax = 0,
            },
        ];
        int expectedTotalPrice = 0;
        RecurringBreakup expectedRecurringBreakup = new()
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };
        int expectedTotalTax = 0;

        Assert.Equal(expectedBillingCountry, deserialized.BillingCountry);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCurrentBreakup, deserialized.CurrentBreakup);
        Assert.Equal(expectedProductCart.Count, deserialized.ProductCart.Count);
        for (int i = 0; i < expectedProductCart.Count; i++)
        {
            Assert.Equal(expectedProductCart[i], deserialized.ProductCart[i]);
        }
        Assert.Equal(expectedTotalPrice, deserialized.TotalPrice);
        Assert.Equal(expectedRecurringBreakup, deserialized.RecurringBreakup);
        Assert.Equal(expectedTotalTax, deserialized.TotalTax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,
            RecurringBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            TotalTax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,
        };

        Assert.Null(model.RecurringBreakup);
        Assert.False(model.RawData.ContainsKey("recurring_breakup"));
        Assert.Null(model.TotalTax);
        Assert.False(model.RawData.ContainsKey("total_tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,

            RecurringBreakup = null,
            TotalTax = null,
        };

        Assert.Null(model.RecurringBreakup);
        Assert.True(model.RawData.ContainsKey("recurring_breakup"));
        Assert.Null(model.TotalTax);
        Assert.True(model.RawData.ContainsKey("total_tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionPreviewResponse
        {
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
            CurrentBreakup = new()
            {
                Discount = 0,
                Subtotal = 0,
                TotalAmount = 0,
                Tax = 0,
            },
            ProductCart =
            [
                new()
                {
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    IsSubscription = true,
                    IsUsageBased = true,
                    Meters =
                    [
                        new()
                        {
                            MeasurementUnit = "measurement_unit",
                            Name = "name",
                            PricePerUnit = "10.50",
                            Description = "description",
                            FreeThreshold = 0,
                        },
                    ],
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    ProductID = "product_id",
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Currency = Currency.Aed,
                            DiscountedPrice = 0,
                            Name = "name",
                            OgCurrency = Currency.Aed,
                            OgPrice = 0,
                            Quantity = 0,
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                            TaxRate = 0,
                            Description = "description",
                            DiscountAmount = 0,
                            Tax = 0,
                        },
                    ],
                    Description = "description",
                    DiscountAmount = 0,
                    DiscountCycle = 0,
                    Name = "name",
                    Tax = 0,
                },
            ],
            TotalPrice = 0,

            RecurringBreakup = null,
            TotalTax = null,
        };

        model.Validate();
    }
}

public class CurrentBreakupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        int expectedDiscount = 0;
        int expectedSubtotal = 0;
        int expectedTotalAmount = 0;
        int expectedTax = 0;

        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrentBreakup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrentBreakup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedDiscount = 0;
        int expectedSubtotal = 0;
        int expectedTotalAmount = 0;
        int expectedTax = 0;

        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
        };

        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,

            Tax = null,
        };

        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CurrentBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,

            Tax = null,
        };

        model.Validate();
    }
}

public class CheckoutSessionPreviewResponseProductCartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    Name = "name",
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Description = "description",
                    DiscountAmount = 0,
                    Tax = 0,
                },
            ],
            Description = "description",
            DiscountAmount = 0,
            DiscountCycle = 0,
            Name = "name",
            Tax = 0,
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedDiscountedPrice = 0;
        bool expectedIsSubscription = true;
        bool expectedIsUsageBased = true;
        List<Meter> expectedMeters =
        [
            new()
            {
                MeasurementUnit = "measurement_unit",
                Name = "name",
                PricePerUnit = "10.50",
                Description = "description",
                FreeThreshold = 0,
            },
        ];
        ApiEnum<string, Currency> expectedOgCurrency = Currency.Aed;
        int expectedOgPrice = 0;
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;
        int expectedTaxRate = 0;
        List<Addon> expectedAddons =
        [
            new()
            {
                AddonID = "addon_id",
                Currency = Currency.Aed,
                DiscountedPrice = 0,
                Name = "name",
                OgCurrency = Currency.Aed,
                OgPrice = 0,
                Quantity = 0,
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
                TaxRate = 0,
                Description = "description",
                DiscountAmount = 0,
                Tax = 0,
            },
        ];
        string expectedDescription = "description";
        int expectedDiscountAmount = 0;
        int expectedDiscountCycle = 0;
        string expectedName = "name";
        int expectedTax = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscountedPrice, model.DiscountedPrice);
        Assert.Equal(expectedIsSubscription, model.IsSubscription);
        Assert.Equal(expectedIsUsageBased, model.IsUsageBased);
        Assert.Equal(expectedMeters.Count, model.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], model.Meters[i]);
        }
        Assert.Equal(expectedOgCurrency, model.OgCurrency);
        Assert.Equal(expectedOgPrice, model.OgPrice);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTaxRate, model.TaxRate);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDiscountAmount, model.DiscountAmount);
        Assert.Equal(expectedDiscountCycle, model.DiscountCycle);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    Name = "name",
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Description = "description",
                    DiscountAmount = 0,
                    Tax = 0,
                },
            ],
            Description = "description",
            DiscountAmount = 0,
            DiscountCycle = 0,
            Name = "name",
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewResponseProductCart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    Name = "name",
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Description = "description",
                    DiscountAmount = 0,
                    Tax = 0,
                },
            ],
            Description = "description",
            DiscountAmount = 0,
            DiscountCycle = 0,
            Name = "name",
            Tax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionPreviewResponseProductCart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedDiscountedPrice = 0;
        bool expectedIsSubscription = true;
        bool expectedIsUsageBased = true;
        List<Meter> expectedMeters =
        [
            new()
            {
                MeasurementUnit = "measurement_unit",
                Name = "name",
                PricePerUnit = "10.50",
                Description = "description",
                FreeThreshold = 0,
            },
        ];
        ApiEnum<string, Currency> expectedOgCurrency = Currency.Aed;
        int expectedOgPrice = 0;
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;
        int expectedTaxRate = 0;
        List<Addon> expectedAddons =
        [
            new()
            {
                AddonID = "addon_id",
                Currency = Currency.Aed,
                DiscountedPrice = 0,
                Name = "name",
                OgCurrency = Currency.Aed,
                OgPrice = 0,
                Quantity = 0,
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
                TaxRate = 0,
                Description = "description",
                DiscountAmount = 0,
                Tax = 0,
            },
        ];
        string expectedDescription = "description";
        int expectedDiscountAmount = 0;
        int expectedDiscountCycle = 0;
        string expectedName = "name";
        int expectedTax = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscountedPrice, deserialized.DiscountedPrice);
        Assert.Equal(expectedIsSubscription, deserialized.IsSubscription);
        Assert.Equal(expectedIsUsageBased, deserialized.IsUsageBased);
        Assert.Equal(expectedMeters.Count, deserialized.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], deserialized.Meters[i]);
        }
        Assert.Equal(expectedOgCurrency, deserialized.OgCurrency);
        Assert.Equal(expectedOgPrice, deserialized.OgPrice);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDiscountAmount, deserialized.DiscountAmount);
        Assert.Equal(expectedDiscountCycle, deserialized.DiscountCycle);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Currency = Currency.Aed,
                    DiscountedPrice = 0,
                    Name = "name",
                    OgCurrency = Currency.Aed,
                    OgPrice = 0,
                    Quantity = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                    TaxRate = 0,
                    Description = "description",
                    DiscountAmount = 0,
                    Tax = 0,
                },
            ],
            Description = "description",
            DiscountAmount = 0,
            DiscountCycle = 0,
            Name = "name",
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DiscountAmount);
        Assert.False(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.DiscountCycle);
        Assert.False(model.RawData.ContainsKey("discount_cycle"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,

            Addons = null,
            Description = null,
            DiscountAmount = null,
            DiscountCycle = null,
            Name = null,
            Tax = null,
        };

        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DiscountAmount);
        Assert.True(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.DiscountCycle);
        Assert.True(model.RawData.ContainsKey("discount_cycle"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionPreviewResponseProductCart
        {
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            IsSubscription = true,
            IsUsageBased = true,
            Meters =
            [
                new()
                {
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    PricePerUnit = "10.50",
                    Description = "description",
                    FreeThreshold = 0,
                },
            ],
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            ProductID = "product_id",
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,

            Addons = null,
            Description = null,
            DiscountAmount = null,
            DiscountCycle = null,
            Name = null,
            Tax = null,
        };

        model.Validate();
    }
}

public class MeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
        };

        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";
        string expectedPricePerUnit = "10.50";
        string expectedDescription = "description";
        long expectedFreeThreshold = 0;

        Assert.Equal(expectedMeasurementUnit, model.MeasurementUnit);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFreeThreshold, model.FreeThreshold);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";
        string expectedPricePerUnit = "10.50";
        string expectedDescription = "description";
        long expectedFreeThreshold = 0;

        Assert.Equal(expectedMeasurementUnit, deserialized.MeasurementUnit);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFreeThreshold, deserialized.FreeThreshold);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FreeThreshold);
        Assert.False(model.RawData.ContainsKey("free_threshold"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",

            Description = null,
            FreeThreshold = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.FreeThreshold);
        Assert.True(model.RawData.ContainsKey("free_threshold"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meter
        {
            MeasurementUnit = "measurement_unit",
            Name = "name",
            PricePerUnit = "10.50",

            Description = null,
            FreeThreshold = null,
        };

        model.Validate();
    }
}

public class AddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Description = "description",
            DiscountAmount = 0,
            Tax = 0,
        };

        string expectedAddonID = "addon_id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedDiscountedPrice = 0;
        string expectedName = "name";
        ApiEnum<string, Currency> expectedOgCurrency = Currency.Aed;
        int expectedOgPrice = 0;
        int expectedQuantity = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;
        int expectedTaxRate = 0;
        string expectedDescription = "description";
        int expectedDiscountAmount = 0;
        int expectedTax = 0;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscountedPrice, model.DiscountedPrice);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOgCurrency, model.OgCurrency);
        Assert.Equal(expectedOgPrice, model.OgPrice);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedTaxRate, model.TaxRate);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDiscountAmount, model.DiscountAmount);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Description = "description",
            DiscountAmount = 0,
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addon>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Description = "description",
            DiscountAmount = 0,
            Tax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addon>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAddonID = "addon_id";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedDiscountedPrice = 0;
        string expectedName = "name";
        ApiEnum<string, Currency> expectedOgCurrency = Currency.Aed;
        int expectedOgPrice = 0;
        int expectedQuantity = 0;
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;
        int expectedTaxRate = 0;
        string expectedDescription = "description";
        int expectedDiscountAmount = 0;
        int expectedTax = 0;

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscountedPrice, deserialized.DiscountedPrice);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOgCurrency, deserialized.OgCurrency);
        Assert.Equal(expectedOgPrice, deserialized.OgPrice);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDiscountAmount, deserialized.DiscountAmount);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
            Description = "description",
            DiscountAmount = 0,
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DiscountAmount);
        Assert.False(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,

            Description = null,
            DiscountAmount = null,
            Tax = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DiscountAmount);
        Assert.True(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Currency = Currency.Aed,
            DiscountedPrice = 0,
            Name = "name",
            OgCurrency = Currency.Aed,
            OgPrice = 0,
            Quantity = 0,
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
            TaxRate = 0,

            Description = null,
            DiscountAmount = null,
            Tax = null,
        };

        model.Validate();
    }
}

public class RecurringBreakupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        int expectedDiscount = 0;
        int expectedSubtotal = 0;
        int expectedTotalAmount = 0;
        int expectedTax = 0;

        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringBreakup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringBreakup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedDiscount = 0;
        int expectedSubtotal = 0;
        int expectedTotalAmount = 0;
        int expectedTax = 0;

        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
        };

        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,

            Tax = null,
        };

        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringBreakup
        {
            Discount = 0,
            Subtotal = 0,
            TotalAmount = 0,

            Tax = null,
        };

        model.Validate();
    }
}
