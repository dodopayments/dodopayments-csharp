using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets.LedgerEntries;

public class CustomerWalletTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerWalletTransaction
        {
            ID = "id",
            AfterBalance = 0,
            Amount = 0,
            BeforeBalance = 0,
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            CustomerID = "customer_id",
            EventType = EventType.Payment,
            IsCredit = true,
            Reason = "reason",
            ReferenceObjectID = "reference_object_id",
        };

        string expectedID = "id";
        long expectedAfterBalance = 0;
        long expectedAmount = 0;
        long expectedBeforeBalance = 0;
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedCustomerID = "customer_id";
        ApiEnum<string, EventType> expectedEventType = EventType.Payment;
        bool expectedIsCredit = true;
        string expectedReason = "reason";
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAfterBalance, model.AfterBalance);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBeforeBalance, model.BeforeBalance);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedIsCredit, model.IsCredit);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReferenceObjectID, model.ReferenceObjectID);
    }
}
