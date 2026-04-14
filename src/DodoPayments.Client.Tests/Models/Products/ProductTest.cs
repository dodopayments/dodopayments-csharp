using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Addons = ["string"],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Files =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Url = "url",
                    },
                ],
                Instructions = "instructions",
            },
            Image = "image",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            Name = "name",
            ProductCollectionID = "product_collection_id",
        };

        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Products::CreditEntitlementMappingResponse> expectedCreditEntitlements =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CreditEntitlementUnit = "credit_entitlement_unit",
                CreditsAmount = "credits_amount",
                OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                OverageEnabled = true,
                ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                RolloverEnabled = true,
                TrialCreditsExpireAfterTrial = true,
                Currency = Currency.Aed,
                ExpiresAfterDays = 0,
                LowBalanceThresholdPercent = 0,
                MaxRolloverCount = 0,
                OverageLimit = "overage_limit",
                PricePerUnit = "price_per_unit",
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
                TrialCredits = "trial_credits",
            },
        ];
        List<Products::Entitlement> expectedEntitlements =
        [
            new()
            {
                ID = "id",
                IntegrationConfig = new Products::GitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
                IntegrationType = Products::IntegrationType.Discord,
                Name = "name",
                Description = "description",
            },
        ];
        bool expectedIsRecurring = true;
        bool expectedLicenseKeyEnabled = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Products::Price expectedPrice = new Products::OneTimePrice()
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
        string expectedProductID = "product_id";
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedAddons = ["string"];
        string expectedDescription = "description";
        Products::ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            ExternalUrl = "external_url",
            Files =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Url = "url",
                },
            ],
            Instructions = "instructions",
        };
        string expectedImage = "image";
        string expectedLicenseKeyActivationMessage = "license_key_activation_message";
        int expectedLicenseKeyActivationsLimit = 0;
        Products::LicenseKeyDuration expectedLicenseKeyDuration = new()
        {
            Count = 0,
            Interval = TimeInterval.Day,
        };
        string expectedName = "name";
        string expectedProductCollectionID = "product_collection_id";

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlements.Count, model.CreditEntitlements.Count);
        for (int i = 0; i < expectedCreditEntitlements.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlements[i], model.CreditEntitlements[i]);
        }
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedIsRecurring, model.IsRecurring);
        Assert.Equal(expectedLicenseKeyEnabled, model.LicenseKeyEnabled);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedTaxCategory, model.TaxCategory);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDigitalProductDelivery, model.DigitalProductDelivery);
        Assert.Equal(expectedImage, model.Image);
        Assert.Equal(expectedLicenseKeyActivationMessage, model.LicenseKeyActivationMessage);
        Assert.Equal(expectedLicenseKeyActivationsLimit, model.LicenseKeyActivationsLimit);
        Assert.Equal(expectedLicenseKeyDuration, model.LicenseKeyDuration);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProductCollectionID, model.ProductCollectionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Addons = ["string"],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Files =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Url = "url",
                    },
                ],
                Instructions = "instructions",
            },
            Image = "image",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            Name = "name",
            ProductCollectionID = "product_collection_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::Product>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Addons = ["string"],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Files =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Url = "url",
                    },
                ],
                Instructions = "instructions",
            },
            Image = "image",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            Name = "name",
            ProductCollectionID = "product_collection_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::Product>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Products::CreditEntitlementMappingResponse> expectedCreditEntitlements =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CreditEntitlementUnit = "credit_entitlement_unit",
                CreditsAmount = "credits_amount",
                OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                OverageEnabled = true,
                ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                RolloverEnabled = true,
                TrialCreditsExpireAfterTrial = true,
                Currency = Currency.Aed,
                ExpiresAfterDays = 0,
                LowBalanceThresholdPercent = 0,
                MaxRolloverCount = 0,
                OverageLimit = "overage_limit",
                PricePerUnit = "price_per_unit",
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
                TrialCredits = "trial_credits",
            },
        ];
        List<Products::Entitlement> expectedEntitlements =
        [
            new()
            {
                ID = "id",
                IntegrationConfig = new Products::GitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
                IntegrationType = Products::IntegrationType.Discord,
                Name = "name",
                Description = "description",
            },
        ];
        bool expectedIsRecurring = true;
        bool expectedLicenseKeyEnabled = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Products::Price expectedPrice = new Products::OneTimePrice()
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
        string expectedProductID = "product_id";
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedAddons = ["string"];
        string expectedDescription = "description";
        Products::ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            ExternalUrl = "external_url",
            Files =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Url = "url",
                },
            ],
            Instructions = "instructions",
        };
        string expectedImage = "image";
        string expectedLicenseKeyActivationMessage = "license_key_activation_message";
        int expectedLicenseKeyActivationsLimit = 0;
        Products::LicenseKeyDuration expectedLicenseKeyDuration = new()
        {
            Count = 0,
            Interval = TimeInterval.Day,
        };
        string expectedName = "name";
        string expectedProductCollectionID = "product_collection_id";

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlements.Count, deserialized.CreditEntitlements.Count);
        for (int i = 0; i < expectedCreditEntitlements.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlements[i], deserialized.CreditEntitlements[i]);
        }
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedIsRecurring, deserialized.IsRecurring);
        Assert.Equal(expectedLicenseKeyEnabled, deserialized.LicenseKeyEnabled);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedTaxCategory, deserialized.TaxCategory);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDigitalProductDelivery, deserialized.DigitalProductDelivery);
        Assert.Equal(expectedImage, deserialized.Image);
        Assert.Equal(expectedLicenseKeyActivationMessage, deserialized.LicenseKeyActivationMessage);
        Assert.Equal(expectedLicenseKeyActivationsLimit, deserialized.LicenseKeyActivationsLimit);
        Assert.Equal(expectedLicenseKeyDuration, deserialized.LicenseKeyDuration);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProductCollectionID, deserialized.ProductCollectionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Addons = ["string"],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Files =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Url = "url",
                    },
                ],
                Instructions = "instructions",
            },
            Image = "image",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            Name = "name",
            ProductCollectionID = "product_collection_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DigitalProductDelivery);
        Assert.False(model.RawData.ContainsKey("digital_product_delivery"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.LicenseKeyActivationMessage);
        Assert.False(model.RawData.ContainsKey("license_key_activation_message"));
        Assert.Null(model.LicenseKeyActivationsLimit);
        Assert.False(model.RawData.ContainsKey("license_key_activations_limit"));
        Assert.Null(model.LicenseKeyDuration);
        Assert.False(model.RawData.ContainsKey("license_key_duration"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ProductCollectionID);
        Assert.False(model.RawData.ContainsKey("product_collection_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Addons = null,
            Description = null,
            DigitalProductDelivery = null,
            Image = null,
            LicenseKeyActivationMessage = null,
            LicenseKeyActivationsLimit = null,
            LicenseKeyDuration = null,
            Name = null,
            ProductCollectionID = null,
        };

        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DigitalProductDelivery);
        Assert.True(model.RawData.ContainsKey("digital_product_delivery"));
        Assert.Null(model.Image);
        Assert.True(model.RawData.ContainsKey("image"));
        Assert.Null(model.LicenseKeyActivationMessage);
        Assert.True(model.RawData.ContainsKey("license_key_activation_message"));
        Assert.Null(model.LicenseKeyActivationsLimit);
        Assert.True(model.RawData.ContainsKey("license_key_activations_limit"));
        Assert.Null(model.LicenseKeyDuration);
        Assert.True(model.RawData.ContainsKey("license_key_duration"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.ProductCollectionID);
        Assert.True(model.RawData.ContainsKey("product_collection_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Addons = null,
            Description = null,
            DigitalProductDelivery = null,
            Image = null,
            LicenseKeyActivationMessage = null,
            LicenseKeyActivationsLimit = null,
            LicenseKeyDuration = null,
            Name = null,
            ProductCollectionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::Product
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlements =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    CreditEntitlementUnit = "credit_entitlement_unit",
                    CreditsAmount = "credits_amount",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    ProrationBehavior = Products::CbbProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    TrialCreditsExpireAfterTrial = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = "overage_limit",
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                },
            ],
            Entitlements =
            [
                new()
                {
                    ID = "id",
                    IntegrationConfig = new Products::GitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = Products::IntegrationType.Discord,
                    Name = "name",
                    Description = "description",
                },
            ],
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Price = new Products::OneTimePrice()
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Addons = ["string"],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Files =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Url = "url",
                    },
                ],
                Instructions = "instructions",
            },
            Image = "image",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            Name = "name",
            ProductCollectionID = "product_collection_id",
        };

        Products::Product copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        string expectedID = "id";
        Products::IntegrationConfig expectedIntegrationConfig = new Products::GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        ApiEnum<string, Products::IntegrationType> expectedIntegrationType =
            Products::IntegrationType.Discord;
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
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::Entitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Products::IntegrationConfig expectedIntegrationConfig = new Products::GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        ApiEnum<string, Products::IntegrationType> expectedIntegrationType =
            Products::IntegrationType.Discord;
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
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::Entitlement
        {
            ID = "id",
            IntegrationConfig = new Products::GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = Products::IntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        Products::Entitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        Products::IntegrationConfig value = new Products::GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        Products::IntegrationConfig value = new Products::DiscordConfig()
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        Products::IntegrationConfig value = new Products::TelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        Products::IntegrationConfig value = new Products::FigmaConfig("figma_file_id");
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        Products::IntegrationConfig value = new Products::FramerConfig("framer_template_id");
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        Products::IntegrationConfig value = new Products::NotionConfig("notion_template_id");
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        Products::IntegrationConfig value = new Products::DigitalFilesConfig()
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
        Products::IntegrationConfig value = new Products::LicenseKeyConfig()
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
        Products::IntegrationConfig value = new Products::GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::DiscordConfig()
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::TelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::FigmaConfig("figma_file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::FramerConfig("framer_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::NotionConfig("notion_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::DigitalFilesConfig()
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        Products::IntegrationConfig value = new Products::LicenseKeyConfig()
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::GitHubConfig
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
        var model = new Products::GitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::GitHubConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::GitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::GitHubConfig>(
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
        var model = new Products::GitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::GitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        Products::GitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        string expectedGuildID = "guild_id";
        string expectedRoleID = "role_id";

        Assert.Equal(expectedGuildID, model.GuildID);
        Assert.Equal(expectedRoleID, model.RoleID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::DiscordConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::DiscordConfig>(
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
        var model = new Products::DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::DiscordConfig { GuildID = "guild_id" };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::DiscordConfig { GuildID = "guild_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::DiscordConfig
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
        var model = new Products::DiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        Products::DiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::TelegramConfig { ChatID = "chat_id" };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::TelegramConfig { ChatID = "chat_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::TelegramConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::TelegramConfig { ChatID = "chat_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::TelegramConfig>(
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
        var model = new Products::TelegramConfig { ChatID = "chat_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::TelegramConfig { ChatID = "chat_id" };

        Products::TelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::FigmaConfig { FigmaFileID = "figma_file_id" };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::FigmaConfig { FigmaFileID = "figma_file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::FigmaConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::FigmaConfig { FigmaFileID = "figma_file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::FigmaConfig>(
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
        var model = new Products::FigmaConfig { FigmaFileID = "figma_file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::FigmaConfig { FigmaFileID = "figma_file_id" };

        Products::FigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::FramerConfig { FramerTemplateID = "framer_template_id" };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::FramerConfig { FramerTemplateID = "framer_template_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::FramerConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::FramerConfig { FramerTemplateID = "framer_template_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::FramerConfig>(
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
        var model = new Products::FramerConfig { FramerTemplateID = "framer_template_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::FramerConfig { FramerTemplateID = "framer_template_id" };

        Products::FramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::NotionConfig { NotionTemplateID = "notion_template_id" };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::NotionConfig { NotionTemplateID = "notion_template_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::NotionConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::NotionConfig { NotionTemplateID = "notion_template_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::NotionConfig>(
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
        var model = new Products::NotionConfig { NotionTemplateID = "notion_template_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::NotionConfig { NotionTemplateID = "notion_template_id" };

        Products::NotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::DigitalFilesConfig
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
        var model = new Products::DigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::DigitalFilesConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::DigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::DigitalFilesConfig>(
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
        var model = new Products::DigitalFilesConfig
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
        var model = new Products::DigitalFilesConfig { DigitalFileIds = ["string"] };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::DigitalFilesConfig { DigitalFileIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::DigitalFilesConfig
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
        var model = new Products::DigitalFilesConfig
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
        var model = new Products::DigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        Products::DigitalFilesConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::LicenseKeyConfig
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
        var model = new Products::LicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::LicenseKeyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::LicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::LicenseKeyConfig>(
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
        var model = new Products::LicenseKeyConfig
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
        var model = new Products::LicenseKeyConfig { };

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
        var model = new Products::LicenseKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::LicenseKeyConfig
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
        var model = new Products::LicenseKeyConfig
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
        var model = new Products::LicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = "duration_interval",
        };

        Products::LicenseKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(Products::IntegrationType.Discord)]
    [InlineData(Products::IntegrationType.Telegram)]
    [InlineData(Products::IntegrationType.GitHub)]
    [InlineData(Products::IntegrationType.Figma)]
    [InlineData(Products::IntegrationType.Framer)]
    [InlineData(Products::IntegrationType.Notion)]
    [InlineData(Products::IntegrationType.DigitalFiles)]
    [InlineData(Products::IntegrationType.LicenseKey)]
    public void Validation_Works(Products::IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Products::IntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Products::IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Products::IntegrationType.Discord)]
    [InlineData(Products::IntegrationType.Telegram)]
    [InlineData(Products::IntegrationType.GitHub)]
    [InlineData(Products::IntegrationType.Figma)]
    [InlineData(Products::IntegrationType.Framer)]
    [InlineData(Products::IntegrationType.Notion)]
    [InlineData(Products::IntegrationType.DigitalFiles)]
    [InlineData(Products::IntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(Products::IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Products::IntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Products::IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Products::IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Products::IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
