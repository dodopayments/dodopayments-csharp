using System;
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
                Conjunction = Meters::MeterMeterFilterConjunction.And,
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
        Meters::MeterMeterFilter expectedFilter = new()
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
            Conjunction = Meters::MeterMeterFilterConjunction.And,
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
}
