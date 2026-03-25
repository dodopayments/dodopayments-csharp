using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(
    typeof(JsonModelConverter<
        ProductCollectionUnarchiveResponse,
        ProductCollectionUnarchiveResponseFromRaw
    >)
)]
public sealed record class ProductCollectionUnarchiveResponse : JsonModel
{
    /// <summary>
    /// Collection ID that was unarchived
    /// </summary>
    public required string CollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("collection_id");
        }
        init { this._rawData.Set("collection_id", value); }
    }

    /// <summary>
    /// Product IDs that were excluded because they are archived
    /// </summary>
    public required IReadOnlyList<string> ExcludedProductIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("excluded_product_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "excluded_product_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Success message
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionID;
        _ = this.ExcludedProductIds;
        _ = this.Message;
    }

    public ProductCollectionUnarchiveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionUnarchiveResponse(
        ProductCollectionUnarchiveResponse productCollectionUnarchiveResponse
    )
        : base(productCollectionUnarchiveResponse) { }
#pragma warning restore CS8618

    public ProductCollectionUnarchiveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionUnarchiveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionUnarchiveResponseFromRaw.FromRawUnchecked"/>
    public static ProductCollectionUnarchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionUnarchiveResponseFromRaw : IFromRawJson<ProductCollectionUnarchiveResponse>
{
    /// <inheritdoc/>
    public ProductCollectionUnarchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCollectionUnarchiveResponse.FromRawUnchecked(rawData);
}
