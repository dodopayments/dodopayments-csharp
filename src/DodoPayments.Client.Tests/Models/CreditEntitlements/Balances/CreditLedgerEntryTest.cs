using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class CreditLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditLedgerEntry
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

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        string expectedBalanceBefore = "balance_before";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        bool expectedIsCredit = true;
        string expectedOverageAfter = "overage_after";
        string expectedOverageBefore = "overage_before";
        ApiEnum<string, TransactionType> expectedTransactionType = TransactionType.CreditAdded;
        string expectedDescription = "description";
        string expectedGrantID = "grant_id";
        string expectedReferenceID = "reference_id";
        string expectedReferenceType = "reference_type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBalanceAfter, model.BalanceAfter);
        Assert.Equal(expectedBalanceBefore, model.BalanceBefore);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedIsCredit, model.IsCredit);
        Assert.Equal(expectedOverageAfter, model.OverageAfter);
        Assert.Equal(expectedOverageBefore, model.OverageBefore);
        Assert.Equal(expectedTransactionType, model.TransactionType);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedGrantID, model.GrantID);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
        Assert.Equal(expectedReferenceType, model.ReferenceType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditLedgerEntry
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditLedgerEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditLedgerEntry
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditLedgerEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        string expectedBalanceBefore = "balance_before";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        bool expectedIsCredit = true;
        string expectedOverageAfter = "overage_after";
        string expectedOverageBefore = "overage_before";
        ApiEnum<string, TransactionType> expectedTransactionType = TransactionType.CreditAdded;
        string expectedDescription = "description";
        string expectedGrantID = "grant_id";
        string expectedReferenceID = "reference_id";
        string expectedReferenceType = "reference_type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBalanceAfter, deserialized.BalanceAfter);
        Assert.Equal(expectedBalanceBefore, deserialized.BalanceBefore);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedIsCredit, deserialized.IsCredit);
        Assert.Equal(expectedOverageAfter, deserialized.OverageAfter);
        Assert.Equal(expectedOverageBefore, deserialized.OverageBefore);
        Assert.Equal(expectedTransactionType, deserialized.TransactionType);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedGrantID, deserialized.GrantID);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
        Assert.Equal(expectedReferenceType, deserialized.ReferenceType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditLedgerEntry
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditLedgerEntry
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
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.GrantID);
        Assert.False(model.RawData.ContainsKey("grant_id"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
        Assert.Null(model.ReferenceType);
        Assert.False(model.RawData.ContainsKey("reference_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditLedgerEntry
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditLedgerEntry
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

            Description = null,
            GrantID = null,
            ReferenceID = null,
            ReferenceType = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.GrantID);
        Assert.True(model.RawData.ContainsKey("grant_id"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
        Assert.Null(model.ReferenceType);
        Assert.True(model.RawData.ContainsKey("reference_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditLedgerEntry
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

            Description = null,
            GrantID = null,
            ReferenceID = null,
            ReferenceType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditLedgerEntry
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

        CreditLedgerEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(TransactionType.CreditAdded)]
    [InlineData(TransactionType.CreditDeducted)]
    [InlineData(TransactionType.CreditExpired)]
    [InlineData(TransactionType.CreditRolledOver)]
    [InlineData(TransactionType.RolloverForfeited)]
    [InlineData(TransactionType.OverageCharged)]
    [InlineData(TransactionType.AutoTopUp)]
    [InlineData(TransactionType.ManualAdjustment)]
    [InlineData(TransactionType.Refund)]
    public void Validation_Works(TransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionType.CreditAdded)]
    [InlineData(TransactionType.CreditDeducted)]
    [InlineData(TransactionType.CreditExpired)]
    [InlineData(TransactionType.CreditRolledOver)]
    [InlineData(TransactionType.RolloverForfeited)]
    [InlineData(TransactionType.OverageCharged)]
    [InlineData(TransactionType.AutoTopUp)]
    [InlineData(TransactionType.ManualAdjustment)]
    [InlineData(TransactionType.Refund)]
    public void SerializationRoundtrip_Works(TransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
