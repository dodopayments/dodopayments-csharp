using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Subscriptions;

[JsonConverter(typeof(DodoPayments::ModelConverter<SubscriptionChargeResponse>))]
public sealed record class SubscriptionChargeResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<SubscriptionChargeResponse>
{
    public required string PaymentID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("payment_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payment_id");
        }
        set { this.Properties["payment_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.PaymentID;
    }

    public SubscriptionChargeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChargeResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionChargeResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubscriptionChargeResponse(string paymentID)
        : this()
    {
        this.PaymentID = paymentID;
    }
}
