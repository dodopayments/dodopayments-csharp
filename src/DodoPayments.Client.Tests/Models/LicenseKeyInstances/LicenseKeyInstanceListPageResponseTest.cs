using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Models.LicenseKeyInstances;

namespace DodoPayments.Client.Tests.Models.LicenseKeyInstances;

public class LicenseKeyInstanceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyInstanceListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "lki_123",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    LicenseKeyID = "lic_123",
                    Name = "Production Server 1",
                },
            ],
        };

        List<LicenseKeyInstance> expectedItems =
        [
            new()
            {
                ID = "lki_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                LicenseKeyID = "lic_123",
                Name = "Production Server 1",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyInstanceListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "lki_123",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    LicenseKeyID = "lic_123",
                    Name = "Production Server 1",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyInstanceListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyInstanceListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "lki_123",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    LicenseKeyID = "lic_123",
                    Name = "Production Server 1",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyInstanceListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<LicenseKeyInstance> expectedItems =
        [
            new()
            {
                ID = "lki_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                LicenseKeyID = "lic_123",
                Name = "Production Server 1",
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyInstanceListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "lki_123",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    LicenseKeyID = "lic_123",
                    Name = "Production Server 1",
                },
            ],
        };

        model.Validate();
    }
}
