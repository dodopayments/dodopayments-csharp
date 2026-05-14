using System;
using System.Text.Json;
using DodoPayments.Client.Core;
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
            PaymentMethod = new New() { ReturnUrl = "return_url" },
        };

        string expectedSubscriptionID = "subscription_id";
        PaymentMethod expectedPaymentMethod = new New() { ReturnUrl = "return_url" };

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedPaymentMethod, parameters.PaymentMethod);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdatePaymentMethodParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            PaymentMethod = new New() { ReturnUrl = "return_url" },
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/subscription_id/update-payment-method"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionUpdatePaymentMethodParams
        {
            SubscriptionID = "subscription_id",
            PaymentMethod = new New() { ReturnUrl = "return_url" },
        };

        SubscriptionUpdatePaymentMethodParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PaymentMethodTest : TestBase
{
    [Fact]
    public void NewValidationWorks()
    {
        PaymentMethod value = new New() { ReturnUrl = "return_url" };
        value.Validate();
    }

    [Fact]
    public void ExistingValidationWorks()
    {
        PaymentMethod value = new Existing("payment_method_id");
        value.Validate();
    }

    [Fact]
    public void NewSerializationRoundtripWorks()
    {
        PaymentMethod value = new New() { ReturnUrl = "return_url" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExistingSerializationRoundtripWorks()
    {
        PaymentMethod value = new Existing("payment_method_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new New { ReturnUrl = "return_url" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("new");
        string expectedReturnUrl = "return_url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedReturnUrl, model.ReturnUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new New { ReturnUrl = "return_url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<New>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new New { ReturnUrl = "return_url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<New>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("new");
        string expectedReturnUrl = "return_url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedReturnUrl, deserialized.ReturnUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new New { ReturnUrl = "return_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new New { };

        Assert.Null(model.ReturnUrl);
        Assert.False(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new New { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new New { ReturnUrl = null };

        Assert.Null(model.ReturnUrl);
        Assert.True(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new New { ReturnUrl = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new New { ReturnUrl = "return_url" };

        New copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExistingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Existing { PaymentMethodID = "payment_method_id" };

        string expectedPaymentMethodID = "payment_method_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("existing");

        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Existing { PaymentMethodID = "payment_method_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Existing>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Existing { PaymentMethodID = "payment_method_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Existing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPaymentMethodID = "payment_method_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("existing");

        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Existing { PaymentMethodID = "payment_method_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Existing { PaymentMethodID = "payment_method_id" };

        Existing copied = new(model);

        Assert.Equal(model, copied);
    }
}
