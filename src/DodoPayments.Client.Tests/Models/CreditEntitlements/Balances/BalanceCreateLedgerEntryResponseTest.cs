using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceCreateLedgerEntryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            GrantID = "grant_id",
            Reason = "reason",
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        string expectedBalanceBefore = "balance_before";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        ApiEnum<string, LedgerEntryType> expectedEntryType = LedgerEntryType.Credit;
        bool expectedIsCredit = true;
        string expectedOverageAfter = "overage_after";
        string expectedOverageBefore = "overage_before";
        string expectedGrantID = "grant_id";
        string expectedReason = "reason";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBalanceAfter, model.BalanceAfter);
        Assert.Equal(expectedBalanceBefore, model.BalanceBefore);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEntryType, model.EntryType);
        Assert.Equal(expectedIsCredit, model.IsCredit);
        Assert.Equal(expectedOverageAfter, model.OverageAfter);
        Assert.Equal(expectedOverageBefore, model.OverageBefore);
        Assert.Equal(expectedGrantID, model.GrantID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            GrantID = "grant_id",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceCreateLedgerEntryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            GrantID = "grant_id",
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceCreateLedgerEntryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        string expectedBalanceBefore = "balance_before";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        ApiEnum<string, LedgerEntryType> expectedEntryType = LedgerEntryType.Credit;
        bool expectedIsCredit = true;
        string expectedOverageAfter = "overage_after";
        string expectedOverageBefore = "overage_before";
        string expectedGrantID = "grant_id";
        string expectedReason = "reason";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBalanceAfter, deserialized.BalanceAfter);
        Assert.Equal(expectedBalanceBefore, deserialized.BalanceBefore);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEntryType, deserialized.EntryType);
        Assert.Equal(expectedIsCredit, deserialized.IsCredit);
        Assert.Equal(expectedOverageAfter, deserialized.OverageAfter);
        Assert.Equal(expectedOverageBefore, deserialized.OverageBefore);
        Assert.Equal(expectedGrantID, deserialized.GrantID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            GrantID = "grant_id",
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
        };

        Assert.Null(model.GrantID);
        Assert.False(model.RawData.ContainsKey("grant_id"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",

            GrantID = null,
            Reason = null,
        };

        Assert.Null(model.GrantID);
        Assert.True(model.RawData.ContainsKey("grant_id"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",

            GrantID = null,
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceCreateLedgerEntryResponse
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            EntryType = LedgerEntryType.Credit,
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            GrantID = "grant_id",
            Reason = "reason",
        };

        BalanceCreateLedgerEntryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
