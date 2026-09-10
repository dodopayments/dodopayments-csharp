using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailLogItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailLogItem
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
        };

        string expectedCategory = "category";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmailLogID = "email_log_id";
        string expectedEmailType = "email_type";
        bool expectedHasPreview = true;
        EmailPolicies expectedPolicies = new()
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };
        ApiEnum<string, EmailLogStatus> expectedStatus = EmailLogStatus.Sent;
        ApiEnum<string, EmailFailureCode> expectedFailureCode = EmailFailureCode.MailboxNotFound;
        string expectedFailureReason = "failure_reason";
        string expectedFrom = "from";
        string expectedIntendedRecipient = "intended_recipient";
        string expectedRecipient = "recipient";
        string expectedSubject = "subject";

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEmailLogID, model.EmailLogID);
        Assert.Equal(expectedEmailType, model.EmailType);
        Assert.Equal(expectedHasPreview, model.HasPreview);
        Assert.Equal(expectedPolicies, model.Policies);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedFailureCode, model.FailureCode);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedIntendedRecipient, model.IntendedRecipient);
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedSubject, model.Subject);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailLogItem
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailLogItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailLogItem
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailLogItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCategory = "category";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmailLogID = "email_log_id";
        string expectedEmailType = "email_type";
        bool expectedHasPreview = true;
        EmailPolicies expectedPolicies = new()
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };
        ApiEnum<string, EmailLogStatus> expectedStatus = EmailLogStatus.Sent;
        ApiEnum<string, EmailFailureCode> expectedFailureCode = EmailFailureCode.MailboxNotFound;
        string expectedFailureReason = "failure_reason";
        string expectedFrom = "from";
        string expectedIntendedRecipient = "intended_recipient";
        string expectedRecipient = "recipient";
        string expectedSubject = "subject";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEmailLogID, deserialized.EmailLogID);
        Assert.Equal(expectedEmailType, deserialized.EmailType);
        Assert.Equal(expectedHasPreview, deserialized.HasPreview);
        Assert.Equal(expectedPolicies, deserialized.Policies);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedFailureCode, deserialized.FailureCode);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedIntendedRecipient, deserialized.IntendedRecipient);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedSubject, deserialized.Subject);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailLogItem
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailLogItem
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
        };

        Assert.Null(model.FailureCode);
        Assert.False(model.RawData.ContainsKey("failure_code"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.IntendedRecipient);
        Assert.False(model.RawData.ContainsKey("intended_recipient"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailLogItem
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EmailLogItem
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

            FailureCode = null,
            FailureReason = null,
            From = null,
            IntendedRecipient = null,
            Recipient = null,
            Subject = null,
        };

        Assert.Null(model.FailureCode);
        Assert.True(model.RawData.ContainsKey("failure_code"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.From);
        Assert.True(model.RawData.ContainsKey("from"));
        Assert.Null(model.IntendedRecipient);
        Assert.True(model.RawData.ContainsKey("intended_recipient"));
        Assert.Null(model.Recipient);
        Assert.True(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.Subject);
        Assert.True(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailLogItem
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

            FailureCode = null,
            FailureReason = null,
            From = null,
            IntendedRecipient = null,
            Recipient = null,
            Subject = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailLogItem
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
        };

        EmailLogItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
