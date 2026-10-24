using System;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterUpdateParams
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",
            Description = "description",
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        string expectedID = "mtr_h5tgTWL55OyMO0L2Q9w9v";
        string expectedDescription = "description";
        string expectedMeasurementUnit = "measurement_unit";
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedMeasurementUnit, parameters.MeasurementUnit);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MeterUpdateParams { ID = "mtr_h5tgTWL55OyMO0L2Q9w9v" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MeasurementUnit);
        Assert.False(parameters.RawBodyData.ContainsKey("measurement_unit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MeterUpdateParams
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",

            Description = null,
            MeasurementUnit = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MeasurementUnit);
        Assert.True(parameters.RawBodyData.ContainsKey("measurement_unit"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        MeterUpdateParams parameters = new() { ID = "mtr_h5tgTWL55OyMO0L2Q9w9v" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/meters/mtr_h5tgTWL55OyMO0L2Q9w9v"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MeterUpdateParams
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",
            Description = "description",
            MeasurementUnit = "measurement_unit",
            Name = "name",
        };

        MeterUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
