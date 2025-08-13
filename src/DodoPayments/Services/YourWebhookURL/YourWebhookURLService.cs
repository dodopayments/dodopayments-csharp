using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Models.YourWebhookURL;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.YourWebhookURL;

public sealed class YourWebhookURLService : IYourWebhookURLService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public YourWebhookURLService(DodoPayments::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task Create(YourWebhookURLCreateParams parameters)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
    }
}
