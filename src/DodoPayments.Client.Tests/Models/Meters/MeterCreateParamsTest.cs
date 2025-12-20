using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterCreateParams
        {
            Aggregation = new() { Type = Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",
            Description = "description",
            Filter = new()
            {
                Clauses = new(
                    [
                        new MeterFilterCondition()
                        {
                            Key = "user_id",
                            Operator = Operator.Equals,
                            Value = "user123",
                        },
                        new MeterFilterCondition()
                        {
                            Key = "amount",
                            Operator = Operator.GreaterThan,
                            Value = 100,
                        },
                    ]
                ),
                Conjunction = MeterFilterConjunction.And,
            },
        };

        MeterAggregation expectedAggregation = new() { Type = Type.Count, Key = "key" };
        string expectedEventName = "event_name";
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";
        string expectedDescription = "description";
        MeterFilter expectedFilter = new()
        {
            Clauses = new(
                [
                    new MeterFilterCondition()
                    {
                        Key = "user_id",
                        Operator = Operator.Equals,
                        Value = "user123",
                    },
                    new MeterFilterCondition()
                    {
                        Key = "amount",
                        Operator = Operator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = MeterFilterConjunction.And,
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
        var parameters = new MeterCreateParams
        {
            Aggregation = new() { Type = Type.Count, Key = "key" },
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
        var parameters = new MeterCreateParams
        {
            Aggregation = new() { Type = Type.Count, Key = "key" },
            EventName = "event_name",
            MeasurementUnit = "measurement_unit",
            Name = "name",

            Description = null,
            Filter = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
    }
}
