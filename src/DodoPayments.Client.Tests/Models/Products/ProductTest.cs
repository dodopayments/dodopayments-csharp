using System;
using System.Collections.Generic;
using System.Text.Json;
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

public class ProductDigitalProductDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductDigitalProductDelivery
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

        string expectedExternalUrl = "external_url";
        List<Products::File> expectedFiles =
        [
            new()
            {
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                FileName = "file_name",
                Url = "url",
            },
        ];
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
        var model = new Products::ProductDigitalProductDelivery
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductDigitalProductDelivery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::ProductDigitalProductDelivery
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductDigitalProductDelivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExternalUrl = "external_url";
        List<Products::File> expectedFiles =
        [
            new()
            {
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                FileName = "file_name",
                Url = "url",
            },
        ];
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
        var model = new Products::ProductDigitalProductDelivery
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Products::ProductDigitalProductDelivery { };

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
        var model = new Products::ProductDigitalProductDelivery { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Products::ProductDigitalProductDelivery
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
        var model = new Products::ProductDigitalProductDelivery
        {
            ExternalUrl = null,
            Files = null,
            Instructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::ProductDigitalProductDelivery
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

        Products::ProductDigitalProductDelivery copied = new(model);

        Assert.Equal(model, copied);
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
            Url = "url",
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedUrl = "url";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Products::File
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::File>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Products::File
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::File>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedUrl = "url";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Products::File
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Products::File
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Url = "url",
        };

        Products::File copied = new(model);

        Assert.Equal(model, copied);
    }
}
