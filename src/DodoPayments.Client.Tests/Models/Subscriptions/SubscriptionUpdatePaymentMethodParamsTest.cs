using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdatePaymentMethodParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdatePaymentMethodParams
        {
            SubscriptionID = "subscription_id",
            Body = new New() { Type = Type.New, ReturnURL = "return_url" },
        };

        string expectedSubscriptionID = "subscription_id";
        Body expectedBody = new New() { Type = Type.New, ReturnURL = "return_url" };

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedBody, parameters.Body);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void NewValidationWorks()
    {
        Body value = new(new New() { Type = Type.New, ReturnURL = "return_url" });
        value.Validate();
    }

    [Fact]
    public void ExistingValidationWorks()
    {
        Body value = new(
            new Existing() { PaymentMethodID = "payment_method_id", Type = ExistingType.Existing }
        );
        value.Validate();
    }

    [Fact]
    public void NewSerializationRoundtripWorks()
    {
        Body value = new(new New() { Type = Type.New, ReturnURL = "return_url" });
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Body>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExistingSerializationRoundtripWorks()
    {
        Body value = new(
            new Existing() { PaymentMethodID = "payment_method_id", Type = ExistingType.Existing }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Body>(element);

        Assert.Equal(value, deserialized);
    }
}

public class NewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new New { Type = Type.New, ReturnURL = "return_url" };

        ApiEnum<string, Type> expectedType = Type.New;
        string expectedReturnURL = "return_url";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedReturnURL, model.ReturnURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new New { Type = Type.New, ReturnURL = "return_url" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<New>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new New { Type = Type.New, ReturnURL = "return_url" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<New>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Type> expectedType = Type.New;
        string expectedReturnURL = "return_url";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedReturnURL, deserialized.ReturnURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new New { Type = Type.New, ReturnURL = "return_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new New { Type = Type.New };

        Assert.Null(model.ReturnURL);
        Assert.False(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new New { Type = Type.New };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new New
        {
            Type = Type.New,

            ReturnURL = null,
        };

        Assert.Null(model.ReturnURL);
        Assert.True(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new New
        {
            Type = Type.New,

            ReturnURL = null,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.New)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.New)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExistingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = ExistingType.Existing,
        };

        string expectedPaymentMethodID = "payment_method_id";
        ApiEnum<string, ExistingType> expectedType = ExistingType.Existing;

        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = ExistingType.Existing,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Existing>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = ExistingType.Existing,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Existing>(element);
        Assert.NotNull(deserialized);

        string expectedPaymentMethodID = "payment_method_id";
        ApiEnum<string, ExistingType> expectedType = ExistingType.Existing;

        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = ExistingType.Existing,
        };

        model.Validate();
    }
}

public class ExistingTypeTest : TestBase
{
    [Theory]
    [InlineData(ExistingType.Existing)]
    public void Validation_Works(ExistingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExistingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExistingType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExistingType.Existing)]
    public void SerializationRoundtrip_Works(ExistingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExistingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExistingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExistingType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExistingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
