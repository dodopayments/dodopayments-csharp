using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Products::ProductUpdateParams
        {
            ID = "id",
            Addons = ["string"],
            BrandID = "brand_id",
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalUrl = "external_url",
                Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
                Instructions = "instructions",
            },
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Price = new Products::OneTimePrice()
            {
                Currency = Currency.Aed,
                Discount = 0,
                Price = 0,
                PurchasingPowerParity = true,
                Type = Products::Type.OneTimePrice,
                PayWhatYouWant = true,
                SuggestedPrice = 0,
                TaxInclusive = true,
            },
            TaxCategory = TaxCategory.DigitalProducts,
        };

        string expectedID = "id";
        List<string> expectedAddons = ["string"];
        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        Products::ProductUpdateParamsDigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            ExternalUrl = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedLicenseKeyActivationMessage = "license_key_activation_message";
        int expectedLicenseKeyActivationsLimit = 0;
        Products::LicenseKeyDuration expectedLicenseKeyDuration = new()
        {
            Count = 0,
            Interval = TimeInterval.Day,
        };
        bool expectedLicenseKeyEnabled = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        Products::Price expectedPrice = new Products::OneTimePrice()
        {
            Currency = Currency.Aed,
            Discount = 0,
            Price = 0,
            PurchasingPowerParity = true,
            Type = Products::Type.OneTimePrice,
            PayWhatYouWant = true,
            SuggestedPrice = 0,
            TaxInclusive = true,
        };
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDigitalProductDelivery, parameters.DigitalProductDelivery);
        Assert.Equal(expectedImageID, parameters.ImageID);
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
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPrice, parameters.Price);
        Assert.Equal(expectedTaxCategory, parameters.TaxCategory);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Products::ProductUpdateParams { ID = "id" };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DigitalProductDelivery);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_product_delivery"));
        Assert.Null(parameters.ImageID);
        Assert.False(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.LicenseKeyActivationMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_activation_message"));
        Assert.Null(parameters.LicenseKeyActivationsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_activations_limit"));
        Assert.Null(parameters.LicenseKeyDuration);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_duration"));
        Assert.Null(parameters.LicenseKeyEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("license_key_enabled"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Price);
        Assert.False(parameters.RawBodyData.ContainsKey("price"));
        Assert.Null(parameters.TaxCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_category"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Products::ProductUpdateParams
        {
            ID = "id",

            Addons = null,
            BrandID = null,
            Description = null,
            DigitalProductDelivery = null,
            ImageID = null,
            LicenseKeyActivationMessage = null,
            LicenseKeyActivationsLimit = null,
            LicenseKeyDuration = null,
            LicenseKeyEnabled = null,
            Metadata = null,
            Name = null,
            Price = null,
            TaxCategory = null,
        };

        Assert.Null(parameters.Addons);
        Assert.True(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DigitalProductDelivery);
        Assert.True(parameters.RawBodyData.ContainsKey("digital_product_delivery"));
        Assert.Null(parameters.ImageID);
        Assert.True(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.LicenseKeyActivationMessage);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_activation_message"));
        Assert.Null(parameters.LicenseKeyActivationsLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_activations_limit"));
        Assert.Null(parameters.LicenseKeyDuration);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_duration"));
        Assert.Null(parameters.LicenseKeyEnabled);
        Assert.True(parameters.RawBodyData.ContainsKey("license_key_enabled"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Price);
        Assert.True(parameters.RawBodyData.ContainsKey("price"));
        Assert.Null(parameters.TaxCategory);
        Assert.True(parameters.RawBodyData.ContainsKey("tax_category"));
    }

    [Fact]
    public void Url_Works()
    {
        Products::ProductUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/products/id"), url);
    }
}

public class ProductUpdateParamsDigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string expectedExternalUrl = "external_url";
        List<string> expectedFiles = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.NotNull(model.Files);
        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductUpdateParamsDigitalProductDelivery>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Products::ProductUpdateParamsDigitalProductDelivery>(
                element
            );
        Assert.NotNull(deserialized);

        string expectedExternalUrl = "external_url";
        List<string> expectedFiles = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.NotNull(deserialized.Files);
        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery
        {
            ExternalUrl = "external_url",
            Files = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery { };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Files);
        Assert.False(model.RawData.ContainsKey("files"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery
        {
            ExternalUrl = null,
            Files = null,
            Instructions = null,
        };

        Assert.Null(model.ExternalUrl);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Files);
        Assert.True(model.RawData.ContainsKey("files"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Products::ProductUpdateParamsDigitalProductDelivery
        {
            ExternalUrl = null,
            Files = null,
            Instructions = null,
        };

        model.Validate();
    }
}
