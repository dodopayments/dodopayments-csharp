using System.Threading.Tasks;
using DodoPayments.Client.Models.Products.Images;

namespace DodoPayments.Client.Services.Products.Images;

public interface IImageService
{
    Task<ImageUpdateResponse> Update(ImageUpdateParams parameters);
}
