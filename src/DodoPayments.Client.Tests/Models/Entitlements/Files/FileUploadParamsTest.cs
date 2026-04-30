using System;
using DodoPayments.Client.Models.Entitlements.Files;

namespace DodoPayments.Client.Tests.Models.Entitlements.Files;

public class FileUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileUploadParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/entitlements/id/files"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams { ID = "id" };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
