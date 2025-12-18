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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "client_secret"); }
        init { JsonModel.Set(this._rawData, "client_secret", value); }
    }

    public DateTimeOffset? ExpiresOn
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "expires_on"); }
        init { JsonModel.Set(this._rawData, "expires_on", value); }
    }

    public string? PaymentID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_id"); }
        init { JsonModel.Set(this._rawData, "payment_id", value); }
    }

    public string? PaymentLink
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_link"); }
        init { JsonModel.Set(this._rawData, "payment_link", value); }
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

    public SubscriptionUpdatePaymentMethodResponse(
        SubscriptionUpdatePaymentMethodResponse subscriptionUpdatePaymentMethodResponse
    )
        : base(subscriptionUpdatePaymentMethodResponse) { }

    public SubscriptionUpdatePaymentMethodResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatePaymentMethodResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
