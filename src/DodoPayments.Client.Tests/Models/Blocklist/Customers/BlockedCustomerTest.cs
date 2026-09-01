using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class BlockedCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlockedCustomer
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
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerEmail = "customer_email";
        string expectedCustomerID = "customer_id";
        string expectedCustomerName = "customer_name";
        string expectedIdentifier = "identifier";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;
        string expectedBlockedByEmail = "blocked_by_email";
        List<string> expectedCancelledSubscriptionIds = ["string"];
        List<BlockedCustomerNote> expectedNotes =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Note = "note",
                AuthorEmail = "author_email",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedReason = "reason";
        List<string> expectedRemainingSubscriptionIds = ["string"];
        bool expectedSubscriptionsSwept = true;
        DateTimeOffset expectedUnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerEmail, model.CustomerEmail);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedCustomerName, model.CustomerName);
        Assert.Equal(expectedIdentifier, model.Identifier);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedBlockedByEmail, model.BlockedByEmail);
        Assert.NotNull(model.CancelledSubscriptionIds);
        Assert.Equal(expectedCancelledSubscriptionIds.Count, model.CancelledSubscriptionIds.Count);
        for (int i = 0; i < expectedCancelledSubscriptionIds.Count; i++)
        {
            Assert.Equal(expectedCancelledSubscriptionIds[i], model.CancelledSubscriptionIds[i]);
        }
        Assert.NotNull(model.Notes);
        Assert.Equal(expectedNotes.Count, model.Notes.Count);
        for (int i = 0; i < expectedNotes.Count; i++)
        {
            Assert.Equal(expectedNotes[i], model.Notes[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
        Assert.NotNull(model.RemainingSubscriptionIds);
        Assert.Equal(expectedRemainingSubscriptionIds.Count, model.RemainingSubscriptionIds.Count);
        for (int i = 0; i < expectedRemainingSubscriptionIds.Count; i++)
        {
            Assert.Equal(expectedRemainingSubscriptionIds[i], model.RemainingSubscriptionIds[i]);
        }
        Assert.Equal(expectedSubscriptionsSwept, model.SubscriptionsSwept);
        Assert.Equal(expectedUnblockedAt, model.UnblockedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlockedCustomer
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockedCustomer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlockedCustomer
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockedCustomer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerEmail = "customer_email";
        string expectedCustomerID = "customer_id";
        string expectedCustomerName = "customer_name";
        string expectedIdentifier = "identifier";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;
        string expectedBlockedByEmail = "blocked_by_email";
        List<string> expectedCancelledSubscriptionIds = ["string"];
        List<BlockedCustomerNote> expectedNotes =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Note = "note",
                AuthorEmail = "author_email",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedReason = "reason";
        List<string> expectedRemainingSubscriptionIds = ["string"];
        bool expectedSubscriptionsSwept = true;
        DateTimeOffset expectedUnblockedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerEmail, deserialized.CustomerEmail);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedCustomerName, deserialized.CustomerName);
        Assert.Equal(expectedIdentifier, deserialized.Identifier);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedBlockedByEmail, deserialized.BlockedByEmail);
        Assert.NotNull(deserialized.CancelledSubscriptionIds);
        Assert.Equal(
            expectedCancelledSubscriptionIds.Count,
            deserialized.CancelledSubscriptionIds.Count
        );
        for (int i = 0; i < expectedCancelledSubscriptionIds.Count; i++)
        {
            Assert.Equal(
                expectedCancelledSubscriptionIds[i],
                deserialized.CancelledSubscriptionIds[i]
            );
        }
        Assert.NotNull(deserialized.Notes);
        Assert.Equal(expectedNotes.Count, deserialized.Notes.Count);
        for (int i = 0; i < expectedNotes.Count; i++)
        {
            Assert.Equal(expectedNotes[i], deserialized.Notes[i]);
        }
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.NotNull(deserialized.RemainingSubscriptionIds);
        Assert.Equal(
            expectedRemainingSubscriptionIds.Count,
            deserialized.RemainingSubscriptionIds.Count
        );
        for (int i = 0; i < expectedRemainingSubscriptionIds.Count; i++)
        {
            Assert.Equal(
                expectedRemainingSubscriptionIds[i],
                deserialized.RemainingSubscriptionIds[i]
            );
        }
        Assert.Equal(expectedSubscriptionsSwept, deserialized.SubscriptionsSwept);
        Assert.Equal(expectedUnblockedAt, deserialized.UnblockedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlockedCustomer
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlockedCustomer
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerID = "customer_id",
            CustomerName = "customer_name",
            Identifier = "identifier",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        Assert.Null(model.BlockedByEmail);
        Assert.False(model.RawData.ContainsKey("blocked_by_email"));
        Assert.Null(model.CancelledSubscriptionIds);
        Assert.False(model.RawData.ContainsKey("cancelled_subscription_ids"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RemainingSubscriptionIds);
        Assert.False(model.RawData.ContainsKey("remaining_subscription_ids"));
        Assert.Null(model.SubscriptionsSwept);
        Assert.False(model.RawData.ContainsKey("subscriptions_swept"));
        Assert.Null(model.UnblockedAt);
        Assert.False(model.RawData.ContainsKey("unblocked_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlockedCustomer
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerID = "customer_id",
            CustomerName = "customer_name",
            Identifier = "identifier",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BlockedCustomer
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerID = "customer_id",
            CustomerName = "customer_name",
            Identifier = "identifier",
            Source = BlockedCustomerSource.BlocklistPage,

            BlockedByEmail = null,
            CancelledSubscriptionIds = null,
            Notes = null,
            Reason = null,
            RemainingSubscriptionIds = null,
            SubscriptionsSwept = null,
            UnblockedAt = null,
        };

        Assert.Null(model.BlockedByEmail);
        Assert.True(model.RawData.ContainsKey("blocked_by_email"));
        Assert.Null(model.CancelledSubscriptionIds);
        Assert.True(model.RawData.ContainsKey("cancelled_subscription_ids"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RemainingSubscriptionIds);
        Assert.True(model.RawData.ContainsKey("remaining_subscription_ids"));
        Assert.Null(model.SubscriptionsSwept);
        Assert.True(model.RawData.ContainsKey("subscriptions_swept"));
        Assert.Null(model.UnblockedAt);
        Assert.True(model.RawData.ContainsKey("unblocked_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlockedCustomer
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerEmail = "customer_email",
            CustomerID = "customer_id",
            CustomerName = "customer_name",
            Identifier = "identifier",
            Source = BlockedCustomerSource.BlocklistPage,

            BlockedByEmail = null,
            CancelledSubscriptionIds = null,
            Notes = null,
            Reason = null,
            RemainingSubscriptionIds = null,
            SubscriptionsSwept = null,
            UnblockedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlockedCustomer
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
        };

        BlockedCustomer copied = new(model);

        Assert.Equal(model, copied);
    }
}
