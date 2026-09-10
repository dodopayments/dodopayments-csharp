using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailBodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,
            FailureCode = EmailFailureCode.MailboxNotFound,
            FailureReason = "failure_reason",
            Html = "html",
            Text = "text",
        };

        bool expectedMerchantAuthored = true;
        ApiEnum<string, EmailFailureCode> expectedFailureCode = EmailFailureCode.MailboxNotFound;
        string expectedFailureReason = "failure_reason";
        string expectedHtml = "html";
        string expectedText = "text";

        Assert.Equal(expectedMerchantAuthored, model.MerchantAuthored);
        Assert.Equal(expectedFailureCode, model.FailureCode);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedHtml, model.Html);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,
            FailureCode = EmailFailureCode.MailboxNotFound,
            FailureReason = "failure_reason",
            Html = "html",
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailBody>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,
            FailureCode = EmailFailureCode.MailboxNotFound,
            FailureReason = "failure_reason",
            Html = "html",
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailBody>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedMerchantAuthored = true;
        ApiEnum<string, EmailFailureCode> expectedFailureCode = EmailFailureCode.MailboxNotFound;
        string expectedFailureReason = "failure_reason";
        string expectedHtml = "html";
        string expectedText = "text";

        Assert.Equal(expectedMerchantAuthored, deserialized.MerchantAuthored);
        Assert.Equal(expectedFailureCode, deserialized.FailureCode);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedHtml, deserialized.Html);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,
            FailureCode = EmailFailureCode.MailboxNotFound,
            FailureReason = "failure_reason",
            Html = "html",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailBody { MerchantAuthored = true };

        Assert.Null(model.FailureCode);
        Assert.False(model.RawData.ContainsKey("failure_code"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.Html);
        Assert.False(model.RawData.ContainsKey("html"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailBody { MerchantAuthored = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,

            FailureCode = null,
            FailureReason = null,
            Html = null,
            Text = null,
        };

        Assert.Null(model.FailureCode);
        Assert.True(model.RawData.ContainsKey("failure_code"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.Html);
        Assert.True(model.RawData.ContainsKey("html"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,

            FailureCode = null,
            FailureReason = null,
            Html = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailBody
        {
            MerchantAuthored = true,
            FailureCode = EmailFailureCode.MailboxNotFound,
            FailureReason = "failure_reason",
            Html = "html",
            Text = "text",
        };

        EmailBody copied = new(model);

        Assert.Equal(model, copied);
    }
}
