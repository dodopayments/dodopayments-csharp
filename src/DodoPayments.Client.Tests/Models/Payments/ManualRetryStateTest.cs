using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class ManualRetryStateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedCanRetry = true;
        long expectedSendsAllowed = 0;
        long expectedSendsUsed = 0;
        string expectedReason = "reason";
        DateTimeOffset expectedRetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanRetry, model.CanRetry);
        Assert.Equal(expectedSendsAllowed, model.SendsAllowed);
        Assert.Equal(expectedSendsUsed, model.SendsUsed);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRetryAvailableAt, model.RetryAvailableAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ManualRetryState>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ManualRetryState>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanRetry = true;
        long expectedSendsAllowed = 0;
        long expectedSendsUsed = 0;
        string expectedReason = "reason";
        DateTimeOffset expectedRetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanRetry, deserialized.CanRetry);
        Assert.Equal(expectedSendsAllowed, deserialized.SendsAllowed);
        Assert.Equal(expectedSendsUsed, deserialized.SendsUsed);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRetryAvailableAt, deserialized.RetryAvailableAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RetryAvailableAt);
        Assert.False(model.RawData.ContainsKey("retry_available_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,

            Reason = null,
            RetryAvailableAt = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RetryAvailableAt);
        Assert.True(model.RawData.ContainsKey("retry_available_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,

            Reason = null,
            RetryAvailableAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ManualRetryState
        {
            CanRetry = true,
            SendsAllowed = 0,
            SendsUsed = 0,
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ManualRetryState copied = new(model);

        Assert.Equal(model, copied);
    }
}
