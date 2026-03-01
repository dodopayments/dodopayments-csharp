using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceListLedgerPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceListLedgerPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        List<CreditLedgerEntry> expectedItems =
        [
            new()
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
        var model = new BalanceListLedgerPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceListLedgerPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceListLedgerPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceListLedgerPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CreditLedgerEntry> expectedItems =
        [
            new()
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
        var model = new BalanceListLedgerPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceListLedgerPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        BalanceListLedgerPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
