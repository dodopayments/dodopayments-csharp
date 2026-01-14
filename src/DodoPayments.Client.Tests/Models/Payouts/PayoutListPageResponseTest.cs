using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payouts;

namespace DodoPayments.Client.Tests.Models.Payouts;

public class PayoutListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Chargebacks = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Fee = 0,
                    PaymentMethod = "payment_method",
                    PayoutID = "payout_id",
                    Refunds = 0,
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentUrl = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        List<PayoutListResponse> expectedItems =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = Status.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
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
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Chargebacks = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Fee = 0,
                    PaymentMethod = "payment_method",
                    PayoutID = "payout_id",
                    Refunds = 0,
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentUrl = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayoutListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Chargebacks = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Fee = 0,
                    PaymentMethod = "payment_method",
                    PayoutID = "payout_id",
                    Refunds = 0,
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentUrl = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayoutListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PayoutListResponse> expectedItems =
        [
            new()
            {
                Amount = 0,
                BusinessID = "business_id",
                Chargebacks = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Fee = 0,
                PaymentMethod = "payment_method",
                PayoutID = "payout_id",
                Refunds = 0,
                Status = Status.NotInitiated,
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                PayoutDocumentUrl = "payout_document_url",
                Remarks = "remarks",
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
        var model = new PayoutListPageResponse
        {
            Items =
            [
                new()
                {
                    Amount = 0,
                    BusinessID = "business_id",
                    Chargebacks = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Fee = 0,
                    PaymentMethod = "payment_method",
                    PayoutID = "payout_id",
                    Refunds = 0,
                    Status = Status.NotInitiated,
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    PayoutDocumentUrl = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        model.Validate();
    }
}
