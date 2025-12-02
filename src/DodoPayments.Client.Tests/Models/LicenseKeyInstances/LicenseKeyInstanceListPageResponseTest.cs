using System;
using System.Collections.Generic;
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
}
