using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerName = "customer_name",
            PaymentID = "payment_id",
            PaymentStatus = IntentStatus.Succeeded,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerEmail = "customer_email";
        string expectedCustomerName = "customer_name";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, IntentStatus> expectedPaymentStatus = IntentStatus.Succeeded;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerEmail, model.CustomerEmail);
        Assert.Equal(expectedCustomerName, model.CustomerName);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentStatus, model.PaymentStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerName = "customer_name",
            PaymentID = "payment_id",
            PaymentStatus = IntentStatus.Succeeded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerName = "customer_name",
            PaymentID = "payment_id",
            PaymentStatus = IntentStatus.Succeeded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutSessionStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerEmail = "customer_email";
        string expectedCustomerName = "customer_name";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, IntentStatus> expectedPaymentStatus = IntentStatus.Succeeded;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerEmail, deserialized.CustomerEmail);
        Assert.Equal(expectedCustomerName, deserialized.CustomerName);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedPaymentStatus, deserialized.PaymentStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerName = "customer_name",
            PaymentID = "payment_id",
            PaymentStatus = IntentStatus.Succeeded,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CustomerEmail);
        Assert.False(model.RawData.ContainsKey("customer_email"));
        Assert.Null(model.CustomerName);
        Assert.False(model.RawData.ContainsKey("customer_name"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PaymentStatus);
        Assert.False(model.RawData.ContainsKey("payment_status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            CustomerEmail = null,
            CustomerName = null,
            PaymentID = null,
            PaymentStatus = null,
        };

        Assert.Null(model.CustomerEmail);
        Assert.True(model.RawData.ContainsKey("customer_email"));
        Assert.Null(model.CustomerName);
        Assert.True(model.RawData.ContainsKey("customer_name"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PaymentStatus);
        Assert.True(model.RawData.ContainsKey("payment_status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            CustomerEmail = null,
            CustomerName = null,
            PaymentID = null,
            PaymentStatus = null,
        };

        model.Validate();
    }
}
