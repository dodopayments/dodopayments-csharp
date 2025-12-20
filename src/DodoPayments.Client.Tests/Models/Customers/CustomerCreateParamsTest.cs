using System.Collections.Generic;
using DodoPayments.Client.Models.Customers;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };

        string expectedEmail = "email";
        string expectedName = "name";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomerCreateParams
        {
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            PhoneNumber = null,
        };

        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phone_number"));
    }
}
