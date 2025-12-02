using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class CheckoutSessionStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutSessionStatus
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerName = "customer_name",
            PaymentID = "payment_id",
            PaymentStatus = IntentStatus.Succeeded,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerEmail = "customer_email";
        string expectedCustomerName = "customer_name";
        string expectedPaymentID = "payment_id";
        ApiEnum<string, IntentStatus> expectedPaymentStatus = IntentStatus.Succeeded;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerEmail, model.CustomerEmail);
        Assert.Equal(expectedCustomerName, model.CustomerName);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedPaymentStatus, model.PaymentStatus);
    }
}
