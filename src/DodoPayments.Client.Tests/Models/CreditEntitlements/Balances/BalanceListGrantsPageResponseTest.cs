using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceListGrantsPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceListGrantsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreditEntitlementID = "credit_entitlement_id",
                    CustomerID = "customer_id",
                    InitialAmount = "initial_amount",
                    IsExpired = true,
                    IsRolledOver = true,
                    RemainingAmount = "remaining_amount",
                    RolloverCount = 0,
                    SourceType = SourceType.Subscription,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ParentGrantID = "parent_grant_id",
                    SourceID = "source_id",
                },
            ],
        };

        List<BalanceListGrantsResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                InitialAmount = "initial_amount",
                IsExpired = true,
                IsRolledOver = true,
                RemainingAmount = "remaining_amount",
                RolloverCount = 0,
                SourceType = SourceType.Subscription,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentGrantID = "parent_grant_id",
                SourceID = "source_id",
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
        var model = new BalanceListGrantsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreditEntitlementID = "credit_entitlement_id",
                    CustomerID = "customer_id",
                    InitialAmount = "initial_amount",
                    IsExpired = true,
                    IsRolledOver = true,
                    RemainingAmount = "remaining_amount",
                    RolloverCount = 0,
                    SourceType = SourceType.Subscription,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ParentGrantID = "parent_grant_id",
                    SourceID = "source_id",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceListGrantsPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceListGrantsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreditEntitlementID = "credit_entitlement_id",
                    CustomerID = "customer_id",
                    InitialAmount = "initial_amount",
                    IsExpired = true,
                    IsRolledOver = true,
                    RemainingAmount = "remaining_amount",
                    RolloverCount = 0,
                    SourceType = SourceType.Subscription,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ParentGrantID = "parent_grant_id",
                    SourceID = "source_id",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceListGrantsPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BalanceListGrantsResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                InitialAmount = "initial_amount",
                IsExpired = true,
                IsRolledOver = true,
                RemainingAmount = "remaining_amount",
                RolloverCount = 0,
                SourceType = SourceType.Subscription,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentGrantID = "parent_grant_id",
                SourceID = "source_id",
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
        var model = new BalanceListGrantsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreditEntitlementID = "credit_entitlement_id",
                    CustomerID = "customer_id",
                    InitialAmount = "initial_amount",
                    IsExpired = true,
                    IsRolledOver = true,
                    RemainingAmount = "remaining_amount",
                    RolloverCount = 0,
                    SourceType = SourceType.Subscription,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ParentGrantID = "parent_grant_id",
                    SourceID = "source_id",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceListGrantsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreditEntitlementID = "credit_entitlement_id",
                    CustomerID = "customer_id",
                    InitialAmount = "initial_amount",
                    IsExpired = true,
                    IsRolledOver = true,
                    RemainingAmount = "remaining_amount",
                    RolloverCount = 0,
                    SourceType = SourceType.Subscription,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ParentGrantID = "parent_grant_id",
                    SourceID = "source_id",
                },
            ],
        };

        BalanceListGrantsPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
