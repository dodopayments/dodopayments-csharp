using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Subscriptions.SubscriptionChargeParamsProperties;

/// <summary>
/// Specify how customer balance is used for the payment
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<CustomerBalanceConfig>))]
public sealed record class CustomerBalanceConfig
    : Client::ModelBase,
        Client::IFromRaw<CustomerBalanceConfig>
{
    /// <summary>
    /// Allows Customer Credit to be purchased to settle payments
    /// </summary>
    public bool? AllowCustomerCreditsPurchase
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "allow_customer_credits_purchase",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allow_customer_credits_purchase"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Allows Customer Credit Balance to be used to settle payments
    /// </summary>
    public bool? AllowCustomerCreditsUsage
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "allow_customer_credits_usage",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allow_customer_credits_usage"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        _ = this.AllowCustomerCreditsPurchase;
        _ = this.AllowCustomerCreditsUsage;
    }

    public CustomerBalanceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerBalanceConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerBalanceConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
