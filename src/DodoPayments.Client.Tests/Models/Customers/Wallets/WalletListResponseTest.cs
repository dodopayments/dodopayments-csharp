using System;
using System.Collections.Generic;
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
}
