using System;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationScreenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ModerationScreenParams
        {
            Image = "image",
            RequestID = "request_id",
            Text = "text",
        };

        string expectedImage = "image";
        string expectedRequestID = "request_id";
        string expectedText = "text";

        Assert.Equal(expectedImage, parameters.Image);
        Assert.Equal(expectedRequestID, parameters.RequestID);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ModerationScreenParams { };

        Assert.Null(parameters.Image);
        Assert.False(parameters.RawBodyData.ContainsKey("image"));
        Assert.Null(parameters.RequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("request_id"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ModerationScreenParams
        {
            Image = null,
            RequestID = null,
            Text = null,
        };

        Assert.Null(parameters.Image);
        Assert.True(parameters.RawBodyData.ContainsKey("image"));
        Assert.Null(parameters.RequestID);
        Assert.True(parameters.RawBodyData.ContainsKey("request_id"));
        Assert.Null(parameters.Text);
        Assert.True(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        ModerationScreenParams parameters = new();

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/moderation/screen"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ModerationScreenParams
        {
            Image = "image",
            RequestID = "request_id",
            Text = "text",
        };

        ModerationScreenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
