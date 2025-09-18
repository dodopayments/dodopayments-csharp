using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<SubscriptionData>))]
public sealed record class SubscriptionData : ModelBase, IFromRaw<SubscriptionData>
{
    public OnDemandSubscription? OnDemand
    {
        get
        {
            if (!this.Properties.TryGetValue("on_demand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OnDemandSubscription?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["on_demand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_days", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trial_period_days"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.OnDemand?.Validate();
        _ = this.TrialPeriodDays;
    }

    public SubscriptionData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionData(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionData FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
