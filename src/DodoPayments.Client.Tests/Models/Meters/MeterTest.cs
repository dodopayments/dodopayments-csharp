using System;
using System.Text.Json;
using Meters = DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meters::Meter
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
                        new()
                        {
                            Key = "user_id",
                            Operator = Meters::Operator.Equals,
                            Value = "user123",
                        },
                        new()
                        {
                            Key = "amount",
                            Operator = Meters::Operator.GreaterThan,
                            Value = 100,
                        },
                    ]
                ),
                Conjunction = Meters::MeterFilterConjunction.And,
            },
        };

        string expectedID = "id";
        Meters::MeterAggregation expectedAggregation = new()
        {
            Type = Meters::Type.Count,
            Key = "key",
        };
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventName = "event_name";
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        Meters::MeterFilter expectedFilter = new()
        {
            Clauses = new(
                [
                    new()
                    {
                        Key = "user_id",
                        Operator = Meters::Operator.Equals,
                        Value = "user123",
                    },
                    new()
                    {
                        Key = "amount",
                        Operator = Meters::Operator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Meters::MeterFilterConjunction.And,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAggregation, model.Aggregation);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedMeasurementUnit, model.MeasurementUnit);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFilter, model.Filter);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meters::Meter
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
                        new()
                        {
                            Key = "user_id",
                            Operator = Meters::Operator.Equals,
                            Value = "user123",
                        },
                        new()
                        {
                            Key = "amount",
                            Operator = Meters::Operator.GreaterThan,
                            Value = 100,
                        },
                    ]
                ),
                Conjunction = Meters::MeterFilterConjunction.And,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Meters::Meter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meters::Meter
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
                        new()
                        {
                            Key = "user_id",
                            Operator = Meters::Operator.Equals,
                            Value = "user123",
                        },
                        new()
                        {
                            Key = "amount",
                            Operator = Meters::Operator.GreaterThan,
                            Value = 100,
                        },
                    ]
                ),
                Conjunction = Meters::MeterFilterConjunction.And,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Meters::Meter>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Meters::MeterAggregation expectedAggregation = new()
        {
            Type = Meters::Type.Count,
            Key = "key",
        };
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventName = "event_name";
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        Meters::MeterFilter expectedFilter = new()
        {
            Clauses = new(
                [
                    new()
                    {
                        Key = "user_id",
                        Operator = Meters::Operator.Equals,
                        Value = "user123",
                    },
                    new()
                    {
                        Key = "amount",
                        Operator = Meters::Operator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Meters::MeterFilterConjunction.And,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAggregation, deserialized.Aggregation);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventName, deserialized.EventName);
        Assert.Equal(expectedMeasurementUnit, deserialized.MeasurementUnit);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFilter, deserialized.Filter);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meters::Meter
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
                        new()
                        {
                            Key = "user_id",
                            Operator = Meters::Operator.Equals,
                            Value = "user123",
                        },
                        new()
                        {
                            Key = "amount",
                            Operator = Meters::Operator.GreaterThan,
                            Value = 100,
                        },
                    ]
                ),
                Conjunction = Meters::MeterFilterConjunction.And,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meters::Meter
        {
            ID = "id",
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Filter);
        Assert.False(model.RawData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meters::Meter
        {
            ID = "id",
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Meters::Meter
        {
            ID = "id",
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            Filter = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Filter);
        Assert.True(model.RawData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meters::Meter
        {
            ID = "id",
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            Filter = null,
        };

        model.Validate();
    }
}
