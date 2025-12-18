using System.Text.Json;
using DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Tests.Models.Refunds;

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(element);
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
