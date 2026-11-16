using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionStartTrialResponse,
        SubscriptionStartTrialResponseFromRaw
    >)
)]
public sealed record class SubscriptionStartTrialResponse : JsonModel
{
    /// <summary>
    /// The paid $0 invoice of the trial.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_id");
        }
        init { this._rawData.Set("invoice_id", value); }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// The first invoice after the trial bills at this time.
    /// </summary>
    public required DateTimeOffset TrialEndsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("trial_ends_at");
        }
        init { this._rawData.Set("trial_ends_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InvoiceID;
        _ = this.SubscriptionID;
        _ = this.TrialEndsAt;
    }

    public SubscriptionStartTrialResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionStartTrialResponse(
        SubscriptionStartTrialResponse subscriptionStartTrialResponse
    )
        : base(subscriptionStartTrialResponse) { }
#pragma warning restore CS8618

    public SubscriptionStartTrialResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionStartTrialResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionStartTrialResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionStartTrialResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionStartTrialResponseFromRaw : IFromRawJson<SubscriptionStartTrialResponse>
{
    /// <inheritdoc/>
    public SubscriptionStartTrialResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionStartTrialResponse.FromRawUnchecked(rawData);
}
