using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class CustomerListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerEmail = "customer_email",
                    CustomerID = "customer_id",
                    CustomerName = "customer_name",
                    Identifier = "identifier",
                    Source = BlockedCustomerSource.BlocklistPage,
                    BlockedByEmail = "blocked_by_email",
                    CancelledSubscriptionIds = ["string"],
                    Notes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Note = "note",
                            AuthorEmail = "author_email",
                            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Reason = "reason",
                    RemainingSubscriptionIds = ["string"],
                    SubscriptionsSwept = true,
                    UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Total = 0,
        };

        List<BlockedCustomer> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerEmail = "customer_email",
                CustomerID = "customer_id",
                CustomerName = "customer_name",
                Identifier = "identifier",
                Source = BlockedCustomerSource.BlocklistPage,
                BlockedByEmail = "blocked_by_email",
                CancelledSubscriptionIds = ["string"],
                Notes =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Note = "note",
                        AuthorEmail = "author_email",
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Reason = "reason",
                RemainingSubscriptionIds = ["string"],
                SubscriptionsSwept = true,
                UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTotal = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerEmail = "customer_email",
                    CustomerID = "customer_id",
                    CustomerName = "customer_name",
                    Identifier = "identifier",
                    Source = BlockedCustomerSource.BlocklistPage,
                    BlockedByEmail = "blocked_by_email",
                    CancelledSubscriptionIds = ["string"],
                    Notes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Note = "note",
                            AuthorEmail = "author_email",
                            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Reason = "reason",
                    RemainingSubscriptionIds = ["string"],
                    SubscriptionsSwept = true,
                    UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerEmail = "customer_email",
                    CustomerID = "customer_id",
                    CustomerName = "customer_name",
                    Identifier = "identifier",
                    Source = BlockedCustomerSource.BlocklistPage,
                    BlockedByEmail = "blocked_by_email",
                    CancelledSubscriptionIds = ["string"],
                    Notes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Note = "note",
                            AuthorEmail = "author_email",
                            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Reason = "reason",
                    RemainingSubscriptionIds = ["string"],
                    SubscriptionsSwept = true,
                    UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BlockedCustomer> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerEmail = "customer_email",
                CustomerID = "customer_id",
                CustomerName = "customer_name",
                Identifier = "identifier",
                Source = BlockedCustomerSource.BlocklistPage,
                BlockedByEmail = "blocked_by_email",
                CancelledSubscriptionIds = ["string"],
                Notes =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Note = "note",
                        AuthorEmail = "author_email",
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Reason = "reason",
                RemainingSubscriptionIds = ["string"],
                SubscriptionsSwept = true,
                UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTotal = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerEmail = "customer_email",
                    CustomerID = "customer_id",
                    CustomerName = "customer_name",
                    Identifier = "identifier",
                    Source = BlockedCustomerSource.BlocklistPage,
                    BlockedByEmail = "blocked_by_email",
                    CancelledSubscriptionIds = ["string"],
                    Notes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Note = "note",
                            AuthorEmail = "author_email",
                            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Reason = "reason",
                    RemainingSubscriptionIds = ["string"],
                    SubscriptionsSwept = true,
                    UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerEmail = "customer_email",
                    CustomerID = "customer_id",
                    CustomerName = "customer_name",
                    Identifier = "identifier",
                    Source = BlockedCustomerSource.BlocklistPage,
                    BlockedByEmail = "blocked_by_email",
                    CancelledSubscriptionIds = ["string"],
                    Notes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Note = "note",
                            AuthorEmail = "author_email",
                            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Reason = "reason",
                    RemainingSubscriptionIds = ["string"],
                    SubscriptionsSwept = true,
                    UnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Total = 0,
        };

        CustomerListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
