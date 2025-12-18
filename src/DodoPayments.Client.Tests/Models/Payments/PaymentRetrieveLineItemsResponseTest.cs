using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentRetrieveLineItemsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentRetrieveLineItemsResponse
        {
            Currency = Currency.Aed,
            Items =
            [
                new()
                {
                    Amount = 0,
                    ItemsID = "items_id",
                    RefundableAmount = 0,
                    Tax = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        List<PaymentRetrieveLineItemsResponseItem> expectedItems =
        [
            new()
            {
                Amount = 0,
                ItemsID = "items_id",
                RefundableAmount = 0,
                Tax = 0,
                Description = "description",
                Name = "name",
            },
        ];

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentRetrieveLineItemsResponse
        {
            Currency = Currency.Aed,
            Items =
            [
                new()
                {
                    Amount = 0,
                    ItemsID = "items_id",
                    RefundableAmount = 0,
                    Tax = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentRetrieveLineItemsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentRetrieveLineItemsResponse
        {
            Currency = Currency.Aed,
            Items =
            [
                new()
                {
                    Amount = 0,
                    ItemsID = "items_id",
                    RefundableAmount = 0,
                    Tax = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentRetrieveLineItemsResponse>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        List<PaymentRetrieveLineItemsResponseItem> expectedItems =
        [
            new()
            {
                Amount = 0,
                ItemsID = "items_id",
                RefundableAmount = 0,
                Tax = 0,
                Description = "description",
                Name = "name",
            },
        ];

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentRetrieveLineItemsResponse
        {
            Currency = Currency.Aed,
            Items =
            [
                new()
                {
                    Amount = 0,
                    ItemsID = "items_id",
                    RefundableAmount = 0,
                    Tax = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }
}

public class PaymentRetrieveLineItemsResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
            Description = "description",
            Name = "name",
        };

        int expectedAmount = 0;
        string expectedItemsID = "items_id";
        int expectedRefundableAmount = 0;
        int expectedTax = 0;
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedItemsID, model.ItemsID);
        Assert.Equal(expectedRefundableAmount, model.RefundableAmount);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
            Description = "description",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentRetrieveLineItemsResponseItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
            Description = "description",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PaymentRetrieveLineItemsResponseItem>(
            element
        );
        Assert.NotNull(deserialized);

        int expectedAmount = 0;
        string expectedItemsID = "items_id";
        int expectedRefundableAmount = 0;
        int expectedTax = 0;
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedItemsID, deserialized.ItemsID);
        Assert.Equal(expectedRefundableAmount, deserialized.RefundableAmount);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
            Description = "description",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,

            Description = null,
            Name = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentRetrieveLineItemsResponseItem
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,

            Description = null,
            Name = null,
        };

        model.Validate();
    }
}
