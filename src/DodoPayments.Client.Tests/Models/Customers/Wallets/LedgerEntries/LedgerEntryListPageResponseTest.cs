using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets.LedgerEntries;

public class LedgerEntryListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerEntryListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        List<CustomerWalletTransaction> expectedItems =
        [
            new()
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
        var model = new LedgerEntryListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LedgerEntryListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerEntryListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LedgerEntryListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<CustomerWalletTransaction> expectedItems =
        [
            new()
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
        var model = new LedgerEntryListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }
}
