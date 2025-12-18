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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the addon belongs.
    /// </summary>
    public required string BusinessID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { JsonModel.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// Created time
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Currency of the Addon
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Name of the Addon
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public required int Price
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawData, "price"); }
        init { JsonModel.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// Tax category applied to this Addon
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TaxCategory>>(
                this.RawData,
                "tax_category"
            );
        }
        init { JsonModel.Set(this._rawData, "tax_category", value); }
    }

    /// <summary>
    /// Updated time
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "updated_at"); }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// Optional description of the Addon
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Image of the Addon
    /// </summary>
    public string? Image
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "image"); }
        init { JsonModel.Set(this._rawData, "image", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
