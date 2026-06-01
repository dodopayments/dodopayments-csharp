using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.ProductCollections;
using DodoPayments.Client.Models.ProductCollections.Groups;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EffectiveAtOnDowngrade = ProductCollectionEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionEffectiveAtOnUpgrade.Immediately,
            Image = "image",
            OnPaymentFailure = ProductCollectionOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        string expectedID = "id";
        string expectedBrandID = "brand_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ProductCollectionGroupResponse> expectedGroups =
        [
            new()
            {
                GroupID = "group_id",
                Products =
                [
                    new()
                    {
                        ID = "id",
                        AddonsCount = 0,
                        FilesCount = 0,
                        HasCreditEntitlements = true,
                        IsRecurring = true,
                        LicenseKeyEnabled = true,
                        MetersCount = 0,
                        ProductID = "product_id",
                        Status = true,
                        Currency = Currency.Aed,
                        Description = "description",
                        Name = "name",
                        Price = 0,
                        PriceDetail = new OneTimePrice()
                        {
                            Currency = Currency.Aed,
                            Discount = 0,
                            PriceValue = 0,
                            PurchasingPowerParity = true,
                            PayWhatYouWant = true,
                            SuggestedPrice = 0,
                            TaxInclusive = true,
                        },
                        TaxCategory = TaxCategory.DigitalProducts,
                        TaxInclusive = true,
                    },
                ],
                Status = true,
                GroupName = "group_name",
            },
        ];
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade> expectedEffectiveAtOnDowngrade =
            ProductCollectionEffectiveAtOnDowngrade.Immediately;
        ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade> expectedEffectiveAtOnUpgrade =
            ProductCollectionEffectiveAtOnUpgrade.Immediately;
        string expectedImage = "image";
        ApiEnum<string, ProductCollectionOnPaymentFailure> expectedOnPaymentFailure =
            ProductCollectionOnPaymentFailure.PreventChange;
        ApiEnum<
            string,
            ProductCollectionProrationBillingModeOnDowngrade
        > expectedProrationBillingModeOnDowngrade =
            ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately;
        ApiEnum<
            string,
            ProductCollectionProrationBillingModeOnUpgrade
        > expectedProrationBillingModeOnUpgrade =
            ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedGroups.Count, model.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], model.Groups[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEffectiveAtOnDowngrade, model.EffectiveAtOnDowngrade);
        Assert.Equal(expectedEffectiveAtOnUpgrade, model.EffectiveAtOnUpgrade);
        Assert.Equal(expectedImage, model.Image);
        Assert.Equal(expectedOnPaymentFailure, model.OnPaymentFailure);
        Assert.Equal(
            expectedProrationBillingModeOnDowngrade,
            model.ProrationBillingModeOnDowngrade
        );
        Assert.Equal(expectedProrationBillingModeOnUpgrade, model.ProrationBillingModeOnUpgrade);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EffectiveAtOnDowngrade = ProductCollectionEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionEffectiveAtOnUpgrade.Immediately,
            Image = "image",
            OnPaymentFailure = ProductCollectionOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EffectiveAtOnDowngrade = ProductCollectionEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionEffectiveAtOnUpgrade.Immediately,
            Image = "image",
            OnPaymentFailure = ProductCollectionOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBrandID = "brand_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ProductCollectionGroupResponse> expectedGroups =
        [
            new()
            {
                GroupID = "group_id",
                Products =
                [
                    new()
                    {
                        ID = "id",
                        AddonsCount = 0,
                        FilesCount = 0,
                        HasCreditEntitlements = true,
                        IsRecurring = true,
                        LicenseKeyEnabled = true,
                        MetersCount = 0,
                        ProductID = "product_id",
                        Status = true,
                        Currency = Currency.Aed,
                        Description = "description",
                        Name = "name",
                        Price = 0,
                        PriceDetail = new OneTimePrice()
                        {
                            Currency = Currency.Aed,
                            Discount = 0,
                            PriceValue = 0,
                            PurchasingPowerParity = true,
                            PayWhatYouWant = true,
                            SuggestedPrice = 0,
                            TaxInclusive = true,
                        },
                        TaxCategory = TaxCategory.DigitalProducts,
                        TaxInclusive = true,
                    },
                ],
                Status = true,
                GroupName = "group_name",
            },
        ];
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade> expectedEffectiveAtOnDowngrade =
            ProductCollectionEffectiveAtOnDowngrade.Immediately;
        ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade> expectedEffectiveAtOnUpgrade =
            ProductCollectionEffectiveAtOnUpgrade.Immediately;
        string expectedImage = "image";
        ApiEnum<string, ProductCollectionOnPaymentFailure> expectedOnPaymentFailure =
            ProductCollectionOnPaymentFailure.PreventChange;
        ApiEnum<
            string,
            ProductCollectionProrationBillingModeOnDowngrade
        > expectedProrationBillingModeOnDowngrade =
            ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately;
        ApiEnum<
            string,
            ProductCollectionProrationBillingModeOnUpgrade
        > expectedProrationBillingModeOnUpgrade =
            ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedGroups.Count, deserialized.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], deserialized.Groups[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEffectiveAtOnDowngrade, deserialized.EffectiveAtOnDowngrade);
        Assert.Equal(expectedEffectiveAtOnUpgrade, deserialized.EffectiveAtOnUpgrade);
        Assert.Equal(expectedImage, deserialized.Image);
        Assert.Equal(expectedOnPaymentFailure, deserialized.OnPaymentFailure);
        Assert.Equal(
            expectedProrationBillingModeOnDowngrade,
            deserialized.ProrationBillingModeOnDowngrade
        );
        Assert.Equal(
            expectedProrationBillingModeOnUpgrade,
            deserialized.ProrationBillingModeOnUpgrade
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EffectiveAtOnDowngrade = ProductCollectionEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionEffectiveAtOnUpgrade.Immediately,
            Image = "image",
            OnPaymentFailure = ProductCollectionOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EffectiveAtOnDowngrade);
        Assert.False(model.RawData.ContainsKey("effective_at_on_downgrade"));
        Assert.Null(model.EffectiveAtOnUpgrade);
        Assert.False(model.RawData.ContainsKey("effective_at_on_upgrade"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.OnPaymentFailure);
        Assert.False(model.RawData.ContainsKey("on_payment_failure"));
        Assert.Null(model.ProrationBillingModeOnDowngrade);
        Assert.False(model.RawData.ContainsKey("proration_billing_mode_on_downgrade"));
        Assert.Null(model.ProrationBillingModeOnUpgrade);
        Assert.False(model.RawData.ContainsKey("proration_billing_mode_on_upgrade"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            EffectiveAtOnDowngrade = null,
            EffectiveAtOnUpgrade = null,
            Image = null,
            OnPaymentFailure = null,
            ProrationBillingModeOnDowngrade = null,
            ProrationBillingModeOnUpgrade = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.EffectiveAtOnDowngrade);
        Assert.True(model.RawData.ContainsKey("effective_at_on_downgrade"));
        Assert.Null(model.EffectiveAtOnUpgrade);
        Assert.True(model.RawData.ContainsKey("effective_at_on_upgrade"));
        Assert.Null(model.Image);
        Assert.True(model.RawData.ContainsKey("image"));
        Assert.Null(model.OnPaymentFailure);
        Assert.True(model.RawData.ContainsKey("on_payment_failure"));
        Assert.Null(model.ProrationBillingModeOnDowngrade);
        Assert.True(model.RawData.ContainsKey("proration_billing_mode_on_downgrade"));
        Assert.Null(model.ProrationBillingModeOnUpgrade);
        Assert.True(model.RawData.ContainsKey("proration_billing_mode_on_upgrade"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            EffectiveAtOnDowngrade = null,
            EffectiveAtOnUpgrade = null,
            Image = null,
            OnPaymentFailure = null,
            ProrationBillingModeOnDowngrade = null,
            ProrationBillingModeOnUpgrade = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCollection
        {
            ID = "id",
            BrandID = "brand_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Groups =
            [
                new()
                {
                    GroupID = "group_id",
                    Products =
                    [
                        new()
                        {
                            ID = "id",
                            AddonsCount = 0,
                            FilesCount = 0,
                            HasCreditEntitlements = true,
                            IsRecurring = true,
                            LicenseKeyEnabled = true,
                            MetersCount = 0,
                            ProductID = "product_id",
                            Status = true,
                            Currency = Currency.Aed,
                            Description = "description",
                            Name = "name",
                            Price = 0,
                            PriceDetail = new OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                PayWhatYouWant = true,
                                SuggestedPrice = 0,
                                TaxInclusive = true,
                            },
                            TaxCategory = TaxCategory.DigitalProducts,
                            TaxInclusive = true,
                        },
                    ],
                    Status = true,
                    GroupName = "group_name",
                },
            ],
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EffectiveAtOnDowngrade = ProductCollectionEffectiveAtOnDowngrade.Immediately,
            EffectiveAtOnUpgrade = ProductCollectionEffectiveAtOnUpgrade.Immediately,
            Image = "image",
            OnPaymentFailure = ProductCollectionOnPaymentFailure.PreventChange,
            ProrationBillingModeOnDowngrade =
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately,
            ProrationBillingModeOnUpgrade =
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately,
        };

        ProductCollection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductCollectionEffectiveAtOnDowngradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionEffectiveAtOnDowngrade.Immediately)]
    [InlineData(ProductCollectionEffectiveAtOnDowngrade.NextBillingDate)]
    public void Validation_Works(ProductCollectionEffectiveAtOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionEffectiveAtOnDowngrade.Immediately)]
    [InlineData(ProductCollectionEffectiveAtOnDowngrade.NextBillingDate)]
    public void SerializationRoundtrip_Works(ProductCollectionEffectiveAtOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionEffectiveAtOnUpgradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionEffectiveAtOnUpgrade.Immediately)]
    [InlineData(ProductCollectionEffectiveAtOnUpgrade.NextBillingDate)]
    public void Validation_Works(ProductCollectionEffectiveAtOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionEffectiveAtOnUpgrade.Immediately)]
    [InlineData(ProductCollectionEffectiveAtOnUpgrade.NextBillingDate)]
    public void SerializationRoundtrip_Works(ProductCollectionEffectiveAtOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionOnPaymentFailureTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionOnPaymentFailure.PreventChange)]
    [InlineData(ProductCollectionOnPaymentFailure.ApplyChange)]
    public void Validation_Works(ProductCollectionOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionOnPaymentFailure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProductCollectionOnPaymentFailure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionOnPaymentFailure.PreventChange)]
    [InlineData(ProductCollectionOnPaymentFailure.ApplyChange)]
    public void SerializationRoundtrip_Works(ProductCollectionOnPaymentFailure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionOnPaymentFailure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProductCollectionOnPaymentFailure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionOnPaymentFailure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionProrationBillingModeOnDowngradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.FullImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.DifferenceImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.DoNotBill)]
    public void Validation_Works(ProductCollectionProrationBillingModeOnDowngrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.FullImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.DifferenceImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnDowngrade.DoNotBill)]
    public void SerializationRoundtrip_Works(
        ProductCollectionProrationBillingModeOnDowngrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCollectionProrationBillingModeOnUpgradeTest : TestBase
{
    [Theory]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.FullImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.DifferenceImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.DoNotBill)]
    public void Validation_Works(ProductCollectionProrationBillingModeOnUpgrade rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.FullImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.DifferenceImmediately)]
    [InlineData(ProductCollectionProrationBillingModeOnUpgrade.DoNotBill)]
    public void SerializationRoundtrip_Works(
        ProductCollectionProrationBillingModeOnUpgrade rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
