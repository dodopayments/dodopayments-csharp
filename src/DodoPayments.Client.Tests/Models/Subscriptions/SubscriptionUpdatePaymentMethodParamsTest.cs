using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<New>(json);
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Existing>(json);
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
