using System.Threading.Tasks;
using DodoPayments.Models.YourWebhookURL;

namespace DodoPayments.Services.YourWebhookURL;

public interface IYourWebhookURLService
{
    Task Create(YourWebhookURLCreateParams parameters);
}
