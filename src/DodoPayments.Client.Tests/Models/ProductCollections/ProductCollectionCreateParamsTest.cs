using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
            BrandID = "brand_id",
            Description = "description",
        };

        List<Group> expectedGroups =
        [
            new()
            {
                Products = [new() { ProductID = "product_id", Status = true }],
                GroupName = "group_name",
                Status = true,
            },
        ];
        string expectedName = "name";
        string expectedBrandID = "brand_id";
        string expectedDescription = "description";

        Assert.Equal(expectedGroups.Count, parameters.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], parameters.Groups[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
        };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",

            BrandID = null,
            Description = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCollectionCreateParams parameters = new()
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/product-collections"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCollectionCreateParams
        {
            Groups =
            [
                new()
                {
                    Products = [new() { ProductID = "product_id", Status = true }],
                    GroupName = "group_name",
                    Status = true,
                },
            ],
            Name = "name",
            BrandID = "brand_id",
            Description = "description",
        };

        ProductCollectionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Group
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        List<Product> expectedProducts = [new() { ProductID = "product_id", Status = true }];
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
        var model = new Group
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Group
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Product> expectedProducts = [new() { ProductID = "product_id", Status = true }];
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
        var model = new Group
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
        var model = new Group { Products = [new() { ProductID = "product_id", Status = true }] };

        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("group_name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Group { Products = [new() { ProductID = "product_id", Status = true }] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Group
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
        var model = new Group
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
        var model = new Group
        {
            Products = [new() { ProductID = "product_id", Status = true }],
            GroupName = "group_name",
            Status = true,
        };

        Group copied = new(model);

        Assert.Equal(model, copied);
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
