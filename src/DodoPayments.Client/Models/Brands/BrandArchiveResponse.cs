using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandArchiveResponse, BrandArchiveResponseFromRaw>))]
public sealed record class BrandArchiveResponse : JsonModel
{
    /// <summary>
    /// Time the brand was archived.
    /// </summary>
    public required DateTimeOffset ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// The archived brand.
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Count of product collections moved to the target brand.
    /// </summary>
    public required long CollectionsMoved
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("collections_moved");
        }
        init { this._rawData.Set("collections_moved", value); }
    }

    /// <summary>
    /// Count of products moved to the target brand.
    /// </summary>
    public required long ProductsMoved
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("products_moved");
        }
        init { this._rawData.Set("products_moved", value); }
    }

    /// <summary>
    /// Count of live subscriptions moved to the target brand.
    /// </summary>
    public required long SubscriptionsMoved
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("subscriptions_moved");
        }
        init { this._rawData.Set("subscriptions_moved", value); }
    }

    /// <summary>
    /// Brand that received the moved records. Null when no target was given.
    /// </summary>
    public string? MovedToBrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("moved_to_brand_id");
        }
        init { this._rawData.Set("moved_to_brand_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ArchivedAt;
        _ = this.BrandID;
        _ = this.CollectionsMoved;
        _ = this.ProductsMoved;
        _ = this.SubscriptionsMoved;
        _ = this.MovedToBrandID;
    }

    public BrandArchiveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandArchiveResponse(BrandArchiveResponse brandArchiveResponse)
        : base(brandArchiveResponse) { }
#pragma warning restore CS8618

    public BrandArchiveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandArchiveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandArchiveResponseFromRaw.FromRawUnchecked"/>
    public static BrandArchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandArchiveResponseFromRaw : IFromRawJson<BrandArchiveResponse>
{
    /// <inheritdoc/>
    public BrandArchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandArchiveResponse.FromRawUnchecked(rawData);
}
