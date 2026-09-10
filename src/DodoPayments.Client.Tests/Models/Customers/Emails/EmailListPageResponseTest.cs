using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailListPageResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailLogID = "email_log_id",
                    EmailType = "email_type",
                    HasPreview = true,
                    Policies = new()
                    {
                        RequiresDifferentAddress = true,
                        ResendAllowed = true,
                        ResendsRemaining = 0,
                        RetryAllowed = true,
                    },
                    Status = EmailLogStatus.Sent,
                    FailureCode = EmailFailureCode.MailboxNotFound,
                    FailureReason = "failure_reason",
                    From = "from",
                    IntendedRecipient = "intended_recipient",
                    Recipient = "recipient",
                    Subject = "subject",
                },
            ],
            TotalCount = 0,
        };

        List<EmailLogItem> expectedItems =
        [
            new()
            {
                Category = "category",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EmailLogID = "email_log_id",
                EmailType = "email_type",
                HasPreview = true,
                Policies = new()
                {
                    RequiresDifferentAddress = true,
                    ResendAllowed = true,
                    ResendsRemaining = 0,
                    RetryAllowed = true,
                },
                Status = EmailLogStatus.Sent,
                FailureCode = EmailFailureCode.MailboxNotFound,
                FailureReason = "failure_reason",
                From = "from",
                IntendedRecipient = "intended_recipient",
                Recipient = "recipient",
                Subject = "subject",
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailListPageResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailLogID = "email_log_id",
                    EmailType = "email_type",
                    HasPreview = true,
                    Policies = new()
                    {
                        RequiresDifferentAddress = true,
                        ResendAllowed = true,
                        ResendsRemaining = 0,
                        RetryAllowed = true,
                    },
                    Status = EmailLogStatus.Sent,
                    FailureCode = EmailFailureCode.MailboxNotFound,
                    FailureReason = "failure_reason",
                    From = "from",
                    IntendedRecipient = "intended_recipient",
                    Recipient = "recipient",
                    Subject = "subject",
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailListPageResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailLogID = "email_log_id",
                    EmailType = "email_type",
                    HasPreview = true,
                    Policies = new()
                    {
                        RequiresDifferentAddress = true,
                        ResendAllowed = true,
                        ResendsRemaining = 0,
                        RetryAllowed = true,
                    },
                    Status = EmailLogStatus.Sent,
                    FailureCode = EmailFailureCode.MailboxNotFound,
                    FailureReason = "failure_reason",
                    From = "from",
                    IntendedRecipient = "intended_recipient",
                    Recipient = "recipient",
                    Subject = "subject",
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EmailLogItem> expectedItems =
        [
            new()
            {
                Category = "category",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EmailLogID = "email_log_id",
                EmailType = "email_type",
                HasPreview = true,
                Policies = new()
                {
                    RequiresDifferentAddress = true,
                    ResendAllowed = true,
                    ResendsRemaining = 0,
                    RetryAllowed = true,
                },
                Status = EmailLogStatus.Sent,
                FailureCode = EmailFailureCode.MailboxNotFound,
                FailureReason = "failure_reason",
                From = "from",
                IntendedRecipient = "intended_recipient",
                Recipient = "recipient",
                Subject = "subject",
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailListPageResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailLogID = "email_log_id",
                    EmailType = "email_type",
                    HasPreview = true,
                    Policies = new()
                    {
                        RequiresDifferentAddress = true,
                        ResendAllowed = true,
                        ResendsRemaining = 0,
                        RetryAllowed = true,
                    },
                    Status = EmailLogStatus.Sent,
                    FailureCode = EmailFailureCode.MailboxNotFound,
                    FailureReason = "failure_reason",
                    From = "from",
                    IntendedRecipient = "intended_recipient",
                    Recipient = "recipient",
                    Subject = "subject",
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailListPageResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailLogID = "email_log_id",
                    EmailType = "email_type",
                    HasPreview = true,
                    Policies = new()
                    {
                        RequiresDifferentAddress = true,
                        ResendAllowed = true,
                        ResendsRemaining = 0,
                        RetryAllowed = true,
                    },
                    Status = EmailLogStatus.Sent,
                    FailureCode = EmailFailureCode.MailboxNotFound,
                    FailureReason = "failure_reason",
                    From = "from",
                    IntendedRecipient = "intended_recipient",
                    Recipient = "recipient",
                    Subject = "subject",
                },
            ],
            TotalCount = 0,
        };

        EmailListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
