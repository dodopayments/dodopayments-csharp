using System.Threading.Tasks;
using DodoPayments.Models.Products.Images;

namespace DodoPayments.Services.Products.Images;

public interface IImageService
{
    Task<ImageUpdateResponse> Update(ImageUpdateParams parameters);
}
