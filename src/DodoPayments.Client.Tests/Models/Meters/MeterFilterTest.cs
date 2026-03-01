using System.Collections.Generic;
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

        Clauses expectedClauses = new(
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

        Clauses expectedClauses = new(
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
                    Operator = FilterOperator.Equals,
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
                                Operator = FilterOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = Conjunction.And,
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
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Clauses>(
            element,
            ModelBase.SerializerOptions
        );

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
                                Operator = FilterOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = Conjunction.And,
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Clauses>(
            element,
            ModelBase.SerializerOptions
        );

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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilterCondition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterFilterCondition
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilterCondition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeterFilterCondition
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        MeterFilterCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MeterFilterConditionValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MeterFilterConditionValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MeterFilterConditionValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        MeterFilterConditionValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MeterFilterConditionValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilterConditionValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MeterFilterConditionValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilterConditionValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        MeterFilterConditionValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterFilterConditionValue>(
            element,
            ModelBase.SerializerOptions
        );

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
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        ClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = FilterOperator.Equals,
                    Value = "string",
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
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilter>(
            json,
            ModelBase.SerializerOptions
        );

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
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = FilterOperator.Equals,
                    Value = "string",
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
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = FilterOperator.Equals,
                        Value = "string",
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
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        ClausesMeterFilter copied = new(model);

        Assert.Equal(model, copied);
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
                    Operator = FilterOperator.Equals,
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
                                Operator = FilterOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = Conjunction.And,
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
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClauses>(
            element,
            ModelBase.SerializerOptions
        );

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
                                Operator = FilterOperator.Equals,
                                Value = "string",
                            },
                        ]
                    ),
                    Conjunction = Conjunction.And,
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClauses>(
            element,
            ModelBase.SerializerOptions
        );

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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterCondition>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterCondition>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        ClausesMeterFilterClausesMeterFilterCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClausesMeterFilterClausesMeterFilterConditionValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterConditionValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterConditionValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterConditionValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterConditionValue>(
                element,
                ModelBase.SerializerOptions
            );

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
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        ClausesMeterFilterClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = FilterOperator.Equals,
                    Value = "string",
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
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilter>(
            json,
            ModelBase.SerializerOptions
        );

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
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ClausesMeterFilterClausesMeterFilterClauses expectedClauses = new(
            [
                new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                {
                    Key = "x",
                    Operator = FilterOperator.Equals,
                    Value = "string",
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
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = FilterOperator.Equals,
                        Value = "string",
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
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition()
                    {
                        Key = "x",
                        Operator = FilterOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = Conjunction.And,
        };

        ClausesMeterFilterClausesMeterFilter copied = new(model);

        Assert.Equal(model, copied);
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
                    Operator = FilterOperator.Equals,
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
                            Operator = FilterOperator.Equals,
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
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClauses>(
            element,
            ModelBase.SerializerOptions
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
                            Operator = FilterOperator.Equals,
                            Value = "string",
                        },
                    ],
                    Conjunction = Conjunction.And,
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClauses>(
            element,
            ModelBase.SerializerOptions
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        ClausesMeterFilterClausesMeterFilterClausesMeterFilterCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilterConditionValue>(
                element,
                ModelBase.SerializerOptions
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
                    Operator = FilterOperator.Equals,
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
                Operator = FilterOperator.Equals,
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
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>(
                json,
                ModelBase.SerializerOptions
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
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClausesMeterFilterClausesMeterFilterClausesMeterFilter>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Clause> expectedClauses =
        [
            new()
            {
                Key = "x",
                Operator = FilterOperator.Equals,
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
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilterClausesMeterFilter
        {
            Clauses =
            [
                new()
                {
                    Key = "x",
                    Operator = FilterOperator.Equals,
                    Value = "string",
                },
            ],
            Conjunction = Conjunction.And,
        };

        ClausesMeterFilterClausesMeterFilterClausesMeterFilter copied = new(model);

        Assert.Equal(model, copied);
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Clause>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Clause
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Clause>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedKey = "x";
        ApiEnum<string, FilterOperator> expectedOperator = FilterOperator.Equals;
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
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Clause
        {
            Key = "x",
            Operator = FilterOperator.Equals,
            Value = "string",
        };

        Clause copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClauseValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ClauseValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ClauseValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ClauseValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ClauseValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClauseValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ClauseValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClauseValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClauseValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClauseValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
