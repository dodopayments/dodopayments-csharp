using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class ProductCollectionGroupDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        List<GroupProduct> expectedProducts = [new() { ProductID = "product_id", Status = true }];
        string expectedGroupName = "group_name";
        bool expectedStatus = true;

        Assert.Equal(expectedProducts.Count, model.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], model.Products[i]);
        }
        Assert.Equal(expectedGroupName, model.GroupName);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionGroupDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionGroupDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GroupProduct> expectedProducts = [new() { ProductID = "product_id", Status = true }];
        string expectedGroupName = "group_name";
        bool expectedStatus = true;

        Assert.Equal(expectedProducts.Count, deserialized.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], deserialized.Products[i]);
        }
        Assert.Equal(expectedGroupName, deserialized.GroupName);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("group_name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],

            GroupName = null,
            Status = null,
        };

        Assert.Null(model.GroupName);
        Assert.True(model.RawData.ContainsKey("group_name"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],

            GroupName = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCollectionGroupDetails
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        ProductCollectionGroupDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
