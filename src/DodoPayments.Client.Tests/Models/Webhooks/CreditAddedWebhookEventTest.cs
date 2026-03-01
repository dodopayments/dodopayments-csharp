using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.CreditEntitlements.Balances;
using Webhooks = DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class CreditAddedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::CreditAddedWebhookEvent
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
            Type = Webhooks::Type.CreditAdded,
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
        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.CreditAdded;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::CreditAddedWebhookEvent
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
            Type = Webhooks::Type.CreditAdded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::CreditAddedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::CreditAddedWebhookEvent
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
            Type = Webhooks::Type.CreditAdded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::CreditAddedWebhookEvent>(
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
        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.CreditAdded;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhooks::CreditAddedWebhookEvent
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
            Type = Webhooks::Type.CreditAdded,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::CreditAddedWebhookEvent
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
            Type = Webhooks::Type.CreditAdded,
        };

        Webhooks::CreditAddedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::Type.CreditAdded)]
    public void Validation_Works(Webhooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Webhooks::Type.CreditAdded)]
    public void SerializationRoundtrip_Works(Webhooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
