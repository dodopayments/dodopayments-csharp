using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.Customers.Wallets;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers.Wallets;

public class WalletListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WalletListResponse
        {
            Items =
            [
                new()
                {
                    Balance = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    CustomerID = "customer_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalBalanceUsd = 0,
        };

        List<CustomerWallet> expectedItems =
        [
            new()
            {
                Balance = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                CustomerID = "customer_id",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTotalBalanceUsd = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedTotalBalanceUsd, model.TotalBalanceUsd);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WalletListResponse
        {
            Items =
            [
                new()
                {
                    Balance = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    CustomerID = "customer_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalBalanceUsd = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WalletListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WalletListResponse
        {
            Items =
            [
                new()
                {
                    Balance = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    CustomerID = "customer_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalBalanceUsd = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WalletListResponse>(json);
        Assert.NotNull(deserialized);

        List<CustomerWallet> expectedItems =
        [
            new()
            {
                Balance = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                CustomerID = "customer_id",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTotalBalanceUsd = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedTotalBalanceUsd, deserialized.TotalBalanceUsd);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WalletListResponse
        {
            Items =
            [
                new()
                {
                    Balance = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    CustomerID = "customer_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TotalBalanceUsd = 0,
        };

        model.Validate();
    }
}
