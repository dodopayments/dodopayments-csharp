using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(typeof(JsonModelConverter<AddonResponse, AddonResponseFromRaw>))]
public sealed record class AddonResponse : JsonModel
{
    /// <summary>
    /// id of the Addon
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the addon belongs.
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Created time
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Currency of the Addon
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Name of the Addon
    /// </summary>
    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public required int Price
    {
        get { return this._rawData.GetNotNullStruct<int>("price"); }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Tax category applied to this Addon
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, TaxCategory>>("tax_category"); }
        init { this._rawData.Set("tax_category", value); }
    }

    /// <summary>
    /// Updated time
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Optional description of the Addon
    /// </summary>
    public string? Description
    {
        get { return this._rawData.GetNullableClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Image of the Addon
    /// </summary>
    public string? Image
    {
        get { return this._rawData.GetNullableClass<string>("image"); }
        init { this._rawData.Set("image", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Name;
        _ = this.Price;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.Image;
    }

    public AddonResponse() { }

    public AddonResponse(AddonResponse addonResponse)
        : base(addonResponse) { }

    public AddonResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonResponseFromRaw.FromRawUnchecked"/>
    public static AddonResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonResponseFromRaw : IFromRawJson<AddonResponse>
{
    /// <inheritdoc/>
    public AddonResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddonResponse.FromRawUnchecked(rawData);
}
