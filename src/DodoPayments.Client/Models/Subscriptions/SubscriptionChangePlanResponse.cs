using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Handles for a hosted checkout page that settles a plan change.
///
/// <para>The four fields repeat `UpdatePaymentMethodResponse` and a subset of `CreateSubscriptionResponse`.
/// A shared type would rename the generated SDK types for all three routes, so each
/// route keeps its own.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionChangePlanResponse,
        SubscriptionChangePlanResponseFromRaw
    >)
)]
public sealed record class SubscriptionChangePlanResponse : JsonModel
{
    /// <summary>
    /// Client secret for an embedded checkout.
    /// </summary>
    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    /// <summary>
    /// When the link stops working.
    /// </summary>
    public DateTimeOffset? ExpiresOn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_on");
        }
        init { this._rawData.Set("expires_on", value); }
    }

    /// <summary>
    /// Id of the payment that settles the plan change.
    /// </summary>
    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// Checkout page URL. Give this to the customer.
    /// </summary>
    public string? PaymentLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_link");
        }
        init { this._rawData.Set("payment_link", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientSecret;
        _ = this.ExpiresOn;
        _ = this.PaymentID;
        _ = this.PaymentLink;
    }

    public SubscriptionChangePlanResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChangePlanResponse(
        SubscriptionChangePlanResponse subscriptionChangePlanResponse
    )
        : base(subscriptionChangePlanResponse) { }
#pragma warning restore CS8618

    public SubscriptionChangePlanResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangePlanResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChangePlanResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionChangePlanResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionChangePlanResponseFromRaw : IFromRawJson<SubscriptionChangePlanResponse>
{
    /// <inheritdoc/>
    public SubscriptionChangePlanResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangePlanResponse.FromRawUnchecked(rawData);
}
