using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionUpdateImagesResponse,
        ProductCollectionUpdateImagesResponseFromRaw
    >)
)]
public sealed record class ProductCollectionUpdateImagesResponse : JsonModel
{
    /// <summary>
    /// Presigned S3 URL for uploading the image
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

    /// <summary>
    /// Optional image ID (present when force_update is true)
    /// </summary>
    public string? ImageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image_id");
        }
        init { this._rawData.Set("image_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.ImageID;
    }

    public ProductCollectionUpdateImagesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionUpdateImagesResponse(
        ProductCollectionUpdateImagesResponse productCollectionUpdateImagesResponse
    )
        : base(productCollectionUpdateImagesResponse) { }
#pragma warning restore CS8618

    public ProductCollectionUpdateImagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionUpdateImagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionUpdateImagesResponseFromRaw.FromRawUnchecked"/>
    public static ProductCollectionUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductCollectionUpdateImagesResponse(string url)
        : this()
    {
        this.Url = url;
    }
}

class ProductCollectionUpdateImagesResponseFromRaw
    : IFromRawJson<ProductCollectionUpdateImagesResponse>
{
    /// <inheritdoc/>
    public ProductCollectionUpdateImagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionUpdateImagesResponse.FromRawUnchecked(rawData);
}
