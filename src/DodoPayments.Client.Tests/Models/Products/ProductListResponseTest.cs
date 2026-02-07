using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
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
