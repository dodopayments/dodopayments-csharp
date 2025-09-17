using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Subscriptions.SubscriptionUpdateParamsProperties;

[JsonConverter(typeof(Dodopayments::ModelConverter<DisableOnDemand>))]
public sealed record class DisableOnDemand
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<DisableOnDemand>
{
    public required DateTime NextBillingDate
    {
        get
        {
            if (!this.Properties.TryGetValue("next_billing_date", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "next_billing_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["next_billing_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.NextBillingDate;
    }

    public DisableOnDemand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisableOnDemand(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DisableOnDemand FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public DisableOnDemand(DateTime nextBillingDate)
        : this()
    {
        this.NextBillingDate = nextBillingDate;
    }
}
