using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class CreditRolledOverWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditRolledOverWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        CreditLedgerEntry expectedData = new()
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            TransactionType = TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("credit.rolled_over");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditRolledOverWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRolledOverWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditRolledOverWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRolledOverWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        CreditLedgerEntry expectedData = new()
        {
            ID = "id",
            Amount = "amount",
            BalanceAfter = "balance_after",
            BalanceBefore = "balance_before",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            IsCredit = true,
            OverageAfter = "overage_after",
            OverageBefore = "overage_before",
            TransactionType = TransactionType.CreditAdded,
            Description = "description",
            GrantID = "grant_id",
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("credit.rolled_over");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditRolledOverWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditRolledOverWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreditRolledOverWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
