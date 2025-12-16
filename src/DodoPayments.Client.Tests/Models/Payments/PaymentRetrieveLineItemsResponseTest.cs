using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class PaymentRetrieveLineItemsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentRetrieveLineItemsResponse
        {
            Currency = Currency.Aed,
            Items =
            [
                new()
                {
                    Amount = 0,
                    ItemsID = "items_id",
                    RefundableAmount = 0,
                    Tax = 0,
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        List<ItemModel> expectedItems =
        [
            new()
            {
                Amount = 0,
                ItemsID = "items_id",
                RefundableAmount = 0,
                Tax = 0,
                Description = "description",
                Name = "name",
            },
        ];

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemModel
        {
            Amount = 0,
            ItemsID = "items_id",
            RefundableAmount = 0,
            Tax = 0,
            Description = "description",
            Name = "name",
        };

        int expectedAmount = 0;
        string expectedItemsID = "items_id";
        int expectedRefundableAmount = 0;
        int expectedTax = 0;
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedItemsID, model.ItemsID);
        Assert.Equal(expectedRefundableAmount, model.RefundableAmount);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }
}
