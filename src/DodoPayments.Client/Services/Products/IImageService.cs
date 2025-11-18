using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Services.Products;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IImageService
{
    IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Task<ImageUpdateResponse> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
