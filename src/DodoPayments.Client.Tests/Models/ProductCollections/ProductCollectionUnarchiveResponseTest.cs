using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.ProductCollections;

namespace DodoPayments.Client.Tests.Models.ProductCollections;

public class ProductCollectionUnarchiveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollectionUnarchiveResponse
        {
            CollectionID = "collection_id",
            ExcludedProductIds = ["string"],
            Message = "message",
        };

        string expectedCollectionID = "collection_id";
        List<string> expectedExcludedProductIds = ["string"];
        string expectedMessage = "message";

        Assert.Equal(expectedCollectionID, model.CollectionID);
        Assert.Equal(expectedExcludedProductIds.Count, model.ExcludedProductIds.Count);
        for (int i = 0; i < expectedExcludedProductIds.Count; i++)
        {
            Assert.Equal(expectedExcludedProductIds[i], model.ExcludedProductIds[i]);
        }
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCollectionUnarchiveResponse
        {
            CollectionID = "collection_id",
            ExcludedProductIds = ["string"],
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionUnarchiveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollectionUnarchiveResponse
        {
            CollectionID = "collection_id",
            ExcludedProductIds = ["string"],
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionUnarchiveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCollectionID = "collection_id";
        List<string> expectedExcludedProductIds = ["string"];
        string expectedMessage = "message";

        Assert.Equal(expectedCollectionID, deserialized.CollectionID);
        Assert.Equal(expectedExcludedProductIds.Count, deserialized.ExcludedProductIds.Count);
        for (int i = 0; i < expectedExcludedProductIds.Count; i++)
        {
            Assert.Equal(expectedExcludedProductIds[i], deserialized.ExcludedProductIds[i]);
        }
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCollectionUnarchiveResponse
        {
            CollectionID = "collection_id",
            ExcludedProductIds = ["string"],
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCollectionUnarchiveResponse
        {
            CollectionID = "collection_id",
            ExcludedProductIds = ["string"],
            Message = "message",
        };

        ProductCollectionUnarchiveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
