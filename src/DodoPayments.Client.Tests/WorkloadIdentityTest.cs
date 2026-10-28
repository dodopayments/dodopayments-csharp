using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Moq;
using Moq.Protected;

namespace DodoPayments.Client.Tests;

public class WorkloadIdentityTest
{
    const string SubjectToken = "test-subject-token";

    const string IdentityProviderID = "wip_test";

    record class ApiParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            ParamsBase.AddDefaultHeaders(request, options);
        }

        public override Uri Url(ClientOptions options)
        {
            return new Uri(options.BaseUrl.TrimEnd('/') + "/payments");
        }
    }

    sealed class RecordedRequest
    {
        public RecordedRequest(string path, string? authorization, string? body)
        {
            Path = path;
            Authorization = authorization;
            Body = body;
        }

        public string Path { get; }

        public string? Authorization { get; }

        public string? Body { get; }
    }

    sealed class FakeApi
    {
        public ConcurrentQueue<RecordedRequest> Requests { get; } = new();

        public int ExpiresIn { get; set; } = 3600;

        public TimeSpan ExchangeDelay { get; set; } = TimeSpan.Zero;

        public HttpStatusCode ExchangeStatus { get; set; } = HttpStatusCode.OK;

        public string ExchangeErrorBody { get; set; } = "";

        public Func<int, HttpStatusCode> ApiStatus { get; set; } = _ => HttpStatusCode.OK;

        int _exchanges = 0;

        int _apiCalls = 0;

        public RecordedRequest[] Exchanges
        {
            get { return [.. Requests.Where(r => r.Path == "/workload-identity/token")]; }
        }

        public RecordedRequest[] ApiCalls
        {
            get { return [.. Requests.Where(r => r.Path == "/payments")]; }
        }

        public RecordedRequest[] Revokes
        {
            get { return [.. Requests.Where(r => r.Path == "/workload-identity/token/revoke")]; }
        }

        public HttpClient HttpClient()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Returns<HttpRequestMessage, CancellationToken>((request, _) => Handle(request));
            return new HttpClient(handlerMock.Object);
        }

        async Task<HttpResponseMessage> Handle(HttpRequestMessage request)
        {
            var path = request.RequestUri!.AbsolutePath;
            var authorization = request.Headers.Authorization?.ToString();
            var body =
                request.Content == null
                    ? null
                    : await request.Content.ReadAsStringAsync().ConfigureAwait(false);
            Requests.Enqueue(new(path, authorization, body));

            switch (path)
            {
                case "/workload-identity/token":
                    var exchange = Interlocked.Increment(ref _exchanges);
                    await Task.Delay(ExchangeDelay).ConfigureAwait(false);
                    if (ExchangeStatus != HttpStatusCode.OK)
                    {
                        return new()
                        {
                            StatusCode = ExchangeStatus,
                            Content = new StringContent(ExchangeErrorBody),
                        };
                    }
                    var expiresAt = DateTimeOffset.UtcNow.AddSeconds(ExpiresIn).ToString("o");
                    return new()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(
                            $"{{\"access_token\":\"access-token-{exchange}\",\"issued_token_type\":\"urn:ietf:params:oauth:token-type:access_token\",\"token_type\":\"Bearer\",\"expires_in\":{ExpiresIn},\"expires_at\":\"{expiresAt}\",\"scope\":\"payments:read\"}}"
                        ),
                    };
                case "/workload-identity/token/revoke":
                    return new() { StatusCode = HttpStatusCode.NoContent };
                default:
                    var call = Interlocked.Increment(ref _apiCalls);
                    return new()
                    {
                        StatusCode = ApiStatus(call),
                        Content = new StringContent("{}"),
                    };
            }
        }

        public DodoPaymentsClient Client()
        {
            return new()
            {
                HttpClient = HttpClient(),
                BaseUrl = "http://localhost",
                WorkloadIdentity = new()
                {
                    IdentityProviderID = IdentityProviderID,
                    Provider = WorkloadIdentityProviders.Static(SubjectToken),
                },
            };
        }
    }

    static Task<HttpResponse> CallApi(
        DodoPaymentsClient client,
        CancellationToken cancellationToken
    )
    {
        return client.WithRawResponse.Execute(
            new HttpRequest<ApiParams> { Method = HttpMethod.Get, Params = new() },
            cancellationToken
        );
    }

    [Fact]
    public async Task Exchange_ThenApiCallSendsAccessToken()
    {
        var api = new FakeApi();
        var client = api.Client();

        using var response = await CallApi(client, TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var exchange = Assert.Single(api.Exchanges);
        Assert.Null(exchange.Authorization);
        Assert.Equal(
            "{\"grant_type\":\"urn:ietf:params:oauth:grant-type:token-exchange\",\"subject_token_type\":\"urn:ietf:params:oauth:token-type:jwt\",\"subject_token\":\"test-subject-token\",\"identity_provider_id\":\"wip_test\"}",
            exchange.Body
        );
        Assert.Equal("Bearer access-token-1", Assert.Single(api.ApiCalls).Authorization);
    }

    [Fact]
    public async Task ConcurrentCalls_ShareOneExchange()
    {
        var api = new FakeApi { ExchangeDelay = TimeSpan.FromMilliseconds(200) };
        var client = api.Client();

        var responses = await Task.WhenAll(
            CallApi(client, TestContext.Current.CancellationToken),
            CallApi(client, TestContext.Current.CancellationToken)
        );

        foreach (var response in responses)
        {
            response.Dispose();
        }
        Assert.Single(api.Exchanges);
        Assert.All(api.ApiCalls, call => Assert.Equal("Bearer access-token-1", call.Authorization));
        Assert.Equal(2, api.ApiCalls.Length);
    }

    [Fact]
    public async Task TokenWithFiveMinutesOrLessLeft_IsExchangedAgain()
    {
        var api = new FakeApi { ExpiresIn = 200 };
        var client = api.Client();

        (await CallApi(client, TestContext.Current.CancellationToken)).Dispose();
        (await CallApi(client, TestContext.Current.CancellationToken)).Dispose();

        Assert.Equal(2, api.Exchanges.Length);
        Assert.Equal("Bearer access-token-2", api.ApiCalls[1].Authorization);
    }

    [Fact]
    public async Task TokenWithMoreThanFiveMinutesLeft_IsReused()
    {
        var api = new FakeApi { ExpiresIn = 3600 };
        var client = api.Client();

        (await CallApi(client, TestContext.Current.CancellationToken)).Dispose();
        (await CallApi(client, TestContext.Current.CancellationToken)).Dispose();

        Assert.Single(api.Exchanges);
        Assert.All(api.ApiCalls, call => Assert.Equal("Bearer access-token-1", call.Authorization));
    }

    [Fact]
    public async Task ApiUnauthorized_ExchangesAgainAndRetriesOnce()
    {
        var api = new FakeApi
        {
            ApiStatus = call => call == 1 ? HttpStatusCode.Unauthorized : HttpStatusCode.OK,
        };
        var client = api.Client();

        using var response = await CallApi(client, TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(2, api.Exchanges.Length);
        Assert.Equal(2, api.ApiCalls.Length);
        Assert.Equal("Bearer access-token-1", api.ApiCalls[0].Authorization);
        Assert.Equal("Bearer access-token-2", api.ApiCalls[1].Authorization);
    }

    [Fact]
    public async Task ApiUnauthorizedTwice_SurfacesSecondUnauthorized()
    {
        var api = new FakeApi { ApiStatus = _ => HttpStatusCode.Unauthorized };
        var client = api.Client();

        await Assert.ThrowsAsync<DodoPaymentsUnauthorizedException>(() =>
            CallApi(client, TestContext.Current.CancellationToken)
        );

        Assert.Equal(2, api.Exchanges.Length);
        Assert.Equal(2, api.ApiCalls.Length);
    }

    [Fact]
    public void BearerTokenAndWorkloadIdentity_AreRejected()
    {
        var workloadIdentity = new WorkloadIdentityOptions
        {
            IdentityProviderID = IdentityProviderID,
            Provider = WorkloadIdentityProviders.Static(SubjectToken),
        };

        Assert.Throws<DodoPaymentsInvalidDataException>(() =>
            new DodoPaymentsClient
            {
                BearerToken = "My Bearer Token",
                WorkloadIdentity = workloadIdentity,
            }
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() =>
            new DodoPaymentsClient
            {
                WorkloadIdentity = workloadIdentity,
                BearerToken = "My Bearer Token",
            }
        );
    }

    [Fact]
    public async Task ExchangeInvalidGrant_ThrowsForbiddenWithDescription()
    {
        var api = new FakeApi
        {
            ExchangeStatus = HttpStatusCode.Forbidden,
            ExchangeErrorBody =
                "{\"error\":\"invalid_grant\",\"error_description\":\"No mapping matches the token claims.\"}",
        };
        var client = api.Client();

        var exception = await Assert.ThrowsAsync<DodoPaymentsForbiddenException>(() =>
            CallApi(client, TestContext.Current.CancellationToken)
        );

        Assert.Contains("invalid_grant", exception.Message);
        Assert.Contains("No mapping matches the token claims.", exception.Message);
        Assert.Single(api.Exchanges);
        Assert.Empty(api.ApiCalls);
    }

    [Fact]
    public async Task Revoke_SendsAccessTokenAndClearsCache()
    {
        var api = new FakeApi();
        var client = api.Client();
        (await CallApi(client, TestContext.Current.CancellationToken)).Dispose();

        await client.RevokeWorkloadIdentityToken(TestContext.Current.CancellationToken);
        (await CallApi(client, TestContext.Current.CancellationToken)).Dispose();

        Assert.Equal("Bearer access-token-1", Assert.Single(api.Revokes).Authorization);
        Assert.Equal(2, api.Exchanges.Length);
        Assert.Equal("Bearer access-token-2", api.ApiCalls[1].Authorization);
    }

    [Fact]
    public async Task Revoke_WithoutCachedToken_SendsNoRequest()
    {
        var api = new FakeApi();
        var client = api.Client();

        await client.RevokeWorkloadIdentityToken(TestContext.Current.CancellationToken);

        Assert.Empty(api.Requests);
    }
}
