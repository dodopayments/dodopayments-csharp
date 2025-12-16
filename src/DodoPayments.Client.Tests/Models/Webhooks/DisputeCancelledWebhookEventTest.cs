using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class DisputeCancelledWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeCancelledWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                Remarks = "remarks",
                PayloadType =
                    DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeCancelledWebhookEventType.DisputeCancelled,
        };

        string expectedBusinessID = "business_id";
        DisputeCancelledWebhookEventData expectedData = new()
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DisputeCancelledWebhookEventType> expectedType =
            DisputeCancelledWebhookEventType.DisputeCancelled;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }
}

public class DisputeCancelledWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeCancelledWebhookEventData
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Remarks = "remarks",
            PayloadType = DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute,
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
        string expectedRemarks = "remarks";
        ApiEnum<
            string,
            DisputeCancelledWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDisputeID, model.DisputeID);
        Assert.Equal(expectedDisputeStage, model.DisputeStage);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRemarks, model.Remarks);
        Assert.Equal(expectedPayloadType, model.PayloadType);
    }
}

public class DisputeCancelledWebhookEventDataIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeCancelledWebhookEventDataIntersectionMember1
        {
            PayloadType = DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        ApiEnum<
            string,
            DisputeCancelledWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeCancelledWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }
}
