using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(ModelConverter<CheckoutSessionResponse, CheckoutSessionResponseFromRaw>))]
public sealed record class CheckoutSessionResponse : ModelBase
{
    /// <summary>
    /// Checkout url
    /// </summary>
    public required string CheckoutURL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "checkout_url"); }
        init { ModelBase.Set(this._rawData, "checkout_url", value); }
    }

    /// <summary>
    /// The ID of the created checkout session
    /// </summary>
    public required string SessionID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "session_id"); }
        init { ModelBase.Set(this._rawData, "session_id", value); }
    }

    public override void Validate()
    {
        _ = this.CheckoutURL;
        _ = this.SessionID;
    }

    public CheckoutSessionResponse() { }

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

    public static CheckoutSessionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionResponseFromRaw : IFromRaw<CheckoutSessionResponse>
{
    public CheckoutSessionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionResponse.FromRawUnchecked(rawData);
}
