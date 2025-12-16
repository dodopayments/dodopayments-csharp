using System;
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
}
