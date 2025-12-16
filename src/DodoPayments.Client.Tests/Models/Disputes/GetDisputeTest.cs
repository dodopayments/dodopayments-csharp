using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class GetDisputeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GetDispute
        {
            Amount = "amount",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            DisputeID = "dispute_id",
            DisputeStage = DisputeDisputeStage.PreDispute,
            DisputeStatus = DisputeDisputeStatus.DisputeOpened,
            PaymentID = "payment_id",
            Reason = "reason",
            Remarks = "remarks",
        };

        string expectedAmount = "amount";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        string expectedDisputeID = "dispute_id";
        ApiEnum<string, DisputeDisputeStage> expectedDisputeStage = DisputeDisputeStage.PreDispute;
        ApiEnum<string, DisputeDisputeStatus> expectedDisputeStatus =
            DisputeDisputeStatus.DisputeOpened;
        string expectedPaymentID = "payment_id";
        string expectedReason = "reason";
        string expectedRemarks = "remarks";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDisputeID, model.DisputeID);
        Assert.Equal(expectedDisputeStage, model.DisputeStage);
        Assert.Equal(expectedDisputeStatus, model.DisputeStatus);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRemarks, model.Remarks);
    }
}
