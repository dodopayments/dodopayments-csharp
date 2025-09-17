using System.Threading.Tasks;
using Dodopayments.Models.Products.Images;

namespace Dodopayments.Services.Products.Images;

public interface IImageService
{
    Task<ImageUpdateResponse> Update(ImageUpdateParams parameters);
}
