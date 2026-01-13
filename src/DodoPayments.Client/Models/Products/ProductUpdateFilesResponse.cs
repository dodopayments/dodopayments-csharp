using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(
    typeof(JsonModelConverter<ProductUpdateFilesResponse, ProductUpdateFilesResponseFromRaw>)
)]
public sealed record class ProductUpdateFilesResponse : JsonModel
{
    public required string FileID
    {
        get { return this._rawData.GetNotNullClass<string>("file_id"); }
        init { this._rawData.Set("file_id", value); }
    }

    public required string Url
    {
        get { return this._rawData.GetNotNullClass<string>("url"); }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.Url;
    }

    public ProductUpdateFilesResponse() { }

    public ProductUpdateFilesResponse(ProductUpdateFilesResponse productUpdateFilesResponse)
        : base(productUpdateFilesResponse) { }

    public ProductUpdateFilesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateFilesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateFilesResponseFromRaw.FromRawUnchecked"/>
    public static ProductUpdateFilesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateFilesResponseFromRaw : IFromRawJson<ProductUpdateFilesResponse>
{
    /// <inheritdoc/>
    public ProductUpdateFilesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateFilesResponse.FromRawUnchecked(rawData);
}
