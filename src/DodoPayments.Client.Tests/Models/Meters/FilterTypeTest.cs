using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class FilterTypeTest : TestBase
{
    [Fact]
    public void MeterFilterConditionListValidationWorks()
    {
        FilterType value = new(
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
    public void NestedMeterFilterListValidationWorks()
    {
        FilterType value = new(
            [
                new MeterFilter()
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
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void MeterFilterConditionListSerializationRoundtripWorks()
    {
        FilterType value = new(
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
        var deserialized = JsonSerializer.Deserialize<FilterType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NestedMeterFilterListSerializationRoundtripWorks()
    {
        FilterType value = new(
            [
                new MeterFilter()
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
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterType>(
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
