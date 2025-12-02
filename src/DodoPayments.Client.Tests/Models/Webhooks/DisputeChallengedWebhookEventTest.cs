using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class DisputeChallengedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeChallengedWebhookEvent
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
                    DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = DisputeChallengedWebhookEventType.DisputeChallenged,
        };

        string expectedBusinessID = "business_id";
        DisputeChallengedWebhookEventData expectedData = new()
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
            PayloadType = DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DisputeChallengedWebhookEventType> expectedType =
            DisputeChallengedWebhookEventType.DisputeChallenged;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }
}

public class DisputeChallengedWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeChallengedWebhookEventData
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
            PayloadType = DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
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
            DisputeChallengedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute;

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

public class DisputeChallengedWebhookEventDataIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisputeChallengedWebhookEventDataIntersectionMember1
        {
            PayloadType = DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute,
        };

        ApiEnum<
            string,
            DisputeChallengedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            DisputeChallengedWebhookEventDataIntersectionMember1PayloadType.Dispute;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }
}
