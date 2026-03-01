using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class MeterCartResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            Description = "description",
            PricePerUnit = "10.50",
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedMeasurementUnit = "measurement_unit";
        string expectedMeterID = "meter_id";
        string expectedName = "name";
        string expectedDescription = "description";
        string expectedPricePerUnit = "10.50";

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFreeThreshold, model.FreeThreshold);
        Assert.Equal(expectedMeasurementUnit, model.MeasurementUnit);
        Assert.Equal(expectedMeterID, model.MeterID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedPricePerUnit, model.PricePerUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            Description = "description",
            PricePerUnit = "10.50",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterCartResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            Description = "description",
            PricePerUnit = "10.50",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterCartResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        long expectedFreeThreshold = 0;
        string expectedMeasurementUnit = "measurement_unit";
        string expectedMeterID = "meter_id";
        string expectedName = "name";
        string expectedDescription = "description";
        string expectedPricePerUnit = "10.50";

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFreeThreshold, deserialized.FreeThreshold);
        Assert.Equal(expectedMeasurementUnit, deserialized.MeasurementUnit);
        Assert.Equal(expectedMeterID, deserialized.MeterID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedPricePerUnit, deserialized.PricePerUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            Description = "description",
            PricePerUnit = "10.50",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.PricePerUnit);
        Assert.False(model.RawData.ContainsKey("price_per_unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",

            Description = null,
            PricePerUnit = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.PricePerUnit);
        Assert.True(model.RawData.ContainsKey("price_per_unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",

            Description = null,
            PricePerUnit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeterCartResponseItem
        {
            Currency = Currency.Aed,
            FreeThreshold = 0,
            MeasurementUnit = "measurement_unit",
            MeterID = "meter_id",
            Name = "name",
            Description = "description",
            PricePerUnit = "10.50",
        };

        MeterCartResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
