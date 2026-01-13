using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.Images;

[JsonConverter(typeof(JsonModelConverter<ImageUpdateResponse, ImageUpdateResponseFromRaw>))]
public sealed record class ImageUpdateResponse : JsonModel
{
    public required string Url
    {
        get { return this._rawData.GetNotNullClass<string>("url"); }
        init { this._rawData.Set("url", value); }
    }

    public string? ImageID
    {
        get { return this._rawData.GetNullableClass<string>("image_id"); }
        init { this._rawData.Set("image_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.ImageID;
    }

    public ImageUpdateResponse() { }

    public ImageUpdateResponse(ImageUpdateResponse imageUpdateResponse)
        : base(imageUpdateResponse) { }

    public ImageUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ImageUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageUpdateResponse(string url)
        : this()
    {
        this.Url = url;
    }
}

class ImageUpdateResponseFromRaw : IFromRawJson<ImageUpdateResponse>
{
    /// <inheritdoc/>
    public ImageUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageUpdateResponse.FromRawUnchecked(rawData);
}
