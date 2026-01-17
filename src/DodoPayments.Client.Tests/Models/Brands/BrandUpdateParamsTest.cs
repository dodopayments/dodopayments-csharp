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
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            StatementDescriptor = "statement_descriptor",
            SupportEmail = "support_email",
        };

        string expectedID = "id";
        string expectedImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "name";
        string expectedStatementDescriptor = "statement_descriptor";
        string expectedSupportEmail = "support_email";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedImageID, parameters.ImageID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStatementDescriptor, parameters.StatementDescriptor);
        Assert.Equal(expectedSupportEmail, parameters.SupportEmail);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandUpdateParams { ID = "id" };

        Assert.Null(parameters.ImageID);
        Assert.False(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.StatementDescriptor);
        Assert.False(parameters.RawBodyData.ContainsKey("statement_descriptor"));
        Assert.Null(parameters.SupportEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("support_email"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandUpdateParams
        {
            ID = "id",

            ImageID = null,
            Name = null,
            StatementDescriptor = null,
            SupportEmail = null,
        };

        Assert.Null(parameters.ImageID);
        Assert.True(parameters.RawBodyData.ContainsKey("image_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.StatementDescriptor);
        Assert.True(parameters.RawBodyData.ContainsKey("statement_descriptor"));
        Assert.Null(parameters.SupportEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("support_email"));
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
            ImageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "name",
            StatementDescriptor = "statement_descriptor",
            SupportEmail = "support_email",
        };

        BrandUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
