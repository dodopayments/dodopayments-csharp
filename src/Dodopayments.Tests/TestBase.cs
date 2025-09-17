using System;
using Dodopayments;

namespace Dodopayments.Tests;

public class TestBase
{
    protected IDodoPaymentsClient client;

    public TestBase()
    {
        client = new DodoPaymentsClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            BearerToken = "My Bearer Token",
        };
    }
}
