using System;
using System.Collections.Generic;
using System.Text.Json;
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

        List<Products::ProductListResponse> expectedItems =
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Products::ProductListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Products::ProductListResponse> expectedItems =
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

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }
}
