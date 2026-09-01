using System;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class CustomerDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerDeleteParams { EntryID = "entry_id" };

        string expectedEntryID = "entry_id";

        Assert.Equal(expectedEntryID, parameters.EntryID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerDeleteParams parameters = new() { EntryID = "entry_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/blocklist/customers/entry_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerDeleteParams { EntryID = "entry_id" };

        CustomerDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
