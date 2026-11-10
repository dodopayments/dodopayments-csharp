using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using Invoices = DodoPayments.Client.Models.Invoices;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DunningState = Invoices::DunningState.NotStarted,
            FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
            Lines =
            [
                new()
                {
                    Amount = 0,
                    Kind = Invoices::Kind.Subscription,
                    Quantity = 0,
                    Tax = 0,
                    TaxInclusive = true,
                    UnitAmount = 0,
                    AddonID = "addon_id",
                    Description = "description",
                    Name = "name",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    SubscriptionID = "subscription_id",
                    TaxRate = 0,
                },
            ],
            Memo = "memo",
            NextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentTermsDays = 0,
            Payments =
            [
                new()
                {
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentID = "payment_id",
                    RetryAttempt = 0,
                    Status = Payments::IntentStatus.Succeeded,
                },
            ],
            PdfUrl = "pdf_url",
            ReminderSettings = new Invoices::UnionMember0()
            {
                OffsetsMinutes = [0],
                Paused = true,
                RemindersEnabled = true,
            },
            ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<ApiEnum<string, Invoices::AllowedAction>> expectedAllowedActions =
        [
            Invoices::AllowedAction.Edit,
        ];
        long expectedAmountDue = 0;
        long expectedAmountPaid = 0;
        long expectedAmountRefunded = 0;
        ApiEnum<string, Invoices::BillingMode> expectedBillingMode = Invoices::BillingMode.Normal;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedCredits = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Invoices::Customer expectedCustomer = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };
        List<string> expectedDiscountIds = ["string"];
        List<ApiEnum<string, Invoices::EditableField>> expectedEditableFields =
        [
            Invoices::EditableField.Customer,
        ];
        Invoices::Frequency expectedFrequency = new Invoices::FrequencyType();
        string expectedInvoiceID = "invoice_id";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        List<string> expectedRefundIds = ["string"];
        int expectedRetryCount = 0;
        long expectedRowVersion = 0;
        ApiEnum<string, Invoices::InvoiceStatus> expectedStatus = Invoices::InvoiceStatus.Open;
        List<string> expectedSubscriptionIds = ["string"];
        List<ApiEnum<string, Invoices::InvoiceTag>> expectedTags = [Invoices::InvoiceTag.Refunded];
        int expectedTax = 0;
        int expectedTotalAmount = 0;
        ApiEnum<string, Invoices::InvoiceCollectionMethod> expectedCollectionMethod =
            Invoices::InvoiceCollectionMethod.AutoCharge;
        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Invoices::DunningState> expectedDunningState =
            Invoices::DunningState.NotStarted;
        DateTimeOffset expectedFinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedUrl = "hosted_url";
        List<Invoices::InvoiceLine> expectedLines =
        [
            new()
            {
                Amount = 0,
                Kind = Invoices::Kind.Subscription,
                Quantity = 0,
                Tax = 0,
                TaxInclusive = true,
                UnitAmount = 0,
                AddonID = "addon_id",
                Description = "description",
                Name = "name",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                SubscriptionID = "subscription_id",
                TaxRate = 0,
            },
        ];
        string expectedMemo = "memo";
        DateTimeOffset expectedNextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedNextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPaymentTermsDays = 0;
        List<Invoices::Payment> expectedPayments =
        [
            new()
            {
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentID = "payment_id",
                RetryAttempt = 0,
                Status = Payments::IntentStatus.Succeeded,
            },
        ];
        string expectedPdfUrl = "pdf_url";
        Invoices::ReminderSettings expectedReminderSettings = new Invoices::UnionMember0()
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };
        DateTimeOffset expectedReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAllowedActions.Count, model.AllowedActions.Count);
        for (int i = 0; i < expectedAllowedActions.Count; i++)
        {
            Assert.Equal(expectedAllowedActions[i], model.AllowedActions[i]);
        }
        Assert.Equal(expectedAmountDue, model.AmountDue);
        Assert.Equal(expectedAmountPaid, model.AmountPaid);
        Assert.Equal(expectedAmountRefunded, model.AmountRefunded);
        Assert.Equal(expectedBillingMode, model.BillingMode);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCredits, model.Credits);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDiscountIds.Count, model.DiscountIds.Count);
        for (int i = 0; i < expectedDiscountIds.Count; i++)
        {
            Assert.Equal(expectedDiscountIds[i], model.DiscountIds[i]);
        }
        Assert.Equal(expectedEditableFields.Count, model.EditableFields.Count);
        for (int i = 0; i < expectedEditableFields.Count; i++)
        {
            Assert.Equal(expectedEditableFields[i], model.EditableFields[i]);
        }
        Assert.Equal(expectedFrequency, model.Frequency);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata));
        Assert.Equal(expectedRefundIds.Count, model.RefundIds.Count);
        for (int i = 0; i < expectedRefundIds.Count; i++)
        {
            Assert.Equal(expectedRefundIds[i], model.RefundIds[i]);
        }
        Assert.Equal(expectedRetryCount, model.RetryCount);
        Assert.Equal(expectedRowVersion, model.RowVersion);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionIds.Count, model.SubscriptionIds.Count);
        for (int i = 0; i < expectedSubscriptionIds.Count; i++)
        {
            Assert.Equal(expectedSubscriptionIds[i], model.SubscriptionIds[i]);
        }
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedCollectionMethod, model.CollectionMethod);
        Assert.Equal(expectedDueAt, model.DueAt);
        Assert.Equal(expectedDunningState, model.DunningState);
        Assert.Equal(expectedFinalizedAt, model.FinalizedAt);
        Assert.Equal(expectedHostedUrl, model.HostedUrl);
        Assert.NotNull(model.Lines);
        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedNextReminderAt, model.NextReminderAt);
        Assert.Equal(expectedNextRetryAt, model.NextRetryAt);
        Assert.Equal(expectedPaymentTermsDays, model.PaymentTermsDays);
        Assert.NotNull(model.Payments);
        Assert.Equal(expectedPayments.Count, model.Payments.Count);
        for (int i = 0; i < expectedPayments.Count; i++)
        {
            Assert.Equal(expectedPayments[i], model.Payments[i]);
        }
        Assert.Equal(expectedPdfUrl, model.PdfUrl);
        Assert.Equal(expectedReminderSettings, model.ReminderSettings);
        Assert.Equal(expectedReviewDeadline, model.ReviewDeadline);
        Assert.Equal(expectedSentAt, model.SentAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DunningState = Invoices::DunningState.NotStarted,
            FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
            Lines =
            [
                new()
                {
                    Amount = 0,
                    Kind = Invoices::Kind.Subscription,
                    Quantity = 0,
                    Tax = 0,
                    TaxInclusive = true,
                    UnitAmount = 0,
                    AddonID = "addon_id",
                    Description = "description",
                    Name = "name",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    SubscriptionID = "subscription_id",
                    TaxRate = 0,
                },
            ],
            Memo = "memo",
            NextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentTermsDays = 0,
            Payments =
            [
                new()
                {
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentID = "payment_id",
                    RetryAttempt = 0,
                    Status = Payments::IntentStatus.Succeeded,
                },
            ],
            PdfUrl = "pdf_url",
            ReminderSettings = new Invoices::UnionMember0()
            {
                OffsetsMinutes = [0],
                Paused = true,
                RemindersEnabled = true,
            },
            ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Invoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DunningState = Invoices::DunningState.NotStarted,
            FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
            Lines =
            [
                new()
                {
                    Amount = 0,
                    Kind = Invoices::Kind.Subscription,
                    Quantity = 0,
                    Tax = 0,
                    TaxInclusive = true,
                    UnitAmount = 0,
                    AddonID = "addon_id",
                    Description = "description",
                    Name = "name",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    SubscriptionID = "subscription_id",
                    TaxRate = 0,
                },
            ],
            Memo = "memo",
            NextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentTermsDays = 0,
            Payments =
            [
                new()
                {
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentID = "payment_id",
                    RetryAttempt = 0,
                    Status = Payments::IntentStatus.Succeeded,
                },
            ],
            PdfUrl = "pdf_url",
            ReminderSettings = new Invoices::UnionMember0()
            {
                OffsetsMinutes = [0],
                Paused = true,
                RemindersEnabled = true,
            },
            ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Invoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, Invoices::AllowedAction>> expectedAllowedActions =
        [
            Invoices::AllowedAction.Edit,
        ];
        long expectedAmountDue = 0;
        long expectedAmountPaid = 0;
        long expectedAmountRefunded = 0;
        ApiEnum<string, Invoices::BillingMode> expectedBillingMode = Invoices::BillingMode.Normal;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedCredits = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        Invoices::Customer expectedCustomer = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };
        List<string> expectedDiscountIds = ["string"];
        List<ApiEnum<string, Invoices::EditableField>> expectedEditableFields =
        [
            Invoices::EditableField.Customer,
        ];
        Invoices::Frequency expectedFrequency = new Invoices::FrequencyType();
        string expectedInvoiceID = "invoice_id";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        List<string> expectedRefundIds = ["string"];
        int expectedRetryCount = 0;
        long expectedRowVersion = 0;
        ApiEnum<string, Invoices::InvoiceStatus> expectedStatus = Invoices::InvoiceStatus.Open;
        List<string> expectedSubscriptionIds = ["string"];
        List<ApiEnum<string, Invoices::InvoiceTag>> expectedTags = [Invoices::InvoiceTag.Refunded];
        int expectedTax = 0;
        int expectedTotalAmount = 0;
        ApiEnum<string, Invoices::InvoiceCollectionMethod> expectedCollectionMethod =
            Invoices::InvoiceCollectionMethod.AutoCharge;
        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Invoices::DunningState> expectedDunningState =
            Invoices::DunningState.NotStarted;
        DateTimeOffset expectedFinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedUrl = "hosted_url";
        List<Invoices::InvoiceLine> expectedLines =
        [
            new()
            {
                Amount = 0,
                Kind = Invoices::Kind.Subscription,
                Quantity = 0,
                Tax = 0,
                TaxInclusive = true,
                UnitAmount = 0,
                AddonID = "addon_id",
                Description = "description",
                Name = "name",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                SubscriptionID = "subscription_id",
                TaxRate = 0,
            },
        ];
        string expectedMemo = "memo";
        DateTimeOffset expectedNextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedNextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPaymentTermsDays = 0;
        List<Invoices::Payment> expectedPayments =
        [
            new()
            {
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentID = "payment_id",
                RetryAttempt = 0,
                Status = Payments::IntentStatus.Succeeded,
            },
        ];
        string expectedPdfUrl = "pdf_url";
        Invoices::ReminderSettings expectedReminderSettings = new Invoices::UnionMember0()
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };
        DateTimeOffset expectedReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAllowedActions.Count, deserialized.AllowedActions.Count);
        for (int i = 0; i < expectedAllowedActions.Count; i++)
        {
            Assert.Equal(expectedAllowedActions[i], deserialized.AllowedActions[i]);
        }
        Assert.Equal(expectedAmountDue, deserialized.AmountDue);
        Assert.Equal(expectedAmountPaid, deserialized.AmountPaid);
        Assert.Equal(expectedAmountRefunded, deserialized.AmountRefunded);
        Assert.Equal(expectedBillingMode, deserialized.BillingMode);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCredits, deserialized.Credits);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDiscountIds.Count, deserialized.DiscountIds.Count);
        for (int i = 0; i < expectedDiscountIds.Count; i++)
        {
            Assert.Equal(expectedDiscountIds[i], deserialized.DiscountIds[i]);
        }
        Assert.Equal(expectedEditableFields.Count, deserialized.EditableFields.Count);
        for (int i = 0; i < expectedEditableFields.Count; i++)
        {
            Assert.Equal(expectedEditableFields[i], deserialized.EditableFields[i]);
        }
        Assert.Equal(expectedFrequency, deserialized.Frequency);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata));
        Assert.Equal(expectedRefundIds.Count, deserialized.RefundIds.Count);
        for (int i = 0; i < expectedRefundIds.Count; i++)
        {
            Assert.Equal(expectedRefundIds[i], deserialized.RefundIds[i]);
        }
        Assert.Equal(expectedRetryCount, deserialized.RetryCount);
        Assert.Equal(expectedRowVersion, deserialized.RowVersion);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionIds.Count, deserialized.SubscriptionIds.Count);
        for (int i = 0; i < expectedSubscriptionIds.Count; i++)
        {
            Assert.Equal(expectedSubscriptionIds[i], deserialized.SubscriptionIds[i]);
        }
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedCollectionMethod, deserialized.CollectionMethod);
        Assert.Equal(expectedDueAt, deserialized.DueAt);
        Assert.Equal(expectedDunningState, deserialized.DunningState);
        Assert.Equal(expectedFinalizedAt, deserialized.FinalizedAt);
        Assert.Equal(expectedHostedUrl, deserialized.HostedUrl);
        Assert.NotNull(deserialized.Lines);
        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedNextReminderAt, deserialized.NextReminderAt);
        Assert.Equal(expectedNextRetryAt, deserialized.NextRetryAt);
        Assert.Equal(expectedPaymentTermsDays, deserialized.PaymentTermsDays);
        Assert.NotNull(deserialized.Payments);
        Assert.Equal(expectedPayments.Count, deserialized.Payments.Count);
        for (int i = 0; i < expectedPayments.Count; i++)
        {
            Assert.Equal(expectedPayments[i], deserialized.Payments[i]);
        }
        Assert.Equal(expectedPdfUrl, deserialized.PdfUrl);
        Assert.Equal(expectedReminderSettings, deserialized.ReminderSettings);
        Assert.Equal(expectedReviewDeadline, deserialized.ReviewDeadline);
        Assert.Equal(expectedSentAt, deserialized.SentAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DunningState = Invoices::DunningState.NotStarted,
            FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
            Lines =
            [
                new()
                {
                    Amount = 0,
                    Kind = Invoices::Kind.Subscription,
                    Quantity = 0,
                    Tax = 0,
                    TaxInclusive = true,
                    UnitAmount = 0,
                    AddonID = "addon_id",
                    Description = "description",
                    Name = "name",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    SubscriptionID = "subscription_id",
                    TaxRate = 0,
                },
            ],
            Memo = "memo",
            NextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentTermsDays = 0,
            Payments =
            [
                new()
                {
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentID = "payment_id",
                    RetryAttempt = 0,
                    Status = Payments::IntentStatus.Succeeded,
                },
            ],
            PdfUrl = "pdf_url",
            ReminderSettings = new Invoices::UnionMember0()
            {
                OffsetsMinutes = [0],
                Paused = true,
                RemindersEnabled = true,
            },
            ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
        };

        Assert.Null(model.CollectionMethod);
        Assert.False(model.RawData.ContainsKey("collection_method"));
        Assert.Null(model.DueAt);
        Assert.False(model.RawData.ContainsKey("due_at"));
        Assert.Null(model.DunningState);
        Assert.False(model.RawData.ContainsKey("dunning_state"));
        Assert.Null(model.FinalizedAt);
        Assert.False(model.RawData.ContainsKey("finalized_at"));
        Assert.Null(model.HostedUrl);
        Assert.False(model.RawData.ContainsKey("hosted_url"));
        Assert.Null(model.Lines);
        Assert.False(model.RawData.ContainsKey("lines"));
        Assert.Null(model.Memo);
        Assert.False(model.RawData.ContainsKey("memo"));
        Assert.Null(model.NextReminderAt);
        Assert.False(model.RawData.ContainsKey("next_reminder_at"));
        Assert.Null(model.NextRetryAt);
        Assert.False(model.RawData.ContainsKey("next_retry_at"));
        Assert.Null(model.PaymentTermsDays);
        Assert.False(model.RawData.ContainsKey("payment_terms_days"));
        Assert.Null(model.Payments);
        Assert.False(model.RawData.ContainsKey("payments"));
        Assert.Null(model.PdfUrl);
        Assert.False(model.RawData.ContainsKey("pdf_url"));
        Assert.Null(model.ReminderSettings);
        Assert.False(model.RawData.ContainsKey("reminder_settings"));
        Assert.Null(model.ReviewDeadline);
        Assert.False(model.RawData.ContainsKey("review_deadline"));
        Assert.Null(model.SentAt);
        Assert.False(model.RawData.ContainsKey("sent_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,

            CollectionMethod = null,
            DueAt = null,
            DunningState = null,
            FinalizedAt = null,
            HostedUrl = null,
            Lines = null,
            Memo = null,
            NextReminderAt = null,
            NextRetryAt = null,
            PaymentTermsDays = null,
            Payments = null,
            PdfUrl = null,
            ReminderSettings = null,
            ReviewDeadline = null,
            SentAt = null,
        };

        Assert.Null(model.CollectionMethod);
        Assert.True(model.RawData.ContainsKey("collection_method"));
        Assert.Null(model.DueAt);
        Assert.True(model.RawData.ContainsKey("due_at"));
        Assert.Null(model.DunningState);
        Assert.True(model.RawData.ContainsKey("dunning_state"));
        Assert.Null(model.FinalizedAt);
        Assert.True(model.RawData.ContainsKey("finalized_at"));
        Assert.Null(model.HostedUrl);
        Assert.True(model.RawData.ContainsKey("hosted_url"));
        Assert.Null(model.Lines);
        Assert.True(model.RawData.ContainsKey("lines"));
        Assert.Null(model.Memo);
        Assert.True(model.RawData.ContainsKey("memo"));
        Assert.Null(model.NextReminderAt);
        Assert.True(model.RawData.ContainsKey("next_reminder_at"));
        Assert.Null(model.NextRetryAt);
        Assert.True(model.RawData.ContainsKey("next_retry_at"));
        Assert.Null(model.PaymentTermsDays);
        Assert.True(model.RawData.ContainsKey("payment_terms_days"));
        Assert.Null(model.Payments);
        Assert.True(model.RawData.ContainsKey("payments"));
        Assert.Null(model.PdfUrl);
        Assert.True(model.RawData.ContainsKey("pdf_url"));
        Assert.Null(model.ReminderSettings);
        Assert.True(model.RawData.ContainsKey("reminder_settings"));
        Assert.Null(model.ReviewDeadline);
        Assert.True(model.RawData.ContainsKey("review_deadline"));
        Assert.Null(model.SentAt);
        Assert.True(model.RawData.ContainsKey("sent_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,

            CollectionMethod = null,
            DueAt = null,
            DunningState = null,
            FinalizedAt = null,
            HostedUrl = null,
            Lines = null,
            Memo = null,
            NextReminderAt = null,
            NextRetryAt = null,
            PaymentTermsDays = null,
            Payments = null,
            PdfUrl = null,
            ReminderSettings = null,
            ReviewDeadline = null,
            SentAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::Invoice
        {
            AllowedActions = [Invoices::AllowedAction.Edit],
            AmountDue = 0,
            AmountPaid = 0,
            AmountRefunded = 0,
            BillingMode = Invoices::BillingMode.Normal,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credits = 0,
            Currency = Currency.Aed,
            Customer = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = CountryCode.Af,
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CcEmails = ["string"],
                CustomerID = "customer_id",
                Email = "email",
                TaxID = "tax_id",
            },
            DiscountIds = ["string"],
            EditableFields = [Invoices::EditableField.Customer],
            Frequency = new Invoices::FrequencyType(),
            InvoiceID = "invoice_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RefundIds = ["string"],
            RetryCount = 0,
            RowVersion = 0,
            Status = Invoices::InvoiceStatus.Open,
            SubscriptionIds = ["string"],
            Tags = [Invoices::InvoiceTag.Refunded],
            Tax = 0,
            TotalAmount = 0,
            CollectionMethod = Invoices::InvoiceCollectionMethod.AutoCharge,
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DunningState = Invoices::DunningState.NotStarted,
            FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
            Lines =
            [
                new()
                {
                    Amount = 0,
                    Kind = Invoices::Kind.Subscription,
                    Quantity = 0,
                    Tax = 0,
                    TaxInclusive = true,
                    UnitAmount = 0,
                    AddonID = "addon_id",
                    Description = "description",
                    Name = "name",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    SubscriptionID = "subscription_id",
                    TaxRate = 0,
                },
            ],
            Memo = "memo",
            NextReminderAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentTermsDays = 0,
            Payments =
            [
                new()
                {
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentID = "payment_id",
                    RetryAttempt = 0,
                    Status = Payments::IntentStatus.Succeeded,
                },
            ],
            PdfUrl = "pdf_url",
            ReminderSettings = new Invoices::UnionMember0()
            {
                OffsetsMinutes = [0],
                Paused = true,
                RemindersEnabled = true,
            },
            ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Invoices::Invoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllowedActionTest : TestBase
{
    [Theory]
    [InlineData(Invoices::AllowedAction.Edit)]
    [InlineData(Invoices::AllowedAction.Finalize)]
    [InlineData(Invoices::AllowedAction.Delete)]
    [InlineData(Invoices::AllowedAction.Send)]
    [InlineData(Invoices::AllowedAction.Retry)]
    [InlineData(Invoices::AllowedAction.Void)]
    [InlineData(Invoices::AllowedAction.MarkUncollectable)]
    [InlineData(Invoices::AllowedAction.ChangeDunning)]
    [InlineData(Invoices::AllowedAction.AddNote)]
    [InlineData(Invoices::AllowedAction.Duplicate)]
    public void Validation_Works(Invoices::AllowedAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::AllowedAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::AllowedAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::AllowedAction.Edit)]
    [InlineData(Invoices::AllowedAction.Finalize)]
    [InlineData(Invoices::AllowedAction.Delete)]
    [InlineData(Invoices::AllowedAction.Send)]
    [InlineData(Invoices::AllowedAction.Retry)]
    [InlineData(Invoices::AllowedAction.Void)]
    [InlineData(Invoices::AllowedAction.MarkUncollectable)]
    [InlineData(Invoices::AllowedAction.ChangeDunning)]
    [InlineData(Invoices::AllowedAction.AddNote)]
    [InlineData(Invoices::AllowedAction.Duplicate)]
    public void SerializationRoundtrip_Works(Invoices::AllowedAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::AllowedAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::AllowedAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::AllowedAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::AllowedAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingModeTest : TestBase
{
    [Theory]
    [InlineData(Invoices::BillingMode.Normal)]
    [InlineData(Invoices::BillingMode.InvoiceLed)]
    public void Validation_Works(Invoices::BillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::BillingMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::BillingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::BillingMode.Normal)]
    [InlineData(Invoices::BillingMode.InvoiceLed)]
    public void SerializationRoundtrip_Works(Invoices::BillingMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::BillingMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::BillingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::BillingMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::BillingMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };

        Invoices::CustomerBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        List<string> expectedCcEmails = ["string"];
        string expectedCustomerID = "customer_id";
        string expectedEmail = "email";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCcEmails.Count, model.CcEmails.Count);
        for (int i = 0; i < expectedCcEmails.Count; i++)
        {
            Assert.Equal(expectedCcEmails[i], model.CcEmails[i]);
        }
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedTaxID, model.TaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Customer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Customer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Invoices::CustomerBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        List<string> expectedCcEmails = ["string"];
        string expectedCustomerID = "customer_id";
        string expectedEmail = "email";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCcEmails.Count, deserialized.CcEmails.Count);
        for (int i = 0; i < expectedCcEmails.Count; i++)
        {
            Assert.Equal(expectedCcEmails[i], deserialized.CcEmails[i]);
        }
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.TaxID);
        Assert.False(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",

            Email = null,
            TaxID = null,
        };

        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.TaxID);
        Assert.True(model.RawData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",

            Email = null,
            TaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::Customer
        {
            BillingAddress = new()
            {
                City = "city",
                Country = CountryCode.Af,
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CcEmails = ["string"],
            CustomerID = "customer_id",
            Email = "email",
            TaxID = "tax_id",
        };

        Invoices::Customer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string expectedCity = "city";
        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedZipcode, model.Zipcode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::CustomerBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::CustomerBillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        ApiEnum<string, CountryCode> expectedCountry = CountryCode.Af;
        string expectedState = "state";
        string expectedStreet = "street";
        string expectedZipcode = "zipcode";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedZipcode, deserialized.Zipcode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoices::CustomerBillingAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.Zipcode);
        Assert.False(model.RawData.ContainsKey("zipcode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoices::CustomerBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = null,
            Country = null,
            State = null,
            Street = null,
            Zipcode = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.Zipcode);
        Assert.True(model.RawData.ContainsKey("zipcode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = null,
            Country = null,
            State = null,
            Street = null,
            Zipcode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::CustomerBillingAddress
        {
            City = "city",
            Country = CountryCode.Af,
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };

        Invoices::CustomerBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EditableFieldTest : TestBase
{
    [Theory]
    [InlineData(Invoices::EditableField.Customer)]
    [InlineData(Invoices::EditableField.Items)]
    [InlineData(Invoices::EditableField.Discounts)]
    [InlineData(Invoices::EditableField.Currency)]
    [InlineData(Invoices::EditableField.BillingAddress)]
    [InlineData(Invoices::EditableField.TaxID)]
    [InlineData(Invoices::EditableField.ReviewRequired)]
    [InlineData(Invoices::EditableField.DueAt)]
    [InlineData(Invoices::EditableField.CollectionMethod)]
    [InlineData(Invoices::EditableField.Memo)]
    [InlineData(Invoices::EditableField.CustomerEmail)]
    [InlineData(Invoices::EditableField.CcEmails)]
    [InlineData(Invoices::EditableField.Dunning)]
    [InlineData(Invoices::EditableField.Metadata)]
    public void Validation_Works(Invoices::EditableField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::EditableField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::EditableField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::EditableField.Customer)]
    [InlineData(Invoices::EditableField.Items)]
    [InlineData(Invoices::EditableField.Discounts)]
    [InlineData(Invoices::EditableField.Currency)]
    [InlineData(Invoices::EditableField.BillingAddress)]
    [InlineData(Invoices::EditableField.TaxID)]
    [InlineData(Invoices::EditableField.ReviewRequired)]
    [InlineData(Invoices::EditableField.DueAt)]
    [InlineData(Invoices::EditableField.CollectionMethod)]
    [InlineData(Invoices::EditableField.Memo)]
    [InlineData(Invoices::EditableField.CustomerEmail)]
    [InlineData(Invoices::EditableField.CcEmails)]
    [InlineData(Invoices::EditableField.Dunning)]
    [InlineData(Invoices::EditableField.Metadata)]
    public void SerializationRoundtrip_Works(Invoices::EditableField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::EditableField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::EditableField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::EditableField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::EditableField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FrequencyTest : TestBase
{
    [Fact]
    public void ObjectValidationWorks()
    {
        Invoices::Frequency value = new Invoices::FrequencyType();
        value.Validate();
    }

    [Fact]
    public void FrequencyUnionMember1ValidationWorks()
    {
        Invoices::Frequency value = new Invoices::FrequencyUnionMember1()
        {
            Count = 0,
            Interval = TimeInterval.Day,
        };
        value.Validate();
    }

    [Fact]
    public void ObjectValidationWorks1()
    {
        Invoices::Frequency value = new Invoices::TypeModel();
        value.Validate();
    }

    [Fact]
    public void ObjectSerializationRoundtripWorks()
    {
        Invoices::Frequency value = new Invoices::FrequencyType();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Frequency>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FrequencyUnionMember1SerializationRoundtripWorks()
    {
        Invoices::Frequency value = new Invoices::FrequencyUnionMember1()
        {
            Count = 0,
            Interval = TimeInterval.Day,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Frequency>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ObjectSerializationRoundtripWorks1()
    {
        Invoices::Frequency value = new Invoices::TypeModel();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Frequency>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FrequencyTypeTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Invoices::FrequencyType();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "one_time"
                }
                """
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Invoices::FrequencyType();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "one_time"
                }
                """
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::FrequencyType>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class FrequencyUnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::FrequencyUnionMember1 { Count = 0, Interval = TimeInterval.Day };

        int expectedCount = 0;
        ApiEnum<string, TimeInterval> expectedInterval = TimeInterval.Day;
        JsonElement expectedType = JsonSerializer.SerializeToElement("recurring");

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedInterval, model.Interval);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::FrequencyUnionMember1 { Count = 0, Interval = TimeInterval.Day };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::FrequencyUnionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::FrequencyUnionMember1 { Count = 0, Interval = TimeInterval.Day };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::FrequencyUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedCount = 0;
        ApiEnum<string, TimeInterval> expectedInterval = TimeInterval.Day;
        JsonElement expectedType = JsonSerializer.SerializeToElement("recurring");

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedInterval, deserialized.Interval);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::FrequencyUnionMember1 { Count = 0, Interval = TimeInterval.Day };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::FrequencyUnionMember1 { Count = 0, Interval = TimeInterval.Day };

        Invoices::FrequencyUnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeModelTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Invoices::TypeModel();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::TypeModel>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "mixed"
                }
                """
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::TypeModel>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Invoices::TypeModel();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::TypeModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::TypeModel>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "mixed"
                }
                """
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::TypeModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Invoices::TypeModel>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::TypeModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class InvoiceTagTest : TestBase
{
    [Theory]
    [InlineData(Invoices::InvoiceTag.Refunded)]
    [InlineData(Invoices::InvoiceTag.PartiallyRefunded)]
    [InlineData(Invoices::InvoiceTag.Disputed)]
    [InlineData(Invoices::InvoiceTag.PaymentReversed)]
    public void Validation_Works(Invoices::InvoiceTag rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::InvoiceTag> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceTag>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::InvoiceTag.Refunded)]
    [InlineData(Invoices::InvoiceTag.PartiallyRefunded)]
    [InlineData(Invoices::InvoiceTag.Disputed)]
    [InlineData(Invoices::InvoiceTag.PaymentReversed)]
    public void SerializationRoundtrip_Works(Invoices::InvoiceTag rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::InvoiceTag> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceTag>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceTag>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceTag>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PaymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            RetryAttempt = 0,
            Status = Payments::IntentStatus.Succeeded,
        };

        long expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentID = "payment_id";
        int expectedRetryAttempt = 0;
        ApiEnum<string, Payments::IntentStatus> expectedStatus = Payments::IntentStatus.Succeeded;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRetryAttempt, model.RetryAttempt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            RetryAttempt = 0,
            Status = Payments::IntentStatus.Succeeded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Payment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            RetryAttempt = 0,
            Status = Payments::IntentStatus.Succeeded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Payment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPaymentID = "payment_id";
        int expectedRetryAttempt = 0;
        ApiEnum<string, Payments::IntentStatus> expectedStatus = Payments::IntentStatus.Succeeded;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRetryAttempt, deserialized.RetryAttempt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            RetryAttempt = 0,
            Status = Payments::IntentStatus.Succeeded,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
        };

        Assert.Null(model.RetryAttempt);
        Assert.False(model.RawData.ContainsKey("retry_attempt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",

            RetryAttempt = null,
            Status = null,
        };

        Assert.Null(model.RetryAttempt);
        Assert.True(model.RawData.ContainsKey("retry_attempt"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",

            RetryAttempt = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::Payment
        {
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentID = "payment_id",
            RetryAttempt = 0,
            Status = Payments::IntentStatus.Succeeded,
        };

        Invoices::Payment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReminderSettingsTest : TestBase
{
    [Fact]
    public void UnionMember0ValidationWorks()
    {
        Invoices::ReminderSettings value = new Invoices::UnionMember0()
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };
        value.Validate();
    }

    [Fact]
    public void ReminderSettingsUnionMember1ValidationWorks()
    {
        Invoices::ReminderSettings value = new Invoices::ReminderSettingsUnionMember1()
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember0SerializationRoundtripWorks()
    {
        Invoices::ReminderSettings value = new Invoices::UnionMember0()
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::ReminderSettings>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReminderSettingsUnionMember1SerializationRoundtripWorks()
    {
        Invoices::ReminderSettings value = new Invoices::ReminderSettingsUnionMember1()
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::ReminderSettings>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::UnionMember0
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        JsonElement expectedKind = JsonSerializer.SerializeToElement("snapshot");
        List<long> expectedOffsetsMinutes = [0];
        bool expectedPaused = true;
        bool expectedRemindersEnabled = true;

        Assert.True(JsonElement.DeepEquals(expectedKind, model.Kind));
        Assert.Equal(expectedOffsetsMinutes.Count, model.OffsetsMinutes.Count);
        for (int i = 0; i < expectedOffsetsMinutes.Count; i++)
        {
            Assert.Equal(expectedOffsetsMinutes[i], model.OffsetsMinutes[i]);
        }
        Assert.Equal(expectedPaused, model.Paused);
        Assert.Equal(expectedRemindersEnabled, model.RemindersEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::UnionMember0
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::UnionMember0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::UnionMember0
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::UnionMember0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedKind = JsonSerializer.SerializeToElement("snapshot");
        List<long> expectedOffsetsMinutes = [0];
        bool expectedPaused = true;
        bool expectedRemindersEnabled = true;

        Assert.True(JsonElement.DeepEquals(expectedKind, deserialized.Kind));
        Assert.Equal(expectedOffsetsMinutes.Count, deserialized.OffsetsMinutes.Count);
        for (int i = 0; i < expectedOffsetsMinutes.Count; i++)
        {
            Assert.Equal(expectedOffsetsMinutes[i], deserialized.OffsetsMinutes[i]);
        }
        Assert.Equal(expectedPaused, deserialized.Paused);
        Assert.Equal(expectedRemindersEnabled, deserialized.RemindersEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::UnionMember0
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::UnionMember0
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        Invoices::UnionMember0 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReminderSettingsUnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        JsonElement expectedKind = JsonSerializer.SerializeToElement("override");
        List<long> expectedOffsetsMinutes = [0];
        bool expectedPaused = true;
        bool expectedRemindersEnabled = true;

        Assert.True(JsonElement.DeepEquals(expectedKind, model.Kind));
        Assert.NotNull(model.OffsetsMinutes);
        Assert.Equal(expectedOffsetsMinutes.Count, model.OffsetsMinutes.Count);
        for (int i = 0; i < expectedOffsetsMinutes.Count; i++)
        {
            Assert.Equal(expectedOffsetsMinutes[i], model.OffsetsMinutes[i]);
        }
        Assert.Equal(expectedPaused, model.Paused);
        Assert.Equal(expectedRemindersEnabled, model.RemindersEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::ReminderSettingsUnionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::ReminderSettingsUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedKind = JsonSerializer.SerializeToElement("override");
        List<long> expectedOffsetsMinutes = [0];
        bool expectedPaused = true;
        bool expectedRemindersEnabled = true;

        Assert.True(JsonElement.DeepEquals(expectedKind, deserialized.Kind));
        Assert.NotNull(deserialized.OffsetsMinutes);
        Assert.Equal(expectedOffsetsMinutes.Count, deserialized.OffsetsMinutes.Count);
        for (int i = 0; i < expectedOffsetsMinutes.Count; i++)
        {
            Assert.Equal(expectedOffsetsMinutes[i], deserialized.OffsetsMinutes[i]);
        }
        Assert.Equal(expectedPaused, deserialized.Paused);
        Assert.Equal(expectedRemindersEnabled, deserialized.RemindersEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1 { };

        Assert.Null(model.OffsetsMinutes);
        Assert.False(model.RawData.ContainsKey("offsets_minutes"));
        Assert.Null(model.Paused);
        Assert.False(model.RawData.ContainsKey("paused"));
        Assert.Null(model.RemindersEnabled);
        Assert.False(model.RawData.ContainsKey("reminders_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = null,
            Paused = null,
            RemindersEnabled = null,
        };

        Assert.Null(model.OffsetsMinutes);
        Assert.True(model.RawData.ContainsKey("offsets_minutes"));
        Assert.Null(model.Paused);
        Assert.True(model.RawData.ContainsKey("paused"));
        Assert.Null(model.RemindersEnabled);
        Assert.True(model.RawData.ContainsKey("reminders_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = null,
            Paused = null,
            RemindersEnabled = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoices::ReminderSettingsUnionMember1
        {
            OffsetsMinutes = [0],
            Paused = true,
            RemindersEnabled = true,
        };

        Invoices::ReminderSettingsUnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
