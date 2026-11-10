using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionChangePlanResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoice_id",
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
            RefundID = "refund_id",
        };

        string expectedClientSecret = "client_secret";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvoiceID = "invoice_id";
        string expectedPaymentID = "payment_id";
        string expectedPaymentLink = "payment_link";
        string expectedRefundID = "refund_id";

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedExpiresOn, model.ExpiresOn);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentLink, model.PaymentLink);
        Assert.Equal(expectedRefundID, model.RefundID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoice_id",
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
            RefundID = "refund_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangePlanResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoice_id",
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
            RefundID = "refund_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangePlanResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientSecret = "client_secret";
        DateTimeOffset expectedExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvoiceID = "invoice_id";
        string expectedPaymentID = "payment_id";
        string expectedPaymentLink = "payment_link";
        string expectedRefundID = "refund_id";

        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedExpiresOn, deserialized.ExpiresOn);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedPaymentLink, deserialized.PaymentLink);
        Assert.Equal(expectedRefundID, deserialized.RefundID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoice_id",
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
            RefundID = "refund_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionChangePlanResponse { };

        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.ExpiresOn);
        Assert.False(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.InvoiceID);
        Assert.False(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PaymentLink);
        Assert.False(model.RawData.ContainsKey("payment_link"));
        Assert.Null(model.RefundID);
        Assert.False(model.RawData.ContainsKey("refund_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionChangePlanResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = null,
            ExpiresOn = null,
            InvoiceID = null,
            PaymentID = null,
            PaymentLink = null,
            RefundID = null,
        };

        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.ExpiresOn);
        Assert.True(model.RawData.ContainsKey("expires_on"));
        Assert.Null(model.InvoiceID);
        Assert.True(model.RawData.ContainsKey("invoice_id"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.PaymentLink);
        Assert.True(model.RawData.ContainsKey("payment_link"));
        Assert.Null(model.RefundID);
        Assert.True(model.RawData.ContainsKey("refund_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = null,
            ExpiresOn = null,
            InvoiceID = null,
            PaymentID = null,
            PaymentLink = null,
            RefundID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionChangePlanResponse
        {
            ClientSecret = "client_secret",
            ExpiresOn = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoice_id",
            PaymentID = "payment_id",
            PaymentLink = "payment_link",
            RefundID = "refund_id",
        };

        SubscriptionChangePlanResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
