using System;
using System.Collections.Generic;
using System.Text.Json;
using Meters = DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meters::MeterListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventName = "event_name",
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Filter = new()
                    {
                        Clauses = new(
                            [
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "user_id",
                                    Operator = Meters::Operator.Equals,
                                    Value = "user123",
                                },
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "amount",
                                    Operator = Meters::Operator.GreaterThan,
                                    Value = 100,
                                },
                            ]
                        ),
                        Conjunction = Meters::MeterFilterConjunction.And,
                    },
                },
            ],
        };

        List<Meters::Meter> expectedItems =
        [
            new()
            {
                ID = "id",
                Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventName = "event_name",
                MeasurementUnit = "measurement_unit",
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Filter = new()
                {
                    Clauses = new(
                        [
                            new Meters::MeterFilterCondition()
                            {
                                Key = "user_id",
                                Operator = Meters::Operator.Equals,
                                Value = "user123",
                            },
                            new Meters::MeterFilterCondition()
                            {
                                Key = "amount",
                                Operator = Meters::Operator.GreaterThan,
                                Value = 100,
                            },
                        ]
                    ),
                    Conjunction = Meters::MeterFilterConjunction.And,
                },
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
        var model = new Meters::MeterListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventName = "event_name",
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Filter = new()
                    {
                        Clauses = new(
                            [
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "user_id",
                                    Operator = Meters::Operator.Equals,
                                    Value = "user123",
                                },
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "amount",
                                    Operator = Meters::Operator.GreaterThan,
                                    Value = 100,
                                },
                            ]
                        ),
                        Conjunction = Meters::MeterFilterConjunction.And,
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Meters::MeterListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meters::MeterListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventName = "event_name",
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Filter = new()
                    {
                        Clauses = new(
                            [
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "user_id",
                                    Operator = Meters::Operator.Equals,
                                    Value = "user123",
                                },
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "amount",
                                    Operator = Meters::Operator.GreaterThan,
                                    Value = 100,
                                },
                            ]
                        ),
                        Conjunction = Meters::MeterFilterConjunction.And,
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Meters::MeterListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<Meters::Meter> expectedItems =
        [
            new()
            {
                ID = "id",
                Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventName = "event_name",
                MeasurementUnit = "measurement_unit",
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Filter = new()
                {
                    Clauses = new(
                        [
                            new Meters::MeterFilterCondition()
                            {
                                Key = "user_id",
                                Operator = Meters::Operator.Equals,
                                Value = "user123",
                            },
                            new Meters::MeterFilterCondition()
                            {
                                Key = "amount",
                                Operator = Meters::Operator.GreaterThan,
                                Value = 100,
                            },
                        ]
                    ),
                    Conjunction = Meters::MeterFilterConjunction.And,
                },
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
        var model = new Meters::MeterListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventName = "event_name",
                    MeasurementUnit = "measurement_unit",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Filter = new()
                    {
                        Clauses = new(
                            [
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "user_id",
                                    Operator = Meters::Operator.Equals,
                                    Value = "user123",
                                },
                                new Meters::MeterFilterCondition()
                                {
                                    Key = "amount",
                                    Operator = Meters::Operator.GreaterThan,
                                    Value = 100,
                                },
                            ]
                        ),
                        Conjunction = Meters::MeterFilterConjunction.And,
                    },
                },
            ],
        };

        model.Validate();
    }
}
