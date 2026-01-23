using System;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandUpdateParams
        {
            ID = "id",
            Description = "description",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            StatementDescriptor = "statement_descriptor",
            SupportEmail = "support_email",
            UrlValue = "url",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";
        string expectedStatementDescriptor = "statement_descriptor";
        string expectedSupportEmail = "support_email";
        string expectedUrlValue = "url";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedImageID, parameters.ImageID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStatementDescriptor, parameters.StatementDescriptor);
        Assert.Equal(expectedSupportEmail, parameters.SupportEmail);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandUpdateParams { ID = "id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ImageID);
        Assert.False(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.StatementDescriptor);
        Assert.False(parameters.RawBodyData.ContainsKey("statement_descriptor"));
        Assert.Null(parameters.SupportEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("support_email"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandUpdateParams
        {
            ID = "id",

            Description = null,
            ImageID = null,
            Name = null,
            StatementDescriptor = null,
            SupportEmail = null,
            UrlValue = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ImageID);
        Assert.True(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.StatementDescriptor);
        Assert.True(parameters.RawBodyData.ContainsKey("statement_descriptor"));
        Assert.Null(parameters.SupportEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("support_email"));
        Assert.Null(parameters.UrlValue);
        Assert.True(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://live.dodopayments.com/brands/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandUpdateParams
        {
            ID = "id",
            Description = "description",
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            StatementDescriptor = "statement_descriptor",
            SupportEmail = "support_email",
            UrlValue = "url",
        };

        BrandUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
