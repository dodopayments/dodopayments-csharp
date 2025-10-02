using System.Net.Http;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
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
        HttpRequest<ImageUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ImageUpdateResponse>().ConfigureAwait(false);
    }
}
