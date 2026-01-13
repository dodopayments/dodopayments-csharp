using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.ShortLinks;

[JsonConverter(typeof(JsonModelConverter<ShortLinkListResponse, ShortLinkListResponseFromRaw>))]
public sealed record class ShortLinkListResponse : JsonModel
{
    /// <summary>
    /// When the short url was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Full URL the short url redirects to
    /// </summary>
    public required string FullUrl
    {
        get { return this._rawData.GetNotNullClass<string>("full_url"); }
        init { this._rawData.Set("full_url", value); }
    }

    /// <summary>
    /// Product ID associated with the short link
    /// </summary>
    public required string ProductID
    {
        get { return this._rawData.GetNotNullClass<string>("product_id"); }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Short URL
    /// </summary>
    public required string ShortUrl
    {
        get { return this._rawData.GetNotNullClass<string>("short_url"); }
        init { this._rawData.Set("short_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.FullUrl;
        _ = this.ProductID;
        _ = this.ShortUrl;
    }

    public ShortLinkListResponse() { }

    public ShortLinkListResponse(ShortLinkListResponse shortLinkListResponse)
        : base(shortLinkListResponse) { }

    public ShortLinkListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortLinkListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShortLinkListResponseFromRaw.FromRawUnchecked"/>
    public static ShortLinkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShortLinkListResponseFromRaw : IFromRawJson<ShortLinkListResponse>
{
    /// <inheritdoc/>
    public ShortLinkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShortLinkListResponse.FromRawUnchecked(rawData);
}
