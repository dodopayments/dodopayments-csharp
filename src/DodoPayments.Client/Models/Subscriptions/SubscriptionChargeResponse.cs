using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<SubscriptionChargeResponse, SubscriptionChargeResponseFromRaw>)
)]
public sealed record class SubscriptionChargeResponse : ModelBase
{
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PaymentID;
    }

    public SubscriptionChargeResponse() { }

    public SubscriptionChargeResponse(SubscriptionChargeResponse subscriptionChargeResponse)
        : base(subscriptionChargeResponse) { }

    public SubscriptionChargeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChargeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SubscriptionChargeResponseFromRaw : IFromRaw<SubscriptionChargeResponse>
{
    /// <inheritdoc/>
    public SubscriptionChargeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChargeResponse.FromRawUnchecked(rawData);
}
