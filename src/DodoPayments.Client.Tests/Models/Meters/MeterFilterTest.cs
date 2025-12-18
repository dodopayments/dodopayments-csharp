using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
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

        Clauses expectedClauses = new(
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
        );
        ApiEnum<string, MeterFilterConjunction> expectedConjunction = MeterFilterConjunction.And;

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeterFilter>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeterFilter>(json);
        Assert.NotNull(deserialized);

        Clauses expectedClauses = new(
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
        );
        ApiEnum<string, MeterFilterConjunction> expectedConjunction = MeterFilterConjunction.And;

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

        model.Validate();
    }
}

public class ClausesTest : TestBase
{
    [Fact]
    public void DirectFilterConditionsValidationWorks()
    {
        Clauses value = new(
            [
                new MeterFilterCondition()
                {
                    Key = "x",
                    Operator = Operator.Equals,
                    Value = "string",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void NestedMeterFiltersValidationWorks()
    {
        Clauses value = new(
            [
                new ClausesMeterFilter()
                {
                    Clauses = new(
                        [
                            new ClausesMeterFilterClausesMeterFilterCondition()
                            {
                                Key = "x",
                                Operator =
                                    ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = ClausesMeterFilterConjunction.And,
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void DirectFilterConditionsSerializationRoundtripWorks()
    {
        Clauses value = new(
            [
                new MeterFilterCondition()
                {
                    Key = "x",
                    Operator = Operator.Equals,
                    Value = "string",
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Clauses>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NestedMeterFiltersSerializationRoundtripWorks()
    {
        Clauses value = new(
            [
                new ClausesMeterFilter()
                {
                    Clauses = new(
                        [
                            new ClausesMeterFilterClausesMeterFilterCondition()
                            {
                                Key = "x",
                                Operator =
                                    ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = ClausesMeterFilterConjunction.And,
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Clauses>(json);

        Assert.Equal(value, deserialized);
    }
}

public class MeterFilterConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterFilterCondition
        {
            Key = "x",
            Operator = Operator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, Operator> expectedOperator = Operator.Equals;
        MeterFilterConditionValue expectedValue = "string";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeterFilterCondition
        {
            Key = "x",
            Operator = Operator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeterFilterCondition>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterFilterCondition
        {
            Key = "x",
            Operator = Operator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MeterFilterCondition>(json);
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, Operator> expectedOperator = Operator.Equals;
        MeterFilterConditionValue expectedValue = "string";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeterFilterCondition
        {
            Key = "x",
            Operator = Operator.Equals,
            Value = "string",
        };

        model.Validate();
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.Equals)]
    [InlineData(Operator.NotEquals)]
    [InlineData(Operator.GreaterThan)]
    [InlineData(Operator.GreaterThanOrEquals)]
    [InlineData(Operator.LessThan)]
    [InlineData(Operator.LessThanOrEquals)]
    [InlineData(Operator.Contains)]
    [InlineData(Operator.DoesNotContain)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.Equals)]
    [InlineData(Operator.NotEquals)]
    [InlineData(Operator.GreaterThan)]
    [InlineData(Operator.GreaterThanOrEquals)]
    [InlineData(Operator.LessThan)]
    [InlineData(Operator.LessThanOrEquals)]
    [InlineData(Operator.Contains)]
    [InlineData(Operator.DoesNotContain)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MeterFilterConditionValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MeterFilterConditionValue value = new("string");
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MeterFilterConditionValue value = new(0);
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        MeterFilterConditionValue value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MeterFilterConditionValue value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MeterFilterConditionValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MeterFilterConditionValue value = new(0);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MeterFilterConditionValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        MeterFilterConditionValue value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MeterFilterConditionValue>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterConjunction.And,
        };

        ClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        ApiEnum<string, ClausesMeterFilterConjunction> expectedConjunction =
            ClausesMeterFilterConjunction.And;

        Assert.Equal(expectedClauses, model.Clauses);
        Assert.Equal(expectedConjunction, model.Conjunction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterConjunction.And,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterConjunction.And,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilter>(json);
        Assert.NotNull(deserialized);

        ClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        ApiEnum<string, ClausesMeterFilterConjunction> expectedConjunction =
            ClausesMeterFilterConjunction.And;

        Assert.Equal(expectedClauses, deserialized.Clauses);
        Assert.Equal(expectedConjunction, deserialized.Conjunction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterConjunction.And,
        };

        model.Validate();
    }
}

public class ClausesMeterFilterClausesTest : TestBase
{
    [Fact]
    public void Level1FilterConditionsValidationWorks()
    {
        ClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void Level1NestedFiltersValidationWorks()
    {
        ClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilter()
                {
                    Clauses = new(
                        [
                            new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                            {
                                Key = "x",
                                Operator =
                                    ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = ClausesMeterFilterClausesMeterFilterConjunction.And,
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void Level1FilterConditionsSerializationRoundtripWorks()
    {
        ClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClauses>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Level1NestedFiltersSerializationRoundtripWorks()
    {
        ClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilter()
                {
                    Clauses = new(
                        [
                            new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                            {
                                Key = "x",
                                Operator =
                                    ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = ClausesMeterFilterClausesMeterFilterConjunction.And,
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClauses>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator> expectedOperator =
            ClausesMeterFilterClausesMeterFilterConditionOperator.Equals;
        ClausesMeterFilterClausesMeterFilterConditionValue expectedValue = "string";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterCondition>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterCondition>(json);
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator> expectedOperator =
            ClausesMeterFilterClausesMeterFilterConditionOperator.Equals;
        ClausesMeterFilterClausesMeterFilterConditionValue expectedValue = "string";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = ClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }
}

public class ClausesMeterFilterClausesMeterFilterConditionOperatorTest : TestBase
{
    [Theory]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.Equals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.LessThan)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.Contains)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain)]
    public void Validation_Works(ClausesMeterFilterClausesMeterFilterConditionOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.Equals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.LessThan)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.Contains)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain)]
    public void SerializationRoundtrip_Works(
        ClausesMeterFilterClausesMeterFilterConditionOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConditionOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterConditionValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = new("string");
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = new(0);
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterConditionValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = new(0);
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterConditionValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterConditionValue>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator =
                            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterClausesMeterFilterConjunction.And,
        };

        ClausesMeterFilterClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator =
                        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction> expectedConjunction =
            ClausesMeterFilterClausesMeterFilterConjunction.And;

        Assert.Equal(expectedClauses, model.Clauses);
        Assert.Equal(expectedConjunction, model.Conjunction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator =
                            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterClausesMeterFilterConjunction.And,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator =
                            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterClausesMeterFilterConjunction.And,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilter>(json);
        Assert.NotNull(deserialized);

        ClausesMeterFilterClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator =
                        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction> expectedConjunction =
            ClausesMeterFilterClausesMeterFilterConjunction.And;

        Assert.Equal(expectedClauses, deserialized.Clauses);
        Assert.Equal(expectedConjunction, deserialized.Conjunction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator =
                            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = ClausesMeterFilterClausesMeterFilterConjunction.And,
        };

        model.Validate();
    }
}

public class ClausesMeterFilterClausesMeterFilterClausesTest : TestBase
{
    [Fact]
    public void Level2FilterConditionsValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator =
                        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void Level2NestedFiltersValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilter()
                {
                    Clauses =
                    [
                        new()
                        {
                            Key = "x",
                            Operator = ClauseOperator.Equals,
                            Value = "string",
                        },
                    ],
                    Conjunction = Conjunction.And,
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void Level2FilterConditionsSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator =
                        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
                    Value = "string",
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClauses>(
            json
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Level2NestedFiltersSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClauses value = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilter()
                {
                    Clauses =
                    [
                        new()
                        {
                            Key = "x",
                            Operator = ClauseOperator.Equals,
                            Value = "string",
                        },
                    ],
                    Conjunction = Conjunction.And,
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClauses>(
            json
        );

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator =
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<
            string,
            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
        > expectedOperator =
            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals;
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue expectedValue =
            "string";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator =
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator =
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<
            string,
            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
        > expectedOperator =
            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals;
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue expectedValue =
            "string";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator =
                ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }
}

public class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperatorTest : TestBase
{
    [Theory]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals)]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan
    )]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals
    )]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThan)]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals
    )]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Contains)]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain
    )]
    public void Validation_Works(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Equals)]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.NotEquals)]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThan
    )]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.GreaterThanOrEquals
    )]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThan)]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.LessThanOrEquals
    )]
    [InlineData(ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.Contains)]
    [InlineData(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator.DoesNotContain
    )]
    public void SerializationRoundtrip_Works(
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = new("string");
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = new(0);
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = new(0);
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterClausesMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilter
        {
            Clauses =
            [
                new()
                {
                    Key = "x",
                    Operator = ClauseOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        List<Clause> expectedClauses =
        [
            new()
            {
                Key = "x",
                Operator = ClauseOperator.Equals,
                Value = "string",
            },
        ];
        ApiEnum<string, Conjunction> expectedConjunction = Conjunction.And;

        Assert.Equal(expectedClauses.Count, model.Clauses.Count);
        for (int i = 0; i < expectedClauses.Count; i++)
        {
            Assert.Equal(expectedClauses[i], model.Clauses[i]);
        }
        Assert.Equal(expectedConjunction, model.Conjunction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilter
        {
            Clauses =
            [
                new()
                {
                    Key = "x",
                    Operator = ClauseOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilter
        {
            Clauses =
            [
                new()
                {
                    Key = "x",
                    Operator = ClauseOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>(
                json
            );
        Assert.NotNull(deserialized);

        List<Clause> expectedClauses =
        [
            new()
            {
                Key = "x",
                Operator = ClauseOperator.Equals,
                Value = "string",
            },
        ];
        ApiEnum<string, Conjunction> expectedConjunction = Conjunction.And;

        Assert.Equal(expectedClauses.Count, deserialized.Clauses.Count);
        for (int i = 0; i < expectedClauses.Count; i++)
        {
            Assert.Equal(expectedClauses[i], deserialized.Clauses[i]);
        }
        Assert.Equal(expectedConjunction, deserialized.Conjunction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilter
        {
            Clauses =
            [
                new()
                {
                    Key = "x",
                    Operator = ClauseOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        model.Validate();
    }
}

public class ClauseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Clause
        {
            Key = "x",
            Operator = ClauseOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, ClauseOperator> expectedOperator = ClauseOperator.Equals;
        ClauseValue expectedValue = "string";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Clause
        {
            Key = "x",
            Operator = ClauseOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Clause>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Clause
        {
            Key = "x",
            Operator = ClauseOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Clause>(json);
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, ClauseOperator> expectedOperator = ClauseOperator.Equals;
        ClauseValue expectedValue = "string";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Clause
        {
            Key = "x",
            Operator = ClauseOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }
}

public class ClauseOperatorTest : TestBase
{
    [Theory]
    [InlineData(ClauseOperator.Equals)]
    [InlineData(ClauseOperator.NotEquals)]
    [InlineData(ClauseOperator.GreaterThan)]
    [InlineData(ClauseOperator.GreaterThanOrEquals)]
    [InlineData(ClauseOperator.LessThan)]
    [InlineData(ClauseOperator.LessThanOrEquals)]
    [InlineData(ClauseOperator.Contains)]
    [InlineData(ClauseOperator.DoesNotContain)]
    public void Validation_Works(ClauseOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClauseOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClauseOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClauseOperator.Equals)]
    [InlineData(ClauseOperator.NotEquals)]
    [InlineData(ClauseOperator.GreaterThan)]
    [InlineData(ClauseOperator.GreaterThanOrEquals)]
    [InlineData(ClauseOperator.LessThan)]
    [InlineData(ClauseOperator.LessThanOrEquals)]
    [InlineData(ClauseOperator.Contains)]
    [InlineData(ClauseOperator.DoesNotContain)]
    public void SerializationRoundtrip_Works(ClauseOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClauseOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClauseOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClauseOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClauseOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ClauseValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ClauseValue value = new("string");
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ClauseValue value = new(0);
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ClauseValue value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ClauseValue value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClauseValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ClauseValue value = new(0);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClauseValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClauseValue value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClauseValue>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ConjunctionTest : TestBase
{
    [Theory]
    [InlineData(Conjunction.And)]
    [InlineData(Conjunction.Or)]
    public void Validation_Works(Conjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Conjunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Conjunction.And)]
    [InlineData(Conjunction.Or)]
    public void SerializationRoundtrip_Works(Conjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Conjunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Conjunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterClausesMeterFilterConjunctionTest : TestBase
{
    [Theory]
    [InlineData(ClausesMeterFilterClausesMeterFilterConjunction.And)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConjunction.Or)]
    public void Validation_Works(ClausesMeterFilterClausesMeterFilterConjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClausesMeterFilterClausesMeterFilterConjunction.And)]
    [InlineData(ClausesMeterFilterClausesMeterFilterConjunction.Or)]
    public void SerializationRoundtrip_Works(
        ClausesMeterFilterClausesMeterFilterConjunction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterClausesMeterFilterConjunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ClausesMeterFilterConjunctionTest : TestBase
{
    [Theory]
    [InlineData(ClausesMeterFilterConjunction.And)]
    [InlineData(ClausesMeterFilterConjunction.Or)]
    public void Validation_Works(ClausesMeterFilterConjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClausesMeterFilterConjunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClausesMeterFilterConjunction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClausesMeterFilterConjunction.And)]
    [InlineData(ClausesMeterFilterConjunction.Or)]
    public void SerializationRoundtrip_Works(ClausesMeterFilterConjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClausesMeterFilterConjunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterConjunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClausesMeterFilterConjunction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClausesMeterFilterConjunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MeterFilterConjunctionTest : TestBase
{
    [Theory]
    [InlineData(MeterFilterConjunction.And)]
    [InlineData(MeterFilterConjunction.Or)]
    public void Validation_Works(MeterFilterConjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MeterFilterConjunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MeterFilterConjunction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MeterFilterConjunction.And)]
    [InlineData(MeterFilterConjunction.Or)]
    public void SerializationRoundtrip_Works(MeterFilterConjunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MeterFilterConjunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MeterFilterConjunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MeterFilterConjunction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MeterFilterConjunction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
