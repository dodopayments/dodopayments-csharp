using System;
using System.Collections.Generic;
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
                    PayoutDocumentURL = "payout_document_url",
                    Remarks = "remarks",
                },
            ],
        };

        List<Item> expectedItems =
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
                PayoutDocumentURL = "payout_document_url",
                Remarks = "remarks",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
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
            PayoutDocumentURL = "payout_document_url",
            Remarks = "remarks",
        };

        long expectedAmount = 0;
        string expectedBusinessID = "business_id";
        long expectedChargebacks = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFee = 0;
        string expectedPaymentMethod = "payment_method";
        string expectedPayoutID = "payout_id";
        long expectedRefunds = 0;
        ApiEnum<string, Status> expectedStatus = Status.NotInitiated;
        long expectedTax = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPayoutDocumentURL = "payout_document_url";
        string expectedRemarks = "remarks";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedChargebacks, model.Chargebacks);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFee, model.Fee);
        Assert.Equal(expectedPaymentMethod, model.PaymentMethod);
        Assert.Equal(expectedPayoutID, model.PayoutID);
        Assert.Equal(expectedRefunds, model.Refunds);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPayoutDocumentURL, model.PayoutDocumentURL);
        Assert.Equal(expectedRemarks, model.Remarks);
    }
}
