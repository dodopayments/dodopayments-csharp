using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterMeterFilter
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
            Conjunction = MeterMeterFilterConjunction.And,
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
        ApiEnum<string, MeterMeterFilterConjunction> expectedConjunction =
            MeterMeterFilterConjunction.And;

        Assert.Equal(expectedClauses, model.Clauses);
        Assert.Equal(expectedConjunction, model.Conjunction);
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
}

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
                        Key = "x",
                        Operator = MeterFilterConditionModelOperator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = MeterFilterConjunction.And,
        };

        MeterFilterClauses expectedClauses = new(
            [
                new()
                {
                    Key = "x",
                    Operator = MeterFilterConditionModelOperator.Equals,
                    Value = "string",
                },
            ]
        );
        ApiEnum<string, MeterFilterConjunction> expectedConjunction = MeterFilterConjunction.And;

        Assert.Equal(expectedClauses, model.Clauses);
        Assert.Equal(expectedConjunction, model.Conjunction);
    }
}

public class MeterFilterConditionModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterFilterConditionModel
        {
            Key = "x",
            Operator = MeterFilterConditionModelOperator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, MeterFilterConditionModelOperator> expectedOperator =
            MeterFilterConditionModelOperator.Equals;
        MeterFilterConditionModelValue expectedValue = "string";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }
}

public class MeterFilterModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterFilterModel
        {
            Clauses = new(
                [
                    new()
                    {
                        Key = "x",
                        Operator = MeterFilterCondition1Operator.Equals,
                        Value = "string",
                    },
                ]
            ),
            Conjunction = MeterFilterModelConjunction.And,
        };

        MeterFilterModelClauses expectedClauses = new(
            [
                new()
                {
                    Key = "x",
                    Operator = MeterFilterCondition1Operator.Equals,
                    Value = "string",
                },
            ]
        );
        ApiEnum<string, MeterFilterModelConjunction> expectedConjunction =
            MeterFilterModelConjunction.And;

        Assert.Equal(expectedClauses, model.Clauses);
        Assert.Equal(expectedConjunction, model.Conjunction);
    }
}

public class MeterFilterCondition1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterFilterCondition1
        {
            Key = "x",
            Operator = MeterFilterCondition1Operator.Equals,
            Value = "string",
        };

        string expectedKey = "x";
        ApiEnum<string, MeterFilterCondition1Operator> expectedOperator =
            MeterFilterCondition1Operator.Equals;
        MeterFilterCondition1Value expectedValue = "string";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }
}

public class MeterFilter1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterFilter1
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
}
