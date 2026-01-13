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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("image_id");
        }
        init { this._rawData.Set("image_id", value); }
    }

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

    public AddonUpdateImagesResponse() { }

    public AddonUpdateImagesResponse(AddonUpdateImagesResponse addonUpdateImagesResponse)
        : base(addonUpdateImagesResponse) { }

    public AddonUpdateImagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonUpdateImagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
