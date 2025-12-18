using System.Text.Json;
using DodoPayments.Client.Models.Licenses;

namespace DodoPayments.Client.Tests.Models.Licenses;

public class LicenseValidateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseValidateResponse { Valid = true };

        bool expectedValid = true;

        Assert.Equal(expectedValid, model.Valid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseValidateResponse { Valid = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseValidateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseValidateResponse { Valid = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseValidateResponse>(element);
        Assert.NotNull(deserialized);

        bool expectedValid = true;

        Assert.Equal(expectedValid, deserialized.Valid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseValidateResponse { Valid = true };

        model.Validate();
    }
}
