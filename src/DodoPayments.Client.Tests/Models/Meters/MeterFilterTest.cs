using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterFilter
        {
            Clauses = new(
                [
                    new MeterFilterCondition()
                    {
                        Key = "user_id",
                        Operator = FilterOperator.Equals,
                        Value = "user123",
                    },
                    new MeterFilterCondition()
                    {
                        Key = "amount",
                        Operator = FilterOperator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        FilterType expectedClauses = new(
            [
                new MeterFilterCondition()
                {
                    Key = "user_id",
                    Operator = FilterOperator.Equals,
                    Value = "user123",
                },
                new MeterFilterCondition()
                {
                    Key = "amount",
                    Operator = FilterOperator.GreaterThan,
                    Value = 100,
                },
            ]
        );
        ApiEnum<string, Conjunction> expectedConjunction = Conjunction.And;

        Assert.Equal(expectedClauses, model.Clauses);
        Assert.Equal(expectedConjunction, model.Conjunction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeterFilter
        {
            Clauses = new(
                [
                    new MeterFilterCondition()
                    {
                        Key = "user_id",
                        Operator = FilterOperator.Equals,
                        Value = "user123",
                    },
                    new MeterFilterCondition()
                    {
                        Key = "amount",
                        Operator = FilterOperator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterFilter
        {
            Clauses = new(
                [
                    new MeterFilterCondition()
                    {
                        Key = "user_id",
                        Operator = FilterOperator.Equals,
                        Value = "user123",
                    },
                    new MeterFilterCondition()
                    {
                        Key = "amount",
                        Operator = FilterOperator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FilterType expectedClauses = new(
            [
                new MeterFilterCondition()
                {
                    Key = "user_id",
                    Operator = FilterOperator.Equals,
                    Value = "user123",
                },
                new MeterFilterCondition()
                {
                    Key = "amount",
                    Operator = FilterOperator.GreaterThan,
                    Value = 100,
                },
            ]
        );
        ApiEnum<string, Conjunction> expectedConjunction = Conjunction.And;

        Assert.Equal(expectedClauses, deserialized.Clauses);
        Assert.Equal(expectedConjunction, deserialized.Conjunction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeterFilter
        {
            Clauses = new(
                [
                    new MeterFilterCondition()
                    {
                        Key = "user_id",
                        Operator = FilterOperator.Equals,
                        Value = "user123",
                    },
                    new MeterFilterCondition()
                    {
                        Key = "amount",
                        Operator = FilterOperator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeterFilter
        {
            Clauses = new(
                [
                    new MeterFilterCondition()
                    {
                        Key = "user_id",
                        Operator = FilterOperator.Equals,
                        Value = "user123",
                    },
                    new MeterFilterCondition()
                    {
                        Key = "amount",
                        Operator = FilterOperator.GreaterThan,
                        Value = 100,
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        MeterFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}
