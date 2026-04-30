using System;
using DodoPayments.Client.Models.Entitlements.Files;

namespace DodoPayments.Client.Tests.Models.Entitlements.Files;

public class FileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDeleteParams { ID = "id", FileID = "file_id" };

        string expectedID = "id";
        string expectedFileID = "file_id";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileDeleteParams parameters = new() { ID = "id", FileID = "file_id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/entitlements/id/files/file_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDeleteParams { ID = "id", FileID = "file_id" };

        FileDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
