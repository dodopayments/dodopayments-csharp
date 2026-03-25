using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.YourWebhookUrl;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class YourWebhookUrlService : IYourWebhookUrlService
{
    readonly Lazy<IYourWebhookUrlServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IYourWebhookUrlServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IYourWebhookUrlService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new YourWebhookUrlService(this._client.WithOptions(modifier));
    }

    public YourWebhookUrlService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new YourWebhookUrlServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public Task Create(
        YourWebhookUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class YourWebhookUrlServiceWithRawResponse : IYourWebhookUrlServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IYourWebhookUrlServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new YourWebhookUrlServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public YourWebhookUrlServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        YourWebhookUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<YourWebhookUrlCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
