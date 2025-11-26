using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(typeof(ModelConverter<AddonUpdateImagesResponse, AddonUpdateImagesResponseFromRaw>))]
public sealed record class AddonUpdateImagesResponse : ModelBase
{
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

    public AddonUpdateImagesResponse() { }

    public AddonUpdateImagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonUpdateImagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddonUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonUpdateImagesResponseFromRaw : IFromRaw<AddonUpdateImagesResponse>
{
    public AddonUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonUpdateImagesResponse.FromRawUnchecked(rawData);
}
