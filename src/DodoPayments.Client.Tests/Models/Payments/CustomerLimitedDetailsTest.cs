using System.Collections.Generic;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class CustomerLimitedDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerLimitedDetails
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };

        string expectedCustomerID = "customer_id";
        string expectedEmail = "email";
        string expectedName = "name";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }
}
