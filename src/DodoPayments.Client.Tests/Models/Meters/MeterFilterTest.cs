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
                    new()
                    {
                        Key = "user_id",
                        Operator = Operator.Equals,
                        Value = "user123",
                    },
                    new()
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
                new()
                {
                    Key = "user_id",
                    Operator = Operator.Equals,
                    Value = "user123",
                },
                new()
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
                    new()
                    {
                        Key = "user_id",
                        Operator = Operator.Equals,
                        Value = "user123",
                    },
                    new()
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
                    new()
                    {
                        Key = "user_id",
                        Operator = Operator.Equals,
                        Value = "user123",
                    },
                    new()
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
                new()
                {
                    Key = "user_id",
                    Operator = Operator.Equals,
                    Value = "user123",
                },
                new()
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
                    new()
                    {
                        Key = "user_id",
                        Operator = Operator.Equals,
                        Value = "user123",
                    },
                    new()
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

public class ClausesMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilter
        {
            Clauses = new(
                [
                    new()
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
                new()
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
                    new()
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
                    new()
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
                new()
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
                    new()
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

public class ClausesMeterFilterClausesMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClausesMeterFilterClausesMeterFilter
        {
            Clauses = new(
                [
                    new()
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
                new()
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
                    new()
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
                    new()
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
                new()
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
                    new()
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
