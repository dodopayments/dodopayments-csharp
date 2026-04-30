using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class ScheduledPlanChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };

        string expectedID = "id";
        List<Addon> expectedAddons =
        [
            new()
            {
                AddonID = "addon_id",
                Name = "name",
                Quantity = 0,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        string expectedProductDescription = "product_description";
        string expectedProductName = "product_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEffectiveAt, model.EffectiveAt);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedProductDescription, model.ProductDescription);
        Assert.Equal(expectedProductName, model.ProductName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScheduledPlanChange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScheduledPlanChange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Addon> expectedAddons =
        [
            new()
            {
                AddonID = "addon_id",
                Name = "name",
                Quantity = 0,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        string expectedProductDescription = "product_description";
        string expectedProductName = "product_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEffectiveAt, deserialized.EffectiveAt);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedProductDescription, deserialized.ProductDescription);
        Assert.Equal(expectedProductName, deserialized.ProductName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
        };

        Assert.Null(model.ProductDescription);
        Assert.False(model.RawData.ContainsKey("product_description"));
        Assert.Null(model.ProductName);
        Assert.False(model.RawData.ContainsKey("product_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,

            ProductDescription = null,
            ProductName = null,
        };

        Assert.Null(model.ProductDescription);
        Assert.True(model.RawData.ContainsKey("product_description"));
        Assert.Null(model.ProductName);
        Assert.True(model.RawData.ContainsKey("product_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,

            ProductDescription = null,
            ProductName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ScheduledPlanChange
        {
            ID = "id",
            Addons =
            [
                new()
                {
                    AddonID = "addon_id",
                    Name = "name",
                    Quantity = 0,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            Quantity = 0,
            ProductDescription = "product_description",
            ProductName = "product_name",
        };

        ScheduledPlanChange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Name = "name",
            Quantity = 0,
        };

        string expectedAddonID = "addon_id";
        string expectedName = "name";
        int expectedQuantity = 0;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Name = "name",
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addon>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Name = "name",
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addon>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAddonID = "addon_id";
        string expectedName = "name";
        int expectedQuantity = 0;

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Name = "name",
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Addon
        {
            AddonID = "addon_id",
            Name = "name",
            Quantity = 0,
        };

        Addon copied = new(model);

        Assert.Equal(model, copied);
    }
}
