using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class CustomerCreditBalanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBalance = "balance";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        string expectedOverage = "overage";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedOverage, model.Overage);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedLastTransactionAt, model.LastTransactionAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerCreditBalance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerCreditBalance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBalance = "balance";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        string expectedOverage = "overage";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedOverage, deserialized.Overage);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedLastTransactionAt, deserialized.LastTransactionAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.LastTransactionAt);
        Assert.False(model.RawData.ContainsKey("last_transaction_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            LastTransactionAt = null,
        };

        Assert.Null(model.LastTransactionAt);
        Assert.True(model.RawData.ContainsKey("last_transaction_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            LastTransactionAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerCreditBalance
        {
            ID = "id",
            Balance = "balance",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Overage = "overage",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransactionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CustomerCreditBalance copied = new(model);

        Assert.Equal(model, copied);
    }
}
