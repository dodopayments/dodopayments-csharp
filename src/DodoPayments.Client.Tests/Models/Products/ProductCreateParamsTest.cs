using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
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
