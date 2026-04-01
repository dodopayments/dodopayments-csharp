using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts.Breakup.Details;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup.Details;

public class DetailListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "event_type";
        long expectedOriginalAmount = 0;
        string expectedOriginalCurrency = "original_currency";
        long expectedPayoutCurrencyAmount = 0;
        long expectedUsdEquivalentAmount = 0;
        string expectedDescription = "description";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedOriginalAmount, model.OriginalAmount);
        Assert.Equal(expectedOriginalCurrency, model.OriginalCurrency);
        Assert.Equal(expectedPayoutCurrencyAmount, model.PayoutCurrencyAmount);
        Assert.Equal(expectedUsdEquivalentAmount, model.UsdEquivalentAmount);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedReferenceObjectID, model.ReferenceObjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DetailListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DetailListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "event_type";
        long expectedOriginalAmount = 0;
        string expectedOriginalCurrency = "original_currency";
        long expectedPayoutCurrencyAmount = 0;
        long expectedUsdEquivalentAmount = 0;
        string expectedDescription = "description";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedOriginalAmount, deserialized.OriginalAmount);
        Assert.Equal(expectedOriginalCurrency, deserialized.OriginalCurrency);
        Assert.Equal(expectedPayoutCurrencyAmount, deserialized.PayoutCurrencyAmount);
        Assert.Equal(expectedUsdEquivalentAmount, deserialized.UsdEquivalentAmount);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedReferenceObjectID, deserialized.ReferenceObjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ReferenceObjectID);
        Assert.False(model.RawData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,

            Description = null,
            ReferenceObjectID = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ReferenceObjectID);
        Assert.True(model.RawData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,

            Description = null,
            ReferenceObjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DetailListResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "event_type",
            OriginalAmount = 0,
            OriginalCurrency = "original_currency",
            PayoutCurrencyAmount = 0,
            UsdEquivalentAmount = 0,
            Description = "description",
            ReferenceObjectID = "reference_object_id",
        };

        DetailListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
