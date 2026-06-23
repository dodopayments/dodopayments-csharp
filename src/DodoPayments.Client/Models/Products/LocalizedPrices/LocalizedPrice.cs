using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products.LocalizedPrices;

[JsonConverter(typeof(JsonModelConverter<LocalizedPrice, LocalizedPriceFromRaw>))]
public sealed record class LocalizedPrice : JsonModel
{
    /// <summary>
    /// Unique identifier for the localized price.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Amount in the smallest currency unit (e.g., cents).
    /// </summary>
    public required int Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Timestamp when the localized price was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Currency to charge in.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Pricing mode of the rule: by_currency or by_country.
    /// </summary>
    public required ApiEnum<string, PricingMode> Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PricingMode>>("mode");
        }
        init { this._rawData.Set("mode", value); }
    }

    /// <summary>
    /// Product this localized price belongs to.
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Timestamp when the localized price was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Country the rule applies to. Only set when mode is by_country.
    /// </summary>
    public ApiEnum<string, CountryCode>? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CountryCode>>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.Currency.Validate();
        this.Mode.Validate();
        _ = this.ProductID;
        _ = this.UpdatedAt;
        this.CountryCode?.Validate();
    }

    public LocalizedPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LocalizedPrice(LocalizedPrice localizedPrice)
        : base(localizedPrice) { }
#pragma warning restore CS8618

    public LocalizedPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalizedPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocalizedPriceFromRaw.FromRawUnchecked"/>
    public static LocalizedPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocalizedPriceFromRaw : IFromRawJson<LocalizedPrice>
{
    /// <inheritdoc/>
    public LocalizedPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocalizedPrice.FromRawUnchecked(rawData);
}
