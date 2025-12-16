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
}
