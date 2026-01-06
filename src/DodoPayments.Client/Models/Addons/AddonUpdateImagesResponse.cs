using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(
    typeof(JsonModelConverter<AddonUpdateImagesResponse, AddonUpdateImagesResponseFromRaw>)
)]
public sealed record class AddonUpdateImagesResponse : JsonModel
{
    public required string ImageID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "image_id"); }
        init { JsonModel.Set(this._rawData, "image_id", value); }
    }

    public required string Url
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImageID;
        _ = this.Url;
    }

    public AddonUpdateImagesResponse() { }

    public AddonUpdateImagesResponse(AddonUpdateImagesResponse addonUpdateImagesResponse)
        : base(addonUpdateImagesResponse) { }

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

    /// <inheritdoc cref="AddonUpdateImagesResponseFromRaw.FromRawUnchecked"/>
    public static AddonUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonUpdateImagesResponseFromRaw : IFromRawJson<AddonUpdateImagesResponse>
{
    /// <inheritdoc/>
    public AddonUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonUpdateImagesResponse.FromRawUnchecked(rawData);
}
