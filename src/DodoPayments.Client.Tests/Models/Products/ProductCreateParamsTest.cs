using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Products::ProductCreateParams
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
            Addons = ["string"],
            BrandID = "brand_id",
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                    CreditsReduceOverage = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    OverageLimit = "overage_limit",
                    PreserveOverageAtReset = true,
                    PricePerUnit = "price_per_unit",
                    ProrationBehavior = Products::ProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                    TrialCreditsExpireAfterTrial = true,
                },
            ],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedName = "name";
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
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        List<string> expectedAddons = ["string"];
        string expectedBrandID = "brand_id";
        List<Products::CreditEntitlement> expectedCreditEntitlements =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                CreditsAmount = "credits_amount",
                CreditsReduceOverage = true,
                Currency = Currency.Aed,
                ExpiresAfterDays = 0,
                LowBalanceThresholdPercent = 0,
                MaxRolloverCount = 0,
                OverageChargeAtBilling = true,
                OverageEnabled = true,
                OverageLimit = "overage_limit",
                PreserveOverageAtReset = true,
                PricePerUnit = "price_per_unit",
                ProrationBehavior = Products::ProrationBehavior.Prorate,
                RolloverEnabled = true,
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
                TrialCredits = "trial_credits",
                TrialCreditsExpireAfterTrial = true,
            },
        ];
        string expectedDescription = "description";
        Products::DigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };
        string expectedLicenseKeyActivationMessage = "license_key_activation_message";
        int expectedLicenseKeyActivationsLimit = 0;
        Products::LicenseKeyDuration expectedLicenseKeyDuration = new()
        {
            Count = 0,
            Interval = TimeInterval.Day,
        };
        bool expectedLicenseKeyEnabled = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPrice, parameters.Price);
        Assert.Equal(expectedTaxCategory, parameters.TaxCategory);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.NotNull(parameters.CreditEntitlements);
        Assert.Equal(expectedCreditEntitlements.Count, parameters.CreditEntitlements.Count);
        for (int i = 0; i < expectedCreditEntitlements.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlements[i], parameters.CreditEntitlements[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDigitalProductDelivery, parameters.DigitalProductDelivery);
        Assert.Equal(expectedLicenseKeyActivationMessage, parameters.LicenseKeyActivationMessage);
        Assert.Equal(expectedLicenseKeyActivationsLimit, parameters.LicenseKeyActivationsLimit);
        Assert.Equal(expectedLicenseKeyDuration, parameters.LicenseKeyDuration);
        Assert.Equal(expectedLicenseKeyEnabled, parameters.LicenseKeyEnabled);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Products::ProductCreateParams
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
            Addons = ["string"],
            BrandID = "brand_id",
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                    CreditsReduceOverage = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    OverageLimit = "overage_limit",
                    PreserveOverageAtReset = true,
                    PricePerUnit = "price_per_unit",
                    ProrationBehavior = Products::ProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                    TrialCreditsExpireAfterTrial = true,
                },
            ],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            LicenseKeyEnabled = true,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Products::ProductCreateParams
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
            Addons = ["string"],
            BrandID = "brand_id",
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                    CreditsReduceOverage = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    OverageLimit = "overage_limit",
                    PreserveOverageAtReset = true,
                    PricePerUnit = "price_per_unit",
                    ProrationBehavior = Products::ProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                    TrialCreditsExpireAfterTrial = true,
                },
            ],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            LicenseKeyEnabled = true,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Products::ProductCreateParams
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.CreditEntitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("credit_entitlements"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DigitalProductDelivery);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_product_delivery"));
        Assert.Null(parameters.LicenseKeyActivationMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_activation_message"));
        Assert.Null(parameters.LicenseKeyActivationsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_activations_limit"));
        Assert.Null(parameters.LicenseKeyDuration);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_duration"));
        Assert.Null(parameters.LicenseKeyEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_enabled"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Products::ProductCreateParams
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Addons = null,
            BrandID = null,
            CreditEntitlements = null,
            Description = null,
            DigitalProductDelivery = null,
            LicenseKeyActivationMessage = null,
            LicenseKeyActivationsLimit = null,
            LicenseKeyDuration = null,
            LicenseKeyEnabled = null,
        };

        Assert.Null(parameters.Addons);
        Assert.True(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.CreditEntitlements);
        Assert.True(parameters.RawBodyData.ContainsKey("credit_entitlements"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DigitalProductDelivery);
        Assert.True(parameters.RawBodyData.ContainsKey("digital_product_delivery"));
        Assert.Null(parameters.LicenseKeyActivationMessage);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_activation_message"));
        Assert.Null(parameters.LicenseKeyActivationsLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_activations_limit"));
        Assert.Null(parameters.LicenseKeyDuration);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_duration"));
        Assert.Null(parameters.LicenseKeyEnabled);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_enabled"));
    }

    [Fact]
    public void Url_Works()
    {
        Products::ProductCreateParams parameters = new()
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/products"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Products::ProductCreateParams
        {
            Name = "name",
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
            TaxCategory = TaxCategory.DigitalProducts,
            Addons = ["string"],
            BrandID = "brand_id",
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                    CreditsReduceOverage = true,
                    Currency = Currency.Aed,
                    ExpiresAfterDays = 0,
                    LowBalanceThresholdPercent = 0,
                    MaxRolloverCount = 0,
                    OverageChargeAtBilling = true,
                    OverageEnabled = true,
                    OverageLimit = "overage_limit",
                    PreserveOverageAtReset = true,
                    PricePerUnit = "price_per_unit",
                    ProrationBehavior = Products::ProrationBehavior.Prorate,
                    RolloverEnabled = true,
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                    TrialCredits = "trial_credits",
                    TrialCreditsExpireAfterTrial = true,
                },
            ],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Products::ProductCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreditEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            CreditsReduceOverage = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PreserveOverageAtReset = true,
            PricePerUnit = "price_per_unit",
            ProrationBehavior = Products::ProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";
        bool expectedCreditsReduceOverage = true;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        bool expectedOverageChargeAtBilling = true;
        bool expectedOverageEnabled = true;
        string expectedOverageLimit = "overage_limit";
        bool expectedPreserveOverageAtReset = true;
        string expectedPricePerUnit = "price_per_unit";
        ApiEnum<string, Products::ProrationBehavior> expectedProrationBehavior =
            Products::ProrationBehavior.Prorate;
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedTrialCredits = "trial_credits";
        bool expectedTrialCreditsExpireAfterTrial = true;

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, model.CreditsAmount);
        Assert.Equal(expectedCreditsReduceOverage, model.CreditsReduceOverage);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedExpiresAfterDays, model.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, model.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, model.MaxRolloverCount);
        Assert.Equal(expectedOverageChargeAtBilling, model.OverageChargeAtBilling);
        Assert.Equal(expectedOverageEnabled, model.OverageEnabled);
        Assert.Equal(expectedOverageLimit, model.OverageLimit);
        Assert.Equal(expectedPreserveOverageAtReset, model.PreserveOverageAtReset);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedProrationBehavior, model.ProrationBehavior);
        Assert.Equal(expectedRolloverEnabled, model.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, model.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, model.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, model.RolloverTimeframeInterval);
        Assert.Equal(expectedTrialCredits, model.TrialCredits);
        Assert.Equal(expectedTrialCreditsExpireAfterTrial, model.TrialCreditsExpireAfterTrial);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            CreditsReduceOverage = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PreserveOverageAtReset = true,
            PricePerUnit = "price_per_unit",
            ProrationBehavior = Products::ProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::CreditEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            CreditsReduceOverage = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PreserveOverageAtReset = true,
            PricePerUnit = "price_per_unit",
            ProrationBehavior = Products::ProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::CreditEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";
        bool expectedCreditsReduceOverage = true;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        int expectedExpiresAfterDays = 0;
        int expectedLowBalanceThresholdPercent = 0;
        int expectedMaxRolloverCount = 0;
        bool expectedOverageChargeAtBilling = true;
        bool expectedOverageEnabled = true;
        string expectedOverageLimit = "overage_limit";
        bool expectedPreserveOverageAtReset = true;
        string expectedPricePerUnit = "price_per_unit";
        ApiEnum<string, Products::ProrationBehavior> expectedProrationBehavior =
            Products::ProrationBehavior.Prorate;
        bool expectedRolloverEnabled = true;
        int expectedRolloverPercentage = 0;
        int expectedRolloverTimeframeCount = 0;
        ApiEnum<string, TimeInterval> expectedRolloverTimeframeInterval = TimeInterval.Day;
        string expectedTrialCredits = "trial_credits";
        bool expectedTrialCreditsExpireAfterTrial = true;

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, deserialized.CreditsAmount);
        Assert.Equal(expectedCreditsReduceOverage, deserialized.CreditsReduceOverage);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedExpiresAfterDays, deserialized.ExpiresAfterDays);
        Assert.Equal(expectedLowBalanceThresholdPercent, deserialized.LowBalanceThresholdPercent);
        Assert.Equal(expectedMaxRolloverCount, deserialized.MaxRolloverCount);
        Assert.Equal(expectedOverageChargeAtBilling, deserialized.OverageChargeAtBilling);
        Assert.Equal(expectedOverageEnabled, deserialized.OverageEnabled);
        Assert.Equal(expectedOverageLimit, deserialized.OverageLimit);
        Assert.Equal(expectedPreserveOverageAtReset, deserialized.PreserveOverageAtReset);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedProrationBehavior, deserialized.ProrationBehavior);
        Assert.Equal(expectedRolloverEnabled, deserialized.RolloverEnabled);
        Assert.Equal(expectedRolloverPercentage, deserialized.RolloverPercentage);
        Assert.Equal(expectedRolloverTimeframeCount, deserialized.RolloverTimeframeCount);
        Assert.Equal(expectedRolloverTimeframeInterval, deserialized.RolloverTimeframeInterval);
        Assert.Equal(expectedTrialCredits, deserialized.TrialCredits);
        Assert.Equal(
            expectedTrialCreditsExpireAfterTrial,
            deserialized.TrialCreditsExpireAfterTrial
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            CreditsReduceOverage = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PreserveOverageAtReset = true,
            PricePerUnit = "price_per_unit",
            ProrationBehavior = Products::ProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        Assert.Null(model.CreditsReduceOverage);
        Assert.False(model.RawData.ContainsKey("credits_reduce_overage"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.False(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.False(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.False(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageChargeAtBilling);
        Assert.False(model.RawData.ContainsKey("overage_charge_at_billing"));
        Assert.Null(model.OverageEnabled);
        Assert.False(model.RawData.ContainsKey("overage_enabled"));
        Assert.Null(model.OverageLimit);
        Assert.False(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.PreserveOverageAtReset);
        Assert.False(model.RawData.ContainsKey("preserve_overage_at_reset"));
        Assert.Null(model.PricePerUnit);
        Assert.False(model.RawData.ContainsKey("price_per_unit"));
        Assert.Null(model.ProrationBehavior);
        Assert.False(model.RawData.ContainsKey("proration_behavior"));
        Assert.Null(model.RolloverEnabled);
        Assert.False(model.RawData.ContainsKey("rollover_enabled"));
        Assert.Null(model.RolloverPercentage);
        Assert.False(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.False(model.RawData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(model.TrialCredits);
        Assert.False(model.RawData.ContainsKey("trial_credits"));
        Assert.Null(model.TrialCreditsExpireAfterTrial);
        Assert.False(model.RawData.ContainsKey("trial_credits_expire_after_trial"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",

            CreditsReduceOverage = null,
            Currency = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageChargeAtBilling = null,
            OverageEnabled = null,
            OverageLimit = null,
            PreserveOverageAtReset = null,
            PricePerUnit = null,
            ProrationBehavior = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            TrialCredits = null,
            TrialCreditsExpireAfterTrial = null,
        };

        Assert.Null(model.CreditsReduceOverage);
        Assert.True(model.RawData.ContainsKey("credits_reduce_overage"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.ExpiresAfterDays);
        Assert.True(model.RawData.ContainsKey("expires_after_days"));
        Assert.Null(model.LowBalanceThresholdPercent);
        Assert.True(model.RawData.ContainsKey("low_balance_threshold_percent"));
        Assert.Null(model.MaxRolloverCount);
        Assert.True(model.RawData.ContainsKey("max_rollover_count"));
        Assert.Null(model.OverageChargeAtBilling);
        Assert.True(model.RawData.ContainsKey("overage_charge_at_billing"));
        Assert.Null(model.OverageEnabled);
        Assert.True(model.RawData.ContainsKey("overage_enabled"));
        Assert.Null(model.OverageLimit);
        Assert.True(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.PreserveOverageAtReset);
        Assert.True(model.RawData.ContainsKey("preserve_overage_at_reset"));
        Assert.Null(model.PricePerUnit);
        Assert.True(model.RawData.ContainsKey("price_per_unit"));
        Assert.Null(model.ProrationBehavior);
        Assert.True(model.RawData.ContainsKey("proration_behavior"));
        Assert.Null(model.RolloverEnabled);
        Assert.True(model.RawData.ContainsKey("rollover_enabled"));
        Assert.Null(model.RolloverPercentage);
        Assert.True(model.RawData.ContainsKey("rollover_percentage"));
        Assert.Null(model.RolloverTimeframeCount);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_count"));
        Assert.Null(model.RolloverTimeframeInterval);
        Assert.True(model.RawData.ContainsKey("rollover_timeframe_interval"));
        Assert.Null(model.TrialCredits);
        Assert.True(model.RawData.ContainsKey("trial_credits"));
        Assert.Null(model.TrialCreditsExpireAfterTrial);
        Assert.True(model.RawData.ContainsKey("trial_credits_expire_after_trial"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",

            CreditsReduceOverage = null,
            Currency = null,
            ExpiresAfterDays = null,
            LowBalanceThresholdPercent = null,
            MaxRolloverCount = null,
            OverageChargeAtBilling = null,
            OverageEnabled = null,
            OverageLimit = null,
            PreserveOverageAtReset = null,
            PricePerUnit = null,
            ProrationBehavior = null,
            RolloverEnabled = null,
            RolloverPercentage = null,
            RolloverTimeframeCount = null,
            RolloverTimeframeInterval = null,
            TrialCredits = null,
            TrialCreditsExpireAfterTrial = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
            CreditsReduceOverage = true,
            Currency = Currency.Aed,
            ExpiresAfterDays = 0,
            LowBalanceThresholdPercent = 0,
            MaxRolloverCount = 0,
            OverageChargeAtBilling = true,
            OverageEnabled = true,
            OverageLimit = "overage_limit",
            PreserveOverageAtReset = true,
            PricePerUnit = "price_per_unit",
            ProrationBehavior = Products::ProrationBehavior.Prorate,
            RolloverEnabled = true,
            RolloverPercentage = 0,
            RolloverTimeframeCount = 0,
            RolloverTimeframeInterval = TimeInterval.Day,
            TrialCredits = "trial_credits",
            TrialCreditsExpireAfterTrial = true,
        };

        Products::CreditEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProrationBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Products::ProrationBehavior.Prorate)]
    [InlineData(Products::ProrationBehavior.NoProrate)]
    public void Validation_Works(Products::ProrationBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Products::ProrationBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Products::ProrationBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Products::ProrationBehavior.Prorate)]
    [InlineData(Products::ProrationBehavior.NoProrate)]
    public void SerializationRoundtrip_Works(Products::ProrationBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Products::ProrationBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Products::ProrationBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Products::ProrationBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Products::ProrationBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::DigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::DigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::DigitalProductDelivery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::DigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::DigitalProductDelivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::DigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::DigitalProductDelivery { };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::DigitalProductDelivery { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::DigitalProductDelivery
        {
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
        var model = new Products::DigitalProductDelivery
        {
            ExternalUrl = null,
            Instructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::DigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        Products::DigitalProductDelivery copied = new(model);

        Assert.Equal(model, copied);
    }
}
