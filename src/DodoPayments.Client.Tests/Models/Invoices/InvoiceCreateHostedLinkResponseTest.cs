using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceCreateHostedLinkResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceCreateHostedLinkResponse
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedUrl = "hosted_url";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedHostedUrl, model.HostedUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceCreateHostedLinkResponse
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceCreateHostedLinkResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceCreateHostedLinkResponse
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceCreateHostedLinkResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedUrl = "hosted_url";

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedHostedUrl, deserialized.HostedUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceCreateHostedLinkResponse
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceCreateHostedLinkResponse
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedUrl = "hosted_url",
        };

        InvoiceCreateHostedLinkResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
