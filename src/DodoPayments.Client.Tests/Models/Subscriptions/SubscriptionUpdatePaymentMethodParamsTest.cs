using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdatePaymentMethodParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdatePaymentMethodParams
        {
            SubscriptionID = "subscription_id",
            Body = new Subscriptions::New()
            {
                Type = Subscriptions::Type.New,
                ReturnUrl = "return_url",
            },
        };

        string expectedSubscriptionID = "subscription_id";
        Subscriptions::Body expectedBody = new Subscriptions::New()
        {
            Type = Subscriptions::Type.New,
            ReturnUrl = "return_url",
        };

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionUpdatePaymentMethodParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            Body = new Subscriptions::New()
            {
                Type = Subscriptions::Type.New,
                ReturnUrl = "return_url",
            },
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/subscriptions/subscription_id/update-payment-method"
            ),
            url
        );
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void NewValidationWorks()
    {
        Subscriptions::Body value = new(
            new Subscriptions::New() { Type = Subscriptions::Type.New, ReturnUrl = "return_url" }
        );
        value.Validate();
    }

    [Fact]
    public void ExistingValidationWorks()
    {
        Subscriptions::Body value = new(
            new Subscriptions::Existing()
            {
                PaymentMethodID = "payment_method_id",
                Type = Subscriptions::ExistingType.Existing,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewSerializationRoundtripWorks()
    {
        Subscriptions::Body value = new(
            new Subscriptions::New() { Type = Subscriptions::Type.New, ReturnUrl = "return_url" }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Body>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExistingSerializationRoundtripWorks()
    {
        Subscriptions::Body value = new(
            new Subscriptions::Existing()
            {
                PaymentMethodID = "payment_method_id",
                Type = Subscriptions::ExistingType.Existing,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Body>(element);

        Assert.Equal(value, deserialized);
    }
}

public class NewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::New
        {
            Type = Subscriptions::Type.New,
            ReturnUrl = "return_url",
        };

        ApiEnum<string, Subscriptions::Type> expectedType = Subscriptions::Type.New;
        string expectedReturnUrl = "return_url";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedReturnUrl, model.ReturnUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::New
        {
            Type = Subscriptions::Type.New,
            ReturnUrl = "return_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::New>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::New
        {
            Type = Subscriptions::Type.New,
            ReturnUrl = "return_url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::New>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::Type> expectedType = Subscriptions::Type.New;
        string expectedReturnUrl = "return_url";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedReturnUrl, deserialized.ReturnUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::New
        {
            Type = Subscriptions::Type.New,
            ReturnUrl = "return_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::New { Type = Subscriptions::Type.New };

        Assert.Null(model.ReturnUrl);
        Assert.False(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::New { Type = Subscriptions::Type.New };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::New
        {
            Type = Subscriptions::Type.New,

            ReturnUrl = null,
        };

        Assert.Null(model.ReturnUrl);
        Assert.True(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::New
        {
            Type = Subscriptions::Type.New,

            ReturnUrl = null,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::Type.New)]
    public void Validation_Works(Subscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Type.New)]
    public void SerializationRoundtrip_Works(Subscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
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
        var model = new Subscriptions::Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = Subscriptions::ExistingType.Existing,
        };

        string expectedPaymentMethodID = "payment_method_id";
        ApiEnum<string, Subscriptions::ExistingType> expectedType =
            Subscriptions::ExistingType.Existing;

        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = Subscriptions::ExistingType.Existing,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Existing>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = Subscriptions::ExistingType.Existing,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Existing>(element);
        Assert.NotNull(deserialized);

        string expectedPaymentMethodID = "payment_method_id";
        ApiEnum<string, Subscriptions::ExistingType> expectedType =
            Subscriptions::ExistingType.Existing;

        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Existing
        {
            PaymentMethodID = "payment_method_id",
            Type = Subscriptions::ExistingType.Existing,
        };

        model.Validate();
    }
}

public class ExistingTypeTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ExistingType.Existing)]
    public void Validation_Works(Subscriptions::ExistingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ExistingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ExistingType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ExistingType.Existing)]
    public void SerializationRoundtrip_Works(Subscriptions::ExistingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ExistingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ExistingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ExistingType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ExistingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
