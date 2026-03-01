using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerListCreditEntitlementsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListCreditEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    Balance = "balance",
                    CreditEntitlementID = "credit_entitlement_id",
                    Name = "name",
                    Overage = "overage",
                    Unit = "unit",
                    Description = "description",
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                Balance = "balance",
                CreditEntitlementID = "credit_entitlement_id",
                Name = "name",
                Overage = "overage",
                Unit = "unit",
                Description = "description",
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
        var model = new CustomerListCreditEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    Balance = "balance",
                    CreditEntitlementID = "credit_entitlement_id",
                    Name = "name",
                    Overage = "overage",
                    Unit = "unit",
                    Description = "description",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListCreditEntitlementsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListCreditEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    Balance = "balance",
                    CreditEntitlementID = "credit_entitlement_id",
                    Name = "name",
                    Overage = "overage",
                    Unit = "unit",
                    Description = "description",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListCreditEntitlementsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                Balance = "balance",
                CreditEntitlementID = "credit_entitlement_id",
                Name = "name",
                Overage = "overage",
                Unit = "unit",
                Description = "description",
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
        var model = new CustomerListCreditEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    Balance = "balance",
                    CreditEntitlementID = "credit_entitlement_id",
                    Name = "name",
                    Overage = "overage",
                    Unit = "unit",
                    Description = "description",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListCreditEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    Balance = "balance",
                    CreditEntitlementID = "credit_entitlement_id",
                    Name = "name",
                    Overage = "overage",
                    Unit = "unit",
                    Description = "description",
                },
            ],
        };

        CustomerListCreditEntitlementsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
            Description = "description",
        };

        string expectedBalance = "balance";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedName = "name";
        string expectedOverage = "overage";
        string expectedUnit = "unit";
        string expectedDescription = "description";

        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOverage, model.Overage);
        Assert.Equal(expectedUnit, model.Unit);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBalance = "balance";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedName = "name";
        string expectedOverage = "overage";
        string expectedUnit = "unit";
        string expectedDescription = "description";

        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOverage, deserialized.Overage);
        Assert.Equal(expectedUnit, deserialized.Unit);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            Balance = "balance",
            CreditEntitlementID = "credit_entitlement_id",
            Name = "name",
            Overage = "overage",
            Unit = "unit",
            Description = "description",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
