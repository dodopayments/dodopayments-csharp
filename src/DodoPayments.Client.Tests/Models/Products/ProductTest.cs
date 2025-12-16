using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
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
            IsRecurring = true,
            LicenseKeyEnabled = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
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
            ProductID = "product_id",
            TaxCategory = TaxCategory.DigitalProducts,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Addons = ["string"],
            Description = "description",
            DigitalProductDelivery = new()
            {
                ExternalURL = "external_url",
                Files =
                [
                    new()
                    {
                        FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        URL = "url",
                    },
                ],
                Instructions = "instructions",
            },
            Image = "image",
            LicenseKeyActivationMessage = "license_key_activation_message",
            LicenseKeyActivationsLimit = 0,
            LicenseKeyDuration = new() { Count = 0, Interval = TimeInterval.Day },
            Name = "name",
        };

        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsRecurring = true;
        bool expectedLicenseKeyEnabled = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
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
        string expectedProductID = "product_id";
        ApiEnum<string, TaxCategory> expectedTaxCategory = TaxCategory.DigitalProducts;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedAddons = ["string"];
        string expectedDescription = "description";
        Products::ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
        {
            ExternalURL = "external_url",
            Files =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    URL = "url",
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

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
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
    }
}

public class ProductDigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductDigitalProductDelivery
        {
            ExternalURL = "external_url",
            Files =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    URL = "url",
                },
            ],
            Instructions = "instructions",
        };

        string expectedExternalURL = "external_url";
        List<Products::File> expectedFiles =
        [
            new()
            {
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                FileName = "file_name",
                URL = "url",
            },
        ];
        string expectedInstructions = "instructions";

        Assert.Equal(expectedExternalURL, model.ExternalURL);
        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::File
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            URL = "url",
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedURL = "url";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedURL, model.URL);
    }
}
