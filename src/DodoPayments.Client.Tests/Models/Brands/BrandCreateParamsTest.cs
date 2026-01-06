using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandCreateParams
        {
            Description = "description",
            Name = "name",
            StatementDescriptor = "statement_descriptor",
            SupportEmail = "support_email",
            URL = "url",
        };

        string expectedDescription = "description";
        string expectedName = "name";
        string expectedStatementDescriptor = "statement_descriptor";
        string expectedSupportEmail = "support_email";
        string expectedURL = "url";

        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStatementDescriptor, parameters.StatementDescriptor);
        Assert.Equal(expectedSupportEmail, parameters.SupportEmail);
        Assert.Equal(expectedURL, parameters.URL);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandCreateParams { };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.StatementDescriptor);
        Assert.False(parameters.RawBodyData.ContainsKey("statement_descriptor"));
        Assert.Null(parameters.SupportEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("support_email"));
        Assert.Null(parameters.URL);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandCreateParams
        {
            Description = null,
            Name = null,
            StatementDescriptor = null,
            SupportEmail = null,
            URL = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.StatementDescriptor);
        Assert.True(parameters.RawBodyData.ContainsKey("statement_descriptor"));
        Assert.Null(parameters.SupportEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("support_email"));
        Assert.Null(parameters.URL);
        Assert.True(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandCreateParams parameters = new();

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/brands"), url);
    }
}
