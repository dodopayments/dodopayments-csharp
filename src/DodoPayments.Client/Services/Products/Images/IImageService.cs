using System;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Services.Products.Images;

public interface IImageService
{
    IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<ImageUpdateResponse> Update(ImageUpdateParams parameters);
}
