using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Description = "description",
            Image = "image",
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
            TaxInclusive = true,
        };

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Products::ProductListResponseEntitlement> expectedEntitlements =
        [
            new()
            {
                ID = "id",
                IntegrationConfig =
                    new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
                Name = "name",
                Description = "description",
            },
        ];
        bool expectedIsRecurring = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedProductID = "product_id";
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        string expectedImage = "image";
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
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedIsRecurring, model.IsRecurring);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedImage, model.Image);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceDetail, model.PriceDetail);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Description = "description",
            Image = "image",
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
            TaxInclusive = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Description = "description",
            Image = "image",
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
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Products::ProductListResponseEntitlement> expectedEntitlements =
        [
            new()
            {
                ID = "id",
                IntegrationConfig =
                    new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
                Name = "name",
                Description = "description",
            },
        ];
        bool expectedIsRecurring = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedProductID = "product_id";
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedDescription = "description";
        string expectedImage = "image";
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
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedIsRecurring, deserialized.IsRecurring);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedImage, deserialized.Image);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceDetail, deserialized.PriceDetail);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Description = "description",
            Image = "image",
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
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceDetail);
        Assert.False(model.RawData.ContainsKey("price_detail"));
        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Currency = null,
            Description = null,
            Image = null,
            Name = null,
            Price = null,
            PriceDetail = null,
            TaxInclusive = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Image);
        Assert.True(model.RawData.ContainsKey("image"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceDetail);
        Assert.True(model.RawData.ContainsKey("price_detail"));
        Assert.Null(model.TaxInclusive);
        Assert.True(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Currency = null,
            Description = null,
            Image = null,
            Name = null,
            Price = null,
            PriceDetail = null,
            TaxInclusive = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponse
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig =
                        new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                        {
                            Permission = "permission",
                            TargetID = "target_id",
                        },
                    IntegrationType =
                        Products::ProductListResponseEntitlementIntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            Description = "description",
            Image = "image",
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
            TaxInclusive = true,
        };

        Products::ProductListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        string expectedID = "id";
        Products::ProductListResponseEntitlementIntegrationConfig expectedIntegrationConfig =
            new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<
            string,
            Products::ProductListResponseEntitlementIntegrationType
        > expectedIntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord;
        string expectedName = "name";
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIntegrationConfig, model.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, model.IntegrationType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductListResponseEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductListResponseEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Products::ProductListResponseEntitlementIntegrationConfig expectedIntegrationConfig =
            new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<
            string,
            Products::ProductListResponseEntitlementIntegrationType
        > expectedIntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord;
        string expectedName = "name";
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIntegrationConfig, deserialized.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, deserialized.IntegrationType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlement
        {
            ID = "id",
            IntegrationConfig =
                new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
            IntegrationType = Products::ProductListResponseEntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        Products::ProductListResponseEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig(
                "figma_file_id"
            );
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig(
                "framer_template_id"
            );
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig(
                "notion_template_id"
            );
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig()
            {
                DigitalFileIds = ["string"],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            };
        value.Validate();
    }

    [Fact]
    public void LicenseKeyValidationWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = "duration_interval",
            };
        value.Validate();
    }

    [Fact]
    public void GitHubSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig(
                "figma_file_id"
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig(
                "framer_template_id"
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig(
                "notion_template_id"
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig()
            {
                DigitalFileIds = ["string"],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        Products::ProductListResponseEntitlementIntegrationConfig value =
            new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = "duration_interval",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ProductListResponseEntitlementIntegrationConfigGitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string expectedPermission = "permission";
        string expectedTargetID = "target_id";

        Assert.Equal(expectedPermission, model.Permission);
        Assert.Equal(expectedTargetID, model.TargetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPermission = "permission";
        string expectedTargetID = "target_id";

        Assert.Equal(expectedPermission, deserialized.Permission);
        Assert.Equal(expectedTargetID, deserialized.TargetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        Products::ProductListResponseEntitlementIntegrationConfigGitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigDiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string expectedGuildID = "guild_id";
        string expectedRoleID = "role_id";

        Assert.Equal(expectedGuildID, model.GuildID);
        Assert.Equal(expectedRoleID, model.RoleID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedGuildID = "guild_id";
        string expectedRoleID = "role_id";

        Assert.Equal(expectedGuildID, deserialized.GuildID);
        Assert.Equal(expectedRoleID, deserialized.RoleID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        Assert.Null(model.RoleID);
        Assert.True(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        Products::ProductListResponseEntitlementIntegrationConfigDiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigTelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, deserialized.ChatID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        Products::ProductListResponseEntitlementIntegrationConfigTelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigFigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, deserialized.FigmaFileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        Products::ProductListResponseEntitlementIntegrationConfigFigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigFramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigFramerConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigFramerConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, deserialized.FramerTemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        Products::ProductListResponseEntitlementIntegrationConfigFramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigNotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigNotionConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigNotionConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, deserialized.NotionTemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        Products::ProductListResponseEntitlementIntegrationConfigNotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigDigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        List<string> expectedDigitalFileIds = ["string"];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedDigitalFileIds.Count, model.DigitalFileIds.Count);
        for (int i = 0; i < expectedDigitalFileIds.Count; i++)
        {
            Assert.Equal(expectedDigitalFileIds[i], model.DigitalFileIds[i]);
        }
        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedDigitalFileIds = ["string"];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedDigitalFileIds.Count, deserialized.DigitalFileIds.Count);
        for (int i = 0; i < expectedDigitalFileIds.Count; i++)
        {
            Assert.Equal(expectedDigitalFileIds[i], deserialized.DigitalFileIds[i]);
        }
        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
        };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],

            ExternalUrl = null,
            Instructions = null,
        };

        Assert.Null(model.ExternalUrl);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],

            ExternalUrl = null,
            Instructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        Products::ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationConfigLicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        string expectedActivationMessage = "activation_message";
        int expectedActivationsLimit = 0;
        int expectedDurationCount = 0;
        string expectedDurationInterval = "duration_interval";

        Assert.Equal(expectedActivationMessage, model.ActivationMessage);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedDurationCount, model.DurationCount);
        Assert.Equal(expectedDurationInterval, model.DurationInterval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedActivationMessage = "activation_message";
        int expectedActivationsLimit = 0;
        int expectedDurationCount = 0;
        string expectedDurationInterval = "duration_interval";

        Assert.Equal(expectedActivationMessage, deserialized.ActivationMessage);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedDurationCount, deserialized.DurationCount);
        Assert.Equal(expectedDurationInterval, deserialized.DurationInterval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        { };

        Assert.Null(model.ActivationMessage);
        Assert.False(model.RawData.ContainsKey("activation_message"));
        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.DurationCount);
        Assert.False(model.RawData.ContainsKey("duration_count"));
        Assert.Null(model.DurationInterval);
        Assert.False(model.RawData.ContainsKey("duration_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = null,
            ActivationsLimit = null,
            DurationCount = null,
            DurationInterval = null,
        };

        Assert.Null(model.ActivationMessage);
        Assert.True(model.RawData.ContainsKey("activation_message"));
        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.DurationCount);
        Assert.True(model.RawData.ContainsKey("duration_count"));
        Assert.Null(model.DurationInterval);
        Assert.True(model.RawData.ContainsKey("duration_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = null,
            ActivationsLimit = null,
            DurationCount = null,
            DurationInterval = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        Products::ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ProductListResponseEntitlementIntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Discord)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Telegram)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.GitHub)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Figma)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Framer)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Notion)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.DigitalFiles)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.LicenseKey)]
    public void Validation_Works(Products::ProductListResponseEntitlementIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Products::ProductListResponseEntitlementIntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Products::ProductListResponseEntitlementIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Discord)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Telegram)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.GitHub)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Figma)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Framer)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.Notion)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.DigitalFiles)]
    [InlineData(Products::ProductListResponseEntitlementIntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(
        Products::ProductListResponseEntitlementIntegrationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Products::ProductListResponseEntitlementIntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Products::ProductListResponseEntitlementIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Products::ProductListResponseEntitlementIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Products::ProductListResponseEntitlementIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
