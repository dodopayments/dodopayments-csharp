using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

public class RefundCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RefundCreateParams
        {
            PaymentID = "payment_id",
            Items =
            [
                new()
                {
                    ItemID = "item_id",
                    Amount = 0,
                    TaxInclusive = true,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Reason = "reason",
        };

        string expectedPaymentID = "payment_id";
        List<Item> expectedItems =
        [
            new()
            {
                ItemID = "item_id",
                Amount = 0,
                TaxInclusive = true,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedReason = "reason";

        Assert.Equal(expectedPaymentID, parameters.PaymentID);
        Assert.NotNull(parameters.Items);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RefundCreateParams
        {
            PaymentID = "payment_id",
            Items =
            [
                new()
                {
                    ItemID = "item_id",
                    Amount = 0,
                    TaxInclusive = true,
                },
            ],
            Reason = "reason",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RefundCreateParams
        {
            PaymentID = "payment_id",
            Items =
            [
                new()
                {
                    ItemID = "item_id",
                    Amount = 0,
                    TaxInclusive = true,
                },
            ],
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RefundCreateParams
        {
            PaymentID = "payment_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Items);
        Assert.False(parameters.RawBodyData.ContainsKey("items"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RefundCreateParams
        {
            PaymentID = "payment_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Items = null,
            Reason = null,
        };

        Assert.Null(parameters.Items);
        Assert.True(parameters.RawBodyData.ContainsKey("items"));
        Assert.Null(parameters.Reason);
        Assert.True(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        RefundCreateParams parameters = new() { PaymentID = "payment_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/refunds"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RefundCreateParams
        {
            PaymentID = "payment_id",
            Items =
            [
                new()
                {
                    ItemID = "item_id",
                    Amount = 0,
                    TaxInclusive = true,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Reason = "reason",
        };

        RefundCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            Amount = 0,
            TaxInclusive = true,
        };

        string expectedItemID = "item_id";
        int expectedAmount = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            Amount = 0,
            TaxInclusive = true,
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
            ItemID = "item_id",
            Amount = 0,
            TaxInclusive = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedItemID = "item_id";
        int expectedAmount = 0;
        bool expectedTaxInclusive = true;

        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            Amount = 0,
            TaxInclusive = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item { ItemID = "item_id", Amount = 0 };

        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item { ItemID = "item_id", Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            Amount = 0,

            // Null should be interpreted as omitted for these properties
            TaxInclusive = null,
        };

        Assert.Null(model.TaxInclusive);
        Assert.False(model.RawData.ContainsKey("tax_inclusive"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            Amount = 0,

            // Null should be interpreted as omitted for these properties
            TaxInclusive = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item { ItemID = "item_id", TaxInclusive = true };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item { ItemID = "item_id", TaxInclusive = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            TaxInclusive = true,

            Amount = null,
        };

        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ItemID = "item_id",
            TaxInclusive = true,

            Amount = null,
        };

        model.Validate();
    }
}
