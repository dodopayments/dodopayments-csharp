using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<SubscriptionData, SubscriptionDataFromRaw>))]
public sealed record class SubscriptionData : JsonModel
{
    public OnDemandSubscription? OnDemand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OnDemandSubscription>("on_demand");
        }
        init { this._rawData.Set("on_demand", value); }
    }

    /// <summary>
    /// Optional trial period in days If specified, this value overrides the trial
    /// period set in the product's price Must be between 0 and 10000 days
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("trial_period_days");
        }
        init { this._rawData.Set("trial_period_days", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.OnDemand?.Validate();
        _ = this.TrialPeriodDays;
    }

    public SubscriptionData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionData(SubscriptionData subscriptionData)
        : base(subscriptionData) { }
#pragma warning restore CS8618

    public SubscriptionData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionDataFromRaw : IFromRawJson<SubscriptionData>
{
    /// <inheritdoc/>
    public SubscriptionData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionData.FromRawUnchecked(rawData);
}
