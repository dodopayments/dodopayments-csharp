using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : ModelBase
{
    /// <summary>
    /// City name
    /// </summary>
    public required string City
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "city"); }
        init { ModelBase.Set(this._rawData, "city", value); }
    }

    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, CountryCode>>(this.RawData, "country");
        }
        init { ModelBase.Set(this._rawData, "country", value); }
    }

    /// <summary>
    /// State or province name
    /// </summary>
    public required string State
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "state"); }
        init { ModelBase.Set(this._rawData, "state", value); }
    }

    /// <summary>
    /// Street address including house number and unit/apartment if applicable
    /// </summary>
    public required string Street
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "street"); }
        init { ModelBase.Set(this._rawData, "street", value); }
    }

    /// <summary>
    /// Postal code or ZIP code
    /// </summary>
    public required string Zipcode
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "zipcode"); }
        init { ModelBase.Set(this._rawData, "zipcode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        this.Country.Validate();
        _ = this.State;
        _ = this.Street;
        _ = this.Zipcode;
    }

    public BillingAddress() { }

    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingAddressFromRaw.FromRawUnchecked"/>
    public static BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingAddressFromRaw : IFromRaw<BillingAddress>
{
    /// <inheritdoc/>
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}
