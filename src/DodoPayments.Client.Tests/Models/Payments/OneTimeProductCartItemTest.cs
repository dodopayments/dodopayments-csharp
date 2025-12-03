using System.Text.Json;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class OneTimeProductCartItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedAmount, model.Amount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<OneTimeProductCartItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<OneTimeProductCartItem>(json);
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        int expectedAmount = 0;

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedAmount, deserialized.Amount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,
            Amount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OneTimeProductCartItem { ProductID = "product_id", Quantity = 0 };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OneTimeProductCartItem { ProductID = "product_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,

            Amount = null,
        };

        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OneTimeProductCartItem
        {
            ProductID = "product_id",
            Quantity = 0,

            Amount = null,
        };

        model.Validate();
    }
}
