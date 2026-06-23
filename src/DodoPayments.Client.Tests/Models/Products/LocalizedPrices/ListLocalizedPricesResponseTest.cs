using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products.LocalizedPrices;

namespace DodoPayments.Client.Tests.Models.Products.LocalizedPrices;

public class ListLocalizedPricesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListLocalizedPricesResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Mode = PricingMode.ByCurrency,
                    ProductID = "product_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CountryCode = CountryCode.Af,
                },
            ],
        };

        List<LocalizedPrice> expectedItems =
        [
            new()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Mode = PricingMode.ByCurrency,
                ProductID = "product_id",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CountryCode = CountryCode.Af,
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
        var model = new ListLocalizedPricesResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Mode = PricingMode.ByCurrency,
                    ProductID = "product_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CountryCode = CountryCode.Af,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListLocalizedPricesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListLocalizedPricesResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Mode = PricingMode.ByCurrency,
                    ProductID = "product_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CountryCode = CountryCode.Af,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListLocalizedPricesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<LocalizedPrice> expectedItems =
        [
            new()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Mode = PricingMode.ByCurrency,
                ProductID = "product_id",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CountryCode = CountryCode.Af,
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
        var model = new ListLocalizedPricesResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Mode = PricingMode.ByCurrency,
                    ProductID = "product_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CountryCode = CountryCode.Af,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ListLocalizedPricesResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Mode = PricingMode.ByCurrency,
                    ProductID = "product_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CountryCode = CountryCode.Af,
                },
            ],
        };

        ListLocalizedPricesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
