using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Addons;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Name = "name",
                    Price = 0,
                    TaxCategory = TaxCategory.DigitalProducts,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Image = "image",
                },
            ],
        };

        List<AddonResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Name = "name",
                Price = 0,
                TaxCategory = TaxCategory.DigitalProducts,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Image = "image",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}
