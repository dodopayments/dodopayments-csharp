using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(
    typeof(JsonModelConverter<BrandUpdateImagesResponse, BrandUpdateImagesResponseFromRaw>)
)]
public sealed record class BrandUpdateImagesResponse : JsonModel
{
    /// <summary>
    /// UUID that will be used as the image identifier/key suffix
    /// </summary>
    public required string ImageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("image_id");
        }
        init { this._rawData.Set("image_id", value); }
    }

    /// <summary>
    /// Presigned URL to upload the image
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImageID;
        _ = this.Url;
    }

    public BrandUpdateImagesResponse() { }

    public BrandUpdateImagesResponse(BrandUpdateImagesResponse brandUpdateImagesResponse)
        : base(brandUpdateImagesResponse) { }

    public BrandUpdateImagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateImagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandUpdateImagesResponseFromRaw.FromRawUnchecked"/>
    public static BrandUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandUpdateImagesResponseFromRaw : IFromRawJson<BrandUpdateImagesResponse>
{
    /// <inheritdoc/>
    public BrandUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandUpdateImagesResponse.FromRawUnchecked(rawData);
}
