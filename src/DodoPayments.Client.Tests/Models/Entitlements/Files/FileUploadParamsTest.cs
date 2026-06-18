using System;
using DodoPayments.Client.Models.Entitlements.Files;

namespace DodoPayments.Client.Tests.Models.Entitlements.Files;

public class FileUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileUploadParams { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        string expectedID = "ent_jt7jcvI79Xh8eehqgWdcm";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new() { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/entitlements/ent_jt7jcvI79Xh8eehqgWdcm/files"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
