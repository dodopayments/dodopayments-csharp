using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Products;

public class AddMeterToPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        string expectedMeterID = "meter_id";
        string expectedPricePerUnit = "10.50";
        string expectedDescription = "description";
        long expectedFreeThreshold = 0;
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";

        Assert.Equal(expectedMeterID, model.MeterID);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFreeThreshold, model.FreeThreshold);
        Assert.Equal(expectedMeasurementUnit, model.MeasurementUnit);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddMeterToPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddMeterToPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMeterID = "meter_id";
        string expectedPricePerUnit = "10.50";
        string expectedDescription = "description";
        long expectedFreeThreshold = 0;
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";

        Assert.Equal(expectedMeterID, deserialized.MeterID);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFreeThreshold, deserialized.FreeThreshold);
        Assert.Equal(expectedMeasurementUnit, deserialized.MeasurementUnit);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddMeterToPrice { MeterID = "meter_id", PricePerUnit = "10.50" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FreeThreshold);
        Assert.False(model.RawData.ContainsKey("free_threshold"));
        Assert.Null(model.MeasurementUnit);
        Assert.False(model.RawData.ContainsKey("measurement_unit"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AddMeterToPrice { MeterID = "meter_id", PricePerUnit = "10.50" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",

            Description = null,
            FreeThreshold = null,
            MeasurementUnit = null,
            Name = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.FreeThreshold);
        Assert.True(model.RawData.ContainsKey("free_threshold"));
        Assert.Null(model.MeasurementUnit);
        Assert.True(model.RawData.ContainsKey("measurement_unit"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",

            Description = null,
            FreeThreshold = null,
            MeasurementUnit = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddMeterToPrice
        {
            MeterID = "meter_id",
            PricePerUnit = "10.50",
            Description = "description",
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        AddMeterToPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}
