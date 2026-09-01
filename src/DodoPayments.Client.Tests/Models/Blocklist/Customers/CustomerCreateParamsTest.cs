using System;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class CustomerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerCreateParams
        {
            CreateBlockedCustomerRequest = new BlocklistCustomersBlockByCustomerID()
            {
                CustomerID = "customer_id",
                Reason = "reason",
                Source = BlockedCustomerSource.BlocklistPage,
            },
        };

        CreateBlockedCustomerRequest expectedCreateBlockedCustomerRequest =
            new BlocklistCustomersBlockByCustomerID()
            {
                CustomerID = "customer_id",
                Reason = "reason",
                Source = BlockedCustomerSource.BlocklistPage,
            };

        Assert.Equal(expectedCreateBlockedCustomerRequest, parameters.CreateBlockedCustomerRequest);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerCreateParams parameters = new()
        {
            CreateBlockedCustomerRequest = new BlocklistCustomersBlockByCustomerID()
            {
                CustomerID = "customer_id",
                Reason = "reason",
                Source = BlockedCustomerSource.BlocklistPage,
            },
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/blocklist/customers"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerCreateParams
        {
            CreateBlockedCustomerRequest = new BlocklistCustomersBlockByCustomerID()
            {
                CustomerID = "customer_id",
                Reason = "reason",
                Source = BlockedCustomerSource.BlocklistPage,
            },
        };

        CustomerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
