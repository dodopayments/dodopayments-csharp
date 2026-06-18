using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.ProductCollections.Groups;
using DodoPayments.Client.Models.ProductCollections.Groups.Items;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups.Items;

public class ItemCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemCreateParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        string expectedID = "pdc_8BWv0hojwUH7iCDabr0NI";
        string expectedGroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<GroupProduct> expectedProducts = [new() { ProductID = "product_id", Status = true }];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedGroupID, parameters.GroupID);
        Assert.Equal(expectedProducts.Count, parameters.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], parameters.Products[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ItemCreateParams parameters = new()
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/product-collections/pdc_8BWv0hojwUH7iCDabr0NI/groups/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/items"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemCreateParams
        {
            ID = "pdc_8BWv0hojwUH7iCDabr0NI",
            GroupID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Products = [new() { ProductID = "product_id", Status = true }],
        };

        ItemCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
