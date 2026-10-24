using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Misc;

/// <summary>
/// A locale that the checkout and the customer portal can show.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LocaleInfo, LocaleInfoFromRaw>))]
public sealed record class LocaleInfo : JsonModel
{
    /// <summary>
    /// The code to send in the `locale` parameter.
    /// </summary>
    public required ApiEnum<string, Locale> Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Locale>>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// The English name of the language.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The name of the language in that language.
    /// </summary>
    public required string NativeName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("native_name");
        }
        init { this._rawData.Set("native_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Code.Validate();
        _ = this.Name;
        _ = this.NativeName;
    }

    public LocaleInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LocaleInfo(LocaleInfo localeInfo)
        : base(localeInfo) { }
#pragma warning restore CS8618

    public LocaleInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocaleInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocaleInfoFromRaw.FromRawUnchecked"/>
    public static LocaleInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocaleInfoFromRaw : IFromRawJson<LocaleInfo>
{
    /// <inheritdoc/>
    public LocaleInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocaleInfo.FromRawUnchecked(rawData);
}
