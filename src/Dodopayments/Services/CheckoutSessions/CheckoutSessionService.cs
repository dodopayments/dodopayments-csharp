using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dodopayments.Models.CheckoutSessions;
using Dodopayments = Dodopayments;

namespace Dodopayments.Services.CheckoutSessions;

public sealed class CheckoutSessionService : ICheckoutSessionService
{
    readonly Dodopayments::IDodoPaymentsClient _client;

    public CheckoutSessionService(Dodopayments::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<CheckoutSessionResponse> Create(CheckoutSessionCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Dodopayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<CheckoutSessionResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Dodopayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
