using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(typeof(ModelConverter<AddonUpdateImagesResponse, AddonUpdateImagesResponseFromRaw>))]
public sealed record class AddonUpdateImagesResponse : ModelBase
{
    public required string ImageID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "image_id"); }
        init { ModelBase.Set(this._rawData, "image_id", value); }
    }

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
