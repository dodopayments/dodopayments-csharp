using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionChargeResponse, SubscriptionChargeResponseFromRaw>)
)]
public sealed record class SubscriptionChargeResponse : JsonModel
{
    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PaymentID;
    }

    public SubscriptionChargeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChargeResponse(SubscriptionChargeResponse subscriptionChargeResponse)
        : base(subscriptionChargeResponse) { }
#pragma warning restore CS8618

    public SubscriptionChargeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChargeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChargeResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionChargeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionChargeResponse(string paymentID)
        : this()
    {
        this.PaymentID = paymentID;
    }
}

class SubscriptionChargeResponseFromRaw : IFromRawJson<SubscriptionChargeResponse>
{
    /// <inheritdoc/>
    public SubscriptionChargeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChargeResponse.FromRawUnchecked(rawData);
}
