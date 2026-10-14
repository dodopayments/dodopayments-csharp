using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

/// <summary>
/// The service period that a payment pays for, for one subscription.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionServicePeriod, SubscriptionServicePeriodFromRaw>)
)]
public sealed record class SubscriptionServicePeriod : JsonModel
{
    /// <summary>
    /// End of the service period.
    /// </summary>
    public required DateTimeOffset EndsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("ends_at");
        }
        init { this._rawData.Set("ends_at", value); }
    }

    /// <summary>
    /// Start of the service period. For a renewal, this is the billing date. For
    /// a plan change that applies at the next billing date, this is the time when
    /// the change applied. This time can be some minutes after the billing date.
    /// </summary>
    public required DateTimeOffset StartsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("starts_at");
        }
        init { this._rawData.Set("starts_at", value); }
    }

    /// <summary>
    /// Identifier of the subscription.
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndsAt;
        _ = this.StartsAt;
        _ = this.SubscriptionID;
    }

    public SubscriptionServicePeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionServicePeriod(SubscriptionServicePeriod subscriptionServicePeriod)
        : base(subscriptionServicePeriod) { }
#pragma warning restore CS8618

    public SubscriptionServicePeriod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionServicePeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionServicePeriodFromRaw.FromRawUnchecked"/>
    public static SubscriptionServicePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionServicePeriodFromRaw : IFromRawJson<SubscriptionServicePeriod>
{
    /// <inheritdoc/>
    public SubscriptionServicePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionServicePeriod.FromRawUnchecked(rawData);
}
