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
            AutomaticRetryNumber = 0,
            AutomaticRetryTotal = 0,
            NextAutomaticRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedCanRetry = true;
        long expectedSendsAllowed = 0;
        long expectedSendsUsed = 0;
        int expectedAutomaticRetryNumber = 0;
        int expectedAutomaticRetryTotal = 0;
        DateTimeOffset expectedNextAutomaticRetryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedReason = "reason";
        DateTimeOffset expectedRetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanRetry, model.CanRetry);
        Assert.Equal(expectedSendsAllowed, model.SendsAllowed);
        Assert.Equal(expectedSendsUsed, model.SendsUsed);
        Assert.Equal(expectedAutomaticRetryNumber, model.AutomaticRetryNumber);
        Assert.Equal(expectedAutomaticRetryTotal, model.AutomaticRetryTotal);
        Assert.Equal(expectedNextAutomaticRetryAt, model.NextAutomaticRetryAt);
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
            AutomaticRetryNumber = 0,
            AutomaticRetryTotal = 0,
            NextAutomaticRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AutomaticRetryNumber = 0,
            AutomaticRetryTotal = 0,
            NextAutomaticRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        int expectedAutomaticRetryNumber = 0;
        int expectedAutomaticRetryTotal = 0;
        DateTimeOffset expectedNextAutomaticRetryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedReason = "reason";
        DateTimeOffset expectedRetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanRetry, deserialized.CanRetry);
        Assert.Equal(expectedSendsAllowed, deserialized.SendsAllowed);
        Assert.Equal(expectedSendsUsed, deserialized.SendsUsed);
        Assert.Equal(expectedAutomaticRetryNumber, deserialized.AutomaticRetryNumber);
        Assert.Equal(expectedAutomaticRetryTotal, deserialized.AutomaticRetryTotal);
        Assert.Equal(expectedNextAutomaticRetryAt, deserialized.NextAutomaticRetryAt);
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
            AutomaticRetryNumber = 0,
            AutomaticRetryTotal = 0,
            NextAutomaticRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        Assert.Null(model.AutomaticRetryNumber);
        Assert.False(model.RawData.ContainsKey("automatic_retry_number"));
        Assert.Null(model.AutomaticRetryTotal);
        Assert.False(model.RawData.ContainsKey("automatic_retry_total"));
        Assert.Null(model.NextAutomaticRetryAt);
        Assert.False(model.RawData.ContainsKey("next_automatic_retry_at"));
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

            AutomaticRetryNumber = null,
            AutomaticRetryTotal = null,
            NextAutomaticRetryAt = null,
            Reason = null,
            RetryAvailableAt = null,
        };

        Assert.Null(model.AutomaticRetryNumber);
        Assert.True(model.RawData.ContainsKey("automatic_retry_number"));
        Assert.Null(model.AutomaticRetryTotal);
        Assert.True(model.RawData.ContainsKey("automatic_retry_total"));
        Assert.Null(model.NextAutomaticRetryAt);
        Assert.True(model.RawData.ContainsKey("next_automatic_retry_at"));
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

            AutomaticRetryNumber = null,
            AutomaticRetryTotal = null,
            NextAutomaticRetryAt = null,
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
            AutomaticRetryNumber = 0,
            AutomaticRetryTotal = 0,
            NextAutomaticRetryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Reason = "reason",
            RetryAvailableAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ManualRetryState copied = new(model);

        Assert.Equal(model, copied);
    }
}
