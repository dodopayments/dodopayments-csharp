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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "session_id"); }
        init { JsonModel.Set(this._rawData, "session_id", value); }
    }

    /// <summary>
    /// Checkout url (None when payment_method_id is provided)
    /// </summary>
    public string? CheckoutUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "checkout_url"); }
        init { JsonModel.Set(this._rawData, "checkout_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SessionID;
        _ = this.CheckoutUrl;
    }

    public CheckoutSessionResponse() { }

    public CheckoutSessionResponse(CheckoutSessionResponse checkoutSessionResponse)
        : base(checkoutSessionResponse) { }

    public CheckoutSessionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
