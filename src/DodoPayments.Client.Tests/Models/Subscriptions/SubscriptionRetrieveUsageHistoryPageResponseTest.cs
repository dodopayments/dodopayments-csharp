using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionRetrieveUsageHistoryPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionRetrieveUsageHistoryPageResponse
        {
            Items =
            [
                new()
                {
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Meters =
                    [
                        new()
                        {
                            ID = "id",
                            ChargeableUnits = "chargeable_units",
                            ConsumedUnits = "consumed_units",
                            Currency = Currency.Aed,
                            FreeThreshold = 0,
                            Name = "name",
                            PricePerUnit = "price_per_unit",
                            TotalPrice = 0,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<SubscriptionRetrieveUsageHistoryResponse> expectedItems =
        [
            new()
            {
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Meters =
                [
                    new()
                    {
                        ID = "id",
                        ChargeableUnits = "chargeable_units",
                        ConsumedUnits = "consumed_units",
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        Name = "name",
                        PricePerUnit = "price_per_unit",
                        TotalPrice = 0,
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new SubscriptionRetrieveUsageHistoryPageResponse
        {
            Items =
            [
                new()
                {
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Meters =
                    [
                        new()
                        {
                            ID = "id",
                            ChargeableUnits = "chargeable_units",
                            ConsumedUnits = "consumed_units",
                            Currency = Currency.Aed,
                            FreeThreshold = 0,
                            Name = "name",
                            PricePerUnit = "price_per_unit",
                            TotalPrice = 0,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionRetrieveUsageHistoryPageResponse
        {
            Items =
            [
                new()
                {
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Meters =
                    [
                        new()
                        {
                            ID = "id",
                            ChargeableUnits = "chargeable_units",
                            ConsumedUnits = "consumed_units",
                            Currency = Currency.Aed,
                            FreeThreshold = 0,
                            Name = "name",
                            PricePerUnit = "price_per_unit",
                            TotalPrice = 0,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SubscriptionRetrieveUsageHistoryResponse> expectedItems =
        [
            new()
            {
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Meters =
                [
                    new()
                    {
                        ID = "id",
                        ChargeableUnits = "chargeable_units",
                        ConsumedUnits = "consumed_units",
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        Name = "name",
                        PricePerUnit = "price_per_unit",
                        TotalPrice = 0,
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new SubscriptionRetrieveUsageHistoryPageResponse
        {
            Items =
            [
                new()
                {
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Meters =
                    [
                        new()
                        {
                            ID = "id",
                            ChargeableUnits = "chargeable_units",
                            ConsumedUnits = "consumed_units",
                            Currency = Currency.Aed,
                            FreeThreshold = 0,
                            Name = "name",
                            PricePerUnit = "price_per_unit",
                            TotalPrice = 0,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }
}
