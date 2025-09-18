using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Services.Products.Images;

public sealed class ImageService : IImageService
{
    readonly IDodoPaymentsClient _client;

    public ImageService(IDodoPaymentsClient client)
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
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ImageUpdateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
