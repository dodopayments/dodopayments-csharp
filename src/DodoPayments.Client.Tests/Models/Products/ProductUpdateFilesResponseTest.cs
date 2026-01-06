using System.Text.Json;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class ProductUpdateFilesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUpdateFilesResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUrl = "url";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductUpdateFilesResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateFilesResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUpdateFilesResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateFilesResponse>(element);
        Assert.NotNull(deserialized);

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedUrl = "url";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductUpdateFilesResponse
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Url = "url",
        };

        model.Validate();
    }
}
