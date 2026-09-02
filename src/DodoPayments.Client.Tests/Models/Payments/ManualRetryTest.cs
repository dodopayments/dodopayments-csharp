using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class ManualRetryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = IntentStatus.Succeeded,
        };

        string expectedInvoiceID = "invoice_id";
        bool expectedIsManualRetry = true;
        string expectedPaymentID = "payment_id";
        int expectedRetryAttempt = 0;
        long expectedSendsAllowed = 0;
        long expectedSendsUsed = 0;
        DateTimeOffset expectedRetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;

        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedIsManualRetry, model.IsManualRetry);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRetryAttempt, model.RetryAttempt);
        Assert.Equal(expectedSendsAllowed, model.SendsAllowed);
        Assert.Equal(expectedSendsUsed, model.SendsUsed);
        Assert.Equal(expectedRetryAvailableAt, model.RetryAvailableAt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = IntentStatus.Succeeded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ManualRetry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = IntentStatus.Succeeded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ManualRetry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInvoiceID = "invoice_id";
        bool expectedIsManualRetry = true;
        string expectedPaymentID = "payment_id";
        int expectedRetryAttempt = 0;
        long expectedSendsAllowed = 0;
        long expectedSendsUsed = 0;
        DateTimeOffset expectedRetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, IntentStatus> expectedStatus = IntentStatus.Succeeded;

        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedIsManualRetry, deserialized.IsManualRetry);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRetryAttempt, deserialized.RetryAttempt);
        Assert.Equal(expectedSendsAllowed, deserialized.SendsAllowed);
        Assert.Equal(expectedSendsUsed, deserialized.SendsUsed);
        Assert.Equal(expectedRetryAvailableAt, deserialized.RetryAvailableAt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = IntentStatus.Succeeded,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
        };

        Assert.Null(model.RetryAvailableAt);
        Assert.False(model.RawData.ContainsKey("retry_available_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,

            RetryAvailableAt = null,
            Status = null,
        };

        Assert.Null(model.RetryAvailableAt);
        Assert.True(model.RawData.ContainsKey("retry_available_at"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,

            RetryAvailableAt = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ManualRetry
        {
            InvoiceID = "invoice_id",
            IsManualRetry = true,
            PaymentID = "payment_id",
            RetryAttempt = 0,
            SendsAllowed = 0,
            SendsUsed = 0,
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = IntentStatus.Succeeded,
        };

        ManualRetry copied = new(model);

        Assert.Equal(model, copied);
    }
}
