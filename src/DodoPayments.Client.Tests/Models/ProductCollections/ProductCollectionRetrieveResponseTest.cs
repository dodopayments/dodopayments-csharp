using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.ProductCollections;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        List<ProductCollectionRetrieveResponseGroup> expectedGroups =
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
                        PriceDetail = new Products::OneTimePrice()
                        {
                            Currency = Currency.Aed,
                            Discount = 0,
                            PriceValue = 0,
                            PurchasingPowerParity = true,
                            Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var deserialized = JsonSerializer.Deserialize<ProductCollectionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var deserialized = JsonSerializer.Deserialize<ProductCollectionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBrandID = "brand_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ProductCollectionRetrieveResponseGroup> expectedGroups =
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
                        PriceDetail = new Products::OneTimePrice()
                        {
                            Currency = Currency.Aed,
                            Discount = 0,
                            PriceValue = 0,
                            PurchasingPowerParity = true,
                            Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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
        var model = new ProductCollectionRetrieveResponse
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
                            PriceDetail = new Products::OneTimePrice()
                            {
                                Currency = Currency.Aed,
                                Discount = 0,
                                PriceValue = 0,
                                PurchasingPowerParity = true,
                                Type = Products::Type.OneTimePrice,
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

        ProductCollectionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductCollectionRetrieveResponseGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
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
        };

        string expectedGroupID = "group_id";
        List<ProductCollectionRetrieveResponseGroupProduct> expectedProducts =
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
                PriceDetail = new Products::OneTimePrice()
                {
                    Currency = Currency.Aed,
                    Discount = 0,
                    PriceValue = 0,
                    PurchasingPowerParity = true,
                    Type = Products::Type.OneTimePrice,
                    PayWhatYouWant = true,
                    SuggestedPrice = 0,
                    TaxInclusive = true,
                },
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
            },
        ];
        bool expectedStatus = true;
        string expectedGroupName = "group_name";

        Assert.Equal(expectedGroupID, model.GroupID);
        Assert.Equal(expectedProducts.Count, model.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], model.Products[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedGroupName, model.GroupName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionRetrieveResponseGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionRetrieveResponseGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedGroupID = "group_id";
        List<ProductCollectionRetrieveResponseGroupProduct> expectedProducts =
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
                PriceDetail = new Products::OneTimePrice()
                {
                    Currency = Currency.Aed,
                    Discount = 0,
                    PriceValue = 0,
                    PurchasingPowerParity = true,
                    Type = Products::Type.OneTimePrice,
                    PayWhatYouWant = true,
                    SuggestedPrice = 0,
                    TaxInclusive = true,
                },
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
            },
        ];
        bool expectedStatus = true;
        string expectedGroupName = "group_name";

        Assert.Equal(expectedGroupID, deserialized.GroupID);
        Assert.Equal(expectedProducts.Count, deserialized.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], deserialized.Products[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedGroupName, deserialized.GroupName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
        };

        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("group_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,

            GroupName = null,
        };

        Assert.Null(model.GroupName);
        Assert.True(model.RawData.ContainsKey("group_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,

            GroupName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroup
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
                    PriceDetail = new Products::OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
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
        };

        ProductCollectionRetrieveResponseGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductCollectionRetrieveResponseGroupProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
            PriceDetail = new Products::OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PriceValue = 0,
                PurchasingPowerParity = true,
                Type = Products::Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            },
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
        };

        string expectedID = "id";
        long expectedAddonsCount = 0;
        long expectedFilesCount = 0;
        bool expectedHasCreditEntitlements = true;
        bool expectedIsRecurring = true;
        bool expectedLicenseKeyEnabled = true;
        long expectedMetersCount = 0;
        string expectedProductID = "product_id";
        bool expectedStatus = true;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        string expectedName = "name";
        int expectedPrice = 0;
        Products::Price expectedPriceDetail = new Products::OneTimePrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            PriceValue = 0,
            PurchasingPowerParity = true,
            Type = Products::Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAddonsCount, model.AddonsCount);
        Assert.Equal(expectedFilesCount, model.FilesCount);
        Assert.Equal(expectedHasCreditEntitlements, model.HasCreditEntitlements);
        Assert.Equal(expectedIsRecurring, model.IsRecurring);
        Assert.Equal(expectedLicenseKeyEnabled, model.LicenseKeyEnabled);
        Assert.Equal(expectedMetersCount, model.MetersCount);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceDetail, model.PriceDetail);
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
            PriceDetail = new Products::OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PriceValue = 0,
                PurchasingPowerParity = true,
                Type = Products::Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            },
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductCollectionRetrieveResponseGroupProduct>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
            PriceDetail = new Products::OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PriceValue = 0,
                PurchasingPowerParity = true,
                Type = Products::Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            },
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductCollectionRetrieveResponseGroupProduct>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAddonsCount = 0;
        long expectedFilesCount = 0;
        bool expectedHasCreditEntitlements = true;
        bool expectedIsRecurring = true;
        bool expectedLicenseKeyEnabled = true;
        long expectedMetersCount = 0;
        string expectedProductID = "product_id";
        bool expectedStatus = true;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        string expectedName = "name";
        int expectedPrice = 0;
        Products::Price expectedPriceDetail = new Products::OneTimePrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            PriceValue = 0,
            PurchasingPowerParity = true,
            Type = Products::Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAddonsCount, deserialized.AddonsCount);
        Assert.Equal(expectedFilesCount, deserialized.FilesCount);
        Assert.Equal(expectedHasCreditEntitlements, deserialized.HasCreditEntitlements);
        Assert.Equal(expectedIsRecurring, deserialized.IsRecurring);
        Assert.Equal(expectedLicenseKeyEnabled, deserialized.LicenseKeyEnabled);
        Assert.Equal(expectedMetersCount, deserialized.MetersCount);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceDetail, deserialized.PriceDetail);
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
            PriceDetail = new Products::OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PriceValue = 0,
                PurchasingPowerParity = true,
                Type = Products::Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            },
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceDetail);
        Assert.False(model.RawData.ContainsKey("price_detail"));
        Assert.Null(model.TaxCategory);
        Assert.False(model.RawData.ContainsKey("tax_category"));
        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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

            Currency = null,
            Description = null,
            Name = null,
            Price = null,
            PriceDetail = null,
            TaxCategory = null,
            TaxInclusive = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceDetail);
        Assert.True(model.RawData.ContainsKey("price_detail"));
        Assert.Null(model.TaxCategory);
        Assert.True(model.RawData.ContainsKey("tax_category"));
        Assert.Null(model.TaxInclusive);
        Assert.True(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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

            Currency = null,
            Description = null,
            Name = null,
            Price = null,
            PriceDetail = null,
            TaxCategory = null,
            TaxInclusive = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCollectionRetrieveResponseGroupProduct
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
            PriceDetail = new Products::OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                PriceValue = 0,
                PurchasingPowerParity = true,
                Type = Products::Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            },
            TaxCategory = TaxCategory.DigitalProducts,
            TaxInclusive = true,
        };

        ProductCollectionRetrieveResponseGroupProduct copied = new(model);

        Assert.Equal(model, copied);
    }
}
