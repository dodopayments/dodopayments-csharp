using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Entitlements.Translations;

/// <summary>
/// The translation of an entitlement in one locale.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntitlementTranslation, EntitlementTranslationFromRaw>))]
public sealed record class EntitlementTranslation : JsonModel
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
    /// The translated activation message of a `license_key` entitlement.
    /// </summary>
    public string? ActivationMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("activation_message");
        }
        init { this._rawData.Set("activation_message", value); }
    }

    /// <summary>
    /// The translated description. `null` shows that the description has no translation.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The translated delivery instructions of a `digital_files` entitlement.
    /// </summary>
    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Locale.Validate();
        _ = this.UpdatedAt;
        _ = this.ActivationMessage;
        _ = this.Description;
        _ = this.Instructions;
        _ = this.Name;
    }

    public EntitlementTranslation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementTranslation(EntitlementTranslation entitlementTranslation)
        : base(entitlementTranslation) { }
#pragma warning restore CS8618

    public EntitlementTranslation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementTranslation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementTranslationFromRaw.FromRawUnchecked"/>
    public static EntitlementTranslation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementTranslationFromRaw : IFromRawJson<EntitlementTranslation>
{
    /// <inheritdoc/>
    public EntitlementTranslation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementTranslation.FromRawUnchecked(rawData);
}
