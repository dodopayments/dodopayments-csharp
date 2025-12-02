using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandUpdateImagesResponse, BrandUpdateImagesResponseFromRaw>))]
public sealed record class BrandUpdateImagesResponse : ModelBase
{
    /// <summary>
    /// UUID that will be used as the image identifier/key suffix
    /// </summary>
    public required string ImageID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "image_id"); }
        init { ModelBase.Set(this._rawData, "image_id", value); }
    }

    /// <summary>
    /// Presigned URL to upload the image
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    public override void Validate()
    {
        _ = this.ImageID;
        _ = this.URL;
    }

    public BrandUpdateImagesResponse() { }

    public BrandUpdateImagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateImagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandUpdateImagesResponseFromRaw : IFromRaw<BrandUpdateImagesResponse>
{
    public BrandUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandUpdateImagesResponse.FromRawUnchecked(rawData);
}
