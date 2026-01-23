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
        SubscriptionUpdatePaymentMethodResponse,
        SubscriptionUpdatePaymentMethodResponseFromRaw
    >)
)]
public sealed record class SubscriptionUpdatePaymentMethodResponse : JsonModel
{
    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    public DateTimeOffset? ExpiresOn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_on");
        }
        init { this._rawData.Set("expires_on", value); }
    }

    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

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

    public SubscriptionUpdatePaymentMethodResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionUpdatePaymentMethodResponse(
        SubscriptionUpdatePaymentMethodResponse subscriptionUpdatePaymentMethodResponse
    )
        : base(subscriptionUpdatePaymentMethodResponse) { }
#pragma warning restore CS8618

    public SubscriptionUpdatePaymentMethodResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatePaymentMethodResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionUpdatePaymentMethodResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionUpdatePaymentMethodResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionUpdatePaymentMethodResponseFromRaw
    : IFromRawJson<SubscriptionUpdatePaymentMethodResponse>
{
    /// <inheritdoc/>
    public SubscriptionUpdatePaymentMethodResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionUpdatePaymentMethodResponse.FromRawUnchecked(rawData);
}
