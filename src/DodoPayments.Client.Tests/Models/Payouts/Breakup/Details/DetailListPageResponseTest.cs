using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payouts.Breakup.Details;

namespace DodoPayments.Client.Tests.Models.Payouts.Breakup.Details;

public class DetailListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DetailListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Unattributed = 0,
        };

        List<DetailListResponse> expectedItems =
        [
            new()
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
            },
        ];
        long expectedUnattributed = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedUnattributed, model.Unattributed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DetailListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Unattributed = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DetailListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DetailListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Unattributed = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DetailListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DetailListResponse> expectedItems =
        [
            new()
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
            },
        ];
        long expectedUnattributed = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedUnattributed, deserialized.Unattributed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DetailListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Unattributed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DetailListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Unattributed = 0,
        };

        DetailListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
