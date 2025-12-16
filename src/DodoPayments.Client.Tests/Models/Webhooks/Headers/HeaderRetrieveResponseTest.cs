using System.Collections.Generic;
using DodoPayments.Client.Models.Webhooks.Headers;

namespace DodoPayments.Client.Tests.Models.Webhooks.Headers;

public class HeaderRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HeaderRetrieveResponse
        {
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Sensitive = ["string"],
        };

        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        List<string> expectedSensitive = ["string"];

        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedSensitive.Count, model.Sensitive.Count);
        for (int i = 0; i < expectedSensitive.Count; i++)
        {
            Assert.Equal(expectedSensitive[i], model.Sensitive[i]);
        }
    }
}
