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

        List<ItemModel> expectedItems =
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>(
            json
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveUsageHistoryPageResponse>(
            json
        );
        Assert.NotNull(deserialized);

        List<ItemModel> expectedItems =
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

public class ItemModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemModel
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
        };

        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MeterModel> expectedMeters =
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
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedMeters.Count, model.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], model.Meters[i]);
        }
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemModel
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ItemModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemModel
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ItemModel>(json);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MeterModel> expectedMeters =
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
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedMeters.Count, deserialized.Meters.Count);
        for (int i = 0; i < expectedMeters.Count; i++)
        {
            Assert.Equal(expectedMeters[i], deserialized.Meters[i]);
        }
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemModel
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
        };

        model.Validate();
    }
}

public class MeterModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterModel
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            ConsumedUnits = "consumed_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            TotalPrice = 0,
        };

        string expectedID = "id";
        string expectedChargeableUnits = "chargeable_units";
        string expectedConsumedUnits = "consumed_units";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedName = "name";
        string expectedPricePerUnit = "price_per_unit";
        int expectedTotalPrice = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChargeableUnits, model.ChargeableUnits);
        Assert.Equal(expectedConsumedUnits, model.ConsumedUnits);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFreeThreshold, model.FreeThreshold);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedTotalPrice, model.TotalPrice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeterModel
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            ConsumedUnits = "consumed_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            TotalPrice = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeterModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterModel
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            ConsumedUnits = "consumed_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            TotalPrice = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeterModel>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedChargeableUnits = "chargeable_units";
        string expectedConsumedUnits = "consumed_units";
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedName = "name";
        string expectedPricePerUnit = "price_per_unit";
        int expectedTotalPrice = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChargeableUnits, deserialized.ChargeableUnits);
        Assert.Equal(expectedConsumedUnits, deserialized.ConsumedUnits);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFreeThreshold, deserialized.FreeThreshold);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedTotalPrice, deserialized.TotalPrice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeterModel
        {
            ID = "id",
            ChargeableUnits = "chargeable_units",
            ConsumedUnits = "consumed_units",
            Currency = Currency.Aed,
            FreeThreshold = 0,
            Name = "name",
            PricePerUnit = "price_per_unit",
            TotalPrice = 0,
        };

        model.Validate();
    }
}
