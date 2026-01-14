using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyInstance
        {
            ID = "lki_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            LicenseKeyID = "lic_123",
            Name = "Production Server 1",
        };

        string expectedID = "lki_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedLicenseKeyID = "lic_123";
        string expectedName = "Production Server 1";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLicenseKeyID, model.LicenseKeyID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyInstance
        {
            ID = "lki_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            LicenseKeyID = "lic_123",
            Name = "Production Server 1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyInstance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyInstance
        {
            ID = "lki_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            LicenseKeyID = "lic_123",
            Name = "Production Server 1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyInstance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "lki_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedLicenseKeyID = "lic_123";
        string expectedName = "Production Server 1";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLicenseKeyID, deserialized.LicenseKeyID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyInstance
        {
            ID = "lki_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            LicenseKeyID = "lic_123",
            Name = "Production Server 1",
        };

        model.Validate();
    }
}
