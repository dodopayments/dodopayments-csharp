using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Services.Products;

public sealed class ImageService : IImageService
{
    public IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageService(this._client.WithOptions(modifier));
    }

    readonly IDodoPaymentsClient _client;

    public ImageService(IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<ImageUpdateResponse> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ImageUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var image = await response
            .Deserialize<ImageUpdateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            image.Validate();
        }
        return image;
    }
}
