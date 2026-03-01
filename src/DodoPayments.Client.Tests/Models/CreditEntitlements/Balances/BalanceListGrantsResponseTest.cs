using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceListGrantsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        string expectedInitialAmount = "initial_amount";
        bool expectedIsExpired = true;
        bool expectedIsRolledOver = true;
        string expectedRemainingAmount = "remaining_amount";
        int expectedRolloverCount = 0;
        ApiEnum<string, SourceType> expectedSourceType = SourceType.Subscription;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentGrantID = "parent_grant_id";
        string expectedSourceID = "source_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedInitialAmount, model.InitialAmount);
        Assert.Equal(expectedIsExpired, model.IsExpired);
        Assert.Equal(expectedIsRolledOver, model.IsRolledOver);
        Assert.Equal(expectedRemainingAmount, model.RemainingAmount);
        Assert.Equal(expectedRolloverCount, model.RolloverCount);
        Assert.Equal(expectedSourceType, model.SourceType);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentGrantID, model.ParentGrantID);
        Assert.Equal(expectedSourceID, model.SourceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceListGrantsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceListGrantsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        string expectedInitialAmount = "initial_amount";
        bool expectedIsExpired = true;
        bool expectedIsRolledOver = true;
        string expectedRemainingAmount = "remaining_amount";
        int expectedRolloverCount = 0;
        ApiEnum<string, SourceType> expectedSourceType = SourceType.Subscription;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentGrantID = "parent_grant_id";
        string expectedSourceID = "source_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedInitialAmount, deserialized.InitialAmount);
        Assert.Equal(expectedIsExpired, deserialized.IsExpired);
        Assert.Equal(expectedIsRolledOver, deserialized.IsRolledOver);
        Assert.Equal(expectedRemainingAmount, deserialized.RemainingAmount);
        Assert.Equal(expectedRolloverCount, deserialized.RolloverCount);
        Assert.Equal(expectedSourceType, deserialized.SourceType);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentGrantID, deserialized.ParentGrantID);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ParentGrantID);
        Assert.False(model.RawData.ContainsKey("parent_grant_id"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BalanceListGrantsResponse
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

            ExpiresAt = null,
            Metadata = null,
            ParentGrantID = null,
            SourceID = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ParentGrantID);
        Assert.True(model.RawData.ContainsKey("parent_grant_id"));
        Assert.Null(model.SourceID);
        Assert.True(model.RawData.ContainsKey("source_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BalanceListGrantsResponse
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

            ExpiresAt = null,
            Metadata = null,
            ParentGrantID = null,
            SourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceListGrantsResponse
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
        };

        BalanceListGrantsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.Subscription)]
    [InlineData(SourceType.OneTime)]
    [InlineData(SourceType.Addon)]
    [InlineData(SourceType.Api)]
    [InlineData(SourceType.Rollover)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.Subscription)]
    [InlineData(SourceType.OneTime)]
    [InlineData(SourceType.Addon)]
    [InlineData(SourceType.Api)]
    [InlineData(SourceType.Rollover)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
