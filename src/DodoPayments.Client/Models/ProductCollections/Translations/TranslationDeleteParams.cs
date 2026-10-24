using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.ProductCollections.Translations;

/// <summary>
/// Deletes the translation of one locale.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TranslationDeleteParams : ParamsBase
{
    public required string ID { get; init; }

    public ApiEnum<string, Locale>? Locale { get; init; }

    public TranslationDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranslationDeleteParams(TranslationDeleteParams translationDeleteParams)
        : base(translationDeleteParams)
    {
        this.ID = translationDeleteParams.ID;
        this.Locale = translationDeleteParams.Locale;
    }
#pragma warning restore CS8618

    public TranslationDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TranslationDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id,
        ApiEnum<string, Locale> locale
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
        this.Locale = locale;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TranslationDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id,
        ApiEnum<string, Locale> locale
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id,
            locale
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["Locale"] = JsonSerializer.SerializeToElement(this.Locale),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TranslationDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.Locale?.Equals(other.Locale) ?? other.Locale == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/product-collections/{0}/translations/{1}",
                    this.ID,
                    this.Locale?.Raw()
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
