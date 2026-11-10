using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices;
using DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Items =
            [
                new()
                {
                    AllowedActions = [AllowedAction.Edit],
                    AmountDue = 0,
                    AmountPaid = 0,
                    AmountRefunded = 0,
                    BillingMode = BillingMode.Normal,
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
                    EditableFields = [EditableField.Customer],
                    Frequency = new OneTime(),
                    InvoiceID = "invoice_id",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RefundIds = ["string"],
                    RetryCount = 0,
                    RowVersion = 0,
                    Status = InvoiceStatus.Open,
                    SubscriptionIds = ["string"],
                    Tags = [InvoiceTag.Refunded],
                    Tax = 0,
                    TotalAmount = 0,
                    CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                    DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DunningState = DunningState.NotStarted,
                    FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedUrl = "hosted_url",
                    Lines =
                    [
                        new()
                        {
                            Amount = 0,
                            Kind = Kind.Subscription,
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
                    ReminderSettings = new Snapshot()
                    {
                        OffsetsMinutes = [0],
                        Paused = true,
                        RemindersEnabled = true,
                    },
                    ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Invoice> expectedItems =
        [
            new()
            {
                AllowedActions = [AllowedAction.Edit],
                AmountDue = 0,
                AmountPaid = 0,
                AmountRefunded = 0,
                BillingMode = BillingMode.Normal,
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
                EditableFields = [EditableField.Customer],
                Frequency = new OneTime(),
                InvoiceID = "invoice_id",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                RefundIds = ["string"],
                RetryCount = 0,
                RowVersion = 0,
                Status = InvoiceStatus.Open,
                SubscriptionIds = ["string"],
                Tags = [InvoiceTag.Refunded],
                Tax = 0,
                TotalAmount = 0,
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DunningState = DunningState.NotStarted,
                FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HostedUrl = "hosted_url",
                Lines =
                [
                    new()
                    {
                        Amount = 0,
                        Kind = Kind.Subscription,
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
                ReminderSettings = new Snapshot()
                {
                    OffsetsMinutes = [0],
                    Paused = true,
                    RemindersEnabled = true,
                },
                ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Items =
            [
                new()
                {
                    AllowedActions = [AllowedAction.Edit],
                    AmountDue = 0,
                    AmountPaid = 0,
                    AmountRefunded = 0,
                    BillingMode = BillingMode.Normal,
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
                    EditableFields = [EditableField.Customer],
                    Frequency = new OneTime(),
                    InvoiceID = "invoice_id",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RefundIds = ["string"],
                    RetryCount = 0,
                    RowVersion = 0,
                    Status = InvoiceStatus.Open,
                    SubscriptionIds = ["string"],
                    Tags = [InvoiceTag.Refunded],
                    Tax = 0,
                    TotalAmount = 0,
                    CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                    DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DunningState = DunningState.NotStarted,
                    FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedUrl = "hosted_url",
                    Lines =
                    [
                        new()
                        {
                            Amount = 0,
                            Kind = Kind.Subscription,
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
                    ReminderSettings = new Snapshot()
                    {
                        OffsetsMinutes = [0],
                        Paused = true,
                        RemindersEnabled = true,
                    },
                    ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Items =
            [
                new()
                {
                    AllowedActions = [AllowedAction.Edit],
                    AmountDue = 0,
                    AmountPaid = 0,
                    AmountRefunded = 0,
                    BillingMode = BillingMode.Normal,
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
                    EditableFields = [EditableField.Customer],
                    Frequency = new OneTime(),
                    InvoiceID = "invoice_id",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RefundIds = ["string"],
                    RetryCount = 0,
                    RowVersion = 0,
                    Status = InvoiceStatus.Open,
                    SubscriptionIds = ["string"],
                    Tags = [InvoiceTag.Refunded],
                    Tax = 0,
                    TotalAmount = 0,
                    CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                    DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DunningState = DunningState.NotStarted,
                    FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedUrl = "hosted_url",
                    Lines =
                    [
                        new()
                        {
                            Amount = 0,
                            Kind = Kind.Subscription,
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
                    ReminderSettings = new Snapshot()
                    {
                        OffsetsMinutes = [0],
                        Paused = true,
                        RemindersEnabled = true,
                    },
                    ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Invoice> expectedItems =
        [
            new()
            {
                AllowedActions = [AllowedAction.Edit],
                AmountDue = 0,
                AmountPaid = 0,
                AmountRefunded = 0,
                BillingMode = BillingMode.Normal,
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
                EditableFields = [EditableField.Customer],
                Frequency = new OneTime(),
                InvoiceID = "invoice_id",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                RefundIds = ["string"],
                RetryCount = 0,
                RowVersion = 0,
                Status = InvoiceStatus.Open,
                SubscriptionIds = ["string"],
                Tags = [InvoiceTag.Refunded],
                Tax = 0,
                TotalAmount = 0,
                CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DunningState = DunningState.NotStarted,
                FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HostedUrl = "hosted_url",
                Lines =
                [
                    new()
                    {
                        Amount = 0,
                        Kind = Kind.Subscription,
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
                ReminderSettings = new Snapshot()
                {
                    OffsetsMinutes = [0],
                    Paused = true,
                    RemindersEnabled = true,
                },
                ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Items =
            [
                new()
                {
                    AllowedActions = [AllowedAction.Edit],
                    AmountDue = 0,
                    AmountPaid = 0,
                    AmountRefunded = 0,
                    BillingMode = BillingMode.Normal,
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
                    EditableFields = [EditableField.Customer],
                    Frequency = new OneTime(),
                    InvoiceID = "invoice_id",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RefundIds = ["string"],
                    RetryCount = 0,
                    RowVersion = 0,
                    Status = InvoiceStatus.Open,
                    SubscriptionIds = ["string"],
                    Tags = [InvoiceTag.Refunded],
                    Tax = 0,
                    TotalAmount = 0,
                    CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                    DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DunningState = DunningState.NotStarted,
                    FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedUrl = "hosted_url",
                    Lines =
                    [
                        new()
                        {
                            Amount = 0,
                            Kind = Kind.Subscription,
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
                    ReminderSettings = new Snapshot()
                    {
                        OffsetsMinutes = [0],
                        Paused = true,
                        RemindersEnabled = true,
                    },
                    ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Items =
            [
                new()
                {
                    AllowedActions = [AllowedAction.Edit],
                    AmountDue = 0,
                    AmountPaid = 0,
                    AmountRefunded = 0,
                    BillingMode = BillingMode.Normal,
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
                    EditableFields = [EditableField.Customer],
                    Frequency = new OneTime(),
                    InvoiceID = "invoice_id",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    RefundIds = ["string"],
                    RetryCount = 0,
                    RowVersion = 0,
                    Status = InvoiceStatus.Open,
                    SubscriptionIds = ["string"],
                    Tags = [InvoiceTag.Refunded],
                    Tax = 0,
                    TotalAmount = 0,
                    CollectionMethod = InvoiceCollectionMethod.AutoCharge,
                    DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DunningState = DunningState.NotStarted,
                    FinalizedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedUrl = "hosted_url",
                    Lines =
                    [
                        new()
                        {
                            Amount = 0,
                            Kind = Kind.Subscription,
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
                    ReminderSettings = new Snapshot()
                    {
                        OffsetsMinutes = [0],
                        Paused = true,
                        RemindersEnabled = true,
                    },
                    ReviewDeadline = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        InvoiceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
