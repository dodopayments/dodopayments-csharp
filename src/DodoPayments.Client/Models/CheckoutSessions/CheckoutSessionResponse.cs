using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<CheckoutSessionResponse, CheckoutSessionResponseFromRaw>))]
public sealed record class CheckoutSessionResponse : JsonModel
{
    /// <summary>
    /// The ID of the created checkout session
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Checkout url (None when payment_method_id is provided)
    /// </summary>
    public string? CheckoutUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkout_url");
        }
        init { this._rawData.Set("checkout_url", value); }
    }

    /// <summary>
    /// Client secret used to load the Dodo Payments checkout SDK. Returned when
    /// `confirm: true` was passed and a PaymentIntent was created at session-creation
    /// time. `None` otherwise.
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
    /// Underlying payment id when `confirm: true` was passed and a PaymentIntent
    /// was created at session-creation time. `None` otherwise.
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
    /// Publishable key for the Dodo Payments checkout SDK. Returned when `confirm:
    /// true` was passed and a PaymentIntent was created at session-creation time.
    /// `None` otherwise.
    /// </summary>
    public string? PublishableKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publishable_key");
        }
        init { this._rawData.Set("publishable_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SessionID;
        _ = this.CheckoutUrl;
        _ = this.ClientSecret;
        _ = this.PaymentID;
        _ = this.PublishableKey;
    }

    public CheckoutSessionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionResponse(CheckoutSessionResponse checkoutSessionResponse)
        : base(checkoutSessionResponse) { }
#pragma warning restore CS8618

    public CheckoutSessionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionResponseFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckoutSessionResponse(string sessionID)
        : this()
    {
        this.SessionID = sessionID;
    }
}

class CheckoutSessionResponseFromRaw : IFromRawJson<CheckoutSessionResponse>
{
    /// <inheritdoc/>
    public CheckoutSessionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionResponse.FromRawUnchecked(rawData);
}
