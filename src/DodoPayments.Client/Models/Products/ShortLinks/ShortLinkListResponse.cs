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
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Full URL the short url redirects to
    /// </summary>
    public required string FullURL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "full_url"); }
        init { JsonModel.Set(this._rawData, "full_url", value); }
    }

    /// <summary>
    /// Product ID associated with the short link
    /// </summary>
    public required string ProductID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { JsonModel.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// Short URL
    /// </summary>
    public required string ShortURL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "short_url"); }
        init { JsonModel.Set(this._rawData, "short_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.FullURL;
        _ = this.ProductID;
        _ = this.ShortURL;
    }

    public ShortLinkListResponse() { }

    public ShortLinkListResponse(ShortLinkListResponse shortLinkListResponse)
        : base(shortLinkListResponse) { }

    public ShortLinkListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortLinkListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
