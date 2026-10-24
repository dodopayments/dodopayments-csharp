using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Products.Translations;

/// <summary>
/// The translation of a product, an add-on, a product collection or a meter in one locale.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Translation, TranslationFromRaw>))]
public sealed record class Translation : JsonModel
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
        _ = this.Description;
        _ = this.Name;
    }

    public Translation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Translation(Translation translation)
        : base(translation) { }
#pragma warning restore CS8618

    public Translation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Translation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TranslationFromRaw.FromRawUnchecked"/>
    public static Translation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TranslationFromRaw : IFromRawJson<Translation>
{
    /// <inheritdoc/>
    public Translation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Translation.FromRawUnchecked(rawData);
}
