using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.CreditEntitlements.Translations;

/// <summary>
/// The translation of a credit entitlement in one locale.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditEntitlementTranslation, CreditEntitlementTranslationFromRaw>)
)]
public sealed record class CreditEntitlementTranslation : JsonModel
{
    /// <summary>
    /// The locale of the translation.
    /// </summary>
    public required ApiEnum<string, Locale> Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Locale>>("locale");
        }
        init { this._rawData.Set("locale", value); }
    }

    /// <summary>
    /// The time of the last change.
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
    /// The translated name. `null` shows that the name has no translation.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The translated unit. `null` shows that the unit has no translation.
    /// </summary>
    public string? Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unit");
        }
        init { this._rawData.Set("unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Locale.Validate();
        _ = this.UpdatedAt;
        _ = this.Name;
        _ = this.Unit;
    }

    public CreditEntitlementTranslation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementTranslation(CreditEntitlementTranslation creditEntitlementTranslation)
        : base(creditEntitlementTranslation) { }
#pragma warning restore CS8618

    public CreditEntitlementTranslation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlementTranslation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditEntitlementTranslationFromRaw.FromRawUnchecked"/>
    public static CreditEntitlementTranslation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditEntitlementTranslationFromRaw : IFromRawJson<CreditEntitlementTranslation>
{
    /// <inheritdoc/>
    public CreditEntitlementTranslation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditEntitlementTranslation.FromRawUnchecked(rawData);
}
