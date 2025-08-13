using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Products.Images;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.Products.Images;

public sealed class ImageService : IImageService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public ImageService(DodoPayments::IDodoPaymentsClient client)
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
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ImageUpdateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
