using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.Images;

[JsonConverter(typeof(ModelConverter<ImageUpdateResponse, ImageUpdateResponseFromRaw>))]
public sealed record class ImageUpdateResponse : ModelBase
{
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    public string? ImageID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "image_id"); }
        init { ModelBase.Set(this._rawData, "image_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.URL;
        _ = this.ImageID;
    }

    public ImageUpdateResponse() { }

    public ImageUpdateResponse(ImageUpdateResponse imageUpdateResponse)
        : base(imageUpdateResponse) { }

    public ImageUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        this.URL = url;
    }
}

class ImageUpdateResponseFromRaw : IFromRaw<ImageUpdateResponse>
{
    /// <inheritdoc/>
    public ImageUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageUpdateResponse.FromRawUnchecked(rawData);
}
