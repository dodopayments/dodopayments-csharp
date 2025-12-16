using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class RefundListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RefundListPageResponse
        {
            Items =
            [
                new()
                {
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsPartial = true,
                    PaymentID = "payment_id",
                    RefundID = "refund_id",
                    Status = RefundStatus.Succeeded,
                    Amount = 0,
                    Currency = Currency.Aed,
                    Reason = "reason",
                },
            ],
        };

        List<ItemModel> expectedItems =
        [
            new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPartial = true,
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemModel
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPartial = true,
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
        };

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsPartial = true;
        string expectedPaymentID = "payment_id";
        string expectedRefundID = "refund_id";
        ApiEnum<string, RefundStatus> expectedStatus = RefundStatus.Succeeded;
        int expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedReason = "reason";

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsPartial, model.IsPartial);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRefundID, model.RefundID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedReason, model.Reason);
    }
}
