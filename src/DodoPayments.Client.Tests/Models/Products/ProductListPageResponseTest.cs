using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using Products = DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::ProductListPageResponse
        {
            Items =
            [
                new()
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
                        Price = 0,
                        PurchasingPowerParity = true,
                        Type = Products::Type.OneTimePrice,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxInclusive = true,
                },
            ],
        };

        List<Products::Item> expectedItems =
        [
            new()
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
                    Price = 0,
                    PurchasingPowerParity = true,
                    Type = Products::Type.OneTimePrice,
                    PayWhatYouWant = true,
                    SuggestedPrice = 0,
                    TaxInclusive = true,
                },
                TaxInclusive = true,
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Products::Item
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
                Price = 0,
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
            Price = 0,
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
}
