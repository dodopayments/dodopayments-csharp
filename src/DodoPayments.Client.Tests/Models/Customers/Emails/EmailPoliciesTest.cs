using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Tests.Models.Customers.Emails;

public class EmailPoliciesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailPolicies
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };

        bool expectedRequiresDifferentAddress = true;
        bool expectedResendAllowed = true;
        long expectedResendsRemaining = 0;
        bool expectedRetryAllowed = true;

        Assert.Equal(expectedRequiresDifferentAddress, model.RequiresDifferentAddress);
        Assert.Equal(expectedResendAllowed, model.ResendAllowed);
        Assert.Equal(expectedResendsRemaining, model.ResendsRemaining);
        Assert.Equal(expectedRetryAllowed, model.RetryAllowed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailPolicies
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailPolicies>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailPolicies
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailPolicies>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedRequiresDifferentAddress = true;
        bool expectedResendAllowed = true;
        long expectedResendsRemaining = 0;
        bool expectedRetryAllowed = true;

        Assert.Equal(expectedRequiresDifferentAddress, deserialized.RequiresDifferentAddress);
        Assert.Equal(expectedResendAllowed, deserialized.ResendAllowed);
        Assert.Equal(expectedResendsRemaining, deserialized.ResendsRemaining);
        Assert.Equal(expectedRetryAllowed, deserialized.RetryAllowed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailPolicies
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailPolicies
        {
            RequiresDifferentAddress = true,
            ResendAllowed = true,
            ResendsRemaining = 0,
            RetryAllowed = true,
        };

        EmailPolicies copied = new(model);

        Assert.Equal(model, copied);
    }
}
