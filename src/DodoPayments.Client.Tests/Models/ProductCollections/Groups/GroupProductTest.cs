using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class GroupProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupProduct { ProductID = "product_id", Status = true };

        string expectedProductID = "product_id";
        bool expectedStatus = true;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroupProduct { ProductID = "product_id", Status = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroupProduct>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupProduct { ProductID = "product_id", Status = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroupProduct>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        bool expectedStatus = true;

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroupProduct { ProductID = "product_id", Status = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GroupProduct { ProductID = "product_id" };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GroupProduct { ProductID = "product_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GroupProduct
        {
            ProductID = "product_id",

            Status = null,
        };

        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GroupProduct
        {
            ProductID = "product_id",

            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroupProduct { ProductID = "product_id", Status = true };

        GroupProduct copied = new(model);

        Assert.Equal(model, copied);
    }
}
