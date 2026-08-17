using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandArchiveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
            MovedToBrandID = "moved_to_brand_id",
        };

        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "brand_id";
        long expectedCollectionsMoved = 0;
        long expectedProductsMoved = 0;
        long expectedSubscriptionsMoved = 0;
        string expectedMovedToBrandID = "moved_to_brand_id";

        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCollectionsMoved, model.CollectionsMoved);
        Assert.Equal(expectedProductsMoved, model.ProductsMoved);
        Assert.Equal(expectedSubscriptionsMoved, model.SubscriptionsMoved);
        Assert.Equal(expectedMovedToBrandID, model.MovedToBrandID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
            MovedToBrandID = "moved_to_brand_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandArchiveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
            MovedToBrandID = "moved_to_brand_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandArchiveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBrandID = "brand_id";
        long expectedCollectionsMoved = 0;
        long expectedProductsMoved = 0;
        long expectedSubscriptionsMoved = 0;
        string expectedMovedToBrandID = "moved_to_brand_id";

        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCollectionsMoved, deserialized.CollectionsMoved);
        Assert.Equal(expectedProductsMoved, deserialized.ProductsMoved);
        Assert.Equal(expectedSubscriptionsMoved, deserialized.SubscriptionsMoved);
        Assert.Equal(expectedMovedToBrandID, deserialized.MovedToBrandID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
            MovedToBrandID = "moved_to_brand_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
        };

        Assert.Null(model.MovedToBrandID);
        Assert.False(model.RawData.ContainsKey("moved_to_brand_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,

            MovedToBrandID = null,
        };

        Assert.Null(model.MovedToBrandID);
        Assert.True(model.RawData.ContainsKey("moved_to_brand_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,

            MovedToBrandID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandArchiveResponse
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BrandID = "brand_id",
            CollectionsMoved = 0,
            ProductsMoved = 0,
            SubscriptionsMoved = 0,
            MovedToBrandID = "moved_to_brand_id",
        };

        BrandArchiveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
