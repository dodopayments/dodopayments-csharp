using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
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
            Image = "image",
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
        string expectedImage = "image";

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
        Assert.Equal(expectedImage, model.Image);
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
            Image = "image",
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
            Image = "image",
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
        string expectedImage = "image";

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
        Assert.Equal(expectedImage, deserialized.Image);
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
            Image = "image",
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
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
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
            Image = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Image);
        Assert.True(model.RawData.ContainsKey("image"));
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
            Image = null,
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
            Image = "image",
        };

        ProductCollection copied = new(model);

        Assert.Equal(model, copied);
    }
}
