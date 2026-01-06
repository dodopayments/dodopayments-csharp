using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.ShortLinks;

[JsonConverter(typeof(JsonModelConverter<ShortLinkCreateResponse, ShortLinkCreateResponseFromRaw>))]
public sealed record class ShortLinkCreateResponse : JsonModel
{
    /// <summary>
    /// Full URL.
    /// </summary>
    public required string FullUrl
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "full_url"); }
        init { JsonModel.Set(this._rawData, "full_url", value); }
    }

    /// <summary>
    /// Short URL.
    /// </summary>
    public required string ShortUrl
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "short_url"); }
        init { JsonModel.Set(this._rawData, "short_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FullUrl;
        _ = this.ShortUrl;
    }

    public ShortLinkCreateResponse() { }

    public ShortLinkCreateResponse(ShortLinkCreateResponse shortLinkCreateResponse)
        : base(shortLinkCreateResponse) { }

    public ShortLinkCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortLinkCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShortLinkCreateResponseFromRaw.FromRawUnchecked"/>
    public static ShortLinkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShortLinkCreateResponseFromRaw : IFromRawJson<ShortLinkCreateResponse>
{
    /// <inheritdoc/>
    public ShortLinkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShortLinkCreateResponse.FromRawUnchecked(rawData);
}
