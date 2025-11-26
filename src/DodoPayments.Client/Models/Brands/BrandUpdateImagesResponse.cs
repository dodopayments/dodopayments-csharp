using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandUpdateImagesResponse, BrandUpdateImagesResponseFromRaw>))]
public sealed record class BrandUpdateImagesResponse : ModelBase
{
    /// <summary>
    /// UUID that will be used as the image identifier/key suffix
    /// </summary>
    public required string ImageID
    {
        get
        {
            if (!this._rawData.TryGetValue("image_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'image_id' cannot be null",
                    new ArgumentOutOfRangeException("image_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'image_id' cannot be null",
                    new ArgumentNullException("image_id")
                );
        }
        init
        {
            this._rawData["image_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Presigned URL to upload the image
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this._rawData.TryGetValue("url", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        init
        {
            this._rawData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
