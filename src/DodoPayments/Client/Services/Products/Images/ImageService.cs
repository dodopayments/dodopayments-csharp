using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Products.Images;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Services.Products.Images;

public sealed class ImageService : IImageService
{
    readonly Client::IDodoPaymentsClient _client;

    public ImageService(Client::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<ImageUpdateResponse> Update(ImageUpdateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Put, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Client::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ImageUpdateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Client::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
