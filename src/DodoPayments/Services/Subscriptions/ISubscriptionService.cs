using System.Threading.Tasks;
using DodoPayments.Models.Subscriptions;

namespace DodoPayments.Services.Subscriptions;

public interface ISubscriptionService
{
    Task<SubscriptionCreateResponse> Create(SubscriptionCreateParams parameters);

    Task<Subscription> Retrieve(SubscriptionRetrieveParams parameters);

    Task<Subscription> Update(SubscriptionUpdateParams parameters);

    Task<SubscriptionListPageResponse> List(SubscriptionListParams parameters);

    Task ChangePlan(SubscriptionChangePlanParams parameters);

    Task<SubscriptionChargeResponse> Charge(SubscriptionChargeParams parameters);
}
