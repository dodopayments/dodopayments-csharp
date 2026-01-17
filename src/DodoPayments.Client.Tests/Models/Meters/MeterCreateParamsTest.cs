using System;
using Meters = DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Meters::MeterCreateParams
        {
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
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
        };

        Meters::MeterAggregation expectedAggregation = new()
        {
            Type = Meters::Type.Count,
            Key = "key",
        };
        string expectedEventName = "event_name";
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";
        string expectedDescription = "description";
        Meters::MeterFilter expectedFilter = new()
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
        };

        Assert.Equal(expectedAggregation, parameters.Aggregation);
        Assert.Equal(expectedEventName, parameters.EventName);
        Assert.Equal(expectedMeasurementUnit, parameters.MeasurementUnit);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFilter, parameters.Filter);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Meters::MeterCreateParams
        {
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Meters::MeterCreateParams
        {
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",

            Description = null,
            Filter = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
    }

    [Fact]
    public void Url_Works()
    {
        Meters::MeterCreateParams parameters = new()
        {
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/meters"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Meters::MeterCreateParams
        {
            Aggregation = new() { Type = Meters::Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
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
        };

        Meters::MeterCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
