using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class DisputeListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
            IsResolvedByRdr = true,
        };

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, DisputeDisputeStage> expectedDisputeStage = DisputeDisputeStage.PreDispute;
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        ApiEnum<string, DisputeListResponsePaymentProvider> expectedPaymentProvider =
            DisputeListResponsePaymentProvider.Stripe;
        bool expectedIsResolvedByRdr = true;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDisputeID, model.DisputeID);
        Assert.Equal(expectedDisputeStage, model.DisputeStage);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentProvider, model.PaymentProvider);
        Assert.Equal(expectedIsResolvedByRdr, model.IsResolvedByRdr);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
            IsResolvedByRdr = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DisputeListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
            IsResolvedByRdr = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DisputeListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, DisputeDisputeStage> expectedDisputeStage = DisputeDisputeStage.PreDispute;
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        ApiEnum<string, DisputeListResponsePaymentProvider> expectedPaymentProvider =
            DisputeListResponsePaymentProvider.Stripe;
        bool expectedIsResolvedByRdr = true;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDisputeID, deserialized.DisputeID);
        Assert.Equal(expectedDisputeStage, deserialized.DisputeStage);
        Assert.Equal(expectedDisputeStatus, deserialized.DisputeStatus);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedPaymentProvider, deserialized.PaymentProvider);
        Assert.Equal(expectedIsResolvedByRdr, deserialized.IsResolvedByRdr);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
            IsResolvedByRdr = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
        };

        Assert.Null(model.IsResolvedByRdr);
        Assert.False(model.RawData.ContainsKey("is_resolved_by_rdr"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,

            IsResolvedByRdr = null,
        };

        Assert.Null(model.IsResolvedByRdr);
        Assert.True(model.RawData.ContainsKey("is_resolved_by_rdr"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,

            IsResolvedByRdr = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DisputeListResponse
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            PaymentProvider = DisputeListResponsePaymentProvider.Stripe,
            IsResolvedByRdr = true,
        };

        DisputeListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DisputeListResponsePaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(DisputeListResponsePaymentProvider.Stripe)]
    [InlineData(DisputeListResponsePaymentProvider.Adyen)]
    [InlineData(DisputeListResponsePaymentProvider.Dodo)]
    public void Validation_Works(DisputeListResponsePaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeListResponsePaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeListResponsePaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeListResponsePaymentProvider.Stripe)]
    [InlineData(DisputeListResponsePaymentProvider.Adyen)]
    [InlineData(DisputeListResponsePaymentProvider.Dodo)]
    public void SerializationRoundtrip_Works(DisputeListResponsePaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeListResponsePaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeListResponsePaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeListResponsePaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DisputeListResponsePaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
