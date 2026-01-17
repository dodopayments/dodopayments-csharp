using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            CustomerID = "customer_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PhoneNumber = "phone_number",
        };

        string expectedCustomerID = "customer_id";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams { CustomerID = "customer_id" };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            CustomerID = "customer_id",

            Metadata = null,
            Name = null,
            PhoneNumber = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PhoneNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("phone_number"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerUpdateParams parameters = new() { CustomerID = "customer_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/customers/customer_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            CustomerID = "customer_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PhoneNumber = "phone_number",
        };

        CustomerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
