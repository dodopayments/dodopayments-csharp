using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdatePaymentMethodParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdatePaymentMethodParams
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            PaymentMethod = new New()
            {
                AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
                ReturnUrl = "return_url",
            },
        };

        string expectedSubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv";
        PaymentMethod expectedPaymentMethod = new New()
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedPaymentMethod, parameters.PaymentMethod);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdatePaymentMethodParams parameters = new()
        {
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            PaymentMethod = new New()
            {
                AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
                ReturnUrl = "return_url",
            },
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/subscriptions/sub_Iuaq622bbmmfOGrVTqdXv/update-payment-method"
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
            SubscriptionID = "sub_Iuaq622bbmmfOGrVTqdXv",
            PaymentMethod = new New()
            {
                AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
                ReturnUrl = "return_url",
            },
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
        PaymentMethod value = new New()
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };
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
        PaymentMethod value = new New()
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };
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
        var model = new New
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("new");
        List<ApiEnum<string, PaymentMethodTypes>> expectedAllowedPaymentMethodTypes =
        [
            PaymentMethodTypes.Ach,
        ];
        string expectedReturnUrl = "return_url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedPaymentMethodTypes);
        Assert.Equal(
            expectedAllowedPaymentMethodTypes.Count,
            model.AllowedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedAllowedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(expectedAllowedPaymentMethodTypes[i], model.AllowedPaymentMethodTypes[i]);
        }
        Assert.Equal(expectedReturnUrl, model.ReturnUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new New
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<New>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new New
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<New>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("new");
        List<ApiEnum<string, PaymentMethodTypes>> expectedAllowedPaymentMethodTypes =
        [
            PaymentMethodTypes.Ach,
        ];
        string expectedReturnUrl = "return_url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedPaymentMethodTypes);
        Assert.Equal(
            expectedAllowedPaymentMethodTypes.Count,
            deserialized.AllowedPaymentMethodTypes.Count
        );
        for (int i = 0; i < expectedAllowedPaymentMethodTypes.Count; i++)
        {
            Assert.Equal(
                expectedAllowedPaymentMethodTypes[i],
                deserialized.AllowedPaymentMethodTypes[i]
            );
        }
        Assert.Equal(expectedReturnUrl, deserialized.ReturnUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new New
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new New { };

        Assert.Null(model.AllowedPaymentMethodTypes);
        Assert.False(model.RawData.ContainsKey("allowed_payment_method_types"));
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
        var model = new New { AllowedPaymentMethodTypes = null, ReturnUrl = null };

        Assert.Null(model.AllowedPaymentMethodTypes);
        Assert.True(model.RawData.ContainsKey("allowed_payment_method_types"));
        Assert.Null(model.ReturnUrl);
        Assert.True(model.RawData.ContainsKey("return_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new New { AllowedPaymentMethodTypes = null, ReturnUrl = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new New
        {
            AllowedPaymentMethodTypes = [PaymentMethodTypes.Ach],
            ReturnUrl = "return_url",
        };

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
