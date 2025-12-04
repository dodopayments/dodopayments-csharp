using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(
    typeof(ModelConverter<ProductUpdateFilesResponse, ProductUpdateFilesResponseFromRaw>)
)]
public sealed record class ProductUpdateFilesResponse : ModelBase
{
    public required string FileID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
    }

    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.URL;
    }

    public ProductUpdateFilesResponse() { }

    public ProductUpdateFilesResponse(ProductUpdateFilesResponse productUpdateFilesResponse)
        : base(productUpdateFilesResponse) { }

    public ProductUpdateFilesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateFilesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ProductUpdateFilesResponseFromRaw : IFromRaw<ProductUpdateFilesResponse>
{
    /// <inheritdoc/>
    public ProductUpdateFilesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateFilesResponse.FromRawUnchecked(rawData);
}
