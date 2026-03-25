using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class GroupCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        string expectedID = "id";
        List<Product> expectedProducts = [new() { ProductID = "product_id", Status = true }];
        string expectedGroupName = "group_name";
        bool expectedStatus = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedProducts.Count, parameters.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], parameters.Products[i]);
        }
        Assert.Equal(expectedGroupName, parameters.GroupName);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        Assert.Null(parameters.GroupName);
        Assert.False(parameters.RawBodyData.ContainsKey("group_name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],

            GroupName = null,
            Status = null,
        };

        Assert.Null(parameters.GroupName);
        Assert.True(parameters.RawBodyData.ContainsKey("group_name"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        GroupCreateParams parameters = new()
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/product-collections/id/groups"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GroupCreateParams
        {
            ID = "id",
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        GroupCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Product { ProductID = "product_id", Status = true };

        string expectedProductID = "product_id";
        bool expectedStatus = true;

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Product { ProductID = "product_id", Status = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Product>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Product { ProductID = "product_id", Status = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Product>(
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
        var model = new Product { ProductID = "product_id", Status = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Product { ProductID = "product_id" };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Product { ProductID = "product_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Product
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
        var model = new Product
        {
            ProductID = "product_id",

            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Product { ProductID = "product_id", Status = true };

        Product copied = new(model);

        Assert.Equal(model, copied);
    }
}
