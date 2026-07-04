using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature { FeatureID = "feature_id", FeatureType = FeatureType.Boolean };

        string expectedFeatureID = "feature_id";
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;

        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedFeatureType, model.FeatureType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feature { FeatureID = "feature_id", FeatureType = FeatureType.Boolean };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature { FeatureID = "feature_id", FeatureType = FeatureType.Boolean };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "feature_id";
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;

        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedFeatureType, deserialized.FeatureType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feature { FeatureID = "feature_id", FeatureType = FeatureType.Boolean };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feature { FeatureID = "feature_id", FeatureType = FeatureType.Boolean };

        Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}
